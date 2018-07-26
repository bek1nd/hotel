using Mzl.DAL.Train.Server.Factory;
using Mzl.EntityModel.Train.Server;
using Mzl.IDAL.Train.Server.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Train.Server.DAL
{
    public class TraOrderOperateServerDAL : ITraOrderOperateServerDAL
    {
        public TraOrderOperateEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraOrderOperate.Where(n => n.LogId == id).ToList();
                return result.First();
            }
        }

        public int Insert(TraOrderOperateEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log = db.TraOrderOperate.Add(t);
                db.SaveChanges();
                return log.LogId;
            }
        }

        public int Update(TraOrderOperateEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }

        public int Delete(TraOrderOperateEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                db.TraOrderOperate.Attach(t);
                db.TraOrderOperate.Remove(t);
                int i = db.SaveChanges();
                //string sql = $"delete from dbo.Tra_HoldSeatCallBackLog where logid={t.LogId}";
                //db.Database.ExecuteSqlCommand(sql);
                if (i > 0)
                    return 0;
                return -1;
            }
        }

        public List<TraOrderOperateEntity> GetOrderOperateListByExpression(
            Expression<Func<TraOrderOperateEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraOrderOperate.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result;
            }
        }

    }
}
