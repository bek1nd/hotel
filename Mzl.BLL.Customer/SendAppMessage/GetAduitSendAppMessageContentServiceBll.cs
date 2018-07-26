using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.ConfigHelper;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.CorpAduit;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.EntityModel.Flight;
using Mzl.EntityModel.Operator;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.SendAppMessage;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.SendAppMessage
{
    internal class GetAduitSendAppMessageContentServiceBll: BaseServiceBll,IGetAduitSendAppMessageContentServiceBll
    {
        private readonly ICorpAduitOrderDal _corpAduitOrderDal;
        private readonly ICorpAduitOrderDetailDal _corpAduitOrderDetailDal;

        public GetAduitSendAppMessageContentServiceBll(ICorpAduitOrderDal corpAduitOrderDal,
            ICorpAduitOrderDetailDal corpAduitOrderDetailDal)
        {
            _corpAduitOrderDal = corpAduitOrderDal;
            _corpAduitOrderDetailDal = corpAduitOrderDetailDal;
        }

        public void GetSendAppMessage(List<SendAppMessageModel> sendAppMessageModels)
        {

            foreach (SendAppMessageModel sendAppMessageModel in sendAppMessageModels)
            {
                GetWaitAuditMessage(sendAppMessageModel);
                GetAuditResultMessage(sendAppMessageModel);
            }

        }


        /// <summary>
        /// 待审批信息
        /// </summary>
        /// <param name="sendAppMessageModel"></param>
        private void GetWaitAuditMessage(SendAppMessageModel sendAppMessageModel)
        {
            if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.AduitOrder &&
                sendAppMessageModel.SendType == SendAppMessageTypeEnum.WaitAuditNotice)
            {
                List<CorpAduitOrderDetailEntity> corpAduitOrderDetailEntities =
                    _corpAduitOrderDetailDal.Query<CorpAduitOrderDetailEntity>(
                        n => n.AduitOrderId == sendAppMessageModel.OrderId, true).ToList();
                if (corpAduitOrderDetailEntities == null || corpAduitOrderDetailEntities.Count == 0)
                    return;
                string orderType = corpAduitOrderDetailEntities[0].OrderType.ValueToDescription<OrderSourceTypeEnum>();
                string orderId = corpAduitOrderDetailEntities[0].OrderId.ToString();
                if (corpAduitOrderDetailEntities[0].OrderType == (int) OrderSourceTypeEnum.FltModApply ||
                    corpAduitOrderDetailEntities[0].OrderType == (int) OrderSourceTypeEnum.FltRetApply)
                {
                    FltRetModApplyEntity fltRetModApplyEntity =
                        base.Context.Set<FltRetModApplyEntity>().Find(corpAduitOrderDetailEntities[0].OrderId);
                    orderId = fltRetModApplyEntity?.OrderId.ToString();
                }

                sendAppMessageModel.SendContent = string.Format("{0}{1}{2}需要您进行审批", orderType,
                    (orderType.Contains("申请") ? "" : "订单"), orderId);
            }
        }
        /// <summary>
        /// 审批结果通知
        /// </summary>
        /// <param name="sendAppMessageModel"></param>
        private void GetAuditResultMessage(SendAppMessageModel sendAppMessageModel)
        {
            if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.AduitOrder)
            {
                CorpAduitOrderEntity corpAduitOrderEntity =
                    _corpAduitOrderDal.Find<CorpAduitOrderEntity>(sendAppMessageModel.OrderId);

                if (corpAduitOrderEntity == null)
                    return;

                List<CorpAduitOrderDetailEntity> corpAduitOrderDetailEntities =
                  _corpAduitOrderDetailDal.Query<CorpAduitOrderDetailEntity>(
                      n => n.AduitOrderId == sendAppMessageModel.OrderId, true).ToList();
                if (corpAduitOrderDetailEntities == null || corpAduitOrderDetailEntities.Count == 0)
                    return;

                string orderType = corpAduitOrderDetailEntities[0].OrderType.ValueToDescription<OrderSourceTypeEnum>();
                string orderId = corpAduitOrderDetailEntities[0].OrderId.ToString();
                if (sendAppMessageModel.SendType == SendAppMessageTypeEnum.AuditResultNotice)
                {
                    if (corpAduitOrderEntity.Status == (int) CorpAduitOrderStatusEnum.J)
                    {
                        sendAppMessageModel.SendContent = string.Format("您的{0}{1}{2}被审批人驳回，请您确认", orderType,
                            (orderType.Contains("申请") ? "" : "订单"), orderId);
                    }
                    else if (corpAduitOrderEntity.Status == (int) CorpAduitOrderStatusEnum.F)
                    {
                        sendAppMessageModel.SendContent = string.Format("您的{0}{1}{2}已完成审批，准备为您{3}", orderType,
                            (orderType.Contains("申请") ? "" : "订单"), orderId, (orderType.Contains("退票") ? "退票" : "出票"));

                        if (!orderType.Contains("退票") && orderType.Contains("机票")&&
                            sendAppMessageModel.SendAppMessageType == SendAppMessageTypeEnum.SendRunPrintFltTicketEmail)
                        {
                            FltOrderEntity fltOrderEntity =
                                base.Context.Set<FltOrderEntity>().Find(Convert.ToInt32(orderId));
                            if (fltOrderEntity != null)
                            {
                                string oid = string.IsNullOrEmpty(fltOrderEntity.CreateOid)
                                    ? "sys"
                                    : fltOrderEntity.CreateOid.ToUpper();

                                OperatorEntity operatorEntity =
                                    base.Context.Set<OperatorEntity>().Where(n =>
                                        n.Oid.ToUpper() == oid).FirstOrDefault();

                                sendAppMessageModel.IsRunOutTicket = true;
                                sendAppMessageModel.Email = operatorEntity?.Email;

                                string isServer = AppSettingsHelper.GetAppSettings(AppSettingsEnum.IsServer);
                                string url = string.Format(
                                    "http://192.168.1.117/orderprocess/Flt_order.asp?orderid={0}",
                                    orderId);
                                if (isServer == "T")
                                {
                                    url = string.Format("http://192.168.1.188/orderprocess/Flt_order.asp?orderid={0}",
                                        orderId);
                                }
                                sendAppMessageModel.SendContent = string.Format("订单<a href='{0}'>{1}</a>已审核，请出票", url,
                                    orderId);
                                sendAppMessageModel.EmailTitle = string.Format("订单{0}已审核，请出票", orderId);
                            }
                        }

                    }
                    else if (corpAduitOrderEntity.Status > (int) CorpAduitOrderStatusEnum.N)
                    {
                        sendAppMessageModel.SendContent = string.Format("您的{0}{1}{2}已通过审批，待下级为您继续审批", orderType,
                            (orderType.Contains("申请") ? "" : "订单"), orderId);
                    }
                }
                else if (sendAppMessageModel.SendType == SendAppMessageTypeEnum.AuditOrderDeleteNotice)
                {
                    sendAppMessageModel.SendContent = string.Format("您的{0}{1}{2}由于已经取消，所以审批自动过期", orderType,
                        (orderType.Contains("申请") ? "" : "订单"), orderId);
                }
            }
        }

    }
}
