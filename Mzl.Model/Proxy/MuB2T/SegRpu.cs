using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 退改签规则
    /// </summary>
    public class SegRpu
    {
        /// <summary>
        /// 签转手续费
        /// </summary>
        public string changeAirLineAm { get; set; }
        /// <summary>
        /// 签转手续费类型
        /// </summary>
        public string changeAirLineAmPer { get; set; }
        /// <summary>
        /// 是否可以签转
        /// </summary>
        public string changeAirLineFlag { get; set; }
        /// <summary>
        /// 最大时间
        /// </summary>
        public string maxTime { get; set; }
        /// <summary>
        /// 是否包含最大时间
        /// </summary>
        public string maxTimeFlag { get; set; }
        /// <summary>
        /// 最大时间单位
        /// </summary>
        public string maxTimeUnit { get; set; }
        /// <summary>
        /// 最小时间
        /// </summary>
        public string minTime { get; set; }
        /// <summary>
        /// 是否包含最小时间
        /// </summary>
        public string minTimeFlag { get; set; }
        /// <summary>
        /// 最小时间单位
        /// </summary>
        public string minTimeUnit { get; set; }
        /// <summary>
        /// 退票手续费
        /// </summary>
        public string refundedAm { get; set; }
        /// <summary>
        /// 退票手续费类型
        /// </summary>
        public string refundedAmPer { get; set; }
        /// <summary>
        /// 是否可以退票
        /// </summary>
        public string refundedFlag { get; set; }
        /// <summary>
        /// 改期手续费
        /// </summary>
        public string rescheduledAm { get; set; }
        /// <summary>
        /// 改期手续费类型
        /// </summary>
        public string rescheduledAmPer { get; set; }
        /// <summary>
        /// 是否可以改期
        /// </summary>
        public string rescheduledFlag { get; set; }
        /// <summary>
        /// 航前航后标示
        /// </summary>
        public string timeflag { get; set; }
    }
}
