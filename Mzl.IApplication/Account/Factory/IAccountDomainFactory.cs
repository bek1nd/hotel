using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IApplication.Account.Domain;
using Mzl.IApplication.Base;

namespace Mzl.IApplication.Account.Factory
{
    public interface IAccountDomainFactory : IBaseDomainFactory<IAccountDomain>
    {
        
    }
}
