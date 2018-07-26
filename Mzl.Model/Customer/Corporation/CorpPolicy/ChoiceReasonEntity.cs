using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace Mzl.EntityModel.Customer.Corporation.CorpPolicy
{
    /// <summary>
    /// 差旅政策违反原因
    /// </summary>
    [Table("Flt_ChoiceReason")]
    public class ChoiceReasonEntity
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string CorpID { get; set; }

        [Required]
        [StringLength(200)]
        public string Reason { get; set; }

        [Required]
        [StringLength(1)]
        [Column("Is_Del")]
        public string IsDel { get; set; }

        public DateTime CreateTime { get; set; }

        public int Cid { get; set; }

        [StringLength(1)]
        public string PolicyType { get; set; }

        public int? TypeId { get; set; }
    }
}
