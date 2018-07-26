using Mzl.IBLL.Customer.Verify.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.IBLL.Customer.Verify.BLL;
using Mzl.BLL.Customer.Verify.BLL;
using Mzl.IDAL.Customer.DAL;
using Mzl.IDAL.Customer.Factory;
using Mzl.DAL.Customer.Customer.Factory;

namespace Mzl.BLL.Customer.Verify.Factory
{
    public class CustomerVerifyBLLFactory : ICustomerVerifyBLLFactory
    {
        public ICustomerVerifyBLL<CustomerInfoModel> CreateBllObj()
        {
            ICustomerInfoDALFactory factory = new CustomerInfoDALFactory();
            ICustomerInfoDAL dal = factory.CreateSampleDalObj();
            return new CustomerVerifyBLL(dal);
        }

        public ICustomerVerifyBLL<CustomerInfoModel> CreateSampleBllObj()
        {
            return new CustomerVerifyBLL();
        }
    }
}
