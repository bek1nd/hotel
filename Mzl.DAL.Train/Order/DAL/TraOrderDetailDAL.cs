using Mzl.IDAL.Train.Order.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.Train.BaseMaintenance;
using Mzl.EntityModel.Train.Order;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Train.Order.DAL
{
    public class TraOrderDetailDAL : ITraOrderDetailDAL
    {
        public int Delete(TraOrderDetailEntity t)
        {
            throw new NotImplementedException();
        }

        public int Insert(TraOrderDetailEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log = db.TraOrderDetail.Add(t);
                db.SaveChanges();
                return log.OdId;
            }
        }

        public TraOrderDetailEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraOrderDetail.Where(n => n.OdId == id).ToList();
                return result.First();
            }
        }

        public List<TraOrderDetailEntity> GetTraOrderDetailListExpression(Expression<Func<TraOrderDetailEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraOrderDetail.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result;
            }
        }

        public int Update(TraOrderDetailEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }
    }
}
