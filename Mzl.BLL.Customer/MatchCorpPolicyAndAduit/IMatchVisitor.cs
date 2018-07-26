using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.DomainModel.Customer.MatchCorpPolicyAndAduit;

namespace Mzl.BLL.Customer.MatchCorpPolicyAndAduit
{
    public interface IMatchVisitor
    {
        /// <summary>
        /// 针对所有临时客人的匹配规则
        /// </summary>
        /// <param name="matchBll"></param>
        /// <returns></returns>
        MatchCorpPolicyAndAduitResultModel DoMatch(AllTemporaryBll matchBll);
        /// <summary>
        /// 针对不同部门的匹配规则
        /// </summary>
        /// <param name="matchBll"></param>
        /// <returns></returns>
        MatchCorpPolicyAndAduitResultModel DoMatch(DiffDepartmentBll matchBll);
        /// <summary>
        /// 针对同一部门的匹配规则
        /// </summary>
        /// <param name="matchBll"></param>
        /// <returns></returns>
        MatchCorpPolicyAndAduitResultModel DoMatch(SameDepartmentBll matchBll);
    }
}
