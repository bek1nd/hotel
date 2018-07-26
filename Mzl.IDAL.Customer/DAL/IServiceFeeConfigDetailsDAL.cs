using Mzl.EntityModel.Customer.Corporation.ServiceFee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.Factory;
using System.Linq.Expressions;

namespace Mzl.IDAL.Customer.DAL
{
    public interface IServiceFeeConfigDetailsDAL : IBaseDAL<ServiceFeeConfigDetailsEntity>
    {
        List<ServiceFeeConfigDetailsEntity> GetServiceFeeConfigDetailsListByExpression(
            Expression<Func<ServiceFeeConfigDetailsEntity, bool>> predicate);
    }
}
