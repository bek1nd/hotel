using Mzl.DomainModel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.DomainModel.Train.Order
{
    public class TraOrderModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        public int Cid { get; set; }
        /// <summary>
        /// 是否线上
        /// </summary>
        public string IsOnline { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public string CreateOid { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 订单类型 0正单 1非正式正单 2退单 3非正式退单
        /// </summary>
        public int OrderType { get; set; }
        /// <summary>
        /// 送票时间
        /// </summary>
        public DateTime? SendTime { get; set; }
        /// <summary>
        /// 最晚送票时间
        /// </summary>
        public DateTime? LastSendTime { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 应收款
        /// </summary>
        public decimal PayAmount { get; set; }
        /// <summary>
        /// 项目名称Id
        /// </summary>
        public int? ProjectId { get; set; }
        /// <summary>
        /// 成本中心
        /// </summary>
        public string CostCenter { get; set; }
        /// <summary>
        /// 出票点
        /// </summary>
        public string TrainPlace { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public PayTypeEnum? PayType { get; set; }
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
        /// 送票方式
        /// </summary>
        public int? SendType { get; set; }
        /// <summary>
        /// 结算方式 0：现结 1：月结
        /// </summary>
        public int? BalanceType { get; set; }
        /// <summary>
        /// 出行类别 0 因公 1因私
        /// </summary>
        public int? TravelType { get; set; }
        /// <summary>
        /// 操作员ID
        /// </summary>
        public string OpeartorId { get; set; }
        /// <summary>
        /// 送取票地址
        /// </summary>
        public string SendAddress { get; set; }
        /// <summary>
        /// 订单备注
        /// </summary>
        public string OrderRemark { get; set; }
        /// <summary>
        /// 固话号
        /// </summary>
        public string CPhone { get; set; }
        /// <summary>
        /// 传真号
        /// </summary>
        public string CFax { get; set; }
        /// <summary>
        ///  审批单状态
        /// </summary>
        public int? AduitOrderStatus { get; set; }

        public string AuditStatus { get; set; }
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

        public int? InterFaceOrderStatus { get; set; }
        /// <summary>
        /// 是否是改签生成的退票单
        /// </summary>
        public bool? IsModRefund { get; set; }
        /// <summary>
        /// 改签订单号
        /// </summary>
        public int? CorderId { get; set; }
        /// <summary>
        /// 第三方接口交易订单号
        /// </summary>
        public string TransactionId { get; set; }
        /// <summary>
        /// 12306帐号Id
        /// </summary>
        public int? Web12306Id { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        public string OrderFrom { get; set; }

        public string OrderSource { get; set; }

        /// <summary>
        /// 是否抢票订单
        /// </summary>
        public bool? IsGrabTicketOrder { get; set; }
        /// <summary>
        /// 12306是否允许退票
        /// </summary>
        public bool? IsRefundBy12306 { get; set; }
        /// <summary>
        /// 是否需要打印 0否 1是
        /// </summary>
        public int? IsPrint { get; set; }
        /// <summary>
        /// 差旅政策Id
        /// </summary>
        public int? CorpPolicyId { get; set; }
        /// <summary>
        /// 差旅审批规则Id
        /// </summary>
        public int? CorpAduitId { get; set; }
        /// <summary>
        /// 出差原由
        /// </summary>
        public string TravelReason { get; set; }
        /// <summary>
        /// 差旅订单归属部门Id
        /// </summary>
        public int? CorpDepartId { get; set; }
        /// <summary>
        /// 退票类型  0普通 1虚退
        /// </summary>
        public int RefundType { get; set; }
        /// <summary>
        /// 是否线上隐藏 0否 1是
        /// </summary>
        public int? IsOnlineShow { get; set; }
        /// <summary>
        /// 复制来源订单Id
        /// </summary>
        public int? CopyFromOrderId { get; set; }
        /// <summary>
        /// 复制类型 C普通复制 X虚退复制
        /// </summary>
        public string CopyType { get; set; }
        /// <summary>
        /// 退票备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 审批单Id
        /// </summary>
        public int? AduitOrderId { get; set; }
    }
}
