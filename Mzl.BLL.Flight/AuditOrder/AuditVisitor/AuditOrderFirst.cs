using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.AuditOrder;

namespace Mzl.BLL.Flight.AuditOrder.AuditVisitor
{
    public class AuditOrderFirst : AuditOrderAbstract
    {
        public override AuditResultModel RunAudit(IRunAuditVisitor visitor)
        {
            return visitor.DoFirstAudit(this);
        }
    }
}
