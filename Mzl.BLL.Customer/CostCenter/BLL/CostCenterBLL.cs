using Mzl.Common.AutoMapperHelper;
using Mzl.DomainModel.Customer.CostCenter;
using Mzl.EntityModel.Customer.Corporation.CostCenter;
using Mzl.IBLL.Customer.CostCenter.BLL;
using Mzl.IDAL.Customer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Mzl.BLL.Customer.CostCenter.BLL
{
    public class CostCenterBLL : ICostCenterBLL<CostCenterModel>
    {
        private readonly ICostCenterDAL _dal;

        public CostCenterBLL(ICostCenterDAL dal)
        {
            _dal = dal;
        }

        public List<CostCenterModel> GetCostCenterListByCorpId(string corpId)
        {
            List<CostCenterEntity> costCenterList =
                _dal.GetCostCenterInfoList(n => n.CorpId == corpId && n.IsHidden != "T");
            if (costCenterList == null)
                return null;
            return Mapper.Map<List<CostCenterEntity>, List<CostCenterModel>>(costCenterList);
        }
    }
}
