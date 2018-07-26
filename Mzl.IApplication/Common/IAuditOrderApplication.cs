using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Common.AuditOrder;

namespace Mzl.IApplication.Common
{
    [Obsolete("该审批功能已废弃")]
    public interface IAuditOrderApplication : IBaseApplication
    {
        AuditOrderResponseViewModel RunAudit(AuditOrderRequestViewModel request);
    }
}
