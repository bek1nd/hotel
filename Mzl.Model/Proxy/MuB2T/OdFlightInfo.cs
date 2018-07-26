using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 航班信息
    /// </summary>
    public class OdFlightInfo
    {
        /// <summary>
        /// 舱位等级
        /// </summary>
        public string cabinLevel { get; set; }
        /// <summary>
        /// 剩余座位数
        /// </summary>
        public string cabinCount { get; set; }
        /// <summary>
        /// 中转时间
        /// </summary>
        public string transferTime { get; set; }
        /// <summary>
        /// 飞行时间
        /// </summary>
        public string flyingTime { get; set; }
        /// <summary>
        /// 票面价（成人）
        /// </summary>
        public float? price { get; set; }
        /// <summary>
        /// 票面价（儿童）
        /// </summary>
        public float? chdPrice { get; set; }
        /// <summary>
        /// 代理费率
        /// </summary>
        public string discount { get; set; }
        /// <summary>
        /// 成人代理费
        /// </summary>
        public float? discountAm { get; set; }
        /// <summary>
        /// 儿童代理费
        /// </summary>
        public float? chdDiscountAm { get; set; }
        /// <summary>
        /// 退改升说明
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// 儿童退改签说明
        /// </summary>
        public string chdComment { get; set; }
        /// <summary>
        /// 航班组合详情
        /// </summary>
        public List<FlightInfo> flightInfo;
    }
}
