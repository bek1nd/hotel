using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.CorpAduit;
using Mzl.Common.Exceptions;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IBLL.Customer.Customer;
using Mzl.EntityModel.Flight;
using Mzl.DomainModel.Common.Operator;
using Mzl.IBLL.Common.Operator;
using Mzl.UIModel.Customer.CorpAduit;
using Mzl.Common.EmailHelper;

namespace Mzl.BLL.Customer.CorpAduit
{
    internal class DoAduitOrderServiceBll : BaseServiceBll, IDoAduitOrderServiceBll
    {
        private readonly ICorpAduitBll _corpAduitBll;
        private readonly IAddSendAppMessageBll _addSendAppMessageBll;
        private readonly IGetOperatorServiceBll _getOperatorServiceBll;
        public DoAduitOrderServiceBll(ICorpAduitBll corpAduitBll, IAddSendAppMessageBll addSendAppMessageBll,
             IGetOperatorServiceBll getOperatorServiceBll)
        {
            _corpAduitBll = corpAduitBll;
            _addSendAppMessageBll = addSendAppMessageBll;
            _getOperatorServiceBll = getOperatorServiceBll;
        }

        public DoAduitOrderResultModel DoAduitOrder(DoAduitOrderModel doAduit)
        {

            BaseDealAduitModel query = new BaseDealAduitModel()
            {
                DealCid = doAduit.DealCid,
                AduitOrderId = doAduit.AduitOrderId,
                DealOid = doAduit.DealOid,
                IsAgree = doAduit.IsAgree,
                DealSource = doAduit.DealSource,
                AduitReason= doAduit.AduitReason,
                CurrentFlow= doAduit.CurrentFlow
            };
            try
            {
                BaseDealAduitResultModel reuslt = _corpAduitBll.DoAduit(query);

                #region 推送app消息
                if (reuslt.IsFinished)
                {
                    _addSendAppMessageBll.AddAppMessage(new SendAppMessageModel()
                    {
                        Cid = reuslt.CreateAduitOrderCid,
                        OrderId = reuslt.AduitOrderId,
                        OrderType = OrderSourceTypeEnum.AduitOrder,
                        SendType = SendAppMessageTypeEnum.AuditResultNotice
                    });
                }
                else
                {
                    foreach (var cid in reuslt.NextFlowCidList)
                    {
                        _addSendAppMessageBll.AddAppMessage(new SendAppMessageModel()
                        {
                            Cid = cid,
                            OrderId = reuslt.AduitOrderId,
                            OrderType = OrderSourceTypeEnum.AduitOrder,
                            SendType = SendAppMessageTypeEnum.WaitAuditNotice
                        });
                    }

                }
                #endregion

                return new DoAduitOrderResultModel()
                {
                    IsSuccessed = reuslt.IsSuccessed,
                    DetailList = reuslt.DetailList,
                    CreateAduitOrderCid = reuslt.CreateAduitOrderCid,
                    IsFinished = reuslt.IsFinished
                };
            }
            catch (MojoryException ex)//捕捉到取消订单异常
            {
                if (ex.Code == MojoryApiResponseCode.AduitCancelOrder)
                {
                    //推送APP消息
                    _addSendAppMessageBll.AddAppMessage(new SendAppMessageModel()
                    {
                        Cid = ex.OtherId,
                        OrderId = query.AduitOrderId,
                        OrderType = OrderSourceTypeEnum.AduitOrder,
                        SendType = SendAppMessageTypeEnum.AuditOrderDeleteNotice
                    });
                }
                throw;
            }
           
        }
        /// <summary>
        /// 针对订单审批后发邮件提醒
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public BaseDealAduitResultDetailModel GetCorpAduitOrderDetailmail(DoAduitOrderRequestViewModel request)
        {
            
            List<BaseDealAduitResultDetailModel> dorder = _corpAduitBll.GetCorpAduitOrderDetail(request.AduitOrderId);
            BaseDealAduitResultDetailModel detailorder = new BaseDealAduitResultDetailModel();
            if (dorder.Count > 0)
            {
                string type = dorder[0].OrderSourceType.ToString();
                bool isFly = false;
                string orderOid = "0";
                switch (type)
                {
                    //飞机正单
                    case "Flt":
                        detailorder.OrderId = dorder[0].OrderId;
                        FltOrderEntity orderentity = base.Context.Set<FltOrderEntity>().Find(detailorder.OrderId);
                        orderOid = orderentity.CreateOid;
                        isFly = true;
                        break;
                    //飞机改签
                    case "FltModApply":
                        detailorder.OrderId = dorder[0].OrderId;
                        FltRetModApplyEntity FltRetentity = base.Context.Set<FltRetModApplyEntity>().Find(detailorder.OrderId);
                        detailorder.OrderId = FltRetentity.OrderId;
                        orderOid = FltRetentity.CreateOid;
                        isFly = true;
                        break;
                    //飞机退票
                    case "FltRetApply":
                        detailorder.OrderId = dorder[0].OrderId;
                        FltRetModApplyEntity Retentity = base.Context.Set<FltRetModApplyEntity>().Find(detailorder.OrderId);
                        detailorder.OrderId = Retentity.OrderId;
                        orderOid = Retentity.CreateOid;
                        isFly = true;
                        break;
                }
                OperatorModel operatorModel = _getOperatorServiceBll.GetOperatorByOid(orderOid);
                string mail = operatorModel.Email;
                string approve = "";
                if (!request.IsAgree)
                {
                    approve = "审批未通过";
                }
                else
                {
                    approve = "审批已通过";
                }
                StringBuilder mailContent = new StringBuilder();
                mailContent.Append("<b>客户审批提醒：<b/>");
                mailContent.Append("<br/>");
                mailContent.Append("客户已经审批了订单，订单编号:" + detailorder.OrderId.ToString() + "，"+ approve + "。");
                mailContent.Append("<br/>");
                mailContent.Append("<b>下单时间:" + DateTime.Now + ",请及时关注~<b/>");
                //发送邮件
                if(!string.IsNullOrEmpty(mail)&& isFly)
                {
                    bool flag = EmailHelper.SendEmail("", "客户审批提醒", null, null, mailContent.ToString(), mail);
                }
               
            }
            return detailorder;
        }
    }
}
