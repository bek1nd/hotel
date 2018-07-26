using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.BLL.Flight.AuditOrder.AuditValidate
{
    public class AlreadyRetModApplyAuditedValidate: AuditAbstractValidate
    {
        public override bool ActionValidate(ValidataAuditContext context)
        {
            this.NextNode?.ActionValidate(context);
            return true;
        }
    }
}
