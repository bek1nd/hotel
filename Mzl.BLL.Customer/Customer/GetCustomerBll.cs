using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.IDAL.Customer.Customer;
using Mzl.EntityModel.Customer.BaseInfo;
using AutoMapper;
using Mzl.Common.CacheHelper;
using Mzl.DomainModel.Customer.Corp;
using Mzl.EntityModel.Customer.Corporation.Department;
using Mzl.IDAL.Customer.Corporation;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.EntityModel.Customer.Corporation.Corp;

namespace Mzl.BLL.Customer.Customer
{
    public class GetCustomerBll: BaseBll, IGetCustomerBll
    {
        private readonly ICustomerDal _customerDal;
        private readonly ICustomerUnionDal _customerUnionDal;
        private readonly ICorpDepartmentDal _corpDepartmentDal;
        private readonly ICorporationDal _corporationDal;

        public GetCustomerBll(ICustomerDal customerDal, ICustomerUnionDal customerUnionDal,
            ICorpDepartmentDal corpDepartmentDal, ICorporationDal corporationDal) : base()
        {
            _customerDal = customerDal;
            _customerUnionDal = customerUnionDal;
            _corpDepartmentDal = corpDepartmentDal;
            _corporationDal = corporationDal;
        }

        public CustomerModel GetCustomerByCid(int cid)
        {
            CustomerInfoEntity customerInfoEntity = _customerDal.Find<CustomerInfoEntity>(cid);
            CustomerUnionInfoEntity customerUnionInfoEntity = _customerUnionDal.Find<CustomerUnionInfoEntity>(cid);

            List<CustomerInfoEntity> customerList = null;
            List<CustomerUnionInfoEntity> customerUnionList = null;

            if (customerInfoEntity != null)
            {
                customerList = new List<CustomerInfoEntity> {customerInfoEntity};
            }

            if (customerUnionInfoEntity != null)
            {
                customerUnionList = new List<CustomerUnionInfoEntity> { customerUnionInfoEntity };
            }

            List < CustomerModel > customerModels= Convert(customerList, customerUnionList);
            return customerModels.FirstOrDefault();
        }

        public List<CustomerModel> GetCustomerByCidList(List<int> cidList)
        {
            List<CustomerInfoEntity> customerInfoEntities = _customerDal.Query<CustomerInfoEntity>(n => cidList.Contains(n.Cid)).ToList();
            List<CustomerUnionInfoEntity> customerUnionInfoEntities =
                _customerUnionDal.Query<CustomerUnionInfoEntity>(n => cidList.Contains(n.Cid)).ToList();
            List < CustomerModel > customerModels = Convert(customerInfoEntities, customerUnionInfoEntities);
            return customerModels;
        }

        public List<CustomerModel> GetCustomerByCorpId(string corpId)
        {
            List<CustomerInfoEntity> customerInfoEntities =
                _customerDal.Query<CustomerInfoEntity>(n => n.CorpID == corpId).ToList();
            List<int> cidList = new List<int>();
            customerInfoEntities.ForEach(n => cidList.Add(n.Cid));
            List<CustomerUnionInfoEntity> customerUnionInfoEntities =
                _customerUnionDal.Query<CustomerUnionInfoEntity>(n => cidList.Contains(n.Cid)).ToList();
            List<CustomerModel> customerModels = Convert(customerInfoEntities, customerUnionInfoEntities);
            return customerModels;
        }


        private List<CustomerModel> Convert(List<CustomerInfoEntity> customerInfoEntities, List<CustomerUnionInfoEntity> customerUnionInfoEntities)
        {
            List<string> corpIdList = new List<string>();
            List<CorporationModel> corporationModels = new List<CorporationModel>();
            #region 获取部门信息
            List<int> departIdList = new List<int>();
            List<CorpDepartmentModel> corpDepartmentModels = new List<CorpDepartmentModel>();
            customerInfoEntities.ForEach(n =>
            {
                if (n.CorpDepartID.HasValue)
                    departIdList.Add(n.CorpDepartID.Value);
                if(!string.IsNullOrEmpty(n.CorpID))
                    corpIdList.Add(n.CorpID);
            });
            if (departIdList.Count > 0)
            {
                departIdList = departIdList.Distinct().ToList();
                List<CorpDepartmentEntity> corpDepartmentEntities =
                    _corpDepartmentDal.Query<CorpDepartmentEntity>(n => departIdList.Contains(n.Id)).ToList();
                corpDepartmentModels =
                    Mapper.Map<List<CorpDepartmentEntity>, List<CorpDepartmentModel>>(corpDepartmentEntities);
            }
            #endregion

            #region 部门信息
            if (corpIdList.Count > 0)
            {
                corpIdList = corpIdList.Distinct().ToList();
                List<CorporationEntity> corporationEntities =
                    _corporationDal.Query<CorporationEntity>(n => corpIdList.Contains(n.CorpId)).ToList();
                corporationModels =
                    Mapper.Map<List<CorporationEntity>, List<CorporationModel>>(corporationEntities);
            } 
            #endregion

            List<CustomerModel> customerModels = new List<CustomerModel>();
            foreach (var customerInfoEntity in customerInfoEntities)
            {
                CustomerModel customerModel = Mapper.Map<CustomerInfoEntity, CustomerModel>(customerInfoEntity);
                if (!string.IsNullOrEmpty(customerModel.CorpID))
                {
                    if (customerModel.CorpDepartID.HasValue)
                        customerModel.CorpDepartment =
                            corpDepartmentModels.Find(n => n.Id == customerModel.CorpDepartID.Value);
                    customerModel.Corporation = corporationModels.Find(n => n.CorpId.ToLower() == customerModel.CorpID.ToLower());
                }
               
                CustomerUnionInfoEntity customerUnionInfoEntity = customerUnionInfoEntities?.Find(n => n.Cid == customerInfoEntity.Cid);
                if (customerUnionInfoEntity != null)
                {
                    customerModel.Cid = customerUnionInfoEntity.Cid;
                    customerModel.CPCID = customerUnionInfoEntity.CPCID;
                    customerModel.CheckType = customerUnionInfoEntity.CheckType;
                    customerModel.CorpDepartIDList = customerUnionInfoEntity.CorpDepartIDList;
                    customerModel.CustomerFrom = customerUnionInfoEntity.CustomerFrom;
                    customerModel.GrantCPCID = customerUnionInfoEntity.GrantCPCID;
                    customerModel.GrantEndDate = customerUnionInfoEntity.GrantEndDate;
                    customerModel.GrantStartDate = customerUnionInfoEntity.GrantStartDate;
                    customerModel.IsCheckU8 = customerUnionInfoEntity.IsCheckU8;
                    customerModel.IsSupplier = customerUnionInfoEntity.IsSupplier;
                    customerModel.TelTime = customerUnionInfoEntity.TelTime;
                }
                
                customerModels.Add(customerModel);
            }
            return customerModels;
        }
    }
}
