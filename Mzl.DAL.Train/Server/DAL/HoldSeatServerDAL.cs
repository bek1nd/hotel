using System.Collections.Generic;
using System.Linq;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.Train.Server;
using Mzl.IDAL.Train.Server.DAL;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Train.Server.DAL
{
    public class HoldSeatServerDAL : IHoldSeatServerDAL
    {
        public TraHoldSeatCallBackLogEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result=db.TraHoldSeatCallBackLog.Where(n => n.LogId == id).ToList();
                return result.First();
            }
        }

        public int Insert(TraHoldSeatCallBackLogEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log=db.TraHoldSeatCallBackLog.Add(t);
                db.SaveChanges();
                return log.LogId;
            }
        }

        public int Update(TraHoldSeatCallBackLogEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }

        public int Delete(TraHoldSeatCallBackLogEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                db.TraHoldSeatCallBackLog.Attach(t);
                db.TraHoldSeatCallBackLog.Remove(t);
                int i = db.SaveChanges();
                //string sql = $"delete from dbo.Tra_HoldSeatCallBackLog where logid={t.LogId}";
                //db.Database.ExecuteSqlCommand(sql);
                if (i > 0)
                    return 0;
                return -1;
            }
        }
    }
}
