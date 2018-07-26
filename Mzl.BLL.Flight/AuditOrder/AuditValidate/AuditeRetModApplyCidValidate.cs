using Mzl.Common.EnumHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Flight.AuditOrder.AuditValidate
{
    public class AuditeRetModApplyCidValidate : AuditAbstractValidate
    {
        public override bool ActionValidate(ValidataAuditContext context)
        {
            this.NextNode?.ActionValidate(context);
            return true;
        }
    }
}
