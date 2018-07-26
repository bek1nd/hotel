using Mzl.IDAL.Train.Order.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Train.Order;
using System.Linq.Expressions;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Train.Order.DAL
{
    public class TraOrderStatusDAL : ITraOrderStatusDAL
    {
        public int Delete(TraOrderStatusEntity t)
        {
            throw new NotImplementedException();
        }

        public TraOrderStatusEntity GetTraOrderStatusByExpression(Expression<Func<TraOrderStatusEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraOrderStatus.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result.First();
            }
        }

        public List<TraOrderStatusEntity> GetTraOrderStatusListByExpression(Expression<Func<TraOrderStatusEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraOrderStatus.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result;
            }
        }

        public int Insert(TraOrderStatusEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log = db.TraOrderStatus.Add(t);
                db.SaveChanges();
                return log.Sid;
            }
        }

        public TraOrderStatusEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraOrderStatus.Where(n => n.Sid == id).ToList();
                return result.First();
            }
        }

        public int Update(TraOrderStatusEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }
    }
}
