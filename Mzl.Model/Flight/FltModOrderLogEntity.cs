using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Mzl.EntityModel.Flight
{
    /// <summary>
    /// 改签订单日志表
    /// </summary>
    [Table("Flt_ModOrder_Log")]
    public partial class FltModOrderLogEntity
    {
        [Key]
        public int LogId { get; set; }

        public int Rmid { get; set; }

        [Required]
        [StringLength(30)]
        public string Oid { get; set; }

        [Required]
        [StringLength(30)]
        public string LogType { get; set; }

        [Required]
        [StringLength(300)]
        public string Remark { get; set; }

        public DateTime LogTime { get; set; }
    }
}
