using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Operator
{
    [Table("P_Operator")]
    public class OperatorEntity
    {
        [Key]
        [StringLength(50)]
        public string Oid { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        [StringLength(50)]
        public string OName { get; set; }

        public int? Dept { get; set; }

        [StringLength(20)]
        public string Tel { get; set; }

        [StringLength(4)]
        public string OpNo { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(1)]
        public string IsStart { get; set; }

        [StringLength(20)]
        public string EName { get; set; }

        [StringLength(1)]
        public string IsDel { get; set; }

        [StringLength(50)]
        public string EtermUserId { get; set; }

        [StringLength(50)]
        public string EtermUserPwd { get; set; }

        [Required]
        [StringLength(1)]
        public string IsUsered { get; set; }

        [StringLength(50)]
        public string Cid { get; set; }

        [StringLength(20)]
        public string WorkAduitOid { get; set; }

        [StringLength(1)]
        public string IsDealOid { get; set; }
    }
}
