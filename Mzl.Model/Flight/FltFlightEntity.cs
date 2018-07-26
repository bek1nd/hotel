using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Mzl.EntityModel.Flight
{
    /// <summary>
    /// 机票航程表
    /// </summary>
    [Table("Flt_Flight")]
    public partial class FltFlightEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Sequence { get; set; }

        [Required]
        [StringLength(7)]
        public string FlightNo { get; set; }

        [Required]
        [StringLength(1)]
        public string Class { get; set; }

        [Required]
        [StringLength(6)]
        public string RecordNo { get; set; }

        public DateTime TackoffTime { get; set; }

        public DateTime ArrivalsTime { get; set; }

        [Required]
        [StringLength(3)]
        public string Dport { get; set; }

        [Required]
        [StringLength(3)]
        public string Aport { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Rate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FacePrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SalePrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TaxFee { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OilFee { get; set; }

        [StringLength(100)]
        public string Remark { get; set; }

        [StringLength(1)]
        public string IsRet { get; set; }

        [StringLength(1)]
        public string IsMod { get; set; }

        [StringLength(1)]
        public string IsEnd { get; set; }

        [StringLength(2000)]
        public string RetDes { get; set; }

        [StringLength(2000)]
        public string ModDes { get; set; }

        [StringLength(600)]
        public string EndDes { get; set; }

        public int? Delayday { get; set; }

        [StringLength(1)]
        public string IsInter { get; set; }

        [StringLength(50)]
        public string Shortlimit { get; set; }

        [StringLength(50)]
        public string Longlimit { get; set; }

        [StringLength(10)]
        public string AirType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GetRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GetRatePrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ReturnRatePrice { get; set; }

        [StringLength(200)]
        public string ChoiceReason { get; set; }

        [Column(TypeName = "numeric")]
        public decimal FRate { get; set; }

        public decimal? LeaveRateA { get; set; }

        public decimal? ChangeAmountA { get; set; }

        public decimal? ProfitA { get; set; }

        public decimal? LeaveRateB { get; set; }

        public decimal? ChangeAmountB { get; set; }

        public decimal? ProfitB { get; set; }

        public decimal? LeaveRateC { get; set; }

        public decimal? ChangeAmountC { get; set; }

        public decimal? ProfitC { get; set; }

        [StringLength(100)]
        public string PlcId { get; set; }

        public decimal? StandardPrice { get; set; }

        public decimal? StandardRate { get; set; }

        [StringLength(4)]
        public string Airportson { get; set; }

        [StringLength(50)]
        public string PolicyLostTime { get; set; }

        [StringLength(50)]
        public string PolicyLostWeekTime { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ServiceFee { get; set; }

        [StringLength(1)]
        public string Meal { get; set; }

        [StringLength(20)]
        public string Luggage { get; set; }

        public decimal? DetailBasePrice { get; set; }

        [StringLength(20)]
        public string FlightTime { get; set; }

        public int? InnerTid { get; set; }

        public decimal? InnerRate { get; set; }

        public decimal? InnerSaleRate { get; set; }

        public decimal? BaseFacePrice { get; set; }

        [StringLength(6)]
        public string OldRecordNo { get; set; }

        public int? BaseFacePriceUpdateCount { get; set; }

        [StringLength(50)]
        public string PolicyType { get; set; }

        [StringLength(5000)]
        public string PolicyMemo { get; set; }

        [StringLength(50)]
        public string AgreementNumber { get; set; }

        [StringLength(50)]
        public string TicketType { get; set; }

        public decimal? PolicyRate { get; set; }

        public decimal? PolicyFloorRate { get; set; }

        public decimal? PolicyReturnMoney { get; set; }

        public decimal? PolicyReward { get; set; }

        public decimal? PolicyServiceFee { get; set; }

        [StringLength(20)]
        public string SharedFlightNo { get; set; }

        [StringLength(10)]
        public string BigRecordNo { get; set; }

        public string CorpPolicy { get; set; }
        /// <summary>
        /// 最低销售价(白屏航班)
        /// </summary>
        public decimal? MinSalePrice{ get; set; }
    }
}
