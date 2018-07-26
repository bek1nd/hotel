using Mzl.IDAL.Customer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Customer.Corporation.Department;
using System.Linq.Expressions;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Customer.Corporation.DAL
{
    public class CorpDepartmentDAL : ICorpDepartmentDAL
    {
        public int Delete(CorpDepartmentEntity t)
        {
            throw new NotImplementedException();
        }

        public List<CorpDepartmentEntity> GetCorpDepartmentList(Expression<Func<CorpDepartmentEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.CorpDepartmentInfo.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result;
            }
        }

        public int Insert(CorpDepartmentEntity t)
        {
            throw new NotImplementedException();
        }

        public CorpDepartmentEntity Query(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(CorpDepartmentEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }
    }
}
