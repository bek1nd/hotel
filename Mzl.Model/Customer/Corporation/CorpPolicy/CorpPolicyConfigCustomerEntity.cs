using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mzl.EntityModel.Customer.Corporation.CorpPolicy
{
    [Table("P_CorpPolicyConfig_Customer")]
    public class CorpPolicyConfigCustomerEntity
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
        /// 政策Id
        /// </summary>
        [Description("政策Id")]
        public int PolicyId { get; set; }
    }
}
