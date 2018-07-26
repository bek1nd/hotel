using System;
using System.ComponentModel;

namespace Mzl.Common.EnumHelper
{
    public enum FltModApplyStatusEnum
    {
        /// <summary>
        /// 待处理
        /// </summary>
        [Description("待处理")]
        W,
        /// <summary>
        /// 待核价
        /// </summary>
        [Description("待核价")]
        T,
        /// <summary>
        /// 待确认
        /// </summary>
        [Description("待确认")]
        A,
       
        /// <summary>
        /// 待出票
        /// </summary>
        [Description("待出票")]
        P,
        /// <summary>
        /// 已取消
        /// </summary>
        [Description("已取消")]
        C,
        /// <summary>
        /// 已出票
        /// </summary>
        [Description("已出票")]
        F,
        /// <summary>
        /// 审批中
        /// </summary>
        [Description("审批中")]
        Aduiting
    }
}
