using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Mzl.EntityModel.Customer.Corporation.CorpPolicy
{
    /// <summary>
    /// 差旅政策
    /// </summary>
    [Table("P_CorpPolicyConfig")]
    public partial class CorpPolicyConfigEntity
    {
        [Key]
        public int PolicyId { get; set; }

        [StringLength(200)]
        public string PolicyName { get; set; }

        public int Cid { get; set; }

        public DateTime AddTime { get; set; }

        [Required]
        [StringLength(1)]
        public string IsDel { get; set; }

        [StringLength(50)]
        public string CorpId { get; set; }
    }
}
