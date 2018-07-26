using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Mzl.EntityModel.Flight
{
    /// <summary>
    /// 退改签申请明细信息
    /// </summary>
    [Table("Flt_ModFlight")]
    public partial class FltRetModFlightApplyEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rmid { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Pid { get; set; }

        public virtual FltPassengerEntity FltPassenger { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Sequence { get; set; }

        [StringLength(20)]
        public string FlightNo { get; set; }

        public DateTime? TackoffTime { get; set; }

        [Required]
        [StringLength(1)]
        public string OrderStatus { get; set; }

        [StringLength(20)]
        public string Oid { get; set; }

        [StringLength(200)]
        public string DisposeResult { get; set; }

        public DateTime? DisposeTime { get; set; }

        [StringLength(50)]
        public string TicketNo { get; set; }

        public int? RefundId { get; set; }

        [StringLength(50)]
        public string Dport { get; set; }

        [StringLength(50)]
        public string Aport { get; set; }

        public DateTime? ArrivalsTime { get; set; }

        [StringLength(1)]
        public string Class { get; set; }

        public decimal? SalePrice { get; set; }

        public decimal? FacePrice { get; set; }

        public decimal? AuditPrice { get; set; }

        [StringLength(200)]
        public string PolicyDesc { get; set; }

        [StringLength(100)]
        public string PolicyId { get; set; }

        public int? ChoiceReasonId { get; set; }

        [StringLength(6)]
        public string RecordNo { get; set; }
    }
}
