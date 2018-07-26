using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Enum
{
    /// <summary>
    /// 线上火车票状态
    /// </summary>
    public enum TraOrderOnlineStatusEnum
    {
        /// <summary>
        /// 待出票
        /// </summary>
        [Description("待出票")]
        WaitPrintTicket = 0,
        /// <summary>
        /// 出票中
        /// </summary>
        [Description("出票中")]
        PrintTicketing = 2,
        /// <summary>
        /// 已出票
        /// </summary>
        [Description("已出票")]
        PrintTicketed = 3

    }
}
