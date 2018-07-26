using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Mzl.EntityModel.Flight
{
    [Table("Flt_Refund")]
    public partial class FltRefundOrderEntity
    {
        [Key]
        public int RefundId { get; set; }

        public int OrderId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RefundCash { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RefundCard { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RefundFee { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RefundMoney { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ExpressFee { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Balance { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Remittance { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PosFee { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UsedAmount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CorporationFee { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SupplierFee { get; set; }

        [StringLength(30)]
        public string ContactPerson { get; set; }

        [StringLength(30)]
        public string ContactTel { get; set; }

        [StringLength(500)]
        public string SendAddress { get; set; }

        public DateTime? SendBeginDate { get; set; }

        public DateTime? SendEndDate { get; set; }

        [StringLength(3)]
        public string SendMode { get; set; }

        [StringLength(1)]
        public string RefundCustomer { get; set; }

        public DateTime? RcDate { get; set; }

        [StringLength(20)]
        public string RcOid { get; set; }

        [StringLength(1)]
        public string RefundSupplier { get; set; }

        public DateTime? RsDate { get; set; }

        [StringLength(20)]
        public string RsOid { get; set; }

        [StringLength(20)]
        public string RefundOid { get; set; }

        public DateTime? RefundDate { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        [StringLength(4)]
        public string CustomerStatus { get; set; }

        [StringLength(4)]
        public string SupplierStatus { get; set; }

        [StringLength(4)]
        public string SingleTripStatus { get; set; }

        [StringLength(3)]
        public string RefundReason { get; set; }

        [StringLength(20)]
        public string HandleOid { get; set; }

        public int? Aid { get; set; }

        [Required]
        [StringLength(1)]
        public string AccountStatus { get; set; } = "F";

        [StringLength(50)]
        public string AccountOid { get; set; }

        public DateTime? AccountDate { get; set; }

        public DateTime? PrintTicketsTime { get; set; }

        [StringLength(1)]
        public string IsCompleted { get; set; }

        [Required]
        [StringLength(1)]
        public string NumberIdentity { get; set; }

        public decimal? Refundfeetemp { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Voucheramount { get; set; }

        [StringLength(1)]
        public string RefundStatus { get; set; }

        [StringLength(1)]
        public string IsLock { get; set; }

        [StringLength(1)]
        public string Refundprofit { get; set; }

        public int? ReAid { get; set; }

        public int? PaAid { get; set; }

        public int PrintNumber { get; set; }

        public DateTime? FristPrintTime { get; set; }

        public int? PressoceStatus { get; set; }

        [Required]
        [StringLength(1)]
        public string IsAudit { get; set; } = "F";

        [StringLength(100)]
        public string AuditRemark { get; set; }

        public decimal SecondRefundMoney { get; set; }

        public int? SecondPaAid { get; set; }

        [StringLength(50)]
        public string SecondOid { get; set; }

        public DateTime? SecondTime { get; set; }

        [StringLength(500)]
        public string SecondRemark { get; set; }

        [StringLength(1)]
        public string SecondPrintTime { get; set; }

        [Required]
        [StringLength(1)]
        public string SecondPrintStatus { get; set; } = "T";

        public int? Rmid { get; set; }

        public int? SecondReAid { get; set; }

        [StringLength(1)]
        public string SecondRefundCustomer { get; set; }

        public DateTime? SecondRcDate { get; set; }

        [StringLength(50)]
        public string SecondRcOid { get; set; }

        public int? FivePrintId { get; set; }

        public DateTime? FivePrintLastTime { get; set; }

        [StringLength(500)]
        public string RefundTypeRemark { get; set; }

        [StringLength(1)]
        public string IsKeepAccount { get; set; }

        public DateTime? KeepAccountDate { get; set; }

        [StringLength(20)]
        public string KeepAccountOid { get; set; }
    }
}
