using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Mzl.EntityModel.Flight
{
    /// <summary>
    /// 机票订单副表
    /// </summary>
    [Table("Flt_OrderUnion")]
    public partial class FltOrderUnionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }

        [StringLength(100)]
        public string PassengerName { get; set; }

        [StringLength(50)]
        public string TicketNo { get; set; }

        [StringLength(500)]
        public string CustomerRemark { get; set; }

        public int ExpandStatus { get; set; }

        public int NotReturnMoney { get; set; }
        /// <summary>
        /// 是否手机订单
        /// </summary>
        [Required]
        [StringLength(1)]
        public string IsMobile { get; set; }

        public int? ProjectId { get; set; }

        public int? Insuaranceoid { get; set; }

        public DateTime? InsurancecreateTime { get; set; }

        [StringLength(10)]
        public string InsuranceOid { get; set; }

        public DateTime? AffirmTime { get; set; }

        [StringLength(6)]
        public string CARecordNo { get; set; }

        [StringLength(20)]
        public string CorpId { get; set; }

        public int? CorpDepartId { get; set; }

        [StringLength(500)]
        public string CorpPolicy { get; set; }

        [StringLength(1)]
        public string Appraise { get; set; }

        public int? CPCid { get; set; }

        public decimal? LostAmount { get; set; }

        [StringLength(1)]
        public string IsPolicyL { get; set; }

        [StringLength(1)]
        public string IsPolicyT { get; set; }

        [StringLength(1)]
        public string IsPolicyR { get; set; }

        [StringLength(50)]
        public string TMNum { get; set; }

        [StringLength(50)]
        public string ProjectCode { get; set; }

        [Required]
        [StringLength(1)]
        public string IsAutoInsurance { get; set; }

        [StringLength(50)]
        public string PolicyUpLoadOid { get; set; }

        [StringLength(50)]
        public string PolicyUpLoadOName { get; set; }

        [StringLength(5)]
        public string FreightRatesType { get; set; }

        public decimal? InnerRateAmount { get; set; }

        public decimal? InnerSaleRateAmount { get; set; }

        public decimal? InnerRate { get; set; }

        public decimal? InnerSaleRate { get; set; }

        [StringLength(1)]
        public string IsFastPrintTicket { get; set; }

        public int? FivePrintId { get; set; }

        public int? FivePrintCount { get; set; }

        public DateTime? FivePrintLastTime { get; set; }

        public int? IsTeamOrder { get; set; }

        public int? BalanceType { get; set; }

        public int? TravelType { get; set; }

        [StringLength(1)]
        public string IsNeedPrint { get; set; }

        public DateTime? IsNeedPrintTime { get; set; }

        [StringLength(50)]
        public string WeiXinOrderId { get; set; }

        public decimal? UnCollectionAmount { get; set; }
    }
}
