using Mzl.IDAL.Customer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Customer.Contact;
using System.Linq.Expressions;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Customer.ContactInfo.DAL
{
    public class ContactIdentificationInfoDAL : IContactIdentificationInfoDAL
    {
        public int Delete(ContactIdentificationInfoEntity t)
        {
            throw new NotImplementedException();
        }

        public List<ContactIdentificationInfoEntity> GetIdentificationInfoList(Expression<Func<ContactIdentificationInfoEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.ContactIdentificationInfo.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result;
            }
        }

        public int Insert(ContactIdentificationInfoEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log = db.ContactIdentificationInfo.Add(t);
                db.SaveChanges();
                return log.Contactid;
            }
        }

        public ContactIdentificationInfoEntity Query(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(ContactIdentificationInfoEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }
    }
}
