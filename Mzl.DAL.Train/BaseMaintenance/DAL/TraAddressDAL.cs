using System;
using System.Linq;
using System.Linq.Expressions;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.Train.BaseMaintenance;
using Mzl.IDAL.Train.BaseMaintenance.DAL;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Train.BaseMaintenance.DAL
{
    public class TraAddressDAL : ITraAddressDAL
    {
        public int Insert(TraAddressEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log = db.TraAddress.Add(t);
                db.SaveChanges();
                return log.Aid;
            }
        }

        public int Update(TraAddressEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }

        public int Delete(TraAddressEntity t)
        {
            throw new NotImplementedException();
        }

        public TraAddressEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraAddress.Where(n => n.Aid == id).ToList();
                return result.First();
            }
        }

        public TraAddressEntity GeTraAddressByExpression(Expression<Func<TraAddressEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraAddress.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result.First();
            }
        }
    }
}
