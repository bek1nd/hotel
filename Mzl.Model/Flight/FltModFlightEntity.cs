using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Mzl.EntityModel.Flight
{
    /// <summary>
    /// 改签行程表
    /// </summary>
    [Table("Flt_Flight_Change")]
    public partial class FltModFlightEntity
    {
        [Key]
        public int Id { get; set; }

        public int Orderid { get; set; }

        public int? Sequence { get; set; }

        [StringLength(7)]
        public string FlightNo { get; set; }

        [StringLength(1)]
        public string Class { get; set; }

        [StringLength(6)]
        public string RecordNo { get; set; }

        public DateTime? TackoffTime { get; set; }

        public DateTime? ArrivalsTime { get; set; }

        [StringLength(3)]
        public string Dport { get; set; }

        [StringLength(3)]
        public string Aport { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Rate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FacePrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SalePrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TaxFee { get; set; }

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

        [StringLength(600)]
        public string RetDes { get; set; }

        [StringLength(600)]
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
        public decimal? GetRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GetRatePrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ReturnRatePrice { get; set; }

        [StringLength(200)]
        public string ChoiceReason { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(50)]
        public string CreateOid { get; set; }

        public int? UpdateCount { get; set; }

        public int Rmid { get; set; }

        [Required]
        [StringLength(1)]
        public string PType { get; set; }

        [StringLength(4)]
        public string Airportson { get; set; }

        [StringLength(1)]
        public string Meal { get; set; }

        [StringLength(20)]
        public string Luggage { get; set; }

        [StringLength(10)]
        public string BigRecordNo { get; set; }
    }
}
