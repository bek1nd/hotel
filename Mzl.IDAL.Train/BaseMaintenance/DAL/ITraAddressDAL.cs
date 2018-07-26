using Mzl.Common.Factory;
using Mzl.EntityModel.Train.BaseMaintenance;
using System;
using System.Linq.Expressions;

namespace Mzl.IDAL.Train.BaseMaintenance.DAL
{
    public interface ITraAddressDAL : IBaseDAL<TraAddressEntity>
    {
        TraAddressEntity GeTraAddressByExpression(Expression<Func<TraAddressEntity, bool>> predicate);
    }
}
