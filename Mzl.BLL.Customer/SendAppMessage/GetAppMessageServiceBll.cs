using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.EntityModel.Customer.AppClient;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.SendAppMessage;
using Mzl.IDAL.Customer.Customer;
using Mzl.Common.EnumHelper;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.EntityModel.Flight;
using Mzl.EntityModel.Train.Order;

namespace Mzl.BLL.Customer.SendAppMessage
{
    internal class GetAppMessageServiceBll : BaseServiceBll, IGetAppMessageServiceBll
    {
        private readonly ISendAppMessageDal _sendAppMessageDal;

        public GetAppMessageServiceBll(ISendAppMessageDal sendAppMessageDal)
        {
            _sendAppMessageDal = sendAppMessageDal;
        }

        public int GetUnReadMessageCount(int cid)
        {
            int type = (int)SendAppMessageTypeEnum.SendRunPrintFltTicketEmail;
            IQueryable<SendAppMessageEntity> iQueryable =
                _sendAppMessageDal.Query<SendAppMessageEntity>(
                    n =>
                        n.Cid == cid && n.SendStatus == 1 && (n.IsRead ?? 0) == 0 &&
                        !string.IsNullOrEmpty(n.SendContent) && n.SendType != type);

            iQueryable=iQueryable.Take(99);

            return iQueryable.Count();
        }

        public GetAppMessageResultModel GetUnReadMessage(GetAppMessageQueryModel query)
        {
            int type = (int)SendAppMessageTypeEnum.SendRunPrintFltTicketEmail;
            GetAppMessageResultModel resultModel = new GetAppMessageResultModel();
            IQueryable<SendAppMessageEntity> iQueryable =
                _sendAppMessageDal.Query<SendAppMessageEntity>(
                    n =>
                        n.Cid == query.Cid && n.SendStatus == 1 && !string.IsNullOrEmpty(n.SendContent) &&
                        n.SendType != type, true);

            resultModel.TotalCount = iQueryable.Count();//查询所有结果的数量

            iQueryable =
                iQueryable.OrderBy(n => n.IsRead??0).ThenByDescending(n=>n.SendLastTime).Skip(query.PageSize * (query.PageIndex - 1)).Take(query.PageSize);

            List<SendAppMessageEntity> sendAppMessageEntities = iQueryable.ToList();
            resultModel.AppMessageList =
                Mapper.Map<List<SendAppMessageEntity>, List<SendAppMessageModel>>(sendAppMessageEntities);

            if (resultModel.AppMessageList != null && resultModel.AppMessageList.Count > 0)
            {
                foreach (var sendAppMessageModel in resultModel.AppMessageList)
                {
                    if (sendAppMessageModel.OrderType== OrderSourceTypeEnum.FltMod)
                    {
                        FltModOrderEntity fltModOrderEntity =
                            base.Context
                                .Set<FltModOrderEntity>()
                                .FirstOrDefault(n => n.Rmid == sendAppMessageModel.OrderId);
                        if (fltModOrderEntity != null && fltModOrderEntity.RootRmid.HasValue)
                        {
                            sendAppMessageModel.OrderId = fltModOrderEntity.RootRmid.Value;
                        }
                    }
                    else if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.FltRet)
                    {
                        FltRefundOrderEntity fltRefundOrderEntity =
                            base.Context
                                .Set<FltRefundOrderEntity>()
                                .FirstOrDefault(n => n.RefundId == sendAppMessageModel.OrderId);
                        if (fltRefundOrderEntity != null && fltRefundOrderEntity.Rmid.HasValue)
                        {
                            sendAppMessageModel.OrderId = fltRefundOrderEntity.Rmid.Value;
                        }
                    }
                    else if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.AduitOrder)
                    {
                        if (sendAppMessageModel.SendType == SendAppMessageTypeEnum.AuditResultNotice ||
                            sendAppMessageModel.SendType == SendAppMessageTypeEnum.AuditOrderDeleteNotice)
                        {
                            CorpAduitOrderDetailEntity corpAduitOrderDetailEntity =
                                base.Context.Set<CorpAduitOrderDetailEntity>()
                                    .FirstOrDefault(n => n.AduitOrderId == sendAppMessageModel.OrderId);
                            if (corpAduitOrderDetailEntity != null)
                            {
                                sendAppMessageModel.OrderId = corpAduitOrderDetailEntity.OrderId;
                            }
                        }
                    }
                    else if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.TraRet)
                    {
                        TraOrderEntity traRetOrderEntity =
                            base.Context.Set<TraOrderEntity>()
                                .FirstOrDefault(n => n.OrderId == sendAppMessageModel.OrderId);
                        if (traRetOrderEntity != null && traRetOrderEntity.OrderRoot.HasValue)
                        {
                            sendAppMessageModel.OrderId = traRetOrderEntity.OrderRoot.Value;
                        }
                    }
                    else if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.TraMod)
                    {
                        TraModOrderEntity traModOrderEntity =
                            base.Context.Set<TraModOrderEntity>()
                                .FirstOrDefault(n => n.CorderId == sendAppMessageModel.OrderId);

                        if (traModOrderEntity != null && traModOrderEntity.OrderId.HasValue)
                        {
                            sendAppMessageModel.OrderId = traModOrderEntity.OrderId.Value;
                        }
                    }
                }
            }

            //if (query.PageIndex == 1)
            //{
            //    //获取未读信息
            //    List<SendAppMessageEntity> unReadList =
            //        _sendAppMessageDal.Query<SendAppMessageEntity>(
            //            n => n.Cid == query.Cid && n.SendStatus == 1 && (n.IsRead ?? 0) == 0, true).ToList();
            //    List<int> unReadIdList = unReadList.Select(n => n.SendId).ToList();
            //    //将未读信息设置为已读
            //    if (unReadIdList != null && unReadIdList.Count > 0)
            //    {
            //        foreach (var unReadId in unReadIdList)
            //        {
            //            _sendAppMessageDal.Update<SendAppMessageEntity>(new SendAppMessageEntity()
            //            {
            //                SendId = unReadId,
            //                IsRead = 1
            //            }, new[] {"IsRead"});
            //        }
            //    }

            //}

            return resultModel;
        }

        public bool SetRead(int sendId)
        {
            _sendAppMessageDal.Update<SendAppMessageEntity>(new SendAppMessageEntity()
            {
                SendId = sendId,
                IsRead = 1
            }, new[] { "IsRead" });

            return true;
        }

    }
}
