using Mzl.Framework.Base;
using Mzl.IBLL.Customer.CostCenter;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CostCenter;
using Mzl.IDAL.Customer.Corporation;
using AutoMapper;
using Mzl.EntityModel.Customer.Corporation.CostCenter;

namespace Mzl.BLL.Customer.CostCenter
{
    public class AddCostCenterServiceBll : BaseServiceBll, IAddCostCenterServiceBll
    {
        private readonly ICostCenterDal _costCenterDal;
        public AddCostCenterServiceBll(ICostCenterDal costCenterDal) : base()
        {
            _costCenterDal = costCenterDal;
        }

        public int AddCostCenter(CostCenterModel costCenterModel)
        {

            CostCenterEntity costCenterEntity = Mapper.Map<CostCenterModel, CostCenterEntity>(costCenterModel);
            costCenterEntity.IsHidden = "F";
            costCenterEntity = _costCenterDal.Insert(costCenterEntity);
            return costCenterEntity.Cid;
        }
    }
}
