using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Customer.Corporation.CorpPolicy
{
    [Table("P_CorpPolicyConfig_Department")]
    public class CorpPolicyConfigDepartmentEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Description("Id")]
        public int Id { get; set; }
        /// <summary>
        /// 部门Id
        /// </summary>
        [Description("部门Id")]
        public int DepartmentId { get; set; }
        /// <summary>
        /// 政策Id
        /// </summary>
        [Description("政策Id")]
        public int PolicyId { get; set; }
    }
}
