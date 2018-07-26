using Mzl.IDAL.Train.Order.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Train.Order;
using System.Data.Entity.Infrastructure;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Train.Order.DAL
{
    public class TraModOrderDetailDAL : ITraModOrderDetailDAL
    {
        public int Insert(TraModOrderDetailEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log = db.TraModDetail.Add(t);
                db.SaveChanges();
                return log.TravelId;
            }
        }

        public int Update(TraModOrderDetailEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }

        public int Delete(TraModOrderDetailEntity t)
        {
            throw new NotImplementedException();
        }

        public TraModOrderDetailEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraModDetail.Where(n => n.TravelId == id).ToList();
                return result.First();
            }
        }

        public List<TraModOrderDetailEntity> GetTraOrderListExpression(
            Expression<Func<TraModOrderDetailEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraModDetail.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result;
            }
        }

        public TraModOrderDetailEntity GetTraOrderExpression(Expression<Func<TraModOrderDetailEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraModDetail.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result.First();
            }
        }
    }
}
