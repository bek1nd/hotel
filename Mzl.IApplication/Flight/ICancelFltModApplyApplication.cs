using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Flight;

namespace Mzl.IApplication.Flight
{
    public interface ICancelFltModApplyApplication : IBaseApplication
    {
        /// <summary>
        /// 核价待确认阶段取消申请
        /// </summary>
        /// <returns></returns>
        CancelFltModApplyResponseViewModel CancelFltModApplyByWaitAuditStep(CancelFltModApplyRequestViewModel request);
    }
}
