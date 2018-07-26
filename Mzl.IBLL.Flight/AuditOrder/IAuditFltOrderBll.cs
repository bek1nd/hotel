using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.DomainModel.Flight;

namespace Mzl.IBLL.Flight.AuditOrder
{
    public interface IAuditFltOrderBll : IAuditFltTypeOrderBll
    {
        AuditResultModel RunAudit(AuditFltOrderQueryModel query);
    }
}
