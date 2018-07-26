using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Flight
{
    public class QueryFlightRetApplyResponseViewModel
    {
        /// <summary>
        /// 总退票金额
        /// </summary>
        public decimal? RefundMoney { get; set; }
        /// <summary>
        /// 退票费用
        /// </summary>
        public decimal? RefundFee{ get; set; }
        /// <summary>
        /// 退票时间
        /// </summary>
        public DateTime? RefundDate { get; set; }

        /// <summary>
        /// 退票核价价格
        /// </summary>
        public decimal? RefundAuditPrice { get; set; }
        /// <summary>
        /// 申请人
        /// </summary>
        public string ApplyName { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 原订单号
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 联系号码
        /// </summary>
        public string ContactTel { get; set; }
        /// <summary>
        /// 申请状态
        /// </summary>
        public string OrderStatusDesc { get; set; }
        public string OrderStatus { get; set; }
        /// <summary>
        /// 申请备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 审批单状态
        /// </summary>
        public int? AduitOrderStatus { get; set; }
        /// <summary>
        /// 审批单状态描述
        /// </summary>
        public string AuditStatus { get; set; }
        /// <summary>
        /// 航程信息
        /// </summary>
        public List<QueryRetApplyFlightViewModel> FltRetFlightList { get; set; }

      

        /// <summary>
        /// 待确认信息
        /// </summary>
        public List<GetModRetApplyAuditViewModel> WaitConfirmList { get; set; }

        /// <summary>
        /// 差旅违规原因
        /// </summary>
        public List<SortedListViewModel> PolicyReason { get; set; }
        /// <summary>
        /// 审批单Id
        /// </summary>
        [Description("审批单Id")]
        public int? AduitOrderId { get; set; }
        /// <summary>
        /// 是否当前登录用户审批该订单
        /// </summary>
        [Description("是否当前登录用户审批该订单")]
        public bool IsCurrentCustomerAduitOrder { get; set; }
    }
}
