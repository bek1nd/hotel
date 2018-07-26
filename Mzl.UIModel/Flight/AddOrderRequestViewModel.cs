using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.UIModel.Flight
{
    public class AddOrderRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 航线类型,S单程,B往返程,M联程
        /// </summary>
        [Description("航线类型,S单程,B往返程,M联程")]
        [Required]
        public string FltType { get; set; }

        /// <summary>
        /// 订单创建人 差旅线上订单默认差旅负责人，其他线上订单默认sys
        /// </summary>
        [Description("订单创建人")]
        public string CreateOid { get; set; } = "sys";
        /// <summary>
        /// 支付类型
        /// </summary>
        [Description("支付类型")]
        public string Paytype { get; set; }
        /// <summary>
        /// 订单总价
        /// </summary>
        [Description("订单总价")]
        public decimal Payamount { get; set; }
        /// <summary>
        /// 送票时间
        /// </summary>
        [Description("送票时间")]
        public DateTime? SendTicketTime { get; set; }
        /// <summary>
        /// 最晚送票时间
        /// </summary>
        [Description("最晚送票时间")]
        public DateTime? LastSendTicketTime { get; set; }
        /// <summary>
        /// 订单乘客类型 C成人 E儿童
        /// </summary>
        [Description(" 订单乘客类型 C成人 E儿童")]
        [Required]
        public string PassengerType { get; set; }
        /// <summary>
        /// 送票地址
        /// </summary>
        [Description("送票地址")]
        public string Address { get; set; }
        /// <summary>
        /// 联系人名称
        /// </summary>
        [Required]
        [Description("联系人名称")]
        public string Cname { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Description("联系电话")]
        public string Phone { get; set; }
        /// <summary>
        /// 联系手机
        /// </summary>
        [Required]
        [Description("联系手机")]
        public string Mobile { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        [Description("传真")]
        public string Fax { get; set; }
        /// <summary>
        /// 电子邮件
        /// </summary>
        [Description("电子邮件")]
        public string Email { get; set; }

        /// <summary>
        /// 是否线上 T是 F不是
        /// </summary>
        [Description("是否线上 T是 F不是")]
        public string IsOnline
        {
            get
            {
                if (string.IsNullOrEmpty(OrderSource))
                    return "F";
                if (OrderSource == "O")
                    return "F";
                return "T";
            }
        }
        /// <summary>
        /// 项目Id
        /// </summary>
        [Description("项目Id")]
        public int? ProjectId { get; set; }
        /// <summary>
        /// 部门Id
        /// </summary>
        [Description("部门Id")]
        public int? CorpDepartId { get; set; }
        /// <summary>
        /// 成本中心
        /// </summary>
        [Description("成本中心")]
        public string CostCenter { get; set; }
        /// <summary>
        /// 行程信息集合
        /// </summary>
        [Description("行程信息集合")]
        [Required]
        public List<AddFltFlightViewModel> FlightList { get; set; }
        /// <summary>
        /// 乘客信息集合
        /// </summary>
        [Description("乘客信息集合")]
        [Required]
        public List<AddFltPassengerViewModel> PassengerList { get; set; }
        /// <summary>
        /// 是否打印两连单
        /// </summary>
        [Description("是否打印两连单")]
        public int? IsPrint { get; set; }
        /// <summary>
        /// 差旅政策Id
        /// </summary>
        [Description("差旅政策Id")]
        public int? CorpPolicyId { get; set; }
        /// <summary>
        /// 差旅审批规则Id
        /// </summary>
        [Description("差旅审批规则Id")]
        public int? CorpAduitId { get; set; }

        /// <summary>
        /// 配送类型 默认无需配送
        /// </summary>
        [Description("配送类型 默认无需配送")]
        public SendTicketTypeEnum SendTicketType { get; set; } = SendTicketTypeEnum.Not;

        /// <summary>
        /// 刷卡手续费
        /// </summary>
        [Description("刷卡手续费")]
        public decimal CreditCardfeeamount { get; set; }
        /// <summary>
        /// 优惠
        /// </summary>
        [Description("优惠")]
        public decimal Voucheramount { get; set; }
        /// <summary>
        /// 送票费
        /// </summary>
        [Description("送票费")]
        public decimal SendTicketamount { get; set; }
        /// <summary>
        /// 订单备注
        /// </summary>
        [Description("订单备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 预计出票时间
        /// </summary>
        [Description("预计出票时间")]
        public DateTime? EstimateTicketTime { get; set; }
        /// <summary>
        /// 送票说明
        /// </summary>
        [Description("送票说明")]
        public string SendTicketRemark { get; set; }
        /// <summary>
        /// 出差原由
        /// </summary>
        [Description("出差原由")]
        public string TravelReason { get; set; }
        /// <summary>
        /// 是否对相同行程做验证
        /// </summary>
        [Description("是否对相同行程做验证 2018.4.17更新")]
        public bool IsCheckSameFlight { get; set; } = true;
        /// <summary>
        /// 是否检查未使用票号
        /// </summary>
        [Description("是否检查未使用票号 2018.6.7更新")]
        public bool IsCheckUnUsedTicketNo { get; set; }
    }
}
