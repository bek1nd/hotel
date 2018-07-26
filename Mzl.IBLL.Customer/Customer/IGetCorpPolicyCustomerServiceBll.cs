using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.DomainModel.Customer.CorpPolicy;

namespace Mzl.IBLL.Customer.Customer
{
    public interface IGetCorpPolicyCustomerServiceBll : IBaseServiceBll
    {
        List<CorpPolicyCustomerModel> GetCorpPolicyCustomer(string corpId,int policyId);
    }
}
