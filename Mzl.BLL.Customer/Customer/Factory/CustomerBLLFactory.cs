using Mzl.IBLL.Customer.Customer.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.IBLL.Customer.Customer.BLL;
using Mzl.BLL.Customer.Customer.BLL;
using Mzl.IDAL.Customer.Factory;
using Mzl.DAL.Customer.Customer.Factory;
using Mzl.IDAL.Customer.DAL;
using Mzl.Common.Factory;

namespace Mzl.BLL.Customer.Customer.Factory
{
    public class CustomerBLLFactory : ICustomerBLLFactory, ICustomerUnionBLLFactory
    {
        public ICustomerBLL<CustomerInfoModel> CreateBllObj()
        {
            ICustomerInfoDALFactory factory = new CustomerInfoDALFactory();
            ICustomerInfoDAL dal = factory.CreateSampleDalObj();
            return new CustomerBLL(dal);
        }

        public ICustomerBLL<CustomerInfoModel> CreateSampleBllObj()
        {
            return null;
        }

        ICustomerUnionBLL<CustomerUnionInfoModel> IBaseBLLFactory<ICustomerUnionBLL<CustomerUnionInfoModel>>.CreateBllObj()
        {
            ICustomerUnionInfoDALFactory factory = new CustomerUnionInfoDALFactory();
            ICustomerUnionInfoDAL dal = factory.CreateSampleDalObj();
            return new CustomerBLL(dal);
        }

        ICustomerUnionBLL<CustomerUnionInfoModel> IBaseBLLFactory<ICustomerUnionBLL<CustomerUnionInfoModel>>.CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
