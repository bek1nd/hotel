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
    ///  酒店订单明细（间夜信息）
    /// </summary>
    [Table("Hol_OrderDetail")]
    public partial class HolOrderDetailEntity
    {
        [Key]
        public int DetailId { get; set; }

        public int OrderId { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(1)]
        public string PriceType { get; set; }

        public decimal DPayAmount { get; set; }

        public decimal DLowAmount { get; set; }

        public decimal BedAmount { get; set; }

        public int BedCount { get; set; }

        public decimal BreakfastAmount { get; set; }

        public int BreakfastCount { get; set; }

        public decimal AdslAmount { get; set; }

        public int AdslCount { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; }

        public decimal? ReturnRate { get; set; }

        public decimal? LeaveRateA { get; set; }

        public decimal? ProfitA { get; set; }

        public decimal? LeaveRateB { get; set; }

        public decimal? ProfitB { get; set; }

        public decimal? LeaveRateC { get; set; }

        public decimal? ProfitC { get; set; }

        public decimal? ReturnRatePrice { get; set; }

        public decimal? ChangeAmountA { get; set; }

        public decimal? ChangeAmountB { get; set; }

        public decimal? ChangeAmountC { get; set; }
    }
}
