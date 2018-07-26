using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper
{
    /// <summary>
    /// 退票申请原因
    /// </summary>
    public enum RetTypeEnum
    {
        /// <summary>
        /// 自愿退票 
        /// </summary>
        [Description("自愿退票")]
        VoluntaryRefund,
        /// <summary>
        /// 航班变动(取消)
        /// </summary>
        [Description("航班变动(取消)")]
        FlightChange,
        /// <summary>
        /// 病退
        /// </summary>
        [Description("病退")]
        Bingtui,
        /// <summary>
        /// 其它
        /// </summary>
        [Description("其它")]
        Other
    }
}
