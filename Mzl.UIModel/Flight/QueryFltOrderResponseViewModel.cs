using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.UIModel.Flight
{
    public class QueryFltOrderResponseViewModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [Description("线上展示订单号 2018.4.22更新 用来替代OrdeId做展示使用")]
        public int ShowOnlineOrderId { get; set; }
        /// <summary>
        /// 订单时间
        /// </summary>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal PayAmount { get; set; }
        /// <summary>
        /// 线上订单状态
        /// </summary>
        public string OnlineOrderStatus { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public string AuditStatus { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderStatus { get; set; }
        /// <summary>
        /// 线上订单展现状态（v1.7.7之后订单列表状态）
        /// </summary>
        public string OnlineShowOrderStatus { get; set; }
        /// <summary>
        /// 成本中心
        /// </summary>
        public string CostCenter { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        public string CName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        /// <summary>
        /// 差旅政策Id
        /// </summary>
        [Description("差旅政策Id")]
        public int? CorpPolicyId { get; set; }
        /// <summary>
        /// 审批规则Id
        /// </summary>
        [Description("审批规则Id")]
        public int? CorpAduitId { get; set; }
        /// <summary>
        /// 行程信息
        /// </summary>
        public List<FltFlightViewModel> FlightList { get; set; }
        /// <summary>
        /// 乘机人信息
        /// </summary>
        public List<FltPassengerViewModel> PassengerList { get; set; }


        /// <summary>
        /// 改签订单信息
        /// </summary>
        public List<FltModOrderViewModel> FltModOrderList { get; set; }
        /// <summary>
        /// 退票订单信息
        /// </summary>
        public List<FltRefundOrderViewModel> FltRefundOrderList { get; set; }
        /// <summary>
        /// 审批单Id
        /// </summary>
        [Description("审批单Id")]
        public int? AduitOrderId  { get; set; }
        /// <summary>
        /// 是否当前登录用户审批该订单
        /// </summary>
        [Description("是否当前登录用户审批该订单")]
        public bool IsCurrentCustomerAduitOrder { get; set; }
        /// <summary>
        /// 是否显示取消按钮
        /// </summary>
        [Description("是否显示取消按钮")]
        public bool IsShowCancelButton { get; set; }
        /// <summary>
        /// 出差原由
        /// </summary>
        [Description("出差原由")]
        public string TravelReason { get; set; }
        /// <summary>
        /// 订单所属客户Id
        /// </summary>
        [Description("订单所属客户Id")]
        public int Cid { get; set; }
        /// <summary>
        /// 项目名称Id
        /// </summary>
        [Description("项目名称Id")]
        public int? ProjectId { get; set; }
        /// <summary>
        /// 是否打印五连单
        /// </summary>
        [Description("是否打印五连单")]
        public int IsPrint { get; set; }

        public decimal CreditCardfeeamount { get; set; }
        public decimal Voucheramount { get; set; }
        public decimal SendTicketamount { get; set; }
        public string SendTicketType { get; set; }
        public int SendTicketTypeValue => (int) SendTicketType.NameToEnum<SendTicketTypeEnum>();
        public DateTime? SendTicketTime { get; set; }
        public DateTime? LastSendTicketTime { get; set; }
        public string Address { get; set; }
    }
}
