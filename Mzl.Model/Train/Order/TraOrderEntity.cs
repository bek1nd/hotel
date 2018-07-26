using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Mzl.EntityModel.Train.Order
{
    [Table("Tra_Order")]
    public class TraOrderEntity
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [Key]
        [Description("订单号")]
        [Column("Order_Id")]
        public int OrderId { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        [Description("联系人姓名")]
        [Column("Customer_Name")]
        public string CName { get; set; }
        /// <summary>
        /// 送票方式0为公司送票,1为快递或邮寄,2上门自取
        /// </summary>
        [Description("送票方式0为公司送票,1为快递或邮寄,2上门自取")]
        [Column("Send_Type")]
        public int SendType { get; set; }
        /// <summary>
        /// 送取票地址
        /// </summary>
        [Description("送取票地址")]
        [Column("Customer_Address")]
        public string SendAddress { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        [Description("订单总金额")]
        [Column("Total_Money")]
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        [Description("下单时间")]
        [Column("Order_Time")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        [Description("支付方式")]
        [Column("Pay_Type")]
        public string PayType { get; set; }
        /// <summary>
        /// 操作员ID
        /// </summary>
        [Description("操作员ID")]
        [Column("OpeartorId")]
        public string OpeartorId { get; set; }
        /// <summary>
        /// 订单备注
        /// </summary>
        [Description("订单备注")]
        [Column("Order_Remark")]
        public string OrderRemark { get; set; }
        /// <summary>
        /// 出票点
        /// </summary>
        [Description("出票点")]
        [Column("Train_Place")]
        public string TrainPlace { get; set; }
        /// <summary>
        /// 订单类型，0为订票单，1为订票临时单,2为退票单,3退票临时单
        /// </summary>
        [Description("订单类型，0为订票单，1为订票临时单,2为退票单,3退票临时单")]
        [Column("Order_Type")]
        public int OrderType { get; set; }
        /// <summary>
        /// 送票时间
        /// </summary>
        [Description("送票时间")]
        [Column("Send_Time")]
        public DateTime? SendTime { get; set; }
        /// <summary>
        /// 最晚送票时间
        /// </summary>
        [Description("最晚送票时间")]
        [Column("Send_LastTime")]
        public DateTime? LastSendTime { get; set; }
        /// <summary>
        /// 退票订单原始单号
        /// </summary>
        [Description("退票订单原始单号")]
        [Column("Order_Root")]
        public int? OrderRoot { get; set; }
        /// <summary>
        /// 成本中心
        /// </summary>
        [Description("成本中心")]
        [Column("Depart")]
        public string CostCenter { get; set; }
        /// <summary>
        /// 申请单号
        /// </summary>
        [Description("申请单号")]
        [Column("AppNumber")]
        public string AppNumber { get; set; }
        /// <summary>
        /// 工作令
        /// </summary>
        [Description("工作令")]
        [Column("WorkOrder")]
        public string WorkOrder { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        [Description("客户Id")]
        [Column("Cid")]
        public int Cid { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Description("手机号")]
        [Column("Customer_Tel")]
        public string CMobile { get; set; }
        /// <summary>
        /// 固话号
        /// </summary>
        [Description("固话号")]
        [Column("Customer_Phone")]
        public string CPhone { get; set; }
        /// <summary>
        /// 传真号
        /// </summary>
        [Description("传真号")]
        [Column("Customer_Fax")]
        public string CFax { get; set; }
        /// <summary>
        /// 邮箱信息
        /// </summary>
        [Description("邮箱信息")]
        [Column("Customer_Email")]
        public string CEmail { get; set; }
        /// <summary>
        /// 12306网站Id
        /// </summary>
        [Description("12306网站Id")]
        [Column("Passid")]
        public int? Web12306Id { get; set; }
        /// <summary>
        /// 采购单打印时间
        /// </summary>
        [Description("采购单打印时间")]
        [Column("PrintProcurementTime")]
        public DateTime? PrintProcurementTime { get; set; }
        /// <summary>
        /// 是否是线上订单
        /// </summary>
        [Description("是否是线上订单")]
        [Column("IsOnLine")]
        public string IsOnLine { get; set; }
        /// <summary>
        /// 是否接受无座
        /// </summary>
        [Description("是否接受无座")]
        [Column("IsWZ")]
        public string IsWz { get; set; }
        /// <summary>
        /// 客户备忘录
        /// </summary>
        [Description("客户备忘录")]
        [Column("CustomerRemark")]
        public string CustomerRemark { get; set; }
        /// <summary>
        /// 实收客户金额
        /// </summary>
        [Description("实收客户金额")]
        [Column("TotalAmount")]
        public decimal? PayAmount { get; set; }
        /// <summary>
        /// 应退客户金额
        /// </summary>
        [Description("应退客户金额")]
        public decimal? BackMoney { get; set; }
        /// <summary>
        /// 项目名称外键ID
        /// </summary>
        [Description("项目名称外键ID")]
        [Column("Projectid")]
        public int? ProjectId { get; set; }
        /// <summary>
        /// 保险预留总利润
        /// </summary>
        [Description("保险预留总利润")]
        [Column("ProfitIns")]
        public decimal? ProfitIns { get; set; }
        /// <summary>
        /// T需授权,F无需授权,W完成授权
        /// </summary>
        [Description("T需授权,F无需授权,W完成授权")]
        [Column("CheckStatus")]
        public string CheckStatus { get; set; }
        /// <summary>
        /// 授权人id
        /// </summary>
        [Description("授权人id")]
        [Column("Cpid")]
        public int? Cpid { get; set; }
        /// <summary>
        /// 实际审核人id
        /// </summary>
        [Description("实际审核人id")]
        [Column("Cpcid")]
        public int? Cpcid { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        [Description("审核时间")]
        [Column("CpTime")]
        public DateTime? CpTime { get; set; }
        /// <summary>
        /// 公司ID
        /// </summary>
        [Description("公司ID")]
        [Column("CorpIDs")]
        public string CorpIDs { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        [Description("部门ID")]
        [Column("CorpDepartId")]
        public int? CorpDepartId { get; set; }
        /// <summary>
        /// 政策内容
        /// </summary>
        [Description("政策内容")]
        [Column("CorpPolicy")]
        public string CorpPolicy { get; set; }
        /// <summary>
        /// 未选择原因
        /// </summary>
        [Description("未选择原因")]
        [Column("ChoiceReason")]
        public string ChoiceReason { get; set; }
        /// <summary>
        /// 审核方式
        /// </summary>
        [Description("审核方式")]
        [Column("CheckType")]
        public string CheckType { get; set; }
        /// <summary>
        /// 超时审核时间
        /// </summary>
        [Description("超时审核时间")]
        [Column("TelTime")]
        public int? TelTime { get; set; }
        /// <summary>
        /// 违反政策损失金额
        /// </summary>
        [Description("违反政策损失金额")]
        [Column("LostAmount")]
        public decimal? LostAmount { get; set; }
        /// <summary>
        /// 结算方式 0：现结 1：月结
        /// </summary>
        [Description("结算方式 0：现结 1：月结")]
        [Column("BalanceType")]
        public int? BalanceType { get; set; }
        /// <summary>
        /// 结算方式 0：因公 1：因私
        /// </summary>
        [Description("结算方式 0：因公 1：因私")]
        [Column("TravelType")]
        public int? TravelType { get; set; }
        /// <summary>
        /// 是否需要再次打印 T需要 F不需要
        /// </summary>
        [Description("是否需要再次打印 T需要 F不需要")]
        [Column("IsNeedPrint")]
        public string IsNeedPrint { get; set; }
        /// <summary>
        /// 需要再次打印的时间
        /// </summary>
        [Description("需要再次打印的时间")]
        [Column("IsNeedPrintTime")]
        public DateTime? IsNeedPrintTime { get; set; }
        /// <summary>
        /// 微信订单号
        /// </summary>
        [Description("微信订单号")]
        [Column("WeiXinOrderId")]
        public string WeiXinOrderId { get; set; }
        /// <summary>
        /// 退票改签编号如ABCDE
        /// </summary>
        [Description("退票改签编号如ABCDE")]
        [Column("NumberIdentity")]
        public string NumberIdentity { get; set; }
        /// <summary>
        /// 订单创建人
        /// </summary>
        [Description("订单创建人")]
        [Column("CreateOid")]
        public string CreateOid { get; set; }

        /// <summary>
        /// 是否是改签生成的退票单
        /// </summary>
        [Description("是否是改签生成的退票单")]
        public bool? IsModRefund { get; set; }
        /// <summary>
        /// 改签订单号 IsModRefund=true 存在
        /// </summary>
        [Description("改签订单号 IsModRefund=true 存在")]
        public int? CorderId { get; set; }
        /// <summary>
        /// 第三方接口交易订单号
        /// </summary>
        [Description("第三方接口交易订单号")]
        public string TransactionId { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        [Description("订单来源")]
        public string OrderFrom { get; set; }
        public string OrderSource { get; set; }
        /// <summary>
        /// 是否抢票订单
        /// </summary>
        public bool? IsGrabTicketOrder { get; set; }
        /// <summary>
        /// 12306网站是否允许退票，仅用于抢票订单
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
        /// 退票类型  0普通 1虚退
        /// </summary>
        public int? RefundType { get; set; }
        /// <summary>
        /// 复制来源订单Id
        /// </summary>
        public int? CopyFromOrderId { get; set; }
        /// <summary>
        /// 复制类型 C普通复制 X虚退复制
        /// </summary>
        public string CopyType { get; set; }
        /// <summary>
        /// 是否线上隐藏 0否 1是
        /// </summary>
        public int? IsOnlineShow { get; set; }

        public string Remark { get; set; }
    }
}
