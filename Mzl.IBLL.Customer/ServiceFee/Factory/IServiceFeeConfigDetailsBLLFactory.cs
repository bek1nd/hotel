using Mzl.DomainModel.Customer.ServiceFee;
using Mzl.IBLL.Customer.ServiceFee.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.Factory;

namespace Mzl.IBLL.Customer.ServiceFee.Factory
{
    public interface IServiceFeeConfigDetailsBLLFactory : IBaseBLLFactory<IServiceFeeConfigDetailsBLL<ServiceFeeConfigDetailsModel>>
    {
    }
}
