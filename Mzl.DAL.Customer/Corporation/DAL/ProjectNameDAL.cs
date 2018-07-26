using Mzl.IDAL.Customer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.Customer.Corporation.Project;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Customer.Corporation.DAL
{
    public class ProjectNameDAL: IProjectNameDAL
    {
        public int Insert(ProjectNameEntity t)
        {
            throw new NotImplementedException();
        }

        public int Update(ProjectNameEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }

        public int Delete(ProjectNameEntity t)
        {
            throw new NotImplementedException();
        }

        public ProjectNameEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.ProjectNameInfo.FirstOrDefault(n => n.ProjectId == id);
                return result;
            }
        }

        public List<ProjectNameEntity> GetProjectNameListByExpression(Expression<Func<ProjectNameEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.ProjectNameInfo.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result;
            }
        }
    }
}
