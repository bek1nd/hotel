using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.UIModel.Train.Order
{
    public class TraOrderViewModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 创建订单人
        /// </summary>
        public string CreateOid { get; set; } = "sys";
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 订单类型 0正单 1非正式正单 2退单 3非正式退单
        /// </summary>
        public int OrderType { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 应收款
        /// </summary>
        public decimal PayAmount { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string CName { get; set; }
        /// <summary>
        /// 联系人手机号码
        /// </summary>
        public string CMobile { get; set; }
        /// <summary>
        /// 联系人Emai
        /// </summary>
        public string CEmail { get; set; }
        /// <summary>
        /// 退票对应正单订单号
        /// </summary>
        public int? OrderRoot { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 副单序号
        /// </summary>
        public string NumberIdentity { get; set; }
        /// <summary>
        /// 固话号
        /// </summary>
        public string CPhone { get; set; }
        /// <summary>
        /// 传真号
        /// </summary>
        public string CFax { get; set; }

        public string OrderStatus { get; set; }
        /// <summary>
        /// 退票单号
        /// </summary>
        public string RefundOrderId
        {
            get
            {
                if (OrderType != 2)
                    return string.Empty;
                return
                    OrderRoot + NumberIdentity;
            }
        }

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
        /// 成本中心
        /// </summary>
        [Description("成本中心")]
        public string CostCenter { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Description("项目名称")]
        public int? ProjectId { get; set; }
        /// <summary>
        /// 是否打印两联单
        /// </summary>
        [Description("是否打印两联单")]
        public int? IsPrint { get; set; }
        /// <summary>
        /// 送票时间
        /// </summary>
        public DateTime? SendTime { get; set; }
        /// <summary>
        /// 最晚送票时间
        /// </summary>
        public DateTime? LastSendTime { get; set; }

        /// <summary>
        /// 送票方式
        /// </summary>
        public int? SendType { get; set; } = (int) SendTicketTypeEnum.Not;
        /// <summary>
        /// 送取票地址
        /// </summary>
        public string SendAddress { get; set; }
        /// <summary>
        /// 订单备注
        /// </summary>
        public string OrderRemark { get; set; }
        /// <summary>
        /// 12306帐号Id
        /// </summary>
        public int? Web12306Id { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public PayTypeEnum? PayType { get; set; } = PayTypeEnum.Cro;

        /// <summary>
        /// 出差原由
        /// </summary>
        [Description("出差原由")]
        public string TravelReason { get; set; }
        /// <summary>
        /// 差旅订单归属部门Id
        /// </summary>
        [Description("差旅订单归属部门Id")]
        public int? CorpDepartId { get; set; }
        /// <summary>
        /// 线上显示订单
        /// </summary>
        public int ShowOnlineOrderId { get; set; }

        public string Remark { get; set; }
        /// <summary>
        /// 审批单Id
        /// </summary>
        [Description("审批单Id")]
        public int? AduitOrderId { get; set; }
    }
}
