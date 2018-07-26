using Mzl.Common.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Train.Order;
using System.Linq.Expressions;

namespace Mzl.IDAL.Train.Order.DAL
{
    public interface ITraModOrderDetailDAL : IBaseDAL<TraModOrderDetailEntity>
    {
        /// <summary>
        /// 根据条件获取改签行程集合信息
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<TraModOrderDetailEntity> GetTraOrderListExpression(Expression<Func<TraModOrderDetailEntity, bool>> predicate);
        /// <summary>
        /// 根据条件获取改签行程信息
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TraModOrderDetailEntity GetTraOrderExpression(Expression<Func<TraModOrderDetailEntity, bool>> predicate);
    }
}
