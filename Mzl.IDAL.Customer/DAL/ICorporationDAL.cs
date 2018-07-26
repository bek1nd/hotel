using Mzl.Common.Factory;
using Mzl.EntityModel.Customer.Corporation.Corp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IDAL.Customer.DAL
{
    public interface ICorporationDAL : IBaseDAL<CorporationEntity>
    {
        CorporationEntity GetContactInfoByExpression(Expression<Func<CorporationEntity, bool>> predicate);
    }
}
