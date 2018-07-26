using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 支付代扣接口输入
    /// </summary>
    public class PayDeductRequest
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
        /// B2T订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 外部订单号
        /// </summary>
        public string ExtRefNo { get; set; }
        /// <summary>
        /// 代扣商户
        /// </summary>
        public string DeductMerchant { get; set; }
        /// <summary>
        /// 回调通知地址
        /// </summary>
        public string NotifyURL { get; set; }
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
        public List<PayTaxInfo> TaxInfo { get; set; }
    }
}
