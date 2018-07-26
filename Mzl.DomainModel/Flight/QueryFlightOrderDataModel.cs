using Mzl.Common.EnumHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class QueryFlightOrderDataModel : QueryFlightOrderListDataModel
    {
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
        /// 改签订单信息
        /// </summary>
        public List<FltModOrderModel> FltModOrderList { get; set; }
        /// <summary>
        /// 退票订单信息
        /// </summary>
        public List<FltRefundOrderModel> FltRefundOrderList { get; set; }
        /// <summary>
        /// 出差原由
        /// </summary>
        [Description("出差原由")]
        public string TravelReason { get; set; }
        /// <summary>
        /// 是否线上隐藏 0否 1是
        /// </summary>
        public int? IsOnlineShow { get; set; }
        /// <summary>
        /// 是否打印五连单
        /// </summary>
        [Description("是否打印五连单")]
        public int IsPrint { get; set; }

        public decimal CreditCardfeeamount { get; set; }
        public decimal Voucheramount { get; set; }
        public decimal SendTicketamount { get; set; }
        public string SendTicketType { get; set; }
        public DateTime? SendTicketTime { get; set; }
        public DateTime? LastSendTicketTime { get; set; }
        public string Address { get; set; }
        public int? ProjectId { get; set; }
    }
}
