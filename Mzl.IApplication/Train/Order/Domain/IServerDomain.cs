using Mzl.DomainModel.Events;
using Mzl.DomainModel.Train.Server;
using Mzl.UIModel.Train.Order;
using System;
using System.Collections.Generic;

namespace Mzl.IApplication.Train.Order.Domain
{
    public interface IServerDomain
    {
        /// <summary>
        /// 占位事件
        /// </summary>
        event EventHandler<TraServerEventArgs<TraHoldSeatCallBackLogModel>> TraHoldSeatCallBackEvent;
        /// <summary>
        /// 出票事件
        /// </summary>
        event EventHandler<TraServerEventArgs<TraOrderConfirmModel>> OrderConfirmEvent;
        /// <summary>
        /// 退票回调事件
        /// </summary>
        event EventHandler<TraServerEventArgs<TraRefundTicketCallBackLogModel>> RefundCallBackEvent;
        /// <summary>
        /// 查询座位（有价格）
        /// </summary>
        /// <returns></returns>
        List<TraTravelInfoModel> DoQueryTrain(TraQueryTrainModel obj);

        /// <summary>
        /// 订单提交
        /// </summary>
        /// <returns></returns>
        TraOrderSubmitResponseModel DoOrderSubmit(TraOrderSubmitModel obj);
        /// <summary>
        /// 提交订单事件
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void DoOrderSubmitrEvent(object o, TraServerEventArgs<TraOrderSubmitModel> e);



        /// <summary>
        /// 订单取消
        /// </summary>
        /// <returns></returns>
        TraOrderCancelResponseModel DoOrderCancel(TraOrderCancelModel obj);


        /// <summary>
        /// 火车票退票
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="refundOrderId"></param>
        /// <returns></returns>
        TraTicketRefundResponseModel DoTicketRefund(TraTicketRefundModel obj, int refundOrderId = 0);


        /// <summary>
        /// 火车票改签订单
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="modOrderId"></param>
        /// <returns></returns>
        TraRequestChangeResponseModel DoRequestChange(TraRequestChangeModel obj, int modOrderId = 0);

        /// <summary>
        /// 火车票改签订单取消
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TraRequestCancelResponseModel DoRequestCancel(TraRequestCancelModel obj);

        /// <summary>
        /// 火车票改签订单确认
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TraRequestConfirmResponseModel DoRequestConfirm(TraRequestConfirmModel obj);





        /// <summary>
        /// 火车票订单查询
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TraSearchOrderInfoResponseModel DoSearchOrderInfo(TraSearchOrderInfoModel obj);




        /// <summary>
        /// 订单确认
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        TraOrderConfirmResponseModel DoOrderConfirm(TraOrderConfirmModel obj);
        

        /// <summary>
        /// 信息查询
        /// </summary>
        /// <returns></returns>
        List<TraTrainInfoResponseDateDetailModel> DoTrainInfo(TraTrainInfoModel obj);

        /// <summary>
        /// 进行占座
        /// </summary>
        /// <returns></returns>
        bool DoHoldSeat();


        /// <summary>
        /// 进行出票
        /// </summary>
        /// <returns></returns>
        string DoPrintTicket();


        /// <summary>
        /// 进行退票
        /// </summary>
        /// <returns></returns>
        bool DoRefundTicket();

        /// <summary>
        /// 进行改签占座
        /// </summary>
        /// <returns></returns>
        bool DoModHoldSeat();

        /// <summary>
        /// 进行改签出票
        /// </summary>
        /// <returns></returns>
        bool DoModPrintTicket();
        /// <summary>
        /// 根据订单号查询当前占位是否成功
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        QueryTraInterfaceOrderStatusResponseViewMode QueryHoldSeatStatus(int orderid);

        void DoRefundSubmitrEvent(object o, TraServerEventArgs<TraTicketRefundModel> e);
        /// <summary>
        /// 改签订单提交操作
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void DoModSubmitrEvent(object o, TraServerEventArgs<TraRequestChangeModel> e);
        /// <summary>
        /// 改签回调事件
        /// </summary>
        event EventHandler<TraServerEventArgs<TraModHoldSeatCallBackLogModel>> ModCallBackEvent;
        /// <summary>
        /// 改签确认回调事件
        /// </summary>
        event EventHandler<TraServerEventArgs<TraRequestConfirmModel>> ModComfireEvent;
        /// <summary>
        /// 改签出票回调事件
        /// </summary>
        event EventHandler<TraServerEventArgs<TraModPrintTicketCallBackLogModel>> ModPrintTicketEvent;

        /// <summary>
        /// 获取需要弥补的占位信息
        /// </summary>
        void HoldSeateMakeUpInfo(IServerDomain orderCancelDomain, IServerDomain requestCancelDomain);
        /// <summary>
        /// 出票回调事件
        /// </summary>
        event EventHandler<TraServerEventArgs<TraPrintTicketCallBackLogModel>> OrderTicketEvent;
        /// <summary>
        /// 需要弥补的正在出票信息
        /// </summary>
        /// <returns></returns>
        void PrintingMakeUp(IServerDomain requestInterfaceOrderDomain);
    }
}
