using Mzl.Common.Factory;
using Mzl.EntityModel.Customer.Corporation.CostCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IDAL.Customer.DAL
{
    public interface ICostCenterDAL : IBaseDAL<CostCenterEntity>
    {
        /// <summary>
        /// 获取成本中心集合信息
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<CostCenterEntity> GetCostCenterInfoList(Expression<Func<CostCenterEntity, bool>> predicate);
    }
}
