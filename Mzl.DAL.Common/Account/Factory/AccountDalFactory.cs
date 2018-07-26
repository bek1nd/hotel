using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DAL.Common.Account.Dal;
using Mzl.IDAL.Common.Account.Dal;
using Mzl.IDAL.Common.Account.Factory;

namespace Mzl.DAL.Common.Account.Factory
{
    public class AccountDalFactory : IAccountDalFactory
    {
        public IAccountDal CreateSampleDalObj()
        {
            return new AccountDal();
        }
    }
}
