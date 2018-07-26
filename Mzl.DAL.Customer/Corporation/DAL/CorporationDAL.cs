using Mzl.IDAL.Customer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Customer.Corporation.Corp;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Customer.Corporation.DAL
{
    public class CorporationDAL: ICorporationDAL
    {
        public int Insert(CorporationEntity t)
        {
            throw new NotImplementedException();
        }

        public int Update(CorporationEntity t, string[] properties = null)
        {
            throw new NotImplementedException();
        }

        public int Delete(CorporationEntity t)
        {
            throw new NotImplementedException();
        }

        public CorporationEntity Query(int id)
        {
            throw new NotImplementedException();
        }

        public CorporationEntity GetContactInfoByExpression(Expression<Func<CorporationEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.CorporationInfo.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result.First();
            }
        }
    }
}
