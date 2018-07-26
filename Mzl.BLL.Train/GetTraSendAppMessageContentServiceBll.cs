using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.EntityModel.Flight;
using Mzl.IBLL.Train;
using Mzl.Framework.Base;
using Mzl.IDAL.Train;
using Mzl.EntityModel.Train.Order;

namespace Mzl.BLL.Train
{
    internal class GetTraSendAppMessageContentServiceBll: BaseServiceBll,IGetTraSendAppMessageContentServiceBll
    {
        private readonly ITraOrderDal _traOrderDal;
        private readonly ITraModOrderDal _traModOrderDal;

        public GetTraSendAppMessageContentServiceBll(ITraOrderDal traOrderDal, ITraModOrderDal traModOrderDal)
        {
            _traOrderDal = traOrderDal;
            _traModOrderDal = traModOrderDal;
        }

        public void GetSendAppMessage(List<SendAppMessageModel> sendAppMessageModels)
        {
            foreach (SendAppMessageModel sendAppMessageModel in sendAppMessageModels)
            {
                GetTraPrintTicketMessage(sendAppMessageModel);
                GetTraModPrintTicketMessage(sendAppMessageModel);
                GetTraRefundedCustomerMessage(sendAppMessageModel);
            }
        }

        #region 出票通知
        /// <summary>
        /// 获取火车出票推送内容
        /// </summary>
        /// <returns></returns>
        private void GetTraPrintTicketMessage(SendAppMessageModel sendAppMessageModel)
        {
            if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.Tra &&
                sendAppMessageModel.SendType == SendAppMessageTypeEnum.PrintTicketNotice)
            {
                TraOrderEntity traOrderEntity = _traOrderDal.Find<TraOrderEntity>(sendAppMessageModel.OrderId);
                sendAppMessageModel.SendContent = string.Format("您的火车票订单{0}已经出票，请确认", traOrderEntity.OrderId);
            }
        }
        /// <summary>
        /// 火车改签出票推送信息
        /// </summary>
        /// <returns></returns>
        private void GetTraModPrintTicketMessage(SendAppMessageModel sendAppMessageModel)
        {
            if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.TraMod &&
               sendAppMessageModel.SendType == SendAppMessageTypeEnum.PrintTicketNotice)
            {
                TraModOrderEntity traModOrderEntity = _traModOrderDal.Find<TraModOrderEntity>(sendAppMessageModel.OrderId);
                sendAppMessageModel.SendContent = string.Format("您的火车票改签订单{0}已经改签出票成功，请确认", traModOrderEntity.Coid);
            }
        }
        #endregion

        #region 退客户通知
        private void GetTraRefundedCustomerMessage(SendAppMessageModel sendAppMessageModel)
        {
            if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.TraRet &&
                sendAppMessageModel.SendType == SendAppMessageTypeEnum.RefundedCustomerNotice)
            {
                TraOrderEntity traOrderEntity = _traOrderDal.Find<TraOrderEntity>(sendAppMessageModel.OrderId);
                sendAppMessageModel.SendContent = string.Format("您的火车票退票订单{0}已经退票成功，请确认", traOrderEntity.OrderRoot+ traOrderEntity.NumberIdentity);
            }
        }
        #endregion
    }
}
