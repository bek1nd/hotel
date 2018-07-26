using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.CorpDepartment;
using Mzl.IDAL.Customer.Corporation;
using Mzl.IDAL.Customer.Customer;
using Mzl.EntityModel.Customer.BaseInfo;

namespace Mzl.BLL.Customer.CorpDepartment
{
    internal class GetCorpBookingDepartListServiceBll: BaseServiceBll,IGetCorpBookingDepartListServiceBll
    {
        private readonly ICustomerDal _customerDal;
        private readonly ICustomerUnionDal _customerUnionDal;
        private readonly IGetCorpDepartmentBll _getCorpDepartmentBll;

        public GetCorpBookingDepartListServiceBll(IGetCorpDepartmentBll getCorpDepartmentBll, ICustomerDal customerDal,
            ICustomerUnionDal customerUnionDal)
        {
            _getCorpDepartmentBll = getCorpDepartmentBll;
            _customerDal = customerDal;
            _customerUnionDal = customerUnionDal;
        }

        public bool IsAll { get; private set; } = false;

        public List<CorpBookingDepartModel> GetCorpBookingDepartList(int cid,string corpId)
        {

            if (cid == 0)
            {
                throw new Exception("该客户信息异常");
            }

            CustomerInfoEntity customerInfoEntity =
                   _customerDal.Find<CustomerInfoEntity>(cid);
            if (string.IsNullOrEmpty(customerInfoEntity?.CorpID))
                throw new Exception("该客户信息异常");
            if (!customerInfoEntity.CorpDepartID.HasValue)
                throw new Exception("该客户部门信息异常");

            List<CorpBookingDepartModel> list = new List<CorpBookingDepartModel>();
            List<CorpDepartmentModel> corpDepartmentModels =
                _getCorpDepartmentBll.GetCorpDepartmentByCorpId(corpId);

            CustomerUnionInfoEntity customerUnionInfoEntity =
                _customerUnionDal.Query<CustomerUnionInfoEntity>(n => n.Cid == cid, true).FirstOrDefault();

            string corpDepartStr = string.Empty;
           
            List<int> departIdList = new List<int>();
            if (customerUnionInfoEntity != null)
            {
                corpDepartStr = customerUnionInfoEntity.CorpDepartIDList;
            }

            if (string.IsNullOrEmpty(corpDepartStr))//如果当前值为NULL，则默认当前客户的部门Id
            {
                departIdList.Add(customerInfoEntity.CorpDepartID.Value);
            }
            else
            {
                if (corpDepartStr == "0")//如果为0值，则认为全部部门
                {
                    IsAll = true;
                }
                else
                {
                    List<string> c = corpDepartStr.Split(',').ToList();
                    if (c != null && c.Count > 0)
                    {
                        c.ForEach(n => departIdList.Add(Convert.ToInt32(n)));
                    }
                    else
                    {
                        throw new Exception("配置信息异常");
                    }
                }
            }




            if (IsAll)
            {
                foreach (var corpDepartmentModel in corpDepartmentModels)
                {
                    CorpBookingDepartModel departModel = new CorpBookingDepartModel()
                    {
                        DepartId = corpDepartmentModel.Id,
                        DepartName = corpDepartmentModel.DepartName,
                        IsBookinged = true
                    };
                    list.Add(departModel);
                }
            }
            else
            {
                foreach (var corpDepartmentModel in corpDepartmentModels)
                {
                    CorpBookingDepartModel departModel = new CorpBookingDepartModel()
                    {
                        DepartId = corpDepartmentModel.Id,
                        DepartName = corpDepartmentModel.DepartName,
                        IsBookinged = departIdList.Contains(corpDepartmentModel.Id)
                    };
                    list.Add(departModel);
                }
            }

            return list;
        }

       
    }
}
