using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Mzl.EntityModel.Flight
{
    /// <summary>
    /// 机票订单日志表
    /// </summary>
    [Table("flt_order_log")]
    public partial class FltOrderLogEntity
    {
        [Key]
        public int LogId { get; set; }

        public int OrderId { get; set; }

        [StringLength(50)]
        public string Oid { get; set; }

        [StringLength(20)]
        public string LogType { get; set; }

        [StringLength(1000)]
        public string Remark { get; set; }

        public DateTime? LogTime { get; set; }

        [StringLength(1)]
        public string CheckStatus { get; set; }

        public int? CPId { get; set; }

        public DateTime? CPTime { get; set; }

        public int ExpandStatus { get; set; }
    }
}
