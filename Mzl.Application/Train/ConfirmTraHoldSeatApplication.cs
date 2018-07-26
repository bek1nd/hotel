using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.DomainModel.Train.Order;
using Mzl.DomainModel.Train.Server;
using Mzl.Framework.Base;
using Mzl.IApplication.Train;
using Mzl.IBLL.Customer.CorpAduit.SubmitCorpAduitOrder;
using Mzl.IBLL.Train.Order;
using Mzl.IBLL.Train.RequestInterface;
using Mzl.UIModel.Train.Order;

namespace Mzl.Application.Train
{
    internal class ConfirmTraHoldSeatApplication : BaseApplicationService, IConfirmTraHoldSeatApplication
    {
        private readonly IRequestPrintTicketServiceBll _requestPrintTicketServiceBll;
        private readonly ICancelTraOrderServiceBll _cancelTraOrderServiceBll;
        private readonly IRequestCancelOrderServiceBll _requestCancelOrderServiceBll;
        private readonly IGetTraOrderServiceBll _getTraOrderServiceBll;
        private readonly ISubmitCorpAduitOrderServiceBll _submitCorpAduitOrderServiceBll;//送审服务
         

        public ConfirmTraHoldSeatApplication(IRequestPrintTicketServiceBll requestPrintTicketServiceBll, 
            IRequestCancelOrderServiceBll requestCancelOrderServiceBll, 
            ISubmitCorpAduitOrderServiceBll submitCorpAduitOrderServiceBll,
            IGetTraOrderServiceBll getTraOrderServiceBll, ICancelTraOrderServiceBll cancelTraOrderServiceBll)
        {
            _requestPrintTicketServiceBll = requestPrintTicketServiceBll;
            _requestCancelOrderServiceBll = requestCancelOrderServiceBll;
            _submitCorpAduitOrderServiceBll = submitCorpAduitOrderServiceBll;
            _getTraOrderServiceBll = getTraOrderServiceBll;
            _cancelTraOrderServiceBll = cancelTraOrderServiceBll;
        }

        public ConfirmTraHoldSeatResponseViewModel ConfirmTraHoldSeat(ConfirmTraHoldSeatRequestViewModel request)
        {
            if (request.IsAgree)//同意占位结果
            {
              
                TraOrderInfoModel traOrderInfoModel = _getTraOrderServiceBll.GetTraOrderByOrderId(request.OrderId);
                #region 送审
                SubmitCorpAduitOrderModel submitCorpAduitOrder = new SubmitCorpAduitOrderModel()
                {
                    OrderInfoList = new List<SubmitCorpAduitOrderDetailModel>()
                        {
                            new SubmitCorpAduitOrderDetailModel()
                            {
                                OrderId = request.OrderId,
                                OrderType = OrderSourceTypeEnum.Tra
                            }
                        },
                    PolicyId = traOrderInfoModel?.Order?.CorpPolicyId,
                    AduitConfigId = traOrderInfoModel?.Order?.CorpAduitId,
                    Source = request.OrderSource,
                    SubmitCid = request.Cid,
                    SubmitOid = request.Oid,
                    IsViolatePolicy = traOrderInfoModel?.IsViolatePolicy,
                    OrderType = OrderSourceTypeEnum.Tra
                };
                _submitCorpAduitOrderServiceBll.Submit(submitCorpAduitOrder);

                #endregion

                if (!_submitCorpAduitOrderServiceBll.IsSendAduit)//没有送审的，直接发起出票请求
                {
                    TraOrderConfirmResponseModel traOrderConfirmResponseModel = _requestPrintTicketServiceBll.RequestPrintTicket(request.OrderId);
                    return new ConfirmTraHoldSeatResponseViewModel()
                    {
                        IsSuccessed = traOrderConfirmResponseModel.success,
                        Message = traOrderConfirmResponseModel.msg
                    };
                }

                return new ConfirmTraHoldSeatResponseViewModel()
                {
                    IsSuccessed = true
                };
            }
            else
            {
                #region 不同意
                //取消订单
                _cancelTraOrderServiceBll.CancelTraOrder(new CancelTraOrderModel()
                {
                    OrderId = request.OrderId,
                    CancelReason = "取消占位，取消订单"
                });
                //取消接口订单
                TraOrderCancelResponseModel traOrderCancelResponseModel =
                            _requestCancelOrderServiceBll.RequestCancelOrder(request.OrderId);
                return new ConfirmTraHoldSeatResponseViewModel()
                {
                    IsSuccessed = traOrderCancelResponseModel.success,
                    Message = traOrderCancelResponseModel.msg
                }; 
                #endregion
            }
            
        }
    }
}
