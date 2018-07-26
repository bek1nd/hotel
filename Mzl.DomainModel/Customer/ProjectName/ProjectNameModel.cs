using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.ProjectName
{
    public class ProjectNameModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Description("主键")]
        public int ProjectId { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Description("项目名称")]
        public string ProjectName { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Description("是否删除")]
        public string IsDelete { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime? CreatTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Description("创建人")]
        public string Oid { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        [Description("用户编号")]
        public int? Cid { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        [Description("公司编号")]
        public string CorpId { get; set; }
        /// <summary>
        /// 是否有对应政策Id
        /// </summary>
        [Description("是否有对应政策Id")]
        public bool IsHasPolicy { get; set; }
        /// <summary>
        /// 是否包含对应的审批规则
        /// </summary>
        [Description("是否包含对应的审批规则")]
        public bool IsHasAduit { get; set; }
    }
}
