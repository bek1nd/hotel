using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.MatchCorpPolicyAndAduit
{
    public class CorpPolicyAndAduitChangeProjectModel
    {
        /// <summary>
        /// 项目成本中心名称Id
        /// </summary>
        public int? ProjectId { get; set; }
        /// <summary>
        /// 项目成本中心名称
        /// </summary>
        public string ProjectName { get; set; }
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
