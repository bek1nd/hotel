using Mzl.Common.Factory;
using Mzl.EntityModel.Train.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IDAL.Train.Order.DAL
{
    public interface ITraOrderStatusDAL : IBaseDAL<TraOrderStatusEntity>
    {
        /// <summary>
        /// 根据lambad表达式获取火车订单状态
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TraOrderStatusEntity GetTraOrderStatusByExpression(Expression<Func<TraOrderStatusEntity, bool>> predicate);
        List<TraOrderStatusEntity> GetTraOrderStatusListByExpression(Expression<Func<TraOrderStatusEntity, bool>> predicate);
    }
}
