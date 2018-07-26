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
    /// 酒店订单日志
    /// </summary>
    [Table("Hol_OrderLog")]
    public partial class HolOrderLogEntity
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        [Required]
        [StringLength(50)]
        public string OpeartorId { get; set; }

        [Required]
        [StringLength(50)]
        public string LogType { get; set; }

        [Required]
        [StringLength(500)]
        public string Context { get; set; }

        public DateTime LogTime { get; set; }
    }
}
