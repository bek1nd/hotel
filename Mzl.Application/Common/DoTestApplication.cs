using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IApplication.Common;
using Mzl.UIModel.Common.AuditOrder;

namespace Mzl.Application.Common
{
    internal class DoTestApplication : IDoTestApplication<AuditOrderResponseViewModel>
    {
        public AuditOrderResponseViewModel Get()
        {
            return new AuditOrderResponseViewModel();
        }
    }
}
