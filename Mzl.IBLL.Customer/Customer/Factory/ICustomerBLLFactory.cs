using Mzl.Common.Factory;
using Mzl.DomainModel.Customer.Base;
using Mzl.IBLL.Customer.Customer.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.Customer.Factory
{
    public interface ICustomerBLLFactory : IBaseBLLFactory<ICustomerBLL<CustomerInfoModel>>
    {
    }
}
