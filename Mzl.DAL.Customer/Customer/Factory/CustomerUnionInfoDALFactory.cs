using Mzl.IDAL.Customer.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IDAL.Customer.DAL;
using Mzl.DAL.Customer.Customer.DAL;

namespace Mzl.DAL.Customer.Customer.Factory
{
    public class CustomerUnionInfoDALFactory : ICustomerUnionInfoDALFactory
    {
        public ICustomerUnionInfoDAL CreateSampleDalObj()
        {
            return new CustomerUnionInfoDAL();
        }
    }
}
