using Mzl.IDAL.Customer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.Customer.Corporation.CostCenter;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Customer.Corporation.DAL
{
    public class CostCenterDAL : ICostCenterDAL
    {
        public int Delete(CostCenterEntity t)
        {
            throw new NotImplementedException();
        }

        public int Insert(CostCenterEntity t)
        {
            throw new NotImplementedException();
        }

        public CostCenterEntity Query(int id)
        {
            throw new NotImplementedException();
        }

        public List<CostCenterEntity> GetCostCenterInfoList(Expression<Func<CostCenterEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.CostCenterInfo.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result;
            }
        }

        public int Update(CostCenterEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }
    }
}
