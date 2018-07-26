using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Mzl.EntityModel.Flight
{
    /// <summary>
    /// 机票舱等表
    /// </summary>
    [Table("Flt_Class_Name")]
    public partial class FltClassNameEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string AirlineCode { get; set; }

        [StringLength(2)]
        public string MClass { get; set; }

        [StringLength(1)]
        public string Class { get; set; }

        [StringLength(50)]
        public string ClassName { get; set; }

        [StringLength(255)]
        public string Rate { get; set; }

        [StringLength(2000)]
        public string Remark { get; set; }

        public int BaggageWeight { get; set; }

        [StringLength(100)]
        public string ClassEnName { get; set; }
    }
}
