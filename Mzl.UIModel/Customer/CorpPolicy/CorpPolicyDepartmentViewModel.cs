using System.ComponentModel;

namespace Mzl.UIModel.Customer.CorpPolicy
{
    public class CorpPolicyDepartmentViewModel
    {
        /// <summary>
        /// 部门Id
        /// </summary>
        [Description("部门Id")]
        public string Id { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Description("部门名称")]
        public string DepartName { get; set; }
        /// <summary>
        /// 是否包含对应的政策
        /// </summary>
        [Description("是否包含对应的政策")]
        public bool IsHasPolicy { get; set; }
        /// <summary>
        /// 是否包含对应的审批规则
        /// </summary>
        [Description("是否包含对应的审批规则")]
        public bool IsHasAduit { get; set; }
    }
}
