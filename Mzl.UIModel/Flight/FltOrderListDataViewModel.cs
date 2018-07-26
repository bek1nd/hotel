using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class FltOrderListDataViewModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号")]
        public int OrderId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [Description("线上展示订单号 2018.4.22更新 用来替代OrdeId做展示使用")]
        public int ShowOnlineOrderId { get; set; }
        /// <summary>
        /// 订单日期
        /// </summary>
        [Description("订单日期")]
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        [Description("订单金额")]
        public decimal PayAmount { get; set; }
        /// <summary>
        /// 线上订单状态
        /// </summary>
        [Description("线上订单状态")]
        public string OnlineOrderStatus { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        [Description("审核状态")]
        public string AuditStatus { get; set; }
        /// <summary>
        /// 线上订单展现状态（v1.7.6之后线上订单状态）
        /// </summary>
        [Description("线上订单展现状态")]
        public string OnlineShowOrderStatus { get; set; }
        /// <summary>
        /// 是否改签
        /// </summary>
        [Description("是否改签")]
        public bool IsMod { get; set; }
        /// <summary>
        /// 是否退票
        /// </summary>
        [Description("是否退票")]
        public bool IsRet { get; set; }
        /// <summary>
        /// 航段信息集合
        /// </summary>
        [Description("航段信息集合")]
        public List<FltFlightListViewModel> FlightList { get; set; }
        /// <summary>
        /// 乘机人信息集合
        /// </summary>
        [Description("乘机人信息集合")]
        public List<FltPassengerListViewModel> PassengerList { get; set; }
    }
}
