using Mzl.DAL.Customer.Customer.DAL;
using Mzl.IDAL.Customer.DAL;
using Mzl.IDAL.Customer.Factory;

namespace Mzl.DAL.Customer.Customer.Factory
{
    public class CustomerInfoDALFactory : ICustomerInfoDALFactory
    {
        public ICustomerInfoDAL CreateSampleDalObj()
        {
            return new CustomerInfoDAL();
        }
    }
}
