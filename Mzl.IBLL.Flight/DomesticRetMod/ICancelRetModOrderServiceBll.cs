using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Flight.DomesticRetMod
{
    public interface ICancelRetModOrderServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 核价确认阶段取消申请
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        int CancelFltModApplyByWaitAuditStep(CancelFltRetModApplyModel query);
        /// <summary>
        /// 取消退改签申请
        /// </summary>
        /// <param name="rmid"></param>
        /// <returns></returns>
        bool CancelFltRetModApply(int rmid);
    }
}
