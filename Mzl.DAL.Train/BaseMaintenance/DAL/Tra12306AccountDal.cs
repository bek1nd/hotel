using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.Train.BaseMaintenance;
using Mzl.IDAL.Train.BaseMaintenance.DAL;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Train.BaseMaintenance.DAL
{
    [Obsolete("已过期 Mzl.DAL.Train.Tra12306AccountDal代替")]
    internal class Tra12306AccountDal : ITra12306AccountDal
    {
        public int Insert(Tra12306AccountEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log = db.Tra12306AccountEntity.Add(t);
                db.SaveChanges();
                return log.PassId;
            }
        }

        public int Update(Tra12306AccountEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }

        public int Delete(Tra12306AccountEntity t)
        {
            throw new NotImplementedException();
        }

        public Tra12306AccountEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.Tra12306AccountEntity.Where(n => n.PassId == id).ToList();
                return result.First();
            }
        }

        public List<Tra12306AccountEntity> GeTraAddressByExpression(Expression<Func<Tra12306AccountEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.Tra12306AccountEntity.Where(predicate).ToList();
                return result;
            }
        }
    }
}
