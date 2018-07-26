using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.Factory;
using Mzl.IDAL.Common.Account.Dal;

namespace Mzl.IDAL.Common.Account.Factory
{
    public interface IAccountDetailDalFactory : IBaseDALFactory<IAccountDetailDal>
    {
    }
}
