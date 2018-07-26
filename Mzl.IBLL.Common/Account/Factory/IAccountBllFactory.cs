using Mzl.Common.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IBLL.Common.Account.Bll;
using Mzl.DomainModel.Common.Account;

namespace Mzl.IBLL.Common.Account.Factory
{
    public interface IAccountBllFactory : IBaseBLLFactory<IAccountBll<AccountModel>>
    {
    }
}
