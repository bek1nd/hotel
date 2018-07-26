using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel.Elong
{
    public class OrderCreateResponse
    {
        /// <summary>
        /// 返回订单Id
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 最晚取消时间
        /// </summary>
        public DateTime CancelTime { get; set; }
        /// <summary>
        /// 担保金额
        /// </summary>
        public decimal GuaranteeAmount { get; set; }
        /// <summary>
        /// 货币类型
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// 是否是即时确认
        /// </summary>
        public bool IsInstantConfirm { get; set; }
        /// <summary>
        /// 支付最后期限
        /// </summary>
        public DateTime PaymentDeadlineTime { get; set; }
        /// <summary>
        /// 支付错误信息
        /// </summary>
        public string PaymentMessage { get; set; }
    }
}
