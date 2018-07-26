using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 支付代扣接口返回
    /// </summary>
    public class PayDeductResponse
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
        /// B2T用户名
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// B2T订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 外部订单号
        /// </summary>
        public string ExtRefNo { get; set; }
        /// <summary>
        /// 实扣金额
        /// </summary>
        public string DeductAmount { get; set; }
        /// <summary>
        /// 银行订单号
        /// </summary>
        public string BankNo { get; set; }
        /// <summary>
        /// 实扣税费明细
        /// </summary>
        public List<TaxInfo> TaxInfo { get; set; }
    }
}
