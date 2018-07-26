using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order.OrderDetail
{
    public class GetTraOrderDetailResponseViewModel
    {
        /// <summary>
        /// 火车正单信息
        /// </summary>
        [Description("火车正单信息")]
        public GetTraOrderViewModel TraOrder { get; set; }
        /// <summary>
        /// 火车改签单信息
        /// </summary>
        [Description("火车改签单信息")]
        public List<GetTraModOrderViewModel> TraModOrderList { get; set; }
        /// <summary>
        /// 退款总额
        /// </summary>
        [Description("退款总额 包含了退票金额+改签退客户金额")]
        public decimal RefundAmount { get; set; }
        /// <summary>
        /// 改签收客户金额
        /// </summary>
        [Description("改签收客户金额")]
        public decimal TotalModAmount { get; set; }
        /// <summary>
        /// 正单总额
        /// </summary>
        [Description("正单总额")]
        public decimal TotalOrderAmount { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号")]
        public int OrderId { get; set; }
        /// <summary>
        /// 线上显示订单号
        /// </summary>
        [Description("线上显示订单号")]
        public int ShowOnlineOrderId { get; set; }
        /// <summary>
        /// 12306订单号
        /// </summary>
        [Description("12306订单号")]
        public string OrderId12306 { get; set; }
    }
}
