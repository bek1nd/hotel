using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;

namespace Mzl.IBLL.Flight.AuditOrder
{
    public interface IValidataFltOrderAuditBll
    {
        bool Validata(AuditFltOrderQueryModel auditFltOrderQuery);
        bool Validata(AuditFltModApplyQueryModel auditFltModApplyQuery);

        bool Validata(AuditFltRetApplyQueryModel auditFltRetApplyQuery);
    }
}
