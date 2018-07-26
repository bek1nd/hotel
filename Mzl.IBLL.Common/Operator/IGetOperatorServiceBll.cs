using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.Operator;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Common.Operator
{
    public interface IGetOperatorServiceBll : IBaseServiceBll
    {
        OperatorModel GetOperatorByOid(string oid);
    }
}
