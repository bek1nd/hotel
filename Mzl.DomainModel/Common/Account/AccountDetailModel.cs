using System;
using System.ComponentModel;

namespace Mzl.DomainModel.Common.Account
{
    public class AccountDetailModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Description("主键")]
        public int ADid { get; set; }
        /// <summary>
        /// 帐号Id
        /// </summary>
        [Description("帐号Id")]
        public int Aid { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        [Description("金额")]
        public decimal Amount { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        [Description("操作类型")]
        public string Detailtype { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [Description("操作人")]
        public string Oid { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        [Description("来源")]
        public string Source { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号")]
        public int? OrderId { get; set; }
        /// <summary>
        /// 退票单Id
        /// </summary>
        [Description("退票单Id")]
        public int? RefundId { get; set; }
        /// <summary>
        /// 更新前金额
        /// </summary>
        [Description("更新前金额")]
        public decimal? OldAmount { get; set; }
        /// <summary>
        /// 更新后金额
        /// </summary>
        [Description("更新后金额")]
        public decimal? NewAmount { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        [Description("供应商")]
        public int? Provider { get; set; }
        /// <summary>
        /// 业务类型(P支付，C收款)
        /// </summary>
        [Description("业务类型(P支付，C收款)")]
        public string BusinessType { get; set; }
        /// <summary>
        /// 明细类型(FLT,机票，HOL,酒店,TRA,火车票)
        /// </summary>
        [Description("明细类型(FLT,机票，HOL,酒店,TRA,火车票)")]
        public string OrderType { get; set; }
        /// <summary>
        /// 收款备注
        /// </summary>
        [Description("收款备注")]
        public string CollectionRemark { get; set; }
        /// <summary>
        /// 预收款ID
        /// </summary>
        [Description("预收款ID")]
        public int? EstimateId { get; set; }
        /// <summary>
        /// 科目明细ID
        /// </summary>
        [Description("科目明细ID")]
        public int? SubjectDetailId { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        [Description("客户编号")]
        public int? Cid { get; set; }
    }
}
