using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.IBLL.Customer.CorpAduit;

namespace Mzl.BLL.Customer.CorpAduit.SubmitCorpAduitOrder
{
    /// <summary>
    /// 送审
    /// </summary>
    public class SubmitAduitVisitor : ISubmitAduitVisitor
    {
        private readonly ICorpAduitBll _corpAduitBll;

        public BaseDealAduitResultModel SubmitResult { get; private set; }

        public SubmitAduitVisitor(ICorpAduitBll corpAduitBll)
        {
            _corpAduitBll = corpAduitBll;
        }

        /// <summary>
        /// 没有审批规则情况
        /// </summary>
        /// <param name="aduitBll"></param>
        /// <returns></returns>
        public bool DoSubmit(NoRuleSubmitAduitBll aduitBll)
        {
            return true;
        }

        /// <summary>
        /// 当前审批规则为无需审批
        /// </summary>
        /// <param name="aduitBll"></param>
        /// <returns></returns>
        public bool DoSubmit(NoNeedSubmitAduitBll aduitBll)
        {
            return true;
        }

        /// <summary>
        /// 符合差旅政策审批
        /// </summary>
        /// <param name="aduitBll"></param>
        /// <returns></returns>
        public bool DoSubmit(AccordPolicySubmitAduitBll aduitBll)
        {
            return Submit(aduitBll.SubmitInfo);
        }

        /// <summary>
        /// 违背差旅政策审批
        /// </summary>
        /// <param name="aduitBll"></param>
        /// <returns></returns>
        public bool DoSubmit(ViolatePolicySubmitAduitBll aduitBll)
        {
            return Submit(aduitBll.SubmitInfo);
        }

        /// <summary>
        /// 需要审批
        /// </summary>
        /// <param name="aduitBll"></param>
        /// <returns></returns>
        public bool DoSubmit(NeedSubmitAduitBll aduitBll)
        {
            return Submit(aduitBll.SubmitInfo);
        }

        private bool Submit(SubmitCorpAduitOrderModel submit)
        {
            if (submit.AduitConfigId.HasValue)
            {
                //提交审批单
                int aduitOrderId = _corpAduitBll.SubmitAduit(new SubmitAduitModel()
                {
                    OrderInfoList = submit.OrderInfoList,
                    AduitConfigId = submit.AduitConfigId.Value,
                    DealSource = submit.Source,
                    SubmitCid = submit.SubmitCid,
                    SubmitOid = submit.SubmitOid,
                    IsViolatePolicy = submit.IsViolatePolicy ?? false,
                    OrderType = submit.OrderType
                });
                if (aduitOrderId > 0)
                {
                    //送审
                    SubmitResult = _corpAduitBll.DeliveAduit(new DeliveAduitModel
                    {
                        DealCid = submit.SubmitCid,
                        DealOid = submit.SubmitOid,
                        AduitOrderId = aduitOrderId,
                        DealSource = submit.Source
                    });
                }
                return true;
            }
            return false;
        }

    }
}
