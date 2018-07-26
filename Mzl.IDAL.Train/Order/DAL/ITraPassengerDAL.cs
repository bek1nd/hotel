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
    public interface ITraPassengerDAL : IBaseDAL<TraPassengerEntity>
    {
        /// <summary>
        /// 根据lambad表达式获取火车乘车人信息
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<TraPassengerEntity> GetTraPassengerListExpression(Expression<Func<TraPassengerEntity, bool>> predicate);
    }
}
