using System;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IBLL.Customer.CorpAduit.SubmitCorpAduitOrder;
using Mzl.IDAL.Customer.Corporation;
using Mzl.Common.EnumHelper.CorpAduit;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.IBLL.Customer.Customer;

namespace Mzl.BLL.Customer.CorpAduit.SubmitCorpAduitOrder
{
    public class SubmitCorpAduitOrderServiceBll : BaseServiceBll, ISubmitCorpAduitOrderServiceBll
    {
      
        private readonly ICorpAduitConfigDal _corpAduitConfigDal;
        private readonly ICorpAduitBll _corpAduitBll;
        private readonly IAddSendAppMessageBll _addSendAppMessageBll;

        public SubmitCorpAduitOrderServiceBll(ICorpAduitConfigDal corpAduitConfigDal, ICorpAduitBll corpAduitBll,
            IAddSendAppMessageBll addSendAppMessageBll)
        {
            _corpAduitConfigDal = corpAduitConfigDal;
            _corpAduitBll = corpAduitBll;
            _addSendAppMessageBll = addSendAppMessageBll;
        }

        public bool IsSendAduit { get; private set; }

        public bool Submit(SubmitCorpAduitOrderModel submitModel)
        {
            /**
             * 送审分为以下情况
             * 1 审批规则为无需审批
             * 2 审批规则为符合差旅政策情况
             * 3 审批规则为违背差旅政策
             * 4 没有审批规则             
             * */
            BaseSubmitAduiBll submitAduiBll = null;

            if (submitModel.AduitConfigId.HasValue)
            {
                #region 存在审批规则
                CorpAduitConfigEntity aduitConfigEntity =
                            _corpAduitConfigDal.Find<CorpAduitConfigEntity>(submitModel.AduitConfigId.Value);
                if (aduitConfigEntity == null)
                    throw new Exception("未找到对应的审批规则");

                if (aduitConfigEntity.IsNeedAduit == 0)
                {
                    //1.当前审批规则为无需审批
                    submitAduiBll = new NoNeedSubmitAduitBll(submitModel);
                    
                }
                else
                {
                    #region 当前审批规则为需要审批
                    if (!submitModel.PolicyId.HasValue)
                    {
                        throw new Exception("当前送审条件需要差旅政策Id");
                    }

                    if (!submitModel.IsViolatePolicy.HasValue)
                        throw new Exception("缺少是否违反差旅政策判断");

                    submitAduiBll = new NeedSubmitAduitBll(submitModel);
                    #endregion
                } 
                #endregion
            }
            else
            {
                //4.没有审批规则情况
                submitAduiBll = new NoRuleSubmitAduitBll(submitModel);
                
            }

            ISubmitAduitVisitor submitAduitVisitor = new SubmitAduitVisitor(_corpAduitBll);
            bool flag= submitAduiBll.DoSubmit(submitAduitVisitor);

            #region 推送app消息

            if (submitAduitVisitor.SubmitResult != null && submitAduitVisitor.SubmitResult.IsSuccessed &&
                !submitAduitVisitor.SubmitResult.IsFinished && submitAduitVisitor.SubmitResult.NextFlowCidList != null &&
                submitAduitVisitor.SubmitResult.NextFlowCidList.Count > 0)
            {
                IsSendAduit = true;
                foreach (var cid in submitAduitVisitor.SubmitResult.NextFlowCidList)
                {
                    _addSendAppMessageBll.AddAppMessage(new SendAppMessageModel()
                    {
                        Cid = cid,
                        OrderId = submitAduitVisitor.SubmitResult.AduitOrderId,
                        OrderType = OrderSourceTypeEnum.AduitOrder,
                        SendType = SendAppMessageTypeEnum.WaitAuditNotice
                    });
                }
            }
            else
            {
                //新增提醒出票邮件推送
                //AddNeSendMessage(submitModel);
            }

            #endregion

            return flag;
        }
        /// <summary>
        /// 新增消息推送 当订单不需要进行审批时
        /// </summary>
        /// <param name="submitModel"></param>
        private void AddNeSendMessage(SubmitCorpAduitOrderModel submitModel)
        {
            foreach (var item in submitModel.OrderInfoList)
            {
                _addSendAppMessageBll.AddAppMessage(new SendAppMessageModel()
                {
                    Cid = submitModel.SubmitCid,
                    OrderId = item.OrderId,
                    OrderType = item.OrderType,
                    SendType = SendAppMessageTypeEnum.SendRunPrintFltTicketEmail
                });
            }
        }
    }
}
