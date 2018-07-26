using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.Customer
{
    public interface IAddPolicyCustomerRelationServiceBll : IBaseServiceBll
    {
        bool AddPolicyCustomerRelation(CorpPolicyConfigCustomerModel model);
    }
}
