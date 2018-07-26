using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.Common.AccountInfo;
using Mzl.IDAL.Common.Account.Dal;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Common.Account.Dal
{
    internal class AccountDal: IAccountDal
    {
        public int Insert(AccountEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log = db.AccountInfo.Add(t);
                db.SaveChanges();
                return log.Aid;
            }
        }

        public int Update(AccountEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }

        public int Delete(AccountEntity t)
        {
            throw new NotImplementedException();
        }

        public AccountEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.AccountInfo.Where(n => n.Aid == id).ToList();
                return result.First();
            }
        }
    }
}
