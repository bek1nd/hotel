using System.Collections.Generic;
using System.ComponentModel;

namespace Mzl.DomainModel.Customer.MatchCorpPolicyAndAduit
{
    public class MatchCorpPolicyAndAduitResultModel
    {
        /// <summary>
        /// 是否冲突
        /// </summary>
        public bool IsConflict { get; set; }
        /// <summary>
        /// 默认政策Id
        /// </summary>
        public int? DefaultPolicyId { get; set; }
        /// <summary>
        /// 默认审批规则Id
        /// </summary>
        public int? DefaultAduitId { get; set; }
        /// <summary>
        /// 默认部门Id
        /// </summary>
        [Description("默认部门Id")]
        public int? DefaultDepartmentId { get; set; }
        /// <summary>
        /// 默认部门名称
        /// </summary>
        [Description("默认部门名称")]
        public string DefaultDepartmentName { get; set; }
        /// <summary>
        /// 默认保险限制
        /// </summary>
        [Description("默认保险限制")]
        public string DefaultInsuranceLimit { get; set; }
        /// <summary>
        /// 默认火车快车席别最高限制
        /// </summary>
        [Description("默认火车快车席别最高限制")]
        public string DefaultViolateTPolicyValQ { get; set; }
        /// <summary>
        /// 默认普车/其他最高限制
        /// </summary>
        [Description("默认普车/其他最高限制")]
        public string DefaultViolateTPolicyValM { get; set; }
        /// <summary>
        /// 默认最高卧铺限制
        /// </summary>
        [Description("默认最高卧铺限制")]
        public string DefaultViolateTPolicyValS { get; set; }

        /// <summary>
        /// 变更选择信息（部门成本中心）
        /// </summary>
        public List<CorpPolicyAndAduitChangeModel> ChangeInfoList { get; set; }
        /// <summary>
        /// 变更选择信息（项目成本中心）
        /// </summary>
        [Description("变更选择信息（项目成本中心）")]
        public List<CorpPolicyAndAduitChangeProjectModel> ProjectChangeInfoList { get; set; }
    }
}
