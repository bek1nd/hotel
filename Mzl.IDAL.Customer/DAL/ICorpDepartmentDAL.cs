using Mzl.Common.Factory;
using Mzl.EntityModel.Customer.Corporation.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IDAL.Customer.DAL
{
    public interface ICorpDepartmentDAL : IBaseDAL<CorpDepartmentEntity>
    {
        /// <summary>
        /// 根据条件获取部门信息
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<CorpDepartmentEntity> GetCorpDepartmentList(
           Expression<Func<CorpDepartmentEntity, bool>> predicate);
    }
}
