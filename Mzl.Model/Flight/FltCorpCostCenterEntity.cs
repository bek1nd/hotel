using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Mzl.EntityModel.Flight
{
    /// <summary>
    /// 机票订单成本中心
    /// </summary>
    [Table("Flt_CorpOrder")]
    public partial class FltCorpCostCenterEntity
    {
        [StringLength(50)]
        public string WorkOrder { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Orderid { get; set; }

        [StringLength(100)]
        public string Depart { get; set; }

        [StringLength(50)]
        public string AppNumber { get; set; }

        [StringLength(30)]
        public string CorpID { get; set; }
    }
}
