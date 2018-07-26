using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Application.Account.Domain;
using Mzl.DomainModel.Common.Account;
using Mzl.IApplication.Account.Domain;
using Mzl.IApplication.Account.Factory;
using Mzl.IBLL.Common.Account.Bll;
using Mzl.IBLL.Common.Account.Factory;
using Mzl.BLL.Common.Account.Factory;

namespace Mzl.Application.Account.Factory
{
    public class AccountDomainFactory : IAccountDomainFactory
    {
        public IAccountDomain CreateDomainObj()
        {
            IAccountBllFactory accountBllFactory = new AccountBllFactory();
            IAccountBll<AccountModel> accountBll = accountBllFactory.CreateBllObj();
            IAccountDetailBllFactory accountDetailBllFactory = new AccountDetailBllFactory();
            IAccountDetailBll<AccountDetailModel> accountDetailBll = accountDetailBllFactory.CreateBllObj();
            return new AccountDomain(accountBll, accountDetailBll);
        }
    }
}
