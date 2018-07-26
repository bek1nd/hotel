using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IDAL.Customer.DAL;
using Mzl.IDAL.Customer.Factory;
using Mzl.DAL.Customer.Corporation.DAL;

namespace Mzl.DAL.Customer.Corporation.Factory
{
    public class ServiceFeeConfigDetailsDALFactory: IServiceFeeConfigDetailsDALFactory
    {
        public IServiceFeeConfigDetailsDAL CreateSampleDalObj()
        {
            return new ServiceFeeConfigDetailsDAL();
        }
    }
}
