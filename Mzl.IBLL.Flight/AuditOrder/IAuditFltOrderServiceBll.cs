using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Flight.AuditOrder
{
    public interface IAuditFltOrderServiceBll : IBaseServiceBll
    {
        [Obsolete("该功能已经废弃")]
        AuditResultModel RunAudit(AuditTypeQueryModel query);
    }
}
