using Mzl.Common.Factory;
using Mzl.EntityModel.Customer.Corporation.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IDAL.Customer.DAL
{
    public interface IProjectNameDAL : IBaseDAL<ProjectNameEntity>
    {
        /// <summary>
        /// 获取项目名称信息集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<ProjectNameEntity> GetProjectNameListByExpression(Expression<Func<ProjectNameEntity, bool>> predicate);
    }
}
