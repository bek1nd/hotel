using Mzl.Common.Factory;
using Mzl.DomainModel.Customer.ServiceFee;
using Mzl.IBLL.Customer.ServiceFee.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.ServiceFee.Factory
{
    public interface IServiceFeeConfigBLLFactory : IBaseBLLFactory<IServiceFeeConfigBLL<ServiceFeeConfigModel>>
    {
    }
}
