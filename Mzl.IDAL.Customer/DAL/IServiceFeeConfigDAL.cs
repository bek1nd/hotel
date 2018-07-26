using Mzl.Common.Factory;
using Mzl.EntityModel.Customer.Corporation.ServiceFee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IDAL.Customer.DAL
{
    public interface IServiceFeeConfigDAL : IBaseDAL<ServiceFeeConfigEntity>
    {
        ServiceFeeConfigEntity GetServiceFeeConfigByExpression(
           Expression<Func<ServiceFeeConfigEntity, bool>> predicate);
    }
}
