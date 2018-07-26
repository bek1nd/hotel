using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace Mzl.EntityModel.Flight
{
    /// <summary>
    /// 机票乘机人表
    /// </summary>
    [Table("Flt_Passenger")]
    public partial class FltPassengerEntity
    {
        [Key]
        public int PId { get; set; }

        public int OrderId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int CardType { get; set; }

        [Required]
        [StringLength(50)]
        public string CardNo { get; set; }

        public DateTime? Birthday { get; set; }

        public int? Insurance { get; set; }

        public int? InsuranceCount { get; set; }

        public int? FreeInsuranceCount { get; set; }

        [Required]
        [StringLength(1)]
        public string AgeType { get; set; }

        [StringLength(12)]
        public string Mobile { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(3)]
        public string Nationality { get; set; }

        public DateTime? CardValidity { get; set; }

        [Required]
        [StringLength(200)]
        public string Remark { get; set; }

        [Required]
        [StringLength(1)]
        public string IsAvailable { get; set; }

        public int? InsCompanyId { get; set; }

        public decimal? InsLowPrice { get; set; }

        public int? InsFaId { get; set; }

        public int? InsAid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ProfitIns { get; set; }

        public int? Contactid { get; set; }
    }
}
