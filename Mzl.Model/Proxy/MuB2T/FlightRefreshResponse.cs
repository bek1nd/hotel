using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 航班刷新接口输出
    /// </summary>
    public class FlightRefreshResponse
    {
        /// <summary>
        /// 返回结果代码
        /// </summary>
        public string MsgType { get; set; }
        /// <summary>
        /// 返回结果描述
        /// </summary>
        public string MsgDesc { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 订单数量
        /// </summary>
        public string OrderAmount { get; set; }
        /// <summary>
        /// 外部订单号
        /// </summary>
        public string ExtRefNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OrderSt { get; set; }
        /// <summary>
        /// 航段信息
        /// </summary>

        public List<SegmentInfo> SegmentInfo { get; set; }
        /// <summary>
        /// 乘车人信息
        /// </summary>
        public List<PassengerInfo> PassengerInfo { get; set; }
    }
}
