using Mzl.Framework.Base;
using Mzl.IBLL.Customer.CostCenter;
using Mzl.IDAL.Customer.Corporation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CostCenter;
using Mzl.EntityModel.Customer.Corporation.CostCenter;
using AutoMapper;
using Mzl.IDAL.Customer.Customer;
using Mzl.EntityModel.Customer.BaseInfo;

namespace Mzl.BLL.Customer.CostCenter
{
    public class GetCostCenterServiceBll: BaseServiceBll,IGetCostCenterServiceBll
    {
        private readonly ICostCenterDal _centerDal;
        private readonly ICustomerDal _customerDal;
        public GetCostCenterServiceBll(ICostCenterDal centerDal) : base()
        {
            _centerDal = centerDal;
        }
        public GetCostCenterServiceBll(ICostCenterDal centerDal, ICustomerDal customerDal) : base()
        {
            _centerDal = centerDal;
            _customerDal = customerDal;
        }

        public List<CostCenterModel> GetCostCenter(string corpId)
        {
            return GetCostCenterByCorpId(corpId);
        }

        public List<CostCenterModel> GetCostCenterByNoDelete(string corpId)
        {
            return GetCostCenterByCorpId(corpId)?.FindAll(n => n.IsHidden == "F" || n.IsHidden == "f");
        }

        public List<CostCenterModel> GetCostCenter(int cid)
        {
            CustomerInfoEntity customerInfoEntity = _customerDal.Find<CustomerInfoEntity>(cid);
            if (string.IsNullOrEmpty(customerInfoEntity.CorpID))
                return null;
            return GetCostCenterByCorpId(customerInfoEntity.CorpID);
        }

        private List<CostCenterModel> GetCostCenterByCorpId(string corpId)
        {
            List<CostCenterEntity> costCenterEntities =
                _centerDal.Query<CostCenterEntity>(n => n.CorpId == corpId).ToList();

            return Mapper.Map<List<CostCenterEntity>, List<CostCenterModel>>(costCenterEntities);
        }
    }
}
