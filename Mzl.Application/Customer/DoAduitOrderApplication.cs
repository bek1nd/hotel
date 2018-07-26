using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.Exceptions;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.DomainModel.Train.Order;
using Mzl.DomainModel.Train.Server;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IBLL.Flight;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.IBLL.Train.Order;
using Mzl.IBLL.Train.RequestInterface;
using Mzl.UIModel.Customer.CorpAduit;


namespace Mzl.Application.Customer
{
    internal class DoAduitOrderApplication : BaseApplicationService, IDoAduitOrderApplication
    {
        private readonly IDoAduitOrderServiceBll _doAduitOrderServiceBll;
        private readonly ICancelFltOrderServiceBll _cancelFltOrderServiceBll;
        private readonly ICancelRetModOrderServiceBll _cancelRetModOrderServiceBll;
        private readonly ICancelTraOrderServiceBll _cancelTraOrderServiceBll;
        private readonly IRequestCancelOrderServiceBll _requestCancelOrderServiceBll;
        private readonly IRequestPrintTicketServiceBll _requestPrintTicketServiceBll;


        public DoAduitOrderApplication(IDoAduitOrderServiceBll doAduitOrderServiceBll,
            ICancelFltOrderServiceBll cancelFltOrderServiceBll,
            ICancelRetModOrderServiceBll cancelRetModOrderServiceBll,
            ICancelTraOrderServiceBll cancelTraOrderServiceBll,
             IRequestCancelOrderServiceBll requestCancelOrderServiceBll,
             IRequestPrintTicketServiceBll requestPrintTicketServiceBll
            )
        {
            _doAduitOrderServiceBll = doAduitOrderServiceBll;
            _cancelFltOrderServiceBll = cancelFltOrderServiceBll;
            _cancelRetModOrderServiceBll = cancelRetModOrderServiceBll;
            _cancelTraOrderServiceBll = cancelTraOrderServiceBll;
            _requestCancelOrderServiceBll = requestCancelOrderServiceBll;
            _requestPrintTicketServiceBll = requestPrintTicketServiceBll;
        }

        public DoAduitOrderResponseViewModel DoAduitOrder(DoAduitOrderRequestViewModel request)
        {
            DoAduitOrderResultModel resultModel = null;
            List<int> traOrderIdList = new List<int>();
       
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    resultModel = _doAduitOrderServiceBll.DoAduitOrder(new DoAduitOrderModel()
                    {
                        AduitOrderId = request.AduitOrderId,
                        IsAgree = request.IsAgree,
                        CurrentFlow = request.CurrentFlow,
                        DealCid = request.Cid,
                        DealOid = request.Oid,
                        AduitReason = request.AduitReason,
                        DealSource = request.OrderSource
                    });
                    if (resultModel.IsSuccessed)
                    {
                        if (!request.IsAgree)
                        {
                            #region 审批不通过，则取消对应的订单

                            foreach (var detail in resultModel.DetailList)
                            {
                                if (detail.OrderSourceType == OrderSourceTypeEnum.Flt)
                                {
                                    _cancelFltOrderServiceBll.CancelOnlineCorpOrder(detail.OrderId,
                                        resultModel.CreateAduitOrderCid, "审批不通过");
                                }
                                if (detail.OrderSourceType == OrderSourceTypeEnum.FltModApply ||
                                    detail.OrderSourceType == OrderSourceTypeEnum.FltRetApply)
                                {
                                    _cancelRetModOrderServiceBll.CancelFltRetModApply(detail.OrderId);
                                }
                                if (detail.OrderSourceType == OrderSourceTypeEnum.Tra)
                                {
                                    traOrderIdList.Add(detail.OrderId);
                                    //取消火车订单
                                    _cancelTraOrderServiceBll.CancelTraOrder(new CancelTraOrderModel()
                                    {
                                        OrderId = detail.OrderId,
                                        CancelReason = "审批不通过，取消订单"
                                    });
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            if (resultModel.IsFinished)
                            {
                                //审批通过，并且当前审批流程已经结束，将审批通过的火车订单加入list
                                traOrderIdList.AddRange(from detail in resultModel.DetailList
                                    where detail.OrderSourceType == OrderSourceTypeEnum.Tra
                                    select detail.OrderId);
                            }
                        }
                    }

                    transaction.Commit();
                }
                catch (MojoryException ex)
                {
                    if (ex.Code == MojoryApiResponseCode.AduitCancelOrder)//如果是返回这种类型的异常，还是提交事务，但是异常抛出
                    {
                        transaction.Commit();
                        throw;
                    }

                    transaction.Rollback();
                    throw;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            foreach (var orderId in traOrderIdList)
            {
                if (!request.IsAgree)
                {
                    //取消火车订单后，访问第三方接口取消对应的订单，这里以后可以用mq替换
                    _requestCancelOrderServiceBll.RequestCancelOrder(orderId);
                }
                else
                {
                    //访问第三方出票接口，进行出票，这里以后可以用mq替换
                    TraOrderConfirmResponseModel confirmResponseModel=_requestPrintTicketServiceBll.RequestPrintTicket(orderId);
                    if (confirmResponseModel != null && !confirmResponseModel.success)
                    {
                        throw new Exception("审批通过，但是火车出票已过时限，请转线下处理");
                    }
                }
            }
            //2.发送提醒邮件
            _doAduitOrderServiceBll.GetCorpAduitOrderDetailmail(request);
            return new DoAduitOrderResponseViewModel()
            {
                IsSuccessed = resultModel.IsSuccessed,
                IsFinished = resultModel.IsFinished
            };
        }
    }
}
