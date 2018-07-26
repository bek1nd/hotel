using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.DomainModel.Flight;

namespace Mzl.IBLL.Flight.AuditOrder
{
    [Obsolete("已废弃")]
    public interface IAuditFltRetApplyBll : IAuditFltTypeOrderBll
    {
        AuditResultModel RunAudit(AuditFltRetApplyQueryModel query);
    }
}
