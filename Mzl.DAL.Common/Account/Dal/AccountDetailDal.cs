using Mzl.IDAL.Common.Account.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Common.AccountInfo;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Common.Account.Dal
{
    internal class AccountDetailDal : IAccountDetailDal
    {
        public int Insert(AccountDetailEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log = db.AccountDetailInfo.Add(t);
                db.SaveChanges();
                return log.ADid;
            }
        }

        public int Update(AccountDetailEntity t, string[] properties = null)
        {
            throw new NotImplementedException();
        }

        public int Delete(AccountDetailEntity t)
        {
            throw new NotImplementedException();
        }

        public AccountDetailEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.AccountDetailInfo.Where(n => n.ADid == id).ToList();
                return result.First();
            }
        }
    }
}
