using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 订单查询接口输出
    /// </summary>
    public class OrderQueryResponse
    {
        /// <summary>
        /// 回调状态
        /// </summary>
        public string MsgType { get; set; }
        /// <summary>
        /// 回调
        /// </summary>
        public string MsgDesc { get; set; }
        /// <summary>
        /// B2T订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 外部订单号
        /// </summary>
        public string ExtRefNo { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderSt { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        public float? OrderAmount { get; set; }
        /// <summary>
        /// 航段信息
        /// </summary>
        public List<SegmentInfo> SegmentInfo { get; set; }
        /// <summary>
        /// 旅客信息
        /// </summary>
        public List<PassengerInfo> PassengerInfo { get; set; }
    }
}
