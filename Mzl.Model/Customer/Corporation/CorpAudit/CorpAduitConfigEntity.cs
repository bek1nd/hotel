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
    [Table("P_CorpAduitConfig")]
    public class CorpAduitConfigEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Description("主键")]
        public int ConfigId { get; set; }
        /// <summary>
        /// 审批规则类型名称
        /// </summary>
        [Description("审批规则类型名称")]
        public string AduitName { get; set; }
        /// <summary>
        /// 适用范围 0不限 1国内机票 2国际机票 3火车
        /// </summary>
        [Description("适用范围 0不限 1国内机票 2国际机票 3火车")]
        public int SuitRange { get; set; }
        /// <summary>
        /// 是否需要审批 0否 1是
        /// </summary>
        [Description("是否需要审批 0否 1是")]
        public int IsNeedAduit { get; set; }
        /// <summary>
        /// 公司Id 
        /// </summary>
        [Description("公司Id ")]
        public string CorpId { get; set; }
        /// <summary>
        /// 创建客户Id
        /// </summary>
        [Description("创建客户Id")]
        public int CreateCid { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否删除 0否 1是
        /// </summary>
        [Description("是否删除 0否 1是")]
        public int IsDel { get; set; }
        /// <summary>
        /// 汇审类别：0 必须都审批 1只需审批一个
        /// </summary>
        [Description("汇审类别：0 必须都审批 1只需审批一个")]
        public int TogetherAduitType { get; set; }
    }
}
