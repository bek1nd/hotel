using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mzl.EntityModel.Customer.Corporation.CostCenter
{
    [Table("P_CostCenter")]
    public class CostCenterEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Description("主键")]
        public int Cid { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        [Description("公司Id")]
        public string CorpId { get; set; }
        /// <summary>
        /// 成本中心
        /// </summary>
        [Description("成本中心")]
        public string Depart { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Description("是否删除")]
        public string IsHidden { get; set; }
    }
}
