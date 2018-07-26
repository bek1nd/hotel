using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper.Train;
using Mzl.DomainModel.Train.GrabTicket.KongTieInterface;
using Mzl.EntityModel.Train;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.GrabTicket;
using Mzl.IBLL.Train.GrabTicket.KongTieInterface;
using Mzl.IDAL.Train;
using Mzl.EntityModel.Train.Order;
using Mzl.DomainModel.Events;
using Mzl.DomainModel.Common.Account;
using Mzl.DomainModel.Enum;
using Mzl.EntityModel.Train.Server;
using Mzl.EntityModel.Train.BaseMaintenance;

namespace Mzl.BLL.Train.GrabTicket
{
    internal class GetGrabTicketNoticeServiceBll : BaseServiceBll, IGetGrabTicketNoticeServiceBll
    {
        private readonly ITraGrabTicketDal _traGrabTicketDal;
        private readonly ITraOrderDal _traOrderDal;
        private readonly ITraOrderDetailDal _traOrderDetailDal;
        private readonly ITraOrderStatusDal _traOrderStatusDal;
        private readonly ITraPassengerDal _traPassengerDal;
        private readonly ITraOrderLogDal _traOrderLogDal;
        private readonly ITraInterFaceOrderDal _traInterFaceOrderDal;
        private readonly ITraOrderOperateDal _traOrderOperateDal;
        private readonly ITraAddressDal _traAddressDal;

        public event EventHandler<CommonEventArgs<AccountDetailModel>> PaySupplierEvent;

        public GetGrabTicketNoticeServiceBll(ITraGrabTicketDal traGrabTicketDal,
             ITraOrderDal traOrderDal, ITraOrderDetailDal traOrderDetailDal, ITraOrderStatusDal traOrderStatusDal,
              ITraPassengerDal traPassengerDal, ITraOrderLogDal traOrderLogDal,
               ITraInterFaceOrderDal traInterFaceOrderDal, ITraOrderOperateDal traOrderOperateDal,
               ITraAddressDal traAddressDal)
        {
            _traGrabTicketDal = traGrabTicketDal;
            _traOrderDal = traOrderDal;
            _traOrderDetailDal = traOrderDetailDal;
            _traOrderStatusDal = traOrderStatusDal;
            _traPassengerDal = traPassengerDal;
            _traOrderLogDal = traOrderLogDal;
            _traInterFaceOrderDal = traInterFaceOrderDal;
            _traOrderOperateDal = traOrderOperateDal;
            _traAddressDal = traAddressDal;
        }

        /// <summary>
        ///  获取抢票异步成功通知，并做处理
        ///  则自动生成火车订单，通知抢票发起者
        /// </summary>
        public void GetGrabTicketSuccessNotice(GrabTicketSuccessedDataAsyncResponseModel successedData)
        {
            int orderid = Convert.ToInt32(successedData.orderid);

            #region 1.更新抢票信息状态

            TraGrabTicketEntity traGrabTicketEntity =
                _traGrabTicketDal.Query<TraGrabTicketEntity>(n => n.OrderId == orderid).FirstOrDefault();
            if (traGrabTicketEntity == null)
                throw new Exception("未找到对应的系统订单");
            traGrabTicketEntity.GrabStatus = TrainGrabStatusEnum.S.ToString();
            _traGrabTicketDal.Update(traGrabTicketEntity, new string[] {"GrabStatus"});

            #endregion


            #region 2.1 根据订单获取预设订单信息

            TraOrderEntity traOrderEntity = _traOrderDal.Find<TraOrderEntity>(orderid);
            if (traOrderEntity == null)
                throw new Exception("订单信息异常");
            if(traOrderEntity.OrderType==0)
                throw new Exception("该订单已经回调");

            TraOrderDetailEntity traOrderDetailEntity =
                _traOrderDetailDal.Query<TraOrderDetailEntity>(n => n.OrderId == traOrderEntity.OrderId)
                    .FirstOrDefault();
            if (traOrderDetailEntity == null)
                throw new Exception("订单信息异常");

            TraOrderStatusEntity traOrderStatusEntity =
                _traOrderStatusDal.Query<TraOrderStatusEntity>(n => n.OrderId == traOrderEntity.OrderId)
                    .FirstOrDefault();
            if (traOrderStatusEntity == null)
                throw new Exception("订单信息异常");

            List<TraPassengerEntity> traPassengerEntities =
                _traPassengerDal.Query<TraPassengerEntity>(n => n.OdId == traOrderDetailEntity.OdId).ToList();
            if (traPassengerEntities.Count == 0)
                throw new Exception("订单信息异常");

            #endregion

            #region 2.2根据返回结果，更新预设订单信息

            traOrderEntity.TransactionId = successedData.transactionid;
            traOrderEntity.OrderType = 0;
            if (successedData.refund_online == "1")
                traOrderEntity.IsRefundBy12306 = false;
            else
                traOrderEntity.IsRefundBy12306 = true;

            traOrderDetailEntity.OrderId12306 = successedData.ordernumber;
            traOrderDetailEntity.StartName = successedData.from_station_name;
            traOrderDetailEntity.StartCode = successedData.from_station_code;
            traOrderDetailEntity.StartTime = Convert.ToDateTime(successedData.start_time);
            TraAddressEntity startAddressEntity =
                _traAddressDal.Query<TraAddressEntity>(n => n.Addr_Name == traOrderDetailEntity.StartName)
                    .FirstOrDefault();
            if (startAddressEntity != null)
                traOrderDetailEntity.StartNameId = startAddressEntity.Aid;

            traOrderDetailEntity.EndName = successedData.to_station_name;
            traOrderDetailEntity.EndCode = successedData.to_station_code;
            traOrderDetailEntity.EndTime = Convert.ToDateTime(successedData.arrive_time);
            TraAddressEntity endAddressEntity =
              _traAddressDal.Query<TraAddressEntity>(n => n.Addr_Name == traOrderDetailEntity.EndName)
                  .FirstOrDefault();
            if (endAddressEntity != null)
                traOrderDetailEntity.EndNameId = endAddressEntity.Aid;

            traOrderDetailEntity.TrainNo = successedData.checi;
            traOrderDetailEntity.FacePrice = Convert.ToDecimal(successedData.orderamount)/2;
            traOrderDetailEntity.TotalPrice = traOrderDetailEntity.FacePrice + traOrderDetailEntity.ServiceFee;



            foreach (TraPassengerEntity traPassengerEntity in traPassengerEntities)
            {
                GrabTicketSuccessedPassengerAsyncResponseModel grabTicketPassenger = successedData.passengers.Find(
                    n => n.passengersename == traPassengerEntity.Name && n.passportseno == traPassengerEntity.CardNo);
                traPassengerEntity.FacePrice = Convert.ToDecimal(grabTicketPassenger.price);
                List<string> cxinList = grabTicketPassenger.cxin.Split(',').ToList();
                if (cxinList.Count == 2)
                {
                    traPassengerEntity.PlaceCar = cxinList[0];
                    traPassengerEntity.PlaceSeatNo = cxinList[1];
                }
                traPassengerEntity.PlaceGrade = grabTicketPassenger.zwname;
                traPassengerEntity.TicketNo = grabTicketPassenger.ticket_no;

                _traPassengerDal.Update(traPassengerEntity,
                    new string[] {"FacePrice", "PlaceCar", "PlaceSeatNo", "PlaceGrade", "TicketNo"});
            }

            traOrderEntity.TotalMoney = traPassengerEntities.Sum(n => (n.ServiceFee ?? 0) + (n.FacePrice ?? 0));
            traOrderEntity.PayAmount = traOrderEntity.TotalMoney;

            traOrderStatusEntity.IsBuy = 1;
            traOrderStatusEntity.ProccessStatus = traOrderStatusEntity.ProccessStatus + 1 + 8 + 64; //已付款，已预定
            traOrderStatusEntity.RealPayOid = "sys";
            traOrderStatusEntity.RealPayDatetime = DateTime.Now;

            //更新订单
            _traOrderDal.Update(traOrderEntity,
                new string[] {"TransactionId", "IsRefundBy12306", "TotalMoney", "PayAmount", "OrderType"});
            //更新行程
            _traOrderDetailDal.Update(traOrderDetailEntity,
                new string[]
                {
                    "OrderId12306", "StartName", "StartCode", "StartTime", "EndName", "EndCode", "EndTime",
                    "TrainNo",
                    "FacePrice", "TotalPrice"
                });
            //更新订单状态
            _traOrderStatusDal.Update(traOrderStatusEntity,
                new[] {"IsBuy", "ProccessStatus", "RealPayOid", "RealPayDatetime"});

            #endregion

            #region 2.3 设置付款信息，并记录日志

            PaySupplierEvent?.Invoke(this, new CommonEventArgs<AccountDetailModel>(new AccountDetailModel()
            {
                Aid = 81,
                Amount = traPassengerEntities.Sum(n => (n.FacePrice ?? 0)) + 5, //抢票订单+5块
                Detailtype = "火车票付票款",
                Oid = "sys",
                CreateTime = DateTime.Now,
                Source = "火车票付票款",
                OrderId = traOrderEntity.OrderId,
                OrderType = "Tra",
                Provider = 0,
                CollectionRemark = "",
                EstimateId = 0
            }));

            _traOrderLogDal.Insert(new TraOrderLogEntity()
            {
                OrderId = traOrderEntity.OrderId,
                CreateOid = "sys",
                CreateTime = DateTime.Now,
                LogContent = "抢票出票回调，自动勾已预定、已付票款、已采购",
                LogType = "修改"
            });

            #endregion

            #region 2.3插入Tra_InterFaceOrder表，以便退改签流程

            TraInterFaceOrderEntity traInterFaceOrderEntity =
                _traInterFaceOrderDal.Insert<TraInterFaceOrderEntity>(new TraInterFaceOrderEntity()
                {
                    OrderId = traOrderEntity.OrderId.ToString(),
                    CreateTime = DateTime.Now,
                    Status = (int) OrderTypeEnum.TicketSuccess,
                    Transactionid = traOrderEntity.TransactionId,
                    OrderNumber = traOrderDetailEntity.OrderId12306
                });

            _traOrderOperateDal.Insert(new TraOrderOperateEntity()
            {
                InterfaceId = traInterFaceOrderEntity.InterfaceId,
                AfterOperateStatus = (int) OrderTypeEnum.TicketSuccess,
                BeforOperateStatus = 0,
                OperateTime = DateTime.Now
            });

            #endregion

        }

        public void GetGrabTicketFailedNotice(GrabTicketFailedDataAsyncResponseModel failedData)
        {
            int orderid = Convert.ToInt32(failedData.orderid);

            TraGrabTicketEntity traGrabTicketEntity =
                  _traGrabTicketDal.Query<TraGrabTicketEntity>(n => n.OrderId == orderid).FirstOrDefault();
            if (traGrabTicketEntity == null)
                throw new Exception("未找到对应的系统订单");
            traGrabTicketEntity.GrabStatus = TrainGrabStatusEnum.F.ToString();
            traGrabTicketEntity.GrabFailedReason = failedData.Msg;
            _traGrabTicketDal.Update(traGrabTicketEntity, new string[] { "GrabStatus", "GrabFailedReason" });

        }



    }
}
