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
    /// 差旅审批规则与部门员工的关系表
    /// </summary>
    [Table("P_CorpAduitConfig_Customer")]
    public class CorpAduitConfigCustomerEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Description("Id")]
        public int Id { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        [Description("客户Id")]
        public int Cid { get; set; }
        /// <summary>
        /// 审批规则Id
        /// </summary>
        [Description("审批规则Id")]
        public int AduitId { get; set; }
    }
}
