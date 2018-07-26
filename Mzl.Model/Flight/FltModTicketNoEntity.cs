using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Mzl.EntityModel.Flight
{
    /// <summary>
    /// 改签票号表
    /// </summary>
    [Table("FltRetMod_ticketNo")]
    public partial class FltModTicketNoEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rmid { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Sequence { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string PassengerName { get; set; }

        [StringLength(3)]
        public string AirlineNo { get; set; }

        [StringLength(10)]
        public string TicketNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DeductionRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Discountprice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TaxFee { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OilFee { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TotalPrice { get; set; }

        public int Faid { get; set; }

        public int? Aid { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ServiceFee { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SalePrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SingleTrip { get; set; }

        [StringLength(1)]
        public string PrintSingleTrip { get; set; }

        [StringLength(1)]
        public string TicketNoStatus { get; set; }

        [StringLength(20)]
        public string AuditOid { get; set; }

        public DateTime? AuditTime { get; set; }

        [Required]
        [StringLength(1)]
        public string IsMod { get; set; }

        public int CheckCount { get; set; }

        [StringLength(20)]
        public string TicketNoStatusStr { get; set; }

        [StringLength(10)]
        public string TicketNoStatusSeq { get; set; }

        [StringLength(5000)]
        public string TicketNoStatusDes { get; set; }

        [StringLength(50)]
        public string TicketCompany { get; set; }
    }
}
