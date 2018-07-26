using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.Train.Order;
using Mzl.IDAL.Train.Order.DAL;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Train.Order.DAL
{
    public class TraOrderLogDAL: ITraOrderLogDAL
    {
        public int Insert(TraOrderLogEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log = db.TraOrderLog.Add(t);
                db.SaveChanges();
                return log.LogId;
            }
        }

        public int Update(TraOrderLogEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }

        public int Delete(TraOrderLogEntity t)
        {
            throw new NotImplementedException();
        }

        public TraOrderLogEntity Query(int id)
        {
            throw new NotImplementedException();
        }

        public List<TraOrderLogEntity> GetTraOrderLogListExpression(Expression<Func<TraOrderLogEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraOrderLog.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result;
            }
        }
    }
}
