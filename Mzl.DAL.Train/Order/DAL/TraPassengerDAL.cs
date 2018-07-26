using Mzl.IDAL.Train.Order.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.Train.Order;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Train.Order.DAL
{
    public class TraPassengerDAL: ITraPassengerDAL
    {
        public int Insert(TraPassengerEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log = db.TraPassenger.Add(t);
                db.SaveChanges();
                return log.Pid;
            }
        }

        public int Update(TraPassengerEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }

        public int Delete(TraPassengerEntity t)
        {
            throw new NotImplementedException();
        }

        public TraPassengerEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraPassenger.Where(n => n.Pid == id).ToList();
                return result.First();
            }
        }

        public List<TraPassengerEntity> GetTraPassengerListExpression(Expression<Func<TraPassengerEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraPassenger.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result;
            }
        }
    }
}
