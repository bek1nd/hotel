using Mzl.IDAL.Customer.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IDAL.Customer.DAL;
using Mzl.DAL.Customer.Corporation.DAL;

namespace Mzl.DAL.Customer.Corporation.Factory
{
    public class CostCenterDALFactory: ICostCenterDALFactory
    {
        public ICostCenterDAL CreateSampleDalObj()
        {
            return new CostCenterDAL();
        }
    }
}
