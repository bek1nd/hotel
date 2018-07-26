using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Mzl.EntityModel.Flight
{
    /// <summary>
    /// 改签订单表
    /// </summary>
    [Table("Flt_ModOrder")]
    public partial class FltModOrderEntity
    {
        [Key]
        public int Rmid { get; set; }

        public int ProcessStatus { get; set; }

        public decimal? ModPrice { get; set; }

        public decimal? ModLowPrice { get; set; }

        [StringLength(30)]
        public string ProcessOid { get; set; }

        [StringLength(20)]
        public string ContactPhone { get; set; }

        [StringLength(20)]
        public string ContactEmail { get; set; }

        [StringLength(20)]
        public string ContactFax { get; set; }

        [Required]
        [StringLength(3)]
        public string SendType { get; set; }

        [StringLength(200)]
        public string SendRemark { get; set; }

        public DateTime? SendTime { get; set; }

        public DateTime? LastSendTime { get; set; }

        [StringLength(200)]
        public string SendAddress { get; set; }

        public int Version { get; set; }

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

        public int? Aid { get; set; }

        [StringLength(30)]
        public string Oid { get; set; }

        public int? RootRmid { get; set; }

        [Required]
        [StringLength(1)]
        public string IsInter { get; set; }

        [Required]
        [StringLength(1)]
        public string IsOnLine { get; set; }

        [Required]
        [StringLength(1)]
        public string IsOnLinePay { get; set; }

        [StringLength(3)]
        public string Paytype { get; set; }

        public DateTime? RealAcceptDatetime { get; set; }

        [StringLength(30)]
        public string RealAcceptOid { get; set; }

        public DateTime? RealPayDatetime { get; set; }

        [StringLength(30)]
        public string RealPayOid { get; set; }

        public DateTime? ReturnAccountTime { get; set; }

        [StringLength(30)]
        public string ReturnAccountOid { get; set; }

        public int? BankId { get; set; }

        public int? Contactid { get; set; }

        [StringLength(50)]
        public string Depart { get; set; }

        public DateTime? PrintTicketTime { get; set; }

        public DateTime? LastPrintTicketTime { get; set; }

        [StringLength(1)]
        public string NumberIdentity { get; set; }

        public DateTime? OutTicketTime { get; set; }

        public int? FivePrintId { get; set; }

        public int? FivePrintCount { get; set; }

        public DateTime? FivePrintLastTime { get; set; }

        public int? BalanceType { get; set; }

        public int? TravelType { get; set; }

        [StringLength(1)]
        public string IsNeedPrint { get; set; }

        public DateTime? IsNeedPrintTime { get; set; }

        [StringLength(50)]
        public string WeiXinOrderId { get; set; }
    }
}
