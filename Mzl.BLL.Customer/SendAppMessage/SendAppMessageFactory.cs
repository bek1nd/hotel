using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.EntityModel.Customer.AppClient;
using Mzl.IBLL.Customer.SendAppMessage;
using Mzl.IDAL.Customer.Customer;

namespace Mzl.BLL.Customer.SendAppMessage
{
    public class SendAppMessageFactory
    {
        private readonly ISendAppMessageDal _sendAppMessageDal;
        private readonly ISendAppMessageBll _sendAppMessageBll;
        private readonly ICustomerAppClientIdDal _customerAppClientIdDal;
   
        public SendAppMessageFactory(ISendAppMessageDal sendAppMessageDal,
           ISendAppMessageBll sendAppMessageBll, ICustomerAppClientIdDal customerAppClientIdDal)
        {
            _sendAppMessageDal = sendAppMessageDal;
            _sendAppMessageBll = sendAppMessageBll;
            _customerAppClientIdDal = customerAppClientIdDal;
        }
        /// <summary>
        /// 获取待推送信息
        /// </summary>
        /// <param name="sendAppMessageType"></param>
        /// <returns></returns>
        public List<SendAppMessageModel> GetSendAppMessage(SendAppMessageTypeEnum sendAppMessageType)
        {
            List<SendAppMessageEntity> waitSendList = null;
            if (sendAppMessageType == SendAppMessageTypeEnum.AuditUrgeNotice)
            {
                waitSendList = _sendAppMessageDal.GetAuditUrgeMessage<SendAppMessageEntity>();
            }
            else if (sendAppMessageType == SendAppMessageTypeEnum.SendPrintFltTicketEmail)
            {
                waitSendList =
                    _sendAppMessageDal.Query<SendAppMessageEntity>(
                        n =>
                            n.SendStatus == 0 &&
                            n.SendType == (int) SendAppMessageTypeEnum.PrintTicketNotice &&
                            n.OrderType.ToUpper() == "FLT", true)
                        .ToList();
            }
            else
            {
                waitSendList =
                    _sendAppMessageDal.Query<SendAppMessageEntity>(
                        n =>
                            (n.SendStatus == 0 || n.SendStatus == -1) &&
                            n.SendType == (int) sendAppMessageType, true)
                        .ToList(); //待推送信息
            }

            if (waitSendList == null || waitSendList.Count == 0)
                return new List<SendAppMessageModel>();

            List<SendAppMessageModel> sendAppMessageModels =
                Mapper.Map<List<SendAppMessageEntity>, List<SendAppMessageModel>>(waitSendList);
            return sendAppMessageModels;
        }
        /// <summary>
        /// 发送待推送信息
        /// </summary>
        /// <param name="sendAppMessageModels"></param>
        /// <param name="sendAppMessageType"></param>
        public void SendAppMessage(List<SendAppMessageModel> sendAppMessageModels, SendAppMessageTypeEnum sendAppMessageType)
        {
            if (sendAppMessageModels == null || sendAppMessageModels.Count == 0)
                return;
            List<int> cidList = sendAppMessageModels.Select(n => n.Cid).ToList();
            List<CustomerAppClientIdEntity> customerAppClientIdEntities =
                _customerAppClientIdDal.Query<CustomerAppClientIdEntity>(n => cidList.Contains(n.Cid), true).ToList();

            foreach (SendAppMessageModel waitSend in sendAppMessageModels)
            {
                SendAppMessageEntity entity = new SendAppMessageEntity();
                entity.SendId = waitSend.SendId;
                entity.SendCount = waitSend.SendCount + 1;
                if (!waitSend.SendFirstTime.HasValue)
                    entity.SendFirstTime = DateTime.Now;
                else
                    entity.SendFirstTime = waitSend.SendFirstTime;
                entity.SendLastTime = DateTime.Now;
                CustomerAppClientIdEntity customerAppClientIdEntity = customerAppClientIdEntities.Find(n => n.Cid == waitSend.Cid);
                entity.ClientId = customerAppClientIdEntity?.ClientId;
                if (waitSend.SendCount <= 10&&!string.IsNullOrEmpty(waitSend.SendContent))//发送记录少于10次
                {
                    if (!string.IsNullOrEmpty(entity.ClientId))
                    {
                        #region 推送app消息

                        string message = waitSend.SendContent;
                        if (sendAppMessageType != SendAppMessageTypeEnum.AuditUrgeNotice)
                        {
                            message = string.Format("message={0}&cid={1}&sendType={2}&id={3}&orderType={4}",
                                waitSend.SendContent,
                                waitSend.Cid, (int) waitSend.SendType, waitSend.OrderId, (int) waitSend.OrderType);
                        }

                        SendAppContentModel content = new SendAppContentModel();
                        content.ClientId = entity.ClientId;
                        content.ClientType = customerAppClientIdEntity?.ClientType;
                        content.Content = message;
                        content.Title = waitSend.SendType.ToDescription();
                        content.Text = waitSend.SendContent;
                        if (sendAppMessageType == SendAppMessageTypeEnum.AuditUrgeNotice &&
                            !string.IsNullOrEmpty(message)&& message.Contains("&"))
                        {
                            content.Text = message.Split('&')[0].Replace("message=", "");
                        }
                        SendAppMessageResultModel resultModel = new SendAppMessageResultModel();
                        try
                        {
                            resultModel = _sendAppMessageBll.SendAppMessage(content);
                            entity.SendContent = content.Content;
                            entity.SendResult = resultModel.ResultInfo;
                            if (resultModel.Result.ToLower() == "ok")
                            {
                                entity.SendStatus = 1;
                            }
                            else
                            {
                                entity.SendStatus = -1;
                            }
                        }
                        catch (Exception ex)
                        {
                            entity.SendResult = ex.Message;
                            entity.SendStatus = -2;
                        }

                        #endregion
                    }
                    else
                    {
                        entity.SendStatus = -3;
                        entity.SendResult = "没有找到对应的设备Id";
                    }
                }
                else
                {
                    entity.SendStatus = -4;
                    entity.SendResult = "已经超过10次，不再发送";
                }

                _sendAppMessageDal.Update(entity, new string[] { "SendCount", "SendFirstTime", "SendLastTime", "ClientId", "SendContent", "SendResult", "SendStatus" });

            }
        }
        /// <summary>
        /// 修改已经推送过的消息的状态
        /// </summary>
        /// <param name="sendAppMessageModels"></param>
        public void SendAppMessageStatuAll(List<SendAppMessageModel> sendAppMessageModels)
        {
            foreach (var item in sendAppMessageModels)
            {
                SendAppMessageEntity entity = new SendAppMessageEntity();
                entity.SendId = item.SendId;
                entity.SendStatus = 1;
                entity.SendLastTime = DateTime.Now;
                entity.SendContent = item.SendContent;
                _sendAppMessageDal.Update(entity, new string[] {  "SendFirstTime", "SendLastTime", "SendContent", "SendStatus" });
            }
        }



    }
}
