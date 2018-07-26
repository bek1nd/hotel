using System;
using System.Collections.Generic;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.Framework.Base;
using Mzl.IApplication.Common;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.SendAppMessage;
using Mzl.IBLL.Flight;
using Mzl.IBLL.Train;

namespace Mzl.Application.Customer
{
    internal class SendAppMessageApplication : BaseApplicationService, ISendAppMessageApplication
    {
        private readonly ISendPrintTicketMessageServiceBll _sendPrintTicketMessageServiceBll;
        private readonly ISendAuditMessageServiceBll _sendAuditMessageServiceBll;
        private readonly ISendAuditResultMessageServiceBll _sendAuditResultMessageServiceBll;
        private readonly ISendConfireAuditPriceMessageServiceBll _sendConfireAuditPriceMessageServiceBll;
        private readonly ISendRefundCustomerMessageServiceBll _sendRefundCustomerMessageServiceBll;
        private readonly IGetFltSendAppMessageContentServiceBll _getFltSendAppMessageContentServiceBll;
        private readonly IGetTraSendAppMessageContentServiceBll _getTraSendAppMessageContentServiceBll;
        private readonly IGetAduitSendAppMessageContentServiceBll _getAduitSendAppMessageContentServiceBll;
        private readonly ISendAuditOrderCancelMessageServiceBll _getAuditOrderCancelMessageServiceBll;
        private readonly ISendAuditUrgeMessageServiceBll _sendAuditUrgeMessageServiceBll;
        private readonly ISendPrintFltTicketEmailServiceBll _sendPrintFltTicketEmailServiceBll;
        private readonly ISendPrintFltTicketEmailMyServiceBLL _sendPrintFltTicketEmailMyServiceBll;
        private readonly IGetPrintFltTicketEmailMessageContentMyServiceBll _getPrintFltTicketEmailMessageContentMyServiceBll;

        public SendAppMessageApplication(ISendPrintTicketMessageServiceBll sendPrintTicketMessageServiceBll,
            ISendAuditMessageServiceBll sendAuditMessageServiceBll,
            ISendAuditResultMessageServiceBll sendAuditResultMessageServiceBll,
            ISendConfireAuditPriceMessageServiceBll sendConfireAuditPriceMessageServiceBll,
            ISendRefundCustomerMessageServiceBll sendRefundCustomerMessageServiceBll,
            IGetFltSendAppMessageContentServiceBll getFltSendAppMessageContentServiceBll,
            IGetTraSendAppMessageContentServiceBll getTraSendAppMessageContentServiceBll,
            IGetAduitSendAppMessageContentServiceBll getAduitSendAppMessageContentServiceBll,
            ISendAuditOrderCancelMessageServiceBll getAuditOrderCancelMessageServiceBll,
            ISendAuditUrgeMessageServiceBll sendAuditUrgeMessageServiceBll, ISendPrintFltTicketEmailServiceBll sendPrintFltTicketEmailServiceBll,
            ISendPrintFltTicketEmailMyServiceBLL sendPrintFltTicketEmailMyServiceBLL,
            IGetPrintFltTicketEmailMessageContentMyServiceBll getPrintFltTicketEmailMessageContentMyServiceBll
            )
        {
            _sendPrintTicketMessageServiceBll = sendPrintTicketMessageServiceBll;
            _sendAuditMessageServiceBll = sendAuditMessageServiceBll;
            _sendAuditResultMessageServiceBll = sendAuditResultMessageServiceBll;
            _sendConfireAuditPriceMessageServiceBll = sendConfireAuditPriceMessageServiceBll;
            _sendRefundCustomerMessageServiceBll = sendRefundCustomerMessageServiceBll;
            _getFltSendAppMessageContentServiceBll = getFltSendAppMessageContentServiceBll;
            _getTraSendAppMessageContentServiceBll = getTraSendAppMessageContentServiceBll;
            _getAduitSendAppMessageContentServiceBll = getAduitSendAppMessageContentServiceBll;
            _getAuditOrderCancelMessageServiceBll = getAuditOrderCancelMessageServiceBll;
            _sendAuditUrgeMessageServiceBll = sendAuditUrgeMessageServiceBll;
            _sendPrintFltTicketEmailServiceBll = sendPrintFltTicketEmailServiceBll;
            _sendPrintFltTicketEmailMyServiceBll = sendPrintFltTicketEmailMyServiceBLL;
            _getPrintFltTicketEmailMessageContentMyServiceBll = getPrintFltTicketEmailMessageContentMyServiceBll;
        }

        public void SendMessage()
        {
            try
            {
                //机票出票Email
                List<SendAppMessageModel> models0 = _sendPrintFltTicketEmailServiceBll.Get();
                _getFltSendAppMessageContentServiceBll.GetSendEmailMessage(models0);
                _sendPrintFltTicketEmailServiceBll.Send(models0);

                //机票审批通过，发送差旅顾问进行出票Email
                //List<SendAppMessageModel> models33 = _sendAuditResultMessageServiceBll.Get();
                //if (models33 != null && models33.Count > 0)
                //{
                //    models33 = models33.FindAll(n => n.SendStatus == 0);
                //    if (models33 != null && models33.Count > 0)
                //    {
                //        models33.ForEach(n => n.SendAppMessageType = SendAppMessageTypeEnum.SendRunPrintFltTicketEmail);
                //        _getAduitSendAppMessageContentServiceBll.GetSendAppMessage(models33);
                //        models33 = models33.FindAll(n => n.IsRunOutTicket);
                //        _sendPrintFltTicketEmailServiceBll.Send(models33);
                //    }
                //}


                //不需要审批的订单，发送差旅顾问进行出票Email
                //List<SendAppMessageModel> models44 = _sendPrintFltTicketEmailMyServiceBll.Get();
                //if (models44 != null && models44.Count > 0)
                //{
                //    _getPrintFltTicketEmailMessageContentMyServiceBll.GetSendAppMessage(models44);
                //    _sendPrintFltTicketEmailMyServiceBll.Send(models44);
                //}

            }
            catch (Exception)
            {

                throw;
            }

            //出票通知
            List<SendAppMessageModel > models1= _sendPrintTicketMessageServiceBll.Get();
            _getFltSendAppMessageContentServiceBll.GetSendAppMessage(models1);
            _getTraSendAppMessageContentServiceBll.GetSendAppMessage(models1);
            _sendPrintTicketMessageServiceBll.Send(models1);

            //审批通知
            List<SendAppMessageModel> models2 = _sendAuditMessageServiceBll.Get();
            _getAduitSendAppMessageContentServiceBll.GetSendAppMessage(models2);
            _sendAuditMessageServiceBll.Send(models2);

            //审批结果通知
            List<SendAppMessageModel> models3 = _sendAuditResultMessageServiceBll.Get();
            _getAduitSendAppMessageContentServiceBll.GetSendAppMessage(models3);
            _sendAuditResultMessageServiceBll.Send(models3);

            //审批过期通知
            List<SendAppMessageModel> models6 = _getAuditOrderCancelMessageServiceBll.Get();
            _getAduitSendAppMessageContentServiceBll.GetSendAppMessage(models6);
            _getAuditOrderCancelMessageServiceBll.Send(models6);

            //退改签申请核价通知
            List<SendAppMessageModel> models4 = _sendConfireAuditPriceMessageServiceBll.Get();
            _getFltSendAppMessageContentServiceBll.GetSendAppMessage(models4);
            _sendConfireAuditPriceMessageServiceBll.Send(models4);

            //退客户通知
            List<SendAppMessageModel> models5 = _sendRefundCustomerMessageServiceBll.Get();
            _getFltSendAppMessageContentServiceBll.GetSendAppMessage(models5);
            _getTraSendAppMessageContentServiceBll.GetSendAppMessage(models5);
            _sendRefundCustomerMessageServiceBll.Send(models5);

            //待审批催促通知，不需要内容组装，直接发送（催促内容是获取的第一次发送内容）
            List<SendAppMessageModel> models7 = _sendAuditUrgeMessageServiceBll.Get();
            _sendAuditUrgeMessageServiceBll.Send(models7);
        }
    }
}
