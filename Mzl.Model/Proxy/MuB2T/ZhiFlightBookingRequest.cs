using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 直达航班预定接口输入
    /// </summary>
    public class ZhiFlightBookingRequest
    {
        /// <summary>
        /// B2T用户名
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>
        public string AgentName { get; set; }
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
        public List<SegmentInfo> ListSegmentInfo { get; set; }
        /// <summary>
        /// 旅客信息
        /// </summary>
        public List<PassengerInfo> ListPassengerInfo { get; set; }
    }
}
