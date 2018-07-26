using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel
{
    /// <summary>
    /// 酒店订单
    /// </summary>
    [Table("Hol_Order")]
    public partial class HolOrderEntity
    {
        [Key]
        public int OrderId { get; set; }

        public int HolId { get; set; }

        public int RtId { get; set; }

        public int Cid { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int DayRange { get; set; }

        public int RoomNum { get; set; }

        public int CustomerNum { get; set; }

        [StringLength(500)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(1)]
        public string OrderType { get; set; }

        [Required]
        [StringLength(1)]
        public string OrderStatus { get; set; }

        public int ProcessStatus { get; set; }

        public int Mid { get; set; }

        [Required]
        [StringLength(50)]
        public string Oid { get; set; }

        [StringLength(1000)]
        public string Remark { get; set; }

        [StringLength(1000)]
        public string Explain { get; set; }

        [Required]
        [StringLength(3)]
        public string PayType { get; set; }

        public decimal PayAmount { get; set; }

        public decimal VoucherAmount { get; set; }

        public decimal CreditCardfeeAmount { get; set; }

        public decimal DepositAmount { get; set; }

        public decimal SendTicketAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal OtherAmount { get; set; }

        public decimal LowAmount { get; set; }

        public decimal ProceedsAmount { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreateOid { get; set; }

        public int CancelType { get; set; }

        public int BankId { get; set; }

        public int CreditId { get; set; }

        [Required]
        [StringLength(1)]
        public string BalanceType { get; set; }

        [StringLength(50)]
        public string ContactName { get; set; }

        [StringLength(20)]
        public string ContactPhone { get; set; }

        [StringLength(20)]
        public string ContactMobile { get; set; }

        [StringLength(50)]
        public string ContactEmail { get; set; }

        [StringLength(3)]
        public string SendType { get; set; }

        [StringLength(100)]
        public string SendRemark { get; set; }

        public DateTime SendTime { get; set; }

        public DateTime LastSendTime { get; set; }

        [StringLength(50)]
        public string SendOid { get; set; }

        public int SendScore { get; set; }

        [StringLength(50)]
        public string SendAddress { get; set; }

        [StringLength(50)]
        public string SendFax { get; set; }

        [StringLength(50)]
        public string Depart { get; set; }

        [StringLength(1000)]
        public string BookingRemark { get; set; }

        [StringLength(1000)]
        public string ConfirmRemark { get; set; }

        public DateTime KeepTo { get; set; }

        public decimal PlanCommission { get; set; }

        public decimal ActualCommission { get; set; }

        public int NightAuditStatus { get; set; }

        public DateTime CommissionMonth { get; set; }

        [StringLength(50)]
        public string OutOrderId { get; set; }

        public DateTime EstimateCollectiontime { get; set; }

        public int InvoiceType { get; set; }

        [StringLength(50)]
        public string InvoiceTitle { get; set; }

        [StringLength(50)]
        public string InvoiceContent { get; set; }

        public decimal InvoiceAmount { get; set; }

        public decimal ExtendAmount { get; set; }

        public decimal BackAmount { get; set; }

        public DateTime? Collectiontime { get; set; }

        [StringLength(50)]
        public string CollectionOid { get; set; }

        public DateTime? RealPayDatetime { get; set; }

        [StringLength(50)]
        public string RealPayOid { get; set; }

        public DateTime? Printordertime { get; set; }

        [StringLength(20)]
        public string Printorderoid { get; set; }

        [Required]
        [StringLength(1)]
        public string HolType { get; set; }

        public DateTime? FaccountsTime { get; set; }

        [StringLength(20)]
        public string FaccountsOid { get; set; }

        [Required]
        [StringLength(1)]
        public string IsOnLine { get; set; }

        public DateTime? KeepToTo { get; set; }

        [StringLength(20)]
        public string ContactFax { get; set; }

        [StringLength(3)]
        public string ComfirmType { get; set; }

        [StringLength(1)]
        public string CollectionForEndMonth { get; set; }

        public DateTime? ConfirmTime { get; set; }

        [StringLength(50)]
        public string ConfirmOid { get; set; }

        public DateTime? FristPrintTime { get; set; }

        public int PrintNumber { get; set; }

        [Required]
        [StringLength(1)]
        public string IsOnLinePay { get; set; }

        [StringLength(1000)]
        public string GuaranteeRemark { get; set; }

        public int? ProjectId { get; set; }

        [StringLength(1)]
        public string IsLuggage { get; set; }

        [StringLength(1)]
        public string IsBuses { get; set; }

        [StringLength(50)]
        public string BusesRemark { get; set; }

        public int? FivePrintId { get; set; }

        public DateTime? FivePrintLastTime { get; set; }

        public int? TravelType { get; set; }

        public int? BalanceMethod { get; set; }

        [StringLength(1)]
        public string IsNeedPrint { get; set; }

        public DateTime? IsNeedPrintTime { get; set; }

        [StringLength(50)]
        public string WeiXinOrderId { get; set; }

        [StringLength(1)]
        public string IsJourneyOrder { get; set; }

        public decimal? UnCollectionAmount { get; set; }

        public decimal? CollectionAmount { get; set; }

        [StringLength(20)]
        public string OrderFrom { get; set; }

        [StringLength(20)]
        public string OrderNumber { get; set; }

        public int? IsSecretInquiry { get; set; }

        [StringLength(4000)]
        public string CustomerMobile { get; set; }

        public int? IsPrint { get; set; }

        public int? IsOnlineShow { get; set; }

        [StringLength(1)]
        public string CopyType { get; set; }

        public int? CopyFromOrderId { get; set; }
    }
}
