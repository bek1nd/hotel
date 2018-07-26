using Mzl.Common.Factory;
using Mzl.EntityModel.Train.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IDAL.Train.Server.DAL
{
  public  interface ITraOrderOperateServerDAL : IBaseDAL<TraOrderOperateEntity>
    {
        List<TraOrderOperateEntity> GetOrderOperateListByExpression(Expression<Func<TraOrderOperateEntity, bool>> predicate);


    }
}
