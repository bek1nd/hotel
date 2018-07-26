using System.Collections.Generic;
using Mzl.DomainModel.Customer.CorpPolicy;

namespace Mzl.DomainModel.Customer.MatchCorpPolicyAndAduit
{
    public class CorpPolicyAndAduitChangeModel
    {
        /// <summary>
        /// 部门Id
        /// </summary>
        public int? DepartmentId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 差旅政策信息
        /// </summary>
        public List<CorpPolicyChangeModel> CorpPolicyChangeList { get; set; }

        /// <summary>
        /// 审批规则信息
        /// </summary>
        public List<CorpAduitChangeModel> CorpAduitChangeList { get; set; }
    }
}
