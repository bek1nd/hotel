using System;
using System.Collections.Concurrent;
using Mzl.DomainModel.Train.Server;
using Mzl.IApplication.Train.Order;
using Mzl.IApplication.Train.Order.Domain;
using Mzl.IBLL.Train.Server;
using Mzl.IBLL.Train.Server.BLL;
using Newtonsoft.Json;
using Mzl.BLL.Train.Server.BLL;
using Mzl.Common.JsonHelper;
using Mzl.Common.MD5Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Mzl.DomainModel.Enum;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Events;
using Mzl.Common.LogHelper;
using System.Transactions;
using Mzl.Common.TransactionOptionsHelper;
using Mzl.IBLL.Train.Order.BLL;
using Mzl.DomainModel.Train.Order;
using System.Web;
using Mzl.Common.EmailHelper;
using System.Threading.Tasks;
using Mzl.Common.CacheHelper;
using Mzl.Common.ConfigHelper;
using Mzl.DomainModel.Train.Server.ModelHelper;
using Mzl.UIModel.Train.Order;

namespace Mzl.Application.Train.Order.Domain
{
    internal class ServerDomain : IServerDomain
    {

        #region 私有字段

        private readonly ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> _interFaceOrderServerBll;
        private readonly ITraOrderOperateServerBLL<TraOrderOperateModel> _orderOperateServerBll;
        private readonly ITraModOrderBLL<TraModOrderModel> _traModOrderBll;
        private readonly IModHoldSeatServerBLL<TraModHoldSeatCallBackLogModel> _modHoldSeatServer;
        private readonly IModPrintTicketServerBLL<TraModPrintTicketCallBackLogModel> _modPrintSeatServer;
        private readonly IRefundTicketServerBLL<TraRefundTicketCallBackLogModel> _refundTicketServer;
        private readonly IHoldSeatServerBLL<TraHoldSeatCallBackLogModel> _holdSeatServer;
        private readonly IPrintTicketServerBLL<TraPrintTicketCallBackLogModel> _printSeatServer;
        private readonly IQueryTrainServerBLL<List<TraTravelInfoModel>> _queryTrainServer;
        private readonly IOrderSubmitServerBLL<TraOrderSubmitResponseModel> _orderSubmitServer;
        private readonly IOrderCancelServerBLL<TraOrderCancelResponseModel> _orderCancelServer;
        private readonly ITraOrderBLL<TraOrderModel> _orderBll;
        private readonly ITraOrderStatusBLL<TraOrderStatusModel> _orderStatusBll;
        private readonly ITrainInfoServerBLL<List<TraTrainInfoResponseDateDetailModel>> _trainInfoServer;
        private readonly IOrderConfirmServerBLL<TraOrderConfirmResponseModel> _orderConfirmServer;
        private readonly ITicketRefundServerBLL<TraTicketRefundResponseModel> _ticketRefundServer;
        private readonly IRequestChangeServerBLL<TraRequestChangeResponseModel> _requestChangeServer;
        private readonly IRequestCancelServerBLL<TraRequestCancelResponseModel> _requestCancelServer;
        private readonly IRequestConfirmServerBLL<TraRequestConfirmResponseModel> _requestConfirmServer;
        private readonly ISearchOrderInfoServerBLL<TraSearchOrderInfoResponseModel> _orderInfoServer;
        private readonly string _email = "qyz@mojory.cn";

        #endregion

        #region 事件监听

        public void DoOrderSubmitrEvent(object o, TraServerEventArgs<TraOrderSubmitModel> e)
        {
            TraOrderSubmitResponseModel orderSubmit = DoOrderSubmit(e.Obj);
            if (orderSubmit.code != 802)
                throw new Exception("订单提交失败，" + orderSubmit.msg);
        }

        public void DoModSubmitrEvent(object o, TraServerEventArgs<TraRequestChangeModel> e)
        {
            DoRequestChange(e.Obj, e.RefundOrderId);
        }

        public void DoRefundSubmitrEvent(object o, TraServerEventArgs<TraTicketRefundModel> e)
        {
            TraTicketRefundResponseModel resultModel = DoTicketRefund(e.Obj, e.RefundOrderId);
            if (resultModel.code != 802)
                throw new Exception("退票提交失败，" + resultModel.msg);
        }

        #endregion

        #region 事件

        public event EventHandler<TraServerEventArgs<TraHoldSeatCallBackLogModel>> TraHoldSeatCallBackEvent;
        public event EventHandler<TraServerEventArgs<TraOrderConfirmModel>> OrderConfirmEvent;
        public event EventHandler<TraServerEventArgs<TraModHoldSeatCallBackLogModel>> ModCallBackEvent;
        public event EventHandler<TraServerEventArgs<TraPrintTicketCallBackLogModel>> OrderTicketEvent;
        public event EventHandler<TraServerEventArgs<TraModPrintTicketCallBackLogModel>> ModPrintTicketEvent;
        public event EventHandler<TraServerEventArgs<TraRefundTicketCallBackLogModel>> RefundCallBackEvent;
        public event EventHandler<TraServerEventArgs<TraRequestConfirmModel>> ModComfireEvent;

        #endregion

        #region 构造方法

        public ServerDomain(ISearchOrderInfoServerBLL<TraSearchOrderInfoResponseModel> orderInfoServer,
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll,
            ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperateServerBll)
        {
            _orderInfoServer = orderInfoServer;
            _interFaceOrderServerBll = interFaceOrderServerBll;
            _orderOperateServerBll = orderOperateServerBll;
        }

        public ServerDomain(IRequestConfirmServerBLL<TraRequestConfirmResponseModel> requestConfirmServer,
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll,
            ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperateServerBll,
            ITraModOrderBLL<TraModOrderModel> traModOrderBll)
        {
            _requestConfirmServer = requestConfirmServer;
            _interFaceOrderServerBll = interFaceOrderServerBll;
            _orderOperateServerBll = orderOperateServerBll;
            _traModOrderBll = traModOrderBll;
        }

        public ServerDomain(IRequestCancelServerBLL<TraRequestCancelResponseModel> requestCancelServer,
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll,
            ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperateServerBll,
            ITraModOrderBLL<TraModOrderModel> traModOrderBll)
        {
            _requestCancelServer = requestCancelServer;
            _interFaceOrderServerBll = interFaceOrderServerBll;
            _orderOperateServerBll = orderOperateServerBll;
            _traModOrderBll = traModOrderBll;
        }

        public ServerDomain(IRequestChangeServerBLL<TraRequestChangeResponseModel> requestChangeServer,
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll,
            ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperateServerBll)
        {
            _requestChangeServer = requestChangeServer;
            _interFaceOrderServerBll = interFaceOrderServerBll;
            _orderOperateServerBll = orderOperateServerBll;
        }

        public ServerDomain(ITicketRefundServerBLL<TraTicketRefundResponseModel> ticketRefundServer,
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll,
            ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperateServerBll)
        {
            _ticketRefundServer = ticketRefundServer;
            _interFaceOrderServerBll = interFaceOrderServerBll;
            _orderOperateServerBll = orderOperateServerBll;
        }

        public ServerDomain(IOrderConfirmServerBLL<TraOrderConfirmResponseModel> orderConfirmServer,
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll,
            ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperateServerBll)
        {
            _orderConfirmServer = orderConfirmServer;
            _interFaceOrderServerBll = interFaceOrderServerBll;
            _orderOperateServerBll = orderOperateServerBll;
        }

        public ServerDomain(ITrainInfoServerBLL<List<TraTrainInfoResponseDateDetailModel>> trainInfoServer)
        {
            _trainInfoServer = trainInfoServer;
        }

        public ServerDomain(IQueryTrainServerBLL<List<TraTravelInfoModel>> queryTrainServer)
        {
            _queryTrainServer = queryTrainServer;
        }

        public ServerDomain(ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll)
        {
            _interFaceOrderServerBll = interFaceOrderServerBll;
        }

        public ServerDomain(ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll,
            ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperate,
            ITraModOrderBLL<TraModOrderModel> traModOrderBll, ITraOrderBLL<TraOrderModel> orderBll)
        {
            _interFaceOrderServerBll = interFaceOrderServerBll;
            _orderOperateServerBll = orderOperate;
            _traModOrderBll = traModOrderBll;
            _orderBll = orderBll;
        }

        public ServerDomain(IModHoldSeatServerBLL<TraModHoldSeatCallBackLogModel> modHoldSeatServer
            , ITraModOrderBLL<TraModOrderModel> traModOrderBll,
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBl
            , ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperateServerBll,
            IRequestCancelServerBLL<TraRequestCancelResponseModel> requestCancelServer)
        {
            _modHoldSeatServer = modHoldSeatServer;
            _traModOrderBll = traModOrderBll;
            _interFaceOrderServerBll = interFaceOrderServerBl;
            _orderOperateServerBll = orderOperateServerBll;
            _requestCancelServer = requestCancelServer;
        }

        public ServerDomain(IModPrintTicketServerBLL<TraModPrintTicketCallBackLogModel> modPrintSeatServer,
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBl
            , ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperateServerBll,
            ITraOrderBLL<TraOrderModel> orderBll)
        {
            _modPrintSeatServer = modPrintSeatServer;
            _interFaceOrderServerBll = interFaceOrderServerBl;
            _orderOperateServerBll = orderOperateServerBll;
            _orderBll = orderBll;
        }

        public ServerDomain(IRefundTicketServerBLL<TraRefundTicketCallBackLogModel> refundTicketServer,
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll
            , ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperateServerBll,
            ITraOrderBLL<TraOrderModel> orderBll)
        {
            _refundTicketServer = refundTicketServer;
            _interFaceOrderServerBll = interFaceOrderServerBll;
            _orderOperateServerBll = orderOperateServerBll;
            _orderBll = orderBll;
        }

        public ServerDomain(IHoldSeatServerBLL<TraHoldSeatCallBackLogModel> holdSeatServer,
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll,
            ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperateServerBll)
        {
            _holdSeatServer = holdSeatServer;
            _interFaceOrderServerBll = interFaceOrderServerBll;
            _orderOperateServerBll = orderOperateServerBll;
        }

        public ServerDomain(IPrintTicketServerBLL<TraPrintTicketCallBackLogModel> printSeatServer,
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll,
            ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperateServerBll)
        {
            _printSeatServer = printSeatServer;
            _interFaceOrderServerBll = interFaceOrderServerBll;
            _orderOperateServerBll = orderOperateServerBll;
        }

        public ServerDomain(IOrderSubmitServerBLL<TraOrderSubmitResponseModel> orderSubmitServer,
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll,
            ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperateServerBll)
        {
            _orderSubmitServer = orderSubmitServer;
            _interFaceOrderServerBll = interFaceOrderServerBll;
            _orderOperateServerBll = orderOperateServerBll;
        }

        public ServerDomain(IOrderCancelServerBLL<TraOrderCancelResponseModel> orderCancelServer,
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll,
            ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperateServerBll,
            ITraOrderBLL<TraOrderModel> orderBll, ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll)
        {
            _orderCancelServer = orderCancelServer;
            _interFaceOrderServerBll = interFaceOrderServerBll;
            _orderOperateServerBll = orderOperateServerBll;
            _orderBll = orderBll;
            _orderStatusBll = orderStatusBll;

        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 占座回调
        /// </summary>
        /// <returns></returns>
        /// 
        public bool DoHoldSeat()
        {
            //1.获取占位信息
            string receiveStr = _holdSeatServer.ReceiveHoldSeatInof();

            #region 2.保存日志信息

            //2.1占位信息保存日志文本
            _holdSeatServer.SaveLog(receiveStr);
            //2.2 将json字符串(holdSeateStr)转成对象model
            string[] holdSeatStr = receiveStr.Split('=');
            string useStr = holdSeatStr[1];
            TraHoldSeatCallBackLogModel model = JsonConvert.DeserializeObject<TraHoldSeatCallBackLogModel>(useStr);
            //2.3解析后，存入日志
            _holdSeatServer.SaveLog(JsonConvert.SerializeObject(model));
            //2.3将对象保存到数据库
            // model.LogOriginalContent = receiveStr;
            //_holdSeatServer.SaveHoldSeatLog(model);

            #endregion

            TransactionOptions option = new TransactionOptions().GetTransactionScope();
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                TraInterFaceOrderModel traInterFaceOrderModel =
                    _interFaceOrderServerBll.GetOrderByTransactionid(model.Transactionid); //根据接口订单号获取数据
                if (traInterFaceOrderModel == null)
                    throw new Exception("无法查询到" + model.Transactionid + "信息");
                TraOrderOperateModel traOrderOperateModel = new TraOrderOperateModel()
                {
                    OperateTime = DateTime.Now,
                    InterfaceId = traInterFaceOrderModel.InterfaceId
                };
                //3.判断是否占位成功，
                //3.1成功
                if (model.OrderSuccess.HasValue && model.OrderSuccess.Value)
                {
                    //3.1.1 判断对应的订单是否申请占位状态了，如果是，则更新
                    if (traInterFaceOrderModel.Status == (int) OrderTypeEnum.ApplyHoldSeat)
                    {
                        traInterFaceOrderModel.Status = (int) OrderTypeEnum.HoldSeatSuccess;
                        traOrderOperateModel.BeforOperateStatus = (int) OrderTypeEnum.ApplyHoldSeat;
                        traOrderOperateModel.AfterOperateStatus = (int) OrderTypeEnum.HoldSeatSuccess;
                        traOrderOperateModel.Operate = traOrderOperateModel.AfterOperateStatus;

                        if (!string.IsNullOrEmpty(model.OrderNumber))
                            traInterFaceOrderModel.OrderNumber = model.OrderNumber;
                        //更新接口订单状态
                        _interFaceOrderServerBll.UpdateOrder(traInterFaceOrderModel, new[] {"Status", "OrderNumber"});
                        //新增操作日志
                        _orderOperateServerBll.AddOrder(traOrderOperateModel);
                        //成功占位之后更新订单信息
                        TraHoldSeatCallBackEvent?.Invoke(this,
                            new TraServerEventArgs<TraHoldSeatCallBackLogModel>(model));
                    }
                }
                else
                {
                    //3.2失败
                    if (traInterFaceOrderModel.Status == (int) OrderTypeEnum.ApplyHoldSeat)
                    {
                        traInterFaceOrderModel.Status = (int) OrderTypeEnum.HoldSeatFail;
                        traInterFaceOrderModel.Reason = model.msg;
                        traOrderOperateModel.BeforOperateStatus = (int) OrderTypeEnum.ApplyHoldSeat;
                        traOrderOperateModel.AfterOperateStatus = (int) OrderTypeEnum.HoldSeatFail;
                        traOrderOperateModel.Operate = traOrderOperateModel.AfterOperateStatus;
                        traOrderOperateModel.Reason = model.msg;


                        //更新接口订单状态
                        _interFaceOrderServerBll.UpdateOrder(traInterFaceOrderModel, new[] {"Status", "Reason"});
                        //新增操作日志
                        _orderOperateServerBll.AddOrder(traOrderOperateModel);
                    }
                }
                scope.Complete();
            }
            return true;
        }

        public bool DoModHoldSeat()
        {
            //1.获取改签占座信息
            string modHoldSeatStr = _modHoldSeatServer.ReceiveModHoldSeatInof();
            //2.占位信息保存日志文本
            _modHoldSeatServer.SaveLog(modHoldSeatStr);
            string[] holdSeatStr = modHoldSeatStr.Split('=');
            modHoldSeatStr = holdSeatStr[1];
            //3.1 将json字符串(holdSeateStr)转成对象model
            TraModHoldSeatCallBackLogModel model =
                JsonConvert.DeserializeObject<TraModHoldSeatCallBackLogModel>(HttpUtility.UrlDecode(modHoldSeatStr));


            //根据reqtoken和transactionid 确定是哪个改签的占位信息
            List<TraInterFaceOrderModel> traInterFaceOrderModels =
                _interFaceOrderServerBll.GetTraInterFaceOrderByTransactionid(model.transactionid);

            if (traInterFaceOrderModels == null || traInterFaceOrderModels.Count == 0)
                throw new Exception("未找到" + model.transactionid + "对应的订单");

            TraInterFaceOrderModel traInterFaceOrderModel =
                traInterFaceOrderModels.Find(n => n.OrderType == model.reqtoken);
            if (traInterFaceOrderModel == null)
                throw new Exception("未找到" + model.transactionid + ",reqtoken:" + model.reqtoken + "对应的的订单");



            #region 更新占位结果

            TransactionOptions option = new TransactionOptions().GetTransactionScope();
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                if (model.success)
                {
                    #region 改签成功

                    if (traInterFaceOrderModel.Status == (int) OrderTypeEnum.ApplyRequestChange)
                    {

                        traInterFaceOrderModel.Status = (int) OrderTypeEnum.RequestChangeSuccess;
                        _interFaceOrderServerBll.UpdateOrder(traInterFaceOrderModel, new[] {"Status"});
                        TraOrderOperateModel orderOperate = new TraOrderOperateModel()
                        {
                            AfterOperateStatus = (int) OrderTypeEnum.RequestChangeSuccess,
                            InterfaceId = traInterFaceOrderModel.InterfaceId,
                            Operate = (int) OrderTypeEnum.ApplyRequestChange,
                            OperateTime = DateTime.Now,
                            BeforOperateStatus = (int) OrderTypeEnum.ApplyRequestChange
                        };
                        _orderOperateServerBll.AddOrder(orderOperate);
                        ModCallBackEvent?.Invoke(this,
                            new TraServerEventArgs<TraModHoldSeatCallBackLogModel>(model,
                                Convert.ToInt32(traInterFaceOrderModel.OrderId)));
                    }

                    #endregion
                }
                else
                {
                    #region 改签失败

                    if (traInterFaceOrderModel.Status == (int) OrderTypeEnum.ApplyRequestChange)
                    {
                        traInterFaceOrderModel.Status = (int) OrderTypeEnum.RequestChangeFail;
                        traInterFaceOrderModel.Reason = model.msg;
                        _interFaceOrderServerBll.UpdateOrder(traInterFaceOrderModel, new[] {"Status", "Reason"});
                        TraOrderOperateModel orderOperate = new TraOrderOperateModel()
                        {
                            AfterOperateStatus = (int) OrderTypeEnum.RequestChangeFail,
                            InterfaceId = traInterFaceOrderModel.InterfaceId,
                            Operate = (int) OrderTypeEnum.RequestChangeFail,
                            OperateTime = DateTime.Now,
                            BeforOperateStatus = (int) OrderTypeEnum.ApplyRequestChange,
                            Reason = model.msg
                        };
                        _orderOperateServerBll.AddOrder(orderOperate);
                    }

                    #endregion
                }
                scope.Complete();
            }


            #endregion

            return true;
        }

        public bool DoModPrintTicket()
        {

            //1.获取改签出票信息
            string modPrintSeateStr = _modPrintSeatServer.ReceivePrintTicketInof();
            //2.占位信息保存日志文本
            _modPrintSeatServer.SaveLog(modPrintSeateStr);

            string[] modPrintSeatStr = modPrintSeateStr.Split('=');
            modPrintSeateStr = modPrintSeatStr[1];

            //3.1 将json字符串(holdSeateStr)转成对象model
            TraModPrintTicketCallBackLogModel model =
                JsonConvert.DeserializeObject<TraModPrintTicketCallBackLogModel>(HttpUtility.UrlDecode(modPrintSeateStr));
            //找到正单对应的交易号
            TraInterFaceOrderModel orderInterFaceOrderModel = _interFaceOrderServerBll.GetOrderByOrderId(model.orderid);
            //根据交易号获取全部信息
            List<TraInterFaceOrderModel> traInterFaceOrderModels =
                _interFaceOrderServerBll.GetTraInterFaceOrderByTransactionid(orderInterFaceOrderModel.Transactionid);
            //获取全部信息汇总的需要出票的改签单
            TraInterFaceOrderModel traInterFaceOrderModel =
                traInterFaceOrderModels.Find(n => n.OrderType == model.reqtoken);

            if (model.success) //改签成功
            {
                #region 改签成功

                traInterFaceOrderModel.Status = (int) OrderTypeEnum.RequestChangeConfirm;
                _interFaceOrderServerBll.UpdateOrder(traInterFaceOrderModel, new[] {"Status"});
                TraOrderOperateModel orderOperate = new TraOrderOperateModel()
                {
                    AfterOperateStatus = (int) OrderTypeEnum.RequestChangeConfirm,
                    InterfaceId = traInterFaceOrderModel.InterfaceId,
                    Operate = (int) OrderTypeEnum.RequestChangeConfirm,
                    OperateTime = DateTime.Now,
                    BeforOperateStatus = (int) OrderTypeEnum.RequestChangeMakingTicket
                };
                _orderOperateServerBll.AddOrder(orderOperate);

                #endregion

                //4.将改签订单中，原订单对应的乘车人的临时退票单，改为正式退票订单，并且勾已退票，已收供应商款，已付客户款，已记账
                ModPrintTicketEvent?.Invoke(this,
                    new TraServerEventArgs<TraModPrintTicketCallBackLogModel>(model,
                        Convert.ToInt32(traInterFaceOrderModel.OrderId)));
            }

            return true;
        }

        /// <summary>
        ///出票回调
        /// </summary>
        /// <returns></returns>
        public string DoPrintTicket()
        {
            //1.获取出票信息
            string printSeateStr = _printSeatServer.ReceiveHoldTicketInof();
            //2.占位信息保存日志文本
            _printSeatServer.SaveLog(printSeateStr);
            //reqtime = 20170727152753775 & sign = ed6618031463d49b091402468e687b4a & orderid = 101882 & transactionid = T17072761F7E4F804DB1042B708BB30BEB395EAFD80 & isSuccess = Y
            string[] callBackStr = printSeateStr.Split(new char[] {'&'});
            TraPrintTicketCallBackLogModel model = new TraPrintTicketCallBackLogModel();

            #region 出票信息解析

            foreach (var item in callBackStr)
            {
                if (item.Contains("isSuccess"))
                {

                    var strList = item.Split(new char[] {'='});
                    foreach (var _item in strList)
                    {
                        if (!_item.Trim().Contains("isSuccess"))
                        {
                            if (_item.Trim() == "Y")
                            {
                                model.isSuccess = true;

                            }
                            else
                            {
                                model.isSuccess = false;
                            }

                        }
                    }

                }

                if (item.Contains("reqtime"))
                {
                    var strList = item.Split(new char[] {'='});
                    foreach (var _item in strList)
                    {
                        if (!_item.Trim().Contains("reqtime"))
                        {

                            model.reqtime = _item.Trim();


                        }
                    }
                }
                if (item.Contains("sign"))
                {
                    var strList = item.Split(new char[] {'='});
                    foreach (var _item in strList)
                    {
                        if (!_item.Trim().Contains("sign"))
                        {

                            model.sign = _item.Trim();


                        }
                    }

                }

                if (item.Contains("orderid"))
                {
                    var StrList = item.Split(new char[] {'='});
                    foreach (var _item in StrList)
                    {
                        if (!_item.Trim().Contains("orderid"))
                        {

                            model.orderid = _item.Trim();


                        }
                    }

                }
                if (item.Contains("transactionid"))
                {
                    var strList = item.Split(new char[] {'='});
                    foreach (var _item in strList)
                    {
                        if (!_item.Trim().Contains("transactionid"))
                        {

                            model.transactionid = _item.Trim();


                        }
                    }

                }


            }

            #endregion

            TransactionOptions option = new TransactionOptions().GetTransactionScope();
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                if (model.isSuccess)
                {
                    TraInterFaceOrderModel exc = _interFaceOrderServerBll.GetOrderByTransactionid(model.transactionid);
                    if(exc==null)
                        throw new Exception("该订单不属于接口订单，拒绝回调");
                    exc.Status = (int) OrderTypeEnum.TicketSuccess;
                    _interFaceOrderServerBll.UpdateOrder(exc, new[] {"Status"});
                    TraOrderOperateModel orderOperate = new TraOrderOperateModel()
                    {
                        AfterOperateStatus = (int) OrderTypeEnum.TicketSuccess,
                        InterfaceId = exc.InterfaceId,
                        Operate = (int) OrderTypeEnum.TicketSuccess,
                        OperateTime = DateTime.Now,
                        BeforOperateStatus = (int) OrderTypeEnum.MakingTicket
                    };
                    _orderOperateServerBll.AddOrder(orderOperate);
                }
                else
                {
                    var exc = _interFaceOrderServerBll.GetOrderByTransactionid(model.transactionid);
                    if (exc == null)
                        throw new Exception("该订单不属于接口订单，拒绝回调");
                    exc.Status = (int) OrderTypeEnum.TicketFail;
                    //修改状态
                    _interFaceOrderServerBll.UpdateOrder(exc, new[] {"Status"});
                    //操作记录
                    TraOrderOperateModel orderOperate = new TraOrderOperateModel()
                    {
                        AfterOperateStatus = (int) OrderTypeEnum.TicketFail,
                        InterfaceId = exc.InterfaceId,
                        Operate = (int) OrderTypeEnum.TicketFail,
                        OperateTime = DateTime.Now,
                        BeforOperateStatus = (int) OrderTypeEnum.MakingTicket
                    };
                    _orderOperateServerBll.AddOrder(orderOperate);
                }
                OrderTicketEvent?.Invoke(this, new TraServerEventArgs<TraPrintTicketCallBackLogModel>(model));
                scope.Complete();
            }
            string rStr = "orderid:" + model.orderid + ":transactionid:" + model.transactionid +
                          ":errorCount:0:isSuccess:Y:iskefu:null";
            return rStr;
        }

        public bool DoRefundTicket()
        {
            //1.获取退票信息
            string refundTicketStr = _refundTicketServer.ReceiveRefundTicketInof();
            //2.占位信息保存日志文本
            _refundTicketServer.SaveLog(refundTicketStr);
            //3.1 将json字符串(holdSeateStr)转成对象model
            if (refundTicketStr.Contains("="))
            {
                refundTicketStr = refundTicketStr.Split('=')[1];
            }
            TraRefundTicketCallBackLogModel model =
                JsonConvert.DeserializeObject<TraRefundTicketCallBackLogModel>(refundTicketStr);

            if (!string.IsNullOrEmpty(model.ReturnState) && model.ReturnState.ToLower() == "true")
            {
                //


                List<string> ticketNoList =
                    (from t in model.ReturnTickets
                        where !string.IsNullOrEmpty(t.ReturnSuccess) && t.ReturnSuccess.ToLower() == "true"
                        select t.Ticket_No)
                        .ToList();
                TraOrderModel retOrderModel = null;
                List<TraOrderModel> retOrderModelList =
                    _orderBll.GetTraRetOrderListByOrderRootAndTicketNo(Convert.ToInt32(model.ApiorderId),
                        ticketNoList);
                if (retOrderModelList != null && retOrderModelList.Count > 0)
                    retOrderModel = retOrderModelList.Find(n => !n.IsModRefund.HasValue || !n.IsModRefund.Value);

                if (retOrderModel != null)
                {
                    TransactionOptions option = new TransactionOptions().GetTransactionScope();
                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
                    {
                        TraInterFaceOrderModel traInterFaceOrderModel =
                            _interFaceOrderServerBll.GetOrderByOrderId(retOrderModel.OrderId.ToString());
                        if(traInterFaceOrderModel==null)
                            throw new Exception("该订单号不属于接口订单，拒绝回调");
                        if (traInterFaceOrderModel.Status == (int) OrderTypeEnum.ReturnTickets)
                        {
                            _interFaceOrderServerBll.UpdateOrder(new TraInterFaceOrderModel()
                            {
                                InterfaceId = traInterFaceOrderModel.InterfaceId,
                                OrderId = traInterFaceOrderModel.OrderId,
                                Status = (int) OrderTypeEnum.ReturnTicketsSuccess
                            }, new[] {"Status"});


                            TraOrderOperateModel orderOperate = new TraOrderOperateModel()
                            {
                                AfterOperateStatus = (int) OrderTypeEnum.ReturnTicketsSuccess,
                                InterfaceId = traInterFaceOrderModel.InterfaceId,
                                Operate = (int) OrderTypeEnum.ReturnTicketsSuccess,
                                OperateTime = DateTime.Now
                            };
                            _orderOperateServerBll.AddOrder(orderOperate);
                        }

                        scope.Complete();
                    }

                }
                else
                {
                    throw new Exception("未找到对应的退票订单信息，拒绝回调");
                }
                RefundCallBackEvent?.Invoke(this, new TraServerEventArgs<TraRefundTicketCallBackLogModel>(model));
            }

            return true;
        }

        public QueryTraInterfaceOrderStatusResponseViewMode QueryHoldSeatStatus(int orderid)
        {
            TraInterFaceOrderModel traInterFaceOrderModel =
                _interFaceOrderServerBll.GetOrderByOrderId(orderid.ToString());
            if (traInterFaceOrderModel == null)
                return new QueryTraInterfaceOrderStatusResponseViewMode()
                {
                    StatusCode = -1,
                    Reason = string.Empty
                };
            return new QueryTraInterfaceOrderStatusResponseViewMode()
            {
                StatusCode = traInterFaceOrderModel.Status,
                Reason = traInterFaceOrderModel.Reason
            };
        }

        //车次查询
        public List<TraTravelInfoModel> DoQueryTrain(TraQueryTrainModel obj)
        {
            //1.制作查询post结构
            var stm = obj;
            BaseInputModelHelper<TraQueryTrainModel>.SupplementInPutModel(stm, "train_query");
            string jsonstr = "jsonStr=" + JsonHelper.SerializeObject(stm);
            _queryTrainServer.Data = jsonstr;
            return _queryTrainServer.DoQueryTrain();
        }

        public TraOrderSubmitResponseModel DoOrderSubmit(TraOrderSubmitModel obj)
        {
            //1.制作查询post结构
            obj.callbackurl = _orderSubmitServer.CallBackUrl;
            BaseInputModelHelper<TraOrderSubmitModel>.SupplementInPutModel(obj, "train_order");
            string jsonstr = "jsonStr=" + JsonHelper.SerializeObject(obj);
            _orderSubmitServer.Data = jsonstr;
            TraOrderSubmitResponseModel responseModel = _orderSubmitServer.DoOrderSubmit(); //请求接口
            if (responseModel.success)
            {
                TransactionOptions option = new TransactionOptions().GetTransactionScope();
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    List<TraInterFaceOrderModel> traInterFaceOrderModels =
                        _interFaceOrderServerBll.GetTraInterFaceOrderByTransactionid(responseModel.orderid);
                        //根据接口订单号获取是否存在信息

                    if (traInterFaceOrderModels == null || traInterFaceOrderModels.Count == 0) //如果没有当前接口的订单号，则插入该条信息
                    {
                        TraInterFaceOrderModel order = new TraInterFaceOrderModel()
                        {
                            CreateTime = DateTime.Now,
                            OrderId = obj.orderid,
                            Status = (int) OrderTypeEnum.ApplyHoldSeat,
                            Transactionid = responseModel.orderid
                        };
                        int interfaceId = _interFaceOrderServerBll.AddOrder(order);

                        TraOrderOperateModel orderOperate = new TraOrderOperateModel()
                        {
                            AfterOperateStatus = (int) OrderTypeEnum.ApplyHoldSeat,
                            InterfaceId = interfaceId,
                            Operate = (int) OrderTypeEnum.ApplyHoldSeat,
                            OperateTime = order.CreateTime
                        };
                        _orderOperateServerBll.AddOrder(orderOperate);
                    }

                    scope.Complete();
                }


            }


            return responseModel;
        }

        public TraOrderCancelResponseModel DoOrderCancel(TraOrderCancelModel obj)
        {
            var stm = obj;
            if (string.IsNullOrEmpty(obj.orderid))
                throw new Exception("请传入订单号");
            if (string.IsNullOrEmpty(obj.transactionid))
            {
                TraInterFaceOrderModel traInterFaceOrderModel = _interFaceOrderServerBll.GetOrderByOrderId(obj.orderid);
                if (traInterFaceOrderModel == null)
                {
                    throw new Exception("未查询到" + obj.orderid + "对应的接口订单信息");
                }
                obj.transactionid = traInterFaceOrderModel.Transactionid;

                if (traInterFaceOrderModel.Status == (int)OrderTypeEnum.TicketSuccess)
                {
                    return new TraOrderCancelResponseModel()
                    {
                        success = false,
                        msg = "已经出票不能取消",
                        code = 2000
                    };
                }

                if (traInterFaceOrderModel.Status == (int)OrderTypeEnum.MakingTicket)
                {
                    return new TraOrderCancelResponseModel()
                    {
                        success = false,
                        msg = "正在出票不能取消",
                        code = 2000
                    };
                }

            }

            //1.制作查询post结构
            BaseInputModelHelper<TraOrderCancelModel>.SupplementInPutModel(obj, "train_cancel");
            string jsonstr = "jsonStr=" + JsonHelper.SerializeObject(obj);
            _orderCancelServer.Data = jsonstr;
            TraOrderCancelResponseModel responseModel = _orderCancelServer.DoOrderCancel(); //请求接口
            if (responseModel.success)
            {


                TransactionOptions option = new TransactionOptions().GetTransactionScope();
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
                {


                    TraInterFaceOrderModel traInterFaceOrderModel =
                        _interFaceOrderServerBll.GetOrderByOrderId(responseModel.orderid);

                    TraOrderStatusModel traOrderStatusModel =
                        _orderStatusBll.GetOrderStatusByOrderId(Convert.ToInt32(responseModel.orderid));

                    traOrderStatusModel.IsCancle = 1;

                    _orderStatusBll.UpdateOrderStatus(traOrderStatusModel, new[] {"IsCancle"});

                    _interFaceOrderServerBll.UpdateOrder(new TraInterFaceOrderModel()
                    {
                        InterfaceId = traInterFaceOrderModel.InterfaceId,
                        OrderId = responseModel.orderid,
                        Status = (int) OrderTypeEnum.OrderCancel
                    }, new[] {"Status"});

                    TraOrderOperateModel orderOperate = new TraOrderOperateModel()
                    {
                        AfterOperateStatus = (int) OrderTypeEnum.OrderCancel,
                        InterfaceId = traInterFaceOrderModel.InterfaceId,
                        Operate = (int) OrderTypeEnum.OrderCancel,
                        OperateTime = DateTime.Now,
                        BeforOperateStatus = traInterFaceOrderModel.Status

                    };
                    _orderOperateServerBll.AddOrder(orderOperate);
                    scope.Complete();
                }
            }
            //2.将接口订单号和系统订单号保存
            //_interFaceOrderServerBll.
            //ITraInterFaceOrderServerDAL

            return responseModel;
        }

        public List<TraTrainInfoResponseDateDetailModel> DoTrainInfo(TraTrainInfoModel obj)
        {
            //1.制作查询post结构
            var stm = obj;
            BaseInputModelHelper<TraTrainInfoModel>.SupplementInPutModel(stm, "get_train_info");
            string jsonstr = "jsonStr=" + JsonHelper.SerializeObject(stm);
            _trainInfoServer.Data = jsonstr;
            return _trainInfoServer.DoTrainInfo();

        }

        public TraOrderConfirmResponseModel DoOrderConfirm(TraOrderConfirmModel obj)
        {
            var stm = obj;
            if (string.IsNullOrEmpty(obj.orderid))
                throw new Exception("请传入订单号");
            if (string.IsNullOrEmpty(obj.transactionid))
            {
                TraInterFaceOrderModel traInterFaceOrderModel = _interFaceOrderServerBll.GetOrderByOrderId(obj.orderid);
                if (traInterFaceOrderModel == null)
                {
                    throw new Exception("未查询到" + obj.orderid + "对应的接口订单信息");
                }


                if (traInterFaceOrderModel.CreateTime.AddMinutes(20) < DateTime.Now)
                {
                    throw new Exception("该订单已经超过出票时间范围");
                }
                obj.transactionid = traInterFaceOrderModel.Transactionid;
            }


            BaseInputModelHelper<TraOrderConfirmModel>.SupplementInPutModel(stm, "train_confirm");
            string jsonstr = "jsonStr=" + JsonHelper.SerializeObject(stm);
            _orderConfirmServer.Data = jsonstr;
            var orderConfirm = _orderConfirmServer.DoOrderConfirm();

            TransactionOptions option = new TransactionOptions().GetTransactionScope();
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                //1.更新接口订单状态
                TraInterFaceOrderModel traInterFaceOrderModel =
                    _interFaceOrderServerBll.GetOrderByTransactionid(obj.transactionid); //根据接口订单号获取数据
                if (traInterFaceOrderModel == null)
                    throw new Exception("无法查询到" + obj.transactionid + "信息");
                TraOrderOperateModel traOrderOperateModel = new TraOrderOperateModel()
                {
                    OperateTime = DateTime.Now,
                    InterfaceId = traInterFaceOrderModel.InterfaceId

                };
                if (orderConfirm.success)
                {
                    //3.1.1 判断对应的订单是占位成功，则更新
                    if (traInterFaceOrderModel.Status == (int) OrderTypeEnum.HoldSeatSuccess)
                    {
                        traInterFaceOrderModel.Status = (int) OrderTypeEnum.MakingTicket;
                        traInterFaceOrderModel.OrderNumber = orderConfirm.ordernumber;
                        traOrderOperateModel.BeforOperateStatus = (int) OrderTypeEnum.HoldSeatSuccess;
                        traOrderOperateModel.AfterOperateStatus = (int) OrderTypeEnum.MakingTicket;
                        traOrderOperateModel.Operate = traOrderOperateModel.AfterOperateStatus;

                        //更新接口订单状态
                        _interFaceOrderServerBll.UpdateOrder(traInterFaceOrderModel, new[] {"Status", "OrderNumber"});
                        //新增操作日志
                        _orderOperateServerBll.AddOrder(traOrderOperateModel);
                        //2.更新系统订单的状态为0，并且已付款，已采购
                        OrderConfirmEvent?.Invoke(this, new TraServerEventArgs<TraOrderConfirmModel>(obj));
                    }
                    else
                    {
                        throw new Exception("当前占位失败，不能出票！");
                    }
                }
                else
                {
                    //3.2失败
                    if (traInterFaceOrderModel.Status == (int) OrderTypeEnum.HoldSeatSuccess)
                    {
                        traInterFaceOrderModel.Status = (int) OrderTypeEnum.TicketFail;
                        traOrderOperateModel.BeforOperateStatus = (int) OrderTypeEnum.HoldSeatSuccess;
                        traOrderOperateModel.AfterOperateStatus = (int) OrderTypeEnum.TicketFail;
                        traOrderOperateModel.Operate = traOrderOperateModel.AfterOperateStatus;
                        //更新接口订单状态
                        _interFaceOrderServerBll.UpdateOrder(traInterFaceOrderModel, new[] {"Status"});
                        //新增操作日志
                        _orderOperateServerBll.AddOrder(traOrderOperateModel);
                    }
                    else
                    {
                        throw new Exception("出票失败！" + orderConfirm.msg);
                    }
                }

                scope.Complete();
            }




            return orderConfirm;
        }

        public TraTicketRefundResponseModel DoTicketRefund(TraTicketRefundModel obj, int refundOrderId = 0)
        {
            var stm = obj;
            if (string.IsNullOrEmpty(obj.orderid))
                throw new Exception("请传入订单号");
            if (string.IsNullOrEmpty(obj.transactionid))
            {
                TraInterFaceOrderModel traInterFaceOrderModel = _interFaceOrderServerBll.GetOrderByOrderId(obj.orderid);
                if (traInterFaceOrderModel == null)
                {
                    throw new Exception("未查询到" + obj.orderid + "对应的接口订单信息");
                }
                obj.transactionid = traInterFaceOrderModel.Transactionid;
            }
            obj.CallBackurl = _ticketRefundServer.CallBackUrl;
            BaseInputModelHelper<TraTicketRefundModel>.SupplementInPutModel(stm, "return_ticket");
            string jsonstr = "jsonStr=" + JsonHelper.SerializeObject(stm);
            _ticketRefundServer.Data = jsonstr;

            string isServer = AppSettingsHelper.GetAppSettings(AppSettingsEnum.IsServer);
            TraTicketRefundResponseModel ticketRefund = null;
            if (isServer=="T")
            {
                 ticketRefund = _ticketRefundServer.DoTicketRefund();
            }
            else
            {
                ticketRefund = new TraTicketRefundResponseModel()
                {
                    success = true,
                    code = 802
                };
            }
          

            TransactionOptions option = new TransactionOptions().GetTransactionScope();
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                //1.更新接口订单状态
                TraInterFaceOrderModel traInterFaceOrderModel =
                    _interFaceOrderServerBll.GetOrderByTransactionid(obj.transactionid); //根据接口订单号获取数据
                if (traInterFaceOrderModel == null)
                    throw new Exception("无法查询到" + obj.transactionid + "信息");

                if (ticketRefund.success)
                {
                    //3.1.1 判断对应的订单是出票成功，
                    if (traInterFaceOrderModel.Status == (int) OrderTypeEnum.TicketSuccess)
                    {
                        //新增退票记录
                        TraInterFaceOrderModel order = new TraInterFaceOrderModel()
                        {
                            CreateTime = DateTime.Now,
                            OrderId = refundOrderId.ToString(),
                            Status = (int) OrderTypeEnum.ReturnTickets,
                            Transactionid = obj.transactionid
                        };
                        int interfaceId = _interFaceOrderServerBll.AddOrder(order);
                        TraOrderOperateModel orderOperate = new TraOrderOperateModel()
                        {
                            AfterOperateStatus = (int) OrderTypeEnum.ReturnTickets,
                            InterfaceId = interfaceId,
                            Operate = (int) OrderTypeEnum.ReturnTickets,
                            OperateTime = order.CreateTime
                        };
                        _orderOperateServerBll.AddOrder(orderOperate);
                    }
                }
                else
                {
                    //3.2失败
                    if (traInterFaceOrderModel.Status == (int) OrderTypeEnum.TicketSuccess)
                    {
                        TraInterFaceOrderModel order = new TraInterFaceOrderModel()
                        {
                            CreateTime = DateTime.Now,
                            OrderId = refundOrderId.ToString(),
                            Status = (int) OrderTypeEnum.ReturnTicketsFail,
                            Transactionid = obj.transactionid
                        };
                        int interfaceId = _interFaceOrderServerBll.AddOrder(order);
                        TraOrderOperateModel orderOperate = new TraOrderOperateModel()
                        {
                            AfterOperateStatus = (int) OrderTypeEnum.ReturnTicketsFail,
                            InterfaceId = interfaceId,
                            Operate = (int) OrderTypeEnum.ReturnTicketsFail,
                            OperateTime = order.CreateTime
                        };
                        _orderOperateServerBll.AddOrder(orderOperate);
                    }
                }

                scope.Complete();
            }




            return ticketRefund;
        }

        public TraRequestChangeResponseModel DoRequestChange(TraRequestChangeModel obj, int modOrderId = 0)
        {
            var stm = obj;
            if (string.IsNullOrEmpty(obj.orderid))
                throw new Exception("请传入订单号");
            if (string.IsNullOrEmpty(obj.transactionid))
            {
                TraInterFaceOrderModel traInterFaceOrderModel = _interFaceOrderServerBll.GetOrderByOrderId(obj.orderid);
                if (traInterFaceOrderModel == null)
                {
                    throw new Exception("未查询到" + obj.orderid + "对应的接口订单信息");
                }
                obj.transactionid = traInterFaceOrderModel.Transactionid;
            }

            obj.callbackurl = _requestChangeServer.CallBackUrl;
            BaseInputModelHelper<TraRequestChangeModel>.SupplementInPutModel(stm, "train_request_change");
            string jsonstr = "jsonStr=" + JsonHelper.SerializeObject(stm);
            _requestChangeServer.Data = jsonstr;

            string isServer = AppSettingsHelper.GetAppSettings(AppSettingsEnum.IsServer);
            TraRequestChangeResponseModel requestChange = null;
            if (isServer == "T")
            {
                requestChange = _requestChangeServer.DoRequestChange();
            }
            else
            {
                requestChange = new TraRequestChangeResponseModel()
                {
                    code = 100
                };
            }

            if (requestChange.code != 100)
            {
                throw new Exception("提交改签失败" + requestChange.msg);
            }

            TransactionOptions option = new TransactionOptions().GetTransactionScope();
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                //新增退票记录
                TraInterFaceOrderModel order = new TraInterFaceOrderModel()
                {
                    CreateTime = DateTime.Now,
                    OrderId = modOrderId.ToString(),
                    Status = (int) OrderTypeEnum.ApplyRequestChange,
                    Transactionid = obj.transactionid,
                    OrderType = obj.reqtoken
                }; //
                int interfaceId = _interFaceOrderServerBll.AddOrder(order);
                TraOrderOperateModel orderOperate = new TraOrderOperateModel()
                {
                    AfterOperateStatus = (int) OrderTypeEnum.ApplyRequestChange,
                    InterfaceId = interfaceId,
                    Operate = (int) OrderTypeEnum.ApplyRequestChange,
                    OperateTime = order.CreateTime
                };
                _orderOperateServerBll.AddOrder(orderOperate);
                scope.Complete();
            }

            return requestChange; //requestChange
        }

        public TraRequestCancelResponseModel DoRequestCancel(TraRequestCancelModel obj)
        {
            var stm = obj;
            //根据改签订单号，获取改签信息
            TraModOrderModel traModOrderModel = _traModOrderBll.GetModOrderBycorderid(Convert.ToInt32(obj.orderid));
            TraInterFaceOrderModel traInterFaceOrderModel =
                _interFaceOrderServerBll.GetOrderByOrderId(traModOrderModel.CorderId.ToString());
            obj.orderid = traModOrderModel.OrderId.ToString();
            obj.transactionid = traInterFaceOrderModel.Transactionid;

            //obj.orderid = "104040";
            //obj.transactionid = "T1708197DCDF3210CCF004FFF083B601781FD9848AE";
            if (string.IsNullOrEmpty(traInterFaceOrderModel.OrderType))
                obj.reqtoken = DateTime.Now.ToString("yyyyMMddHHmmss");
            else
            {
                obj.reqtoken = traInterFaceOrderModel.OrderType;
            }

            if (traInterFaceOrderModel.Status == (int)OrderTypeEnum.RequestChangeConfirm)
            {
                return new TraRequestCancelResponseModel()
                {
                    success = false,
                    msg = "已经出票不能取消",
                    code=2000
                };
            }

            if (traInterFaceOrderModel.Status == (int)OrderTypeEnum.RequestChangeMakingTicket)
            {
                return new TraRequestCancelResponseModel()
                {
                    success = false,
                    msg = "正在出票不能取消",
                    code = 2000
                };
            }

            string isServer = AppSettingsHelper.GetAppSettings(AppSettingsEnum.IsServer);
            TraRequestCancelResponseModel requestCancel = null;
            if (isServer == "T")
            {
                BaseInputModelHelper<TraRequestCancelModel>.SupplementInPutModel(stm, "train_cancel_change");
                string jsonstr = "jsonStr=" + JsonHelper.SerializeObject(stm);
                _requestCancelServer.Data = jsonstr;
                 requestCancel = _requestCancelServer.DoRequestCancel();

            }
            else
            {
                requestCancel = new TraRequestCancelResponseModel()
                {
                    code = 100,
                    success = true
                };
            }

       
            //改签取消成功，或者失败但是是“改签票已是取消状态”和“已改签票不能取消”的都取消对应的改签订单
            if (requestCancel.code == 100 ||
                (!requestCancel.success && (requestCancel.msg == "改签票已是取消状态" || requestCancel.msg == "已改签票不能取消"))
                && traInterFaceOrderModel.Status != (int) OrderTypeEnum.RequestChangeCancel)
            {
                traModOrderModel.OrderStatus = "C";
                _traModOrderBll.UpdateModOrder(traModOrderModel, new[] {"OrderStatus"});

                int status = traInterFaceOrderModel.Status;
                traInterFaceOrderModel.Status = (int) OrderTypeEnum.RequestChangeCancel;
                _interFaceOrderServerBll.UpdateOrder(traInterFaceOrderModel, new[] {"Status"});
                TraOrderOperateModel orderOperate = new TraOrderOperateModel()
                {
                    AfterOperateStatus = (int) OrderTypeEnum.RequestChangeCancel,
                    InterfaceId = traInterFaceOrderModel.InterfaceId,
                    Operate = (int) OrderTypeEnum.RequestChangeCancel,
                    OperateTime = DateTime.Now,
                    BeforOperateStatus = status
                };
                _orderOperateServerBll.AddOrder(orderOperate);
            }





            return requestCancel;
        }

        //改签订单确认
        public TraRequestConfirmResponseModel DoRequestConfirm(TraRequestConfirmModel obj)
        {
            var stm = obj;

            TraInterFaceOrderModel traInterFaceOrderModel = _interFaceOrderServerBll.GetOrderByOrderId(obj.orderid);
            if (traInterFaceOrderModel == null)
            {
                throw new Exception("未查询到" + obj.orderid + "对应的接口订单信息");
            }
            if (traInterFaceOrderModel.CreateTime.AddMinutes(20) < DateTime.Now)
            {
                throw new Exception("该订单已经超过出票时间范围");
            }
            obj.transactionid = traInterFaceOrderModel.Transactionid;
            //根据改签订单号获取原订单号
            TraModOrderModel traModOrderModel = _traModOrderBll.GetModOrderBycorderid(Convert.ToInt32(obj.orderid));
            obj.orderid = traModOrderModel.OrderId.ToString();

            obj.callbackurl = _requestConfirmServer.CallBackUrl;
            BaseInputModelHelper<TraRequestConfirmModel>.SupplementInPutModel(stm, "train_confirm_change");
            string jsonstr = "jsonStr=" + JsonHelper.SerializeObject(stm);
            _requestConfirmServer.Data = jsonstr;

            string isServer = AppSettingsHelper.GetAppSettings(AppSettingsEnum.IsServer);
            TraRequestConfirmResponseModel requestConfirm = null;
            if (isServer=="T")
            {
                 requestConfirm = _requestConfirmServer.DoRequestConfirm();
            }
            else
            {
                requestConfirm = new TraRequestConfirmResponseModel()
                {
                    code=100,
                    success=true
                };
            }
        
            if (requestConfirm.code != 100)
            {
                throw new Exception("请求失败,错误原因：" + requestConfirm.msg);
            }

            #region 更新占位结果

            if (traInterFaceOrderModel.Status == (int) OrderTypeEnum.RequestChangeSuccess)
            {
                //根据原订单号，和改签人信息获取对应的改签订单号
                TransactionOptions option = new TransactionOptions().GetTransactionScope();
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    //更新interfaceOrder信息
                    if (requestConfirm.success)
                    {
                        traInterFaceOrderModel.Status = (int) OrderTypeEnum.RequestChangeMakingTicket;
                        traInterFaceOrderModel.OrderType = obj.reqtoken;
                        _interFaceOrderServerBll.UpdateOrder(traInterFaceOrderModel, new[] {"Status", "OrderType"});
                        TraOrderOperateModel orderOperate = new TraOrderOperateModel()
                        {
                            AfterOperateStatus = (int) OrderTypeEnum.RequestChangeMakingTicket,
                            InterfaceId = traInterFaceOrderModel.InterfaceId,
                            Operate = (int) OrderTypeEnum.RequestChangeMakingTicket,
                            OperateTime = DateTime.Now,
                            BeforOperateStatus = (int) OrderTypeEnum.RequestChangeSuccess
                        };
                        _orderOperateServerBll.AddOrder(orderOperate);

                        ModComfireEvent?.Invoke(this,
                            new TraServerEventArgs<TraRequestConfirmModel>(obj, traModOrderModel.CorderId));
                    }
                    scope.Complete();
                }
            }

            #endregion


            return requestConfirm;
        }


        public TraSearchOrderInfoResponseModel DoSearchOrderInfo(TraSearchOrderInfoModel obj)
        {
            var stm = obj;
            BaseInputModelHelper<TraSearchOrderInfoModel>.SupplementInPutModel(stm, "train_query_info");
            string jsonstr = "jsonStr=" + JsonHelper.SerializeObject(stm);
            _orderInfoServer.Data = jsonstr;
            var OrderInfo = _orderInfoServer.DoOrderInfo();

            if (OrderInfo.code != 100)
            {
                throw new Exception("请求失败,错误原因：" + OrderInfo.msg);
            }


            return OrderInfo;
        }


        /// <summary>
        /// 获取需要弥补的占位信息
        /// </summary>
        /// <returns></returns>
        public void HoldSeateMakeUpInfo(IServerDomain orderCancelDomain, IServerDomain requestCancelDomain)
        {
            List<int> statusList = new List<int>();
            statusList.Add((int) OrderTypeEnum.ApplyHoldSeat); //申请占座
            statusList.Add((int) OrderTypeEnum.HoldSeatFail); //正单占位失败
            statusList.Add((int) OrderTypeEnum.RequestChangeFail); //改签单占位失败
            statusList.Add((int) OrderTypeEnum.HoldSeatSuccess); //占位成功
            statusList.Add((int) OrderTypeEnum.RequestChangeSuccess); //改签占位成功
            statusList.Add((int) OrderTypeEnum.TicketFail); //出票失败
            List<TraInterFaceOrderModel> traInterFaceOrderModels =
                _interFaceOrderServerBll.GetOrderListByStatus(statusList, DateTime.Now.AddMinutes(-30));


            #region 任何占位失败的操作做弥补（取消订单）

            var failedModels = traInterFaceOrderModels.FindAll(
                n =>
                    n.Status == (int) OrderTypeEnum.HoldSeatFail ||
                    n.Status == (int) OrderTypeEnum.RequestChangeFail);

            if (failedModels.Count > 0)
            {
                foreach (var failedModel in failedModels)
                {
                    //一旦改签失败，则访问取消订单接口
                    if (failedModel.Status == (int) OrderTypeEnum.HoldSeatFail)
                    {
                        DoOrderCancel(failedModel, orderCancelDomain);
                    }

                    if (failedModel.Status == (int) OrderTypeEnum.RequestChangeFail)
                    {
                        DoChangeOrderCancel(failedModel, requestCancelDomain);
                    }
                }
            }

            #endregion



            #region 占位成功，但超过30分钟没出票的做取消订单操作

            var successedModels = traInterFaceOrderModels.FindAll(
                n =>
                    (n.Status == (int) OrderTypeEnum.HoldSeatSuccess ||
                     n.Status == (int) OrderTypeEnum.RequestChangeSuccess) &&
                    n.CreateTime.AddHours(30) >= DateTime.Now
                );

            if (successedModels.Count > 0)
            {
                foreach (var successedModel in successedModels)
                {
                    if (successedModel.Status == (int) OrderTypeEnum.HoldSeatSuccess)
                    {
                        DoOrderCancel(successedModel, orderCancelDomain);
                    }
                    if (successedModel.Status == (int) OrderTypeEnum.RequestChangeSuccess)
                    {
                        DoChangeOrderCancel(successedModel, requestCancelDomain);
                    }
                }
            }

            #endregion

        }

        /// <summary>
        /// 需要弥补的正在出票信息
        /// </summary>
        /// <returns></returns>
        public void PrintingMakeUp(IServerDomain requestInterfaceOrderDomain)
        {
            List<int> statusList = new List<int>();
            statusList.Add((int) OrderTypeEnum.MakingTicket); //正单正在出票
            statusList.Add((int) OrderTypeEnum.RequestChangeMakingTicket); //改签正在出票
            statusList.Add((int) OrderTypeEnum.ReturnTickets); //正在退票

            List<TraInterFaceOrderModel> traInterFaceOrderModels =
                _interFaceOrderServerBll.GetOrderListByStatus(statusList, DateTime.Now.AddMinutes(-30)); //查询半小时内依旧在出票的

            foreach (var faceOrder in traInterFaceOrderModels)
            {
                MakingPrintMakeUp(faceOrder, requestInterfaceOrderDomain);
            }
        }

        #endregion

        #region 私有方法

        private void DoOrderCancel(TraInterFaceOrderModel failedModel, IServerDomain orderCancelDomain)
        {
            TraOrderCancelResponseModel traOrderCancelResponseModel =
                orderCancelDomain.DoOrderCancel(new TraOrderCancelModel()
                {
                    transactionid = failedModel.Transactionid,
                    orderid = failedModel.OrderId,
                });
            string request = JsonConvert.SerializeObject(failedModel);
            LogHelper.WriteLog("火车正单取消请求：" + request, "MakeUp");
            string log = JsonConvert.SerializeObject(traOrderCancelResponseModel);
            LogHelper.WriteLog("火车正单取消返回" + log, "MakeUp");
        }

        private void DoChangeOrderCancel(TraInterFaceOrderModel failedModel, IServerDomain requestCancelDomain)
        {
            TraRequestCancelResponseModel traRequestCancelResponseModel =
                requestCancelDomain.DoRequestCancel(new TraRequestCancelModel()
                {
                    transactionid = failedModel.Transactionid,
                    orderid = failedModel.OrderId,
                });
            string request = JsonConvert.SerializeObject(failedModel);
            LogHelper.WriteLog("火车改签取消请求：" + request, "MakeUp");
            string log = JsonConvert.SerializeObject(traRequestCancelResponseModel);
            LogHelper.WriteLog("火车改签取消返回" + log, "MakeUp");

        }

        /// <summary>
        /// 出票弥补服务
        /// </summary>
        /// <param name="faceOrder"></param>
        /// <param name="requestInterfaceOrderDomain"></param>
        private void MakingPrintMakeUp(TraInterFaceOrderModel faceOrder, IServerDomain requestInterfaceOrderDomain)
        {
            TraSearchOrderInfoResponseModel traSearchOrderInfoResponseModel = null;

            if (faceOrder.Status == (int) OrderTypeEnum.MakingTicket)
            {
                traSearchOrderInfoResponseModel =
                    requestInterfaceOrderDomain.DoSearchOrderInfo(new TraSearchOrderInfoModel()
                    {
                        transactionid = faceOrder.Transactionid,
                        orderid = faceOrder.OrderId
                    });

                int printCount = traSearchOrderInfoResponseModel.ticketstatus.FindAll(n => n.status == "已出票").Count;
                //1.如果还没出票，提醒
                if (printCount == 0)
                {
                    EmailHelper.SendEmail("", faceOrder.OrderId + "超过半小时没出票", null, null, "", _email);
                }
                //2.已经出票，提醒
                if (printCount > 0)
                {
                    EmailHelper.SendEmail("", faceOrder.OrderId + "已经出票了，但是没有收到出票回执", null, null, "", _email);
                }
            }

            if (faceOrder.Status == (int) OrderTypeEnum.RequestChangeMakingTicket)
            {

                var traModOrder = _traModOrderBll.GetModOrderBycorderid(Convert.ToInt32(faceOrder.OrderId));
                traSearchOrderInfoResponseModel =
                    requestInterfaceOrderDomain.DoSearchOrderInfo(new TraSearchOrderInfoModel()
                    {
                        transactionid = faceOrder.Transactionid,
                        orderid = traModOrder.OrderId.ToString()
                    });
                int printCount = traSearchOrderInfoResponseModel.ticketstatus.FindAll(n => n.status == "已在线改签").Count;

                //1.如果还没在线改签，提醒
                if (printCount == 0)
                {
                    EmailHelper.SendEmail("", "改签单：" + traModOrder.Coid + "超过半小时没出票", null, null, "", _email);
                }
                //2.已经在线改签，提醒
                if (printCount > 0)
                {
                    EmailHelper.SendEmail("", "改签单：" + traModOrder.Coid + "已经出票了，但是没有收到出票回执", null, null, "", _email);
                }
            }
            if (faceOrder.Status == (int) OrderTypeEnum.ReturnTickets)
            {
                var traRetOrder = _orderBll.GetOrderByOrderId(Convert.ToInt32(faceOrder.OrderId));
                traSearchOrderInfoResponseModel =
                    requestInterfaceOrderDomain.DoSearchOrderInfo(new TraSearchOrderInfoModel()
                    {
                        transactionid = faceOrder.Transactionid,
                        orderid = traRetOrder.OrderRoot.ToString()
                    });
                int refundCount = traSearchOrderInfoResponseModel.ticketstatus.FindAll(n => n.status == "已在线退票").Count;
                //1.如果还没在线退票，提醒
                if (refundCount == 0)
                {
                    EmailHelper.SendEmail("", traRetOrder.RefundOrderId + "超过半小时没退票成功", null, null, "", _email);
                }
                //2.已经在线退票，提醒
                if (refundCount > 0)
                {
                    EmailHelper.SendEmail("", traRetOrder.RefundOrderId + "已经退票成功，但是没有收到退票回执", null, null, "", _email);
                }
            }
        }

        private bool CheckSendEmailCache(TrainMakeUpSendEmailModel model)
        {
            if (model.SendCount > 1)
            {
                if (model.SendTime.AddHours(1) > DateTime.Now)
                    return false;
            }

            model.SendTime = DateTime.Now;
            model.SendCount = model.SendCount + 1;
            return true;
        }

        #endregion


    }
}
