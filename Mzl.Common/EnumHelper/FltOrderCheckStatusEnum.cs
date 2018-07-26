using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper
{
    public enum FltOrderCheckStatusEnum
    {
        /// <summary>
        /// 待一级审批
        /// </summary>
        [Description("待一级审批")]
        T,
        /// <summary>
        /// 待二级审批
        /// </summary>
        [Description("待二级审批")]
        S,
        /// <summary>
        /// 审批否决
        /// </summary>
        [Description("审批否决")]
        J,
        /// <summary>
        /// 审批通过
        /// </summary>
        [Description("审批通过")]
        W,
    }
}
