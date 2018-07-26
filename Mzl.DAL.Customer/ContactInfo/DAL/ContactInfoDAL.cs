using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.Customer.Contact;
using Mzl.IDAL.Customer.DAL;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Customer.ContactInfo.DAL
{
    public class ContactInfoDAL : IContactInfoDAL
    {
        public int Delete(ContactInfoEntity t)
        {
            throw new NotImplementedException();
        }

        public ContactInfoEntity GetContactInfoByExpression(Expression<Func<ContactInfoEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.ContactInfo.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result.First();
            }
        }

        /// <summary>
        /// 获取联系人集合信息
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<ContactInfoEntity> GetContactInfoListByExpression(Expression<Func<ContactInfoEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.ContactInfo.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result;
            }
        }

        public int Insert(ContactInfoEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log = db.ContactInfo.Add(t);
                db.SaveChanges();
                return log.Contactid;
            }
        }

        public ContactInfoEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.ContactInfo.Where(n=>n.Contactid==id).ToList();
                if (result.Count == 0)
                    return null;
                return result.First();
            }
        }

        public int Update(ContactInfoEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }
    }
}
