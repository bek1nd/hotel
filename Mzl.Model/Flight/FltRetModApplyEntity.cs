using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace Mzl.EntityModel.Flight
{
    /// <summary>
    /// 退改签申请表
    /// </summary>
    [Table("Flt_RetModOrder")]
    public partial class FltRetModApplyEntity
    {
        [Key]
        public int Rmid { get; set; }

        [Required]
        [StringLength(1)]
        public string OrderType { get; set; }

        public int OrderId { get; set; }

        public int Cid { get; set; }

        public DateTime CreateTime { get; set; }

        [StringLength(50)]
        public string ContactName { get; set; }

        [StringLength(20)]
        public string ContactTel { get; set; }

        [Required]
        [StringLength(1)]
        public string OrderStatus { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        [StringLength(20)]
        public string CorpId { get; set; }

        [StringLength(50)]
        public string EditOid { get; set; }

        public DateTime? EditTime { get; set; }

        [StringLength(50)]
        public string CreateOid { get; set; }

        [Required]
        [StringLength(1)]
        public string IsOnlineRefund { get; set; }

        public int? OrderRmid { get; set; }

        [StringLength(500)]
        public string UploadUrl { get; set; }

        [StringLength(1)]
        public string IsKeepPnr { get; set; }

        [StringLength(50)]
        public string KeepPnrRemark { get; set; }

        [StringLength(200)]
        public string AuditRemark { get; set; }

        public DateTime? AuditTime { get; set; }

        [StringLength(20)]
        public string AuditOid { get; set; }

        public int? Cpid { get; set; }

        public int? CpidSecond { get; set; }

        [StringLength(1)]
        public string CheckType { get; set; }

        public int? TelTime { get; set; }

        public int? AgainNewOrderId { get; set; }

        [StringLength(1)]
        public string OrderFrom { get; set; }

        [StringLength(100)]
        public string OrderNumber { get; set; }

        public int? BackOrderId { get; set; }

        public decimal? OtherSystemBudget { get; set; }

        public int? ProcessStatus { get; set; }

        public int? NewRmid { get; set; }

        public int? CorpLinkId { get; set; }

        [StringLength(50)]
        public string RefundType { get; set; }

        public decimal? ServiceFee { get; set; }

        [StringLength(500)]
        public string LostUpLoadUrl { get; set; }

        [StringLength(500)]
        public string LostReason { get; set; }

        public DateTime? RecoverDate { get; set; }

        [StringLength(50)]
        public string RecoverType { get; set; }
        public string OrderSource { get; set; }
        /// <summary>
        /// 差旅政策Id
        /// </summary>
        public int? CorpPolicyId { get; set; }
        /// <summary>
        /// 差旅审批规则Id
        /// </summary>
        public int? CorpAduitId { get; set; }
        /// <summary>
        /// 隐藏订单
        /// </summary>
        public int? IsHidden { get; set; }
    }
}
