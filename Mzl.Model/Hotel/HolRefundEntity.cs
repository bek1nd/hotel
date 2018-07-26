using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel
{
    [Table("Hol_Refund")]
    public class HolRefundEntity
    {
        [Key]
        public int RefundId { get; set; }

        public int OrderId { get; set; }

        public decimal RefundCash { get; set; }

        public decimal RefundCard { get; set; }

        public decimal RefundFee { get; set; }

        public decimal RefundMoney { get; set; }

        public decimal ExpressFee { get; set; }

        public decimal Balance { get; set; }

        public decimal Remittance { get; set; }

        public decimal PosFee { get; set; }

        public decimal UsedAmount { get; set; }

        public decimal CorporationFee { get; set; }

        [Required]
        [StringLength(1)]
        public string RefundCustomer { get; set; }

        public DateTime? RcDate { get; set; }

        [StringLength(50)]
        public string RcOid { get; set; }

        [Required]
        [StringLength(1)]
        public string RefundMerchant { get; set; }

        public DateTime? RmDate { get; set; }

        [StringLength(50)]
        public string RmOid { get; set; }

        [Required]
        [StringLength(50)]
        public string RefundOid { get; set; }

        public DateTime RefundDate { get; set; }

        [Required]
        [StringLength(500)]
        public string Remark { get; set; }

        [Required]
        [StringLength(50)]
        public string HandleOid { get; set; }

        [Required]
        [StringLength(50)]
        public string ContactName { get; set; }

        [Required]
        [StringLength(20)]
        public string ContactPhone { get; set; }

        [Required]
        [StringLength(20)]
        public string ContactMobile { get; set; }

        [Required]
        [StringLength(50)]
        public string ContactEmail { get; set; }

        [Required]
        [StringLength(3)]
        public string SendType { get; set; }

        [Required]
        [StringLength(200)]
        public string SendRemark { get; set; }

        public DateTime SendTime { get; set; }

        public DateTime LastSendTime { get; set; }

        [Required]
        [StringLength(20)]
        public string SendOid { get; set; }

        public int SendScore { get; set; }

        [Required]
        [StringLength(50)]
        public string SendAddress { get; set; }

        public decimal RefundMerchantAmount { get; set; }

        [Required]
        [StringLength(1)]
        public string NumberIdentity { get; set; }

        public int PaymentId { get; set; }

        public int ReceivablesId { get; set; }

        public int Applyid { get; set; }

        public int? FivePrintId { get; set; }

        public int? FivePrintCount { get; set; }

        public DateTime? FivePrintLastTime { get; set; }

        public DateTime? FristPrintTime { get; set; }

        public DateTime? ReturnAccountTime { get; set; }

        [StringLength(50)]
        public string ReturnAccountOid { get; set; }

        public int? IsReturnAccount { get; set; }

        public int? IsPrint { get; set; }

        [StringLength(1)]
        public string IsKeepAccount { get; set; }

        public DateTime? KeepAccountDate { get; set; }

        [StringLength(20)]
        public string KeepAccountOid { get; set; }

        public int? RefundType { get; set; }
    }
}
