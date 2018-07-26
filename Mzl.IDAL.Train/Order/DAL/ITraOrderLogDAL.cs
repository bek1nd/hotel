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
    public interface ITraOrderLogDAL : IBaseDAL<TraOrderLogEntity>
    {
        List<TraOrderLogEntity> GetTraOrderLogListExpression(Expression<Func<TraOrderLogEntity, bool>> predicate);
    }
}
