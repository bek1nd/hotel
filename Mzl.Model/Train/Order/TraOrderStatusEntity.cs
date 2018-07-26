using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Mzl.EntityModel.Train.Order
{
    [Table("Tra_Order_Status")]
    public class TraOrderStatusEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Description("主键")]
        public int Sid { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        [Description("订单编号")]
        [Column("Order_Id")]
        public int OrderId { get; set; }
        /// <summary>
        /// 购票单打印状态
        /// </summary>
        [Description("购票单打印状态")]
        public int Status1 { get; set; }
        /// <summary>
        /// 购票状态
        /// </summary>
        [Description("购票状态")]
        [Column("Status2")]
        public int IsBuy { get; set; }
        /// <summary>
        /// 送票单打印状态
        /// </summary>
        [Description("送票单打印状态")]
        public int Status3 { get; set; }
        /// <summary>
        /// 已退票
        /// </summary>
        [Description("已退票")]
        public int Status4 { get; set; }
        /// <summary>
        /// 收款状态
        /// </summary>
        [Description("收款状态")]
        public int Status5 { get; set; }
        /// <summary>
        /// 是否取消
        /// </summary>
        [Description("是否取消")]
        [Column("Is_Cancle")]
        public int IsCancle { get; set; }
        /// <summary>
        /// 订单取消原因
        /// </summary>
        [Description("订单取消原因")]
        [Column("Cancle_Reason")]
        public string CancleReason { get; set; }
        /// <summary>
        /// 订单变化原因
        /// </summary>
        [Description("订单变化原因")]
        [Column("Status_Remark")]
        public string StatusRemark { get; set; }
        /// <summary>
        /// 付款操作人
        /// </summary>
        [Description("付款操作人")]
        public string RealPayOid { get; set; }
        /// <summary>
        /// 付款操作时间
        /// </summary>
        [Description("付款操作时间")]
        public DateTime? RealPayDatetime { get; set; }
        /// <summary>
        /// 打印操作人
        /// </summary>
        [Description("打印操作人")]
        public string PrintTicketOid { get; set; }
        /// <summary>
        /// 打印操作时间
        /// </summary>
        [Description("打印操作时间")]
        public DateTime? PrintTicketTime { get; set; }
        /// <summary>
        /// 收款操作人
        /// </summary>
        [Description("收款操作人")]
        public string CollectionOid { get; set; }
        /// <summary>
        /// 收款操作时间
        /// </summary>
        [Description("收款操作时间")]
        public DateTime? Collectiontime { get; set; }
        /// <summary>
        /// 送票人
        /// </summary>
        [Description("送票人")]
        public string SendOid { get; set; }
        /// <summary>
        /// 送票分数
        /// </summary>
        [Description("送票分数")]
        public int? SendScore { get; set; }
        /// <summary>
        /// 新增的订单状态
        /// </summary>
        [Description("新增的订单状态")]
        public int ProccessStatus { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        [Description("供应商")]
        public int Provider { get; set; }
        /// <summary>
        /// 归账人id
        /// </summary>
        [Description("归账人id")]
        public string FaccountsOid { get; set; }
        /// <summary>
        /// 归账时间
        /// </summary>
        [Description("归账时间")]
        public DateTime? FaccountsTime { get; set; }
        /// <summary>
        /// 月底收款状态
        /// </summary>
        [Description("月底收款状态")]
        public string CollectionForEndMonth { get; set; }
        /// <summary>
        /// 预定时间
        /// </summary>
        [Description("预定时间")]
        public DateTime? DestineTime { get; set; }
        /// <summary>
        /// 五联单打印序列号
        /// </summary>
        [Description("五联单打印序列号")]
        public int? FivePrintId { get; set; }
        /// <summary>
        /// 五联单打印次数
        /// </summary>
        [Description("五联单打印次数")]
        public int? FivePrintCount { get; set; }
        /// <summary>
        /// 五联单最后打印时间
        /// </summary>
        [Description("五联单最后打印时间")]
        public DateTime? FivePrintLastTime { get; set; }
        /// <summary>
        /// 等待处理人
        /// </summary>
        [Description("等待处理人")]
        public int? WaitHandle { get; set; }
        /// <summary>
        /// 记账日期
        /// </summary>
        [Description("记账日期")]
        public DateTime? KeepAccountDate { get; set; }
        /// <summary>
        /// 记账操作人
        /// </summary>
        [Description("记账操作人")]
        public string KeepAccountOid { get; set; }
    }
}
