using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.Factory;
using Mzl.DomainModel.Common.Account;
using Mzl.IBLL.Common.Account.Bll;

namespace Mzl.IBLL.Common.Account.Factory
{
    public interface IAccountDetailBllFactory : IBaseBLLFactory<IAccountDetailBll<AccountDetailModel>>
    {
    }
}
