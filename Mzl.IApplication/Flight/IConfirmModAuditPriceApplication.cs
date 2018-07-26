using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Flight;

namespace Mzl.IApplication.Flight
{
    public interface IConfirmModAuditPriceApplication : IBaseApplication
    {
        /// <summary>
        /// 确认核价
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        bool ConfirmModAuditPrice(ConfirmRetModAuditPriceRequestViewModel request);
    }
}
