using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.DomainModel.Customer.MatchCorpPolicyAndAduit;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.MatchCorpPolicyAndAduit
{
    /// <summary>
    /// 匹配差旅政策和审批规则
    /// </summary>
    public interface IMatchCorpPolicyAndAduitServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 匹配差旅政策和审批规则
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MatchCorpPolicyAndAduitResultModel Match(MatchCorpPolicyAndAduitModel model);
    }
}
