using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpAduit;

namespace Mzl.BLL.Customer.CorpAduit.SubmitCorpAduitOrder
{
    public interface ISubmitAduitVisitor
    {
        /// <summary>
        /// 送审结果
        /// </summary>
        BaseDealAduitResultModel SubmitResult { get;  }
        /// <summary>
        /// 没有审批规则情况
        /// </summary>
        /// <param name="aduitBll"></param>
        /// <returns></returns>
        bool DoSubmit(NoRuleSubmitAduitBll aduitBll);

        /// <summary>
        /// 当前审批规则为无需审批
        /// </summary>
        /// <param name="aduitBll"></param>
        /// <returns></returns>
        bool DoSubmit(NoNeedSubmitAduitBll aduitBll);
        /// <summary>
        /// 符合差旅政策审批
        /// </summary>
        /// <param name="aduitBll"></param>
        /// <returns></returns>
        bool DoSubmit(AccordPolicySubmitAduitBll aduitBll);

        /// <summary>
        /// 违背差旅政策审批
        /// </summary>
        /// <param name="aduitBll"></param>
        /// <returns></returns>
        bool DoSubmit(ViolatePolicySubmitAduitBll aduitBll);

        /// <summary>
        /// 需要审批
        /// </summary>
        /// <param name="aduitBll"></param>
        /// <returns></returns>
        bool DoSubmit(NeedSubmitAduitBll aduitBll);
    }
}
