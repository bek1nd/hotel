using System;
using System.ComponentModel;

namespace Mzl.Common.EnumHelper
{
    public enum FltRetApplyStatusEnum
    {
        /// <summary>
        /// 待退票
        /// </summary>
        [Description("待退票")]
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
        /// 待取消编码
        /// </summary>
        [Description("待取消编码")]
        D,
        /// <summary>
        /// 退票中
        /// </summary>
        [Description("退票中")]
        P,
        /// <summary>
        /// 已取消
        /// </summary>
        [Description("已取消")]
        C,
        /// <summary>
        /// 完成
        /// </summary>
        [Description("完成")]
        F,
      
    }
}
