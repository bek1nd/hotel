using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.ConfigHelper;
using Mzl.DomainModel.Enum;
using Mzl.DomainModel.Train.Server;
using Mzl.EntityModel.Train.Server;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.RequestInterface;
using Mzl.IDAL.Train;

namespace Mzl.BLL.Train.RequestInterface
{
    internal class RequestCancelOrderServiceBll: BaseServiceBll,IRequestCancelOrderServiceBll
    {
        private readonly IRequestCancelOrderBll _requestCancelOrderBll;
        private readonly ITraInterFaceOrderDal _traInterFaceOrderDal;
        private readonly ITraOrderOperateDal _traOrderOperateDal;

        public RequestCancelOrderServiceBll(IRequestCancelOrderBll requestCancelOrderBll
          , ITraInterFaceOrderDal traInterFaceOrderDal
          , ITraOrderOperateDal traOrderOperateDal)
        {
            _requestCancelOrderBll = requestCancelOrderBll;
            _traInterFaceOrderDal = traInterFaceOrderDal;
            _traOrderOperateDal = traOrderOperateDal;
        }

        public TraOrderCancelResponseModel RequestCancelOrder(int orderId)
        {
            TraInterFaceOrderEntity traInterFaceOrderEntity =
                   _traInterFaceOrderDal.Query<TraInterFaceOrderEntity>(n => n.OrderId == orderId.ToString())
                       .FirstOrDefault();
            if (traInterFaceOrderEntity == null)
                return null;
            
            int status = traInterFaceOrderEntity.Status;
            if (status == (int) OrderTypeEnum.OrderCancel)
                return null;

            TraOrderCancelResponseModel responseModel = null;
            string isServer = AppSettingsHelper.GetAppSettings(AppSettingsEnum.IsServer);
            if (isServer == "T")
            {
                responseModel = _requestCancelOrderBll.RequestCancelOrder(new TraOrderCancelModel()
                {
                    orderid = orderId.ToString(),
                    transactionid = traInterFaceOrderEntity.Transactionid
                });
            }
            else
            {
                responseModel=new TraOrderCancelResponseModel()
                {
                    success=true
                };
            }
           

            if (responseModel.success)
            {
                traInterFaceOrderEntity.Status = (int)OrderTypeEnum.OrderCancel;
                _traInterFaceOrderDal.Update<TraInterFaceOrderEntity>(traInterFaceOrderEntity, new[] { "Status"});

                _traOrderOperateDal.Insert<TraOrderOperateEntity>(new TraOrderOperateEntity()
                {
                    AfterOperateStatus = (int)OrderTypeEnum.OrderCancel,
                    InterfaceId = traInterFaceOrderEntity.InterfaceId,
                    Operate = (int)OrderTypeEnum.OrderCancel,
                    OperateTime = traInterFaceOrderEntity.CreateTime,
                    BeforOperateStatus= status
                });
            }

            return responseModel;

        }
    }
}
