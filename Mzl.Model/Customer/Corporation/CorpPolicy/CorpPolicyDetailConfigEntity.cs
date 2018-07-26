using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Mzl.EntityModel.Customer.Corporation.CorpPolicy
{
    /// <summary>
    /// 差旅政策明细
    /// </summary>
    [Table("P_CorpPolicyDetailConfig")]
    public partial class CorpPolicyDetailConfigEntity
    {
        [Key]
        public int PolicyDetailId { get; set; }

        public int PolicyId { get; set; }

        [Required]
        [StringLength(1)]
        public string DetailType { get; set; }

        [Required]
        [StringLength(50)]
        public string PolicyVal { get; set; }

        public int? Cid { get; set; }

        public DateTime? LastUpdateTime { get; set; }

        [StringLength(1)]
        public string PolicyType { get; set; }
    }
}
