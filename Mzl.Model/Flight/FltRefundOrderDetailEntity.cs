using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace Mzl.EntityModel.Flight
{
    [Table("Flt_Refund_Detail")]
    public partial class FltRefundOrderDetailEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rid { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Sequence { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string PassengerName { get; set; }

        [StringLength(3)]
        public string AirlineNo { get; set; }

        [StringLength(50)]
        public string TicketNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RefundFee { get; set; }

        public decimal? ReturnAmount { get; set; }

        public decimal? ReturnPoint { get; set; }

        [StringLength(50)]
        public string TravelPrintId { get; set; }

        public int? TravelRetrieveStatus { get; set; }

        public DateTime? TravelRetrieveTime { get; set; }
    }
}
