using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Customer.Corporation.CorpAudit
{
    /// <summary>
    /// 差旅审批规则与部门的关系表
    /// </summary>
    [Table("P_CorpAduitConfig_Department")]
    public class CorpAduitConfigDepartmentEntity
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
        /// 审批规则Id
        /// </summary>
        [Description("审批规则Id")]
        public int AduitId { get; set; }
    }
}
