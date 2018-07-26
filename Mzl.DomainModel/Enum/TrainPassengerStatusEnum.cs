using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Enum
{
    /// <summary>
    /// 火车乘车人状态
    /// </summary>
    public enum TrainPassengerStatusEnum
    {
        /// <summary>
        /// 正常状态
        /// </summary>
        [Description("")]
        Common = 0,
        /// <summary>
        /// 已改签
        /// </summary>
        [Description("已改签")]
        Mod = 1,
        /// <summary>
        /// 已退票
        /// </summary>
        [Description("已退票")]
        Refund = 2

    }
}
