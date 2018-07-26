using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.ConfigHelper;
using Mzl.Common.LogHelper;
using Mzl.DomainModel.Enum;
using Mzl.DomainModel.Train.Order;
using Mzl.DomainModel.Train.Server;
using Mzl.EntityModel.Train.Order;
using Mzl.EntityModel.Train.Server;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.RequestInterface;
using Mzl.IDAL.Train;

namespace Mzl.BLL.Train.RequestInterface
{
    internal class RequestPrintTicketServiceBll: BaseServiceBll,IRequestPrintTicketServiceBll
    {
        private readonly IRequestPrintTicketBll _requestPrintTicketBll;
        private readonly ITraInterFaceOrderDal _traInterFaceOrderDal;
        private readonly ITraOrderOperateDal _traOrderOperateDal;

        public RequestPrintTicketServiceBll(IRequestPrintTicketBll requestPrintTicketBll
        , ITraInterFaceOrderDal traInterFaceOrderDal
        , ITraOrderOperateDal traOrderOperateDal)
        {
            _requestPrintTicketBll = requestPrintTicketBll;
            _traInterFaceOrderDal = traInterFaceOrderDal;
            _traOrderOperateDal = traOrderOperateDal;
        }

        public TraOrderConfirmResponseModel RequestPrintTicket(int orderId)
        {
            TraInterFaceOrderEntity traInterFaceOrderEntity =
                 _traInterFaceOrderDal.Query<TraInterFaceOrderEntity>(n => n.OrderId == orderId.ToString())
                     .FirstOrDefault();
            if (traInterFaceOrderEntity == null)
                return null;
            int status = traInterFaceOrderEntity.Status;

            if (traInterFaceOrderEntity.CreateTime.AddMinutes(30) < DateTime.Now)
            {
                return new TraOrderConfirmResponseModel()
                {
                    success = false,
                    msg = "该订单已经超过出票时间范围"
                };
            }

            if (status == (int)OrderTypeEnum.MakingTicket)
            {
                return new TraOrderConfirmResponseModel()
                {
                    success = false,
                    msg = "该订单已经发起出票请求了"
                };
            }
            if (status == (int) OrderTypeEnum.TicketSuccess)
            {
                return new TraOrderConfirmResponseModel()
                {
                    success = false,
                    msg = "该订单已经出票了"
                };
            }

            if (status == (int)OrderTypeEnum.OrderCancel)
            {
                return new TraOrderConfirmResponseModel()
                {
                    success = false,
                    msg = "该订单已经取消了"
                };
            }


            string isServer = AppSettingsHelper.GetAppSettings(AppSettingsEnum.IsServer);
            TraOrderConfirmResponseModel responseModel = null;
            if (isServer == "T")
            {
                responseModel = _requestPrintTicketBll.RequestPrintTicket(new TraOrderConfirmModel()
                {
                    orderid = orderId.ToString(),
                    transactionid = traInterFaceOrderEntity.Transactionid
                });
            }
            else
            {
                responseModel = new TraOrderConfirmResponseModel()
                {
                    success = true,
                    ordernumber = "ETest" + DateTime.Now.ToString("yyyyMMdd")+ new Random().Next(1000)
                };
            }
            

            if (responseModel.success)
            {
                traInterFaceOrderEntity.Status = (int) OrderTypeEnum.MakingTicket;
                traInterFaceOrderEntity.OrderNumber = responseModel.ordernumber;

                _traInterFaceOrderDal.Update<TraInterFaceOrderEntity>(traInterFaceOrderEntity, new[] {"Status", "OrderNumber"});

                _traOrderOperateDal.Insert<TraOrderOperateEntity>(new TraOrderOperateEntity()
                {
                    AfterOperateStatus = (int) OrderTypeEnum.TicketSuccess,
                    InterfaceId = traInterFaceOrderEntity.InterfaceId,
                    Operate = (int) OrderTypeEnum.MakingTicket,
                    OperateTime = traInterFaceOrderEntity.CreateTime,
                    BeforOperateStatus = status
                });

               
            }

            return responseModel;
        }
    }
}
