using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mzl.EntityModel.Customer.Identification
{
    [Table("P_IdentificationType")]
    public class IdentificationTypeEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Description("主键")]
        public int Iid { get; set; }
        /// <summary>
        /// 证件名称
        /// </summary>
        [Description("证件名称")]
        public string IdentificationName { get; set; }
    }
}
