using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper
{
    /// <summary>
    /// 订单类型枚举
    /// </summary>
    public enum OrderSourceTypeEnum
    {
        /// <summary>
        /// 酒店
        /// </summary>
        [Description("酒店")]
        Hol = 1,
        /// <summary>
        /// 火车
        /// </summary>
        [Description("火车")]
        Tra = 2,
        /// <summary>
        /// 机票
        /// </summary>
        [Description("机票")]
        Flt = 3,
        /// <summary>
        /// 机票改签申请
        /// </summary>
        [Description("机票改签申请")]
        FltModApply = 4,
        /// <summary>
        /// 机票退票申请
        /// </summary>
        [Description("机票退票申请")]
        FltRetApply = 5,
        /// <summary>
        /// 机票改签
        /// </summary>
        [Description("机票改签")]
        FltMod = 6,
        /// <summary>
        /// 火车改签
        /// </summary>
        [Description("火车改签")]
        TraMod =7,
        /// <summary>
        /// 机票退票
        /// </summary>
        [Description("机票退票")]
        FltRet = 8,
        /// <summary>
        /// 火车退票
        /// </summary>
        [Description("火车退票")]
        TraRet = 9,
        /// <summary>
        /// 审批单
        /// </summary>
        [Description("审批单")]
        AduitOrder =10
    }
}
