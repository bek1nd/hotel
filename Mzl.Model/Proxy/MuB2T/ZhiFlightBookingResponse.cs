using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 直达航班预定接口返回数据
    /// </summary>
    public class ZhiFlightBookingResponse
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
        /// B2T订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 总的票面金额
        /// </summary>
        public float TicketPrice { get; set; }
        /// <summary>
        /// 总的实收金额
        /// </summary>
        public float? SalePrice { get; set; }
        /// <summary>
        /// 总的代理费
        /// </summary>
        public float? DiscountAmount { get; set; }
        /// <summary>
        /// 代理费率
        /// </summary>
        public float? DiscountPercent { get; set; }
        /// <summary>
        /// B2T用户名
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 联系人邮箱
        /// </summary>
        public string ContactEmail { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string ContactPhone { get; set; }
        /// <summary>
        /// 旅客联系电话
        /// </summary>
        public string PassengerPhone { get; set; }
        /// <summary>
        /// 外部订单号
        /// </summary>
        public string ExtRefNo { get; set; }
        /// <summary>
        /// 预定方式
        /// </summary>
        public int? BookingChannel { get; set; }
        /// <summary>
        /// 航班类型
        /// </summary>
        public string FlightType { get; set; }
        /// <summary>
        /// 旅客订座编号
        /// </summary>
        public string PnrCode { get; set; }
        /// <summary>
        /// 航段信息
        /// </summary>
        public List<SegmentInfo> SegmentInfo { get; set; }
        /// <summary>
        /// 旅客信息
        /// </summary>
        public List<PassengerInfo> PassengerInfo { get; set; }
        /// <summary>
        /// 税费信息
        /// </summary>
        public List<TaxInfo> taxInfo { get; set; }
    }
}
