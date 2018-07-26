using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.BLL.Common.Account.Bll;
using Mzl.DAL.Common.Account.Factory;
using Mzl.DomainModel.Common.Account;
using Mzl.IBLL.Common.Account.Bll;
using Mzl.IBLL.Common.Account.Factory;
using Mzl.IDAL.Common.Account.Factory;

namespace Mzl.BLL.Common.Account.Factory
{
    public class AccountDetailBllFactory: IAccountDetailBllFactory
    {
        public IAccountDetailBll<AccountDetailModel> CreateBllObj()
        {
            IAccountDetailDalFactory accountDetailDalFactory = new AccountDetailDalFactory();
            return new AccountDetailBll(accountDetailDalFactory.CreateSampleDalObj());
        }

        public IAccountDetailBll<AccountDetailModel> CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
