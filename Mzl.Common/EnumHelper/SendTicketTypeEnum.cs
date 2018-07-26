using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper
{
    /// <summary>
    /// 送票方式枚举
    /// </summary>
    public enum SendTicketTypeEnum
    {
        /// <summary>
        /// 公司送票
        /// </summary>
        [Description("公司送票")]
        Com=0,
        /// <summary>
        /// 快递/邮寄
        /// </summary>
        [Description("快递/邮寄")]
        Exp=1,
        /// <summary>
        /// 上门自取
        /// </summary>
        [Description("上门自取")]
        Hom=2,
        /// <summary>
        /// 车站自取
        /// </summary>
        [Description("车站自取")]
        TraBefore = 3,
        /// <summary>
        /// 发车后取票
        /// </summary>
        [Description("发车后取票")]
        TraAfter = 4,
        /// <summary>
        /// 机场自取
        /// </summary>
        [Description("机场自取")]
        Air =5,
        /// <summary>
        /// 无需送票
        /// </summary>
        [Description("无需送票")]
        Not=99


    }
}
