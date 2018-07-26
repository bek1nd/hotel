using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Mzl.EntityModel.Flight
{
    /// <summary>
    /// 改签乘机人
    /// </summary>
    [Table("Flt_RetModPassenger")]
    public partial class FltModPassengerEntity
    {
        [Key]
        public int Id { get; set; }

        public int Rmid { get; set; }

        public int Pid { get; set; }

        [Required]
        [StringLength(1)]
        public string PType { get; set; }
    }
}
