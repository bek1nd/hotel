using Mzl.DAL.Train.Server.Factory;
using Mzl.EntityModel.Train.Server;
using Mzl.IDAL.Train.Server.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Train.Server.DAL
{
  public  class TraInterFaceOrderServerDAL: ITraInterFaceOrderServerDAL
    {
        public TraInterFaceOrderEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.InterFaceOrder.Where(n => n.InterfaceId == id).ToList();
                return result.First();
            }
        }

        public int Insert(TraInterFaceOrderEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log = db.InterFaceOrder.Add(t);
                db.SaveChanges();
                return log.InterfaceId;
            }
        }

      

        public int Update(TraInterFaceOrderEntity t, string[] properties=null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }

        public int Delete(TraInterFaceOrderEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                db.InterFaceOrder.Attach(t);
                db.InterFaceOrder.Remove(t);
                int i = db.SaveChanges();
                //string sql = $"delete from dbo.Tra_HoldSeatCallBackLog where logid={t.LogId}";
                //db.Database.ExecuteSqlCommand(sql);
                if (i > 0)
                    return 0;
                return -1;
            }
        }
        public List<TraInterFaceOrderEntity> GetInterFaceOrderListByExpression(Expression<Func<TraInterFaceOrderEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.InterFaceOrder.Where(predicate).ToList();
                return result;
            }
        }

    }
}
