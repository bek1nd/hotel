using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.BLL.Common.Account.Bll;
using Mzl.DomainModel.Common.Account;
using Mzl.IBLL.Common.Account.Bll;
using Mzl.IBLL.Common.Account.Factory;
using Mzl.IDAL.Common.Account.Factory;
using Mzl.DAL.Common.Account.Factory;

namespace Mzl.BLL.Common.Account.Factory
{
    public class AccountBllFactory: IAccountBllFactory
    {
        public IAccountBll<AccountModel> CreateBllObj()
        {
            IAccountDalFactory accountDalFactory=new AccountDalFactory();
            return new AccountBll(accountDalFactory.CreateSampleDalObj());
        }

        public IAccountBll<AccountModel> CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
