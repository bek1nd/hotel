using Mzl.Common.Factory;
using Mzl.EntityModel.Train.BaseMaintenance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IDAL.Train.BaseMaintenance.DAL
{
    [Obsolete("已过期 Mzl.IDAL.Train.ITra12306AccountDal代替")]
    public interface ITra12306AccountDal : IBaseDAL<Tra12306AccountEntity>
    {
        List<Tra12306AccountEntity> GeTraAddressByExpression(Expression<Func<Tra12306AccountEntity, bool>> predicate);
    }
}
