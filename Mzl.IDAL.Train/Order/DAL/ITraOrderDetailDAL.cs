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
    public interface ITraOrderDetailDAL : IBaseDAL<TraOrderDetailEntity>
    {
        /// <summary>
        /// 根据lambad表达式获取火车行程信息
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<TraOrderDetailEntity> GetTraOrderDetailListExpression(Expression<Func<TraOrderDetailEntity, bool>> predicate);
    }
}
