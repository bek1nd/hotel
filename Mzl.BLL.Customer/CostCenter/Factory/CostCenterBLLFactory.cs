using Mzl.IBLL.Customer.CostCenter.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CostCenter;
using Mzl.IBLL.Customer.CostCenter.BLL;
using Mzl.IDAL.Customer.Factory;
using Mzl.DAL.Customer.Corporation.Factory;
using Mzl.BLL.Customer.CostCenter.BLL;

namespace Mzl.BLL.Customer.CostCenter.Factory
{
    public class CostCenterBLLFactory : ICostCenterBLLFactory
    {
        public ICostCenterBLL<CostCenterModel> CreateBllObj()
        {
            ICostCenterDALFactory factory = new CostCenterDALFactory();
            return new CostCenterBLL(factory.CreateSampleDalObj());
        }

        public ICostCenterBLL<CostCenterModel> CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
