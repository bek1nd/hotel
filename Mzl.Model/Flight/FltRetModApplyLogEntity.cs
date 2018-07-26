using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Mzl.EntityModel.Flight
{
    /// <summary>
    /// 退改签申请日志
    /// </summary>
    [Table("Flt_RetModOrder_Log")]
    public partial class FltRetModApplyLogEntity
    {
        [Key]
        public int LogId { get; set; }

        public int? Rmid { get; set; }

        [StringLength(30)]
        public string Oid { get; set; }

        [StringLength(30)]
        public string LogType { get; set; }

        [StringLength(300)]
        public string Remark { get; set; }

        public DateTime? LogTime { get; set; }
    }
}
