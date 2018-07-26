using System;
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
using Mzl.DomainModel.Train.Order;
using Mzl.IBLL.Train.Order.BLL;
using Mzl.IBLL.Customer.CostCenter.BLL;
using Mzl.DomainModel.Customer.CostCenter;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.IBLL.Customer.ProjectName.BLL;
using System.Transactions;
using Mzl.BLL.Train.Order.BLL;
using System.Linq;
using Mzl.Common.EnumHelper;
using Mzl.IBLL.Customer.Customer.BLL;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Enum;
using Mzl.DomainModel.Events;
using Mzl.Common.TransactionOptionsHelper;
using Mzl.IBLL.Train.Order.Factory;
using Mzl.BLL.Train.Order.Factory;
using System.Configuration;
using System.Text;
using Mzl.DomainModel.Train.BaseMaintenance;
using Mzl.IBLL.Train.BaseMaintenance.Bll;
using Mzl.DomainModel.Common.Account;
using Mzl.DomainModel.Customer.ContactInfo;
using System.Threading;
using System.Text.RegularExpressions;
using Mzl.Common.RegexHelper;
using Mzl.Application.Train.Order.Analysis;
using Mzl.Common.ConfigHelper;
using Mzl.IBLL.Customer.Customer;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.IBLL.Customer.Corp.BLL;
using Mzl.DomainModel.Customer.Corp;
using Mzl.BLL.Customer.Corp.BLL;
using Mzl.BLL.Customer.CorpAduit;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.Common.EnumHelper.CorpAduit;

namespace Mzl.Application.Train.Order.Domain
{
    /// <summary>
    /// 火车票业务实现
    /// </summary>
    internal class OrderDomain : IOrderDomain
    {
        #region 私有字段
        /// <summary>
        /// 正单/退单Bll
        /// </summary>
        private readonly ITraOrderBLL<TraOrderModel> _orderBll;
        /// <summary>
        /// 正单/退单状态Bll
        /// </summary>
        private readonly ITraOrderStatusBLL<TraOrderStatusModel> _orderStatusBll;
        /// <summary>
        /// 正单/退单行程Bll
        /// </summary>
        private readonly ITraOrderDetailBLL<TraOrderDetailModel> _orderDetailBll;
        /// <summary>
        /// 正单/退单乘车人Bll
        /// </summary>
        private readonly ITraPassengerBLL<TraPassengerModel> _passengerBll;
        /// <summary>
        /// 正单/退单列表Bll
        /// </summary>
        private readonly ITraOrderListBLL<TraOrderListDataModel> _orderListBll;
        /// <summary>
        /// 客户Bll
        /// </summary>
        private readonly ICustomerBLL<CustomerInfoModel> _customerBll;

        private readonly ICorporationBLL<CorporationModel> _corporationBll;
        /// <summary>
        /// 项目信息Bll
        /// </summary>
        private readonly IProjectNameBLL<ProjectNameModel> _projectNameBll;
        /// <summary>
        /// 改签Bll
        /// </summary>
        private readonly ITraModOrderBLL<TraModOrderModel> _traModOrderBll;
        /// <summary>
        /// 改签行程Bll
        /// </summary>
        private readonly ITraModOrderDetailBLL<TraModOrderDetailModel> _traModOrderDetailBll;
        /// <summary>
        /// 接口订单Bll
        /// </summary>
        private readonly ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> _traInterFaceOrderServerBll;
        /// <summary>
        /// 改签列表Bll
        /// </summary>
        private readonly ITraOrderListBLL<TraModOrderListDataModel> _traModOrderListBll;
        /// <summary>
        /// 正单/退单日志Bll
        /// </summary>
        private readonly ITraOrderLogBLL<TraOrderLogModel> _traOrderLogBll;
        /// <summary>
        /// 12306帐号信息Bll
        /// </summary>
        private readonly ITra12306AccountBll<Tra12306AccountModel> _tra12306AccountBll;

        private readonly IAddSendAppMessageServiceBll _addSendAppMessageServiceBll;

        private readonly IGetCorpAduitOrderServiceBll _getCorpAduitOrderServiceBll;
        #endregion

        #region 事件
        public event EventHandler<TraServerEventArgs<TraOrderSubmitModel>> ServerOrderSubmit;
        public event EventHandler<TraServerEventArgs<TraTicketRefundModel>> ServerRefundSubmit;
        public event EventHandler<TraServerEventArgs<TraRequestChangeModel>> ServerModSubmit;
        public event EventHandler<CommonEventArgs<AccountDetailModel>> PaySupplierEvent;
        public event EventHandler<CommonEventArgs<AccountDetailModel>> CollectSupplierEvent;
        public event EventHandler<CommonEventArgs<List<ContactInfoModel>>> AddContactEvent;
        #endregion

        #region 事件监听
        public void DoTraHoldSeatCallBackEvent(object o, TraServerEventArgs<TraHoldSeatCallBackLogModel> e)
        {
            //更新订单信息
            TransactionOptions option = new TransactionOptions().GetTransactionScope();
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                TraHoldSeatCallBackLogModel traInterFaceOrderModel = e.Obj;//占位成功信息
                //根据回调中的系统订单号，获取火车订单详情信息
                TraOrderModel traOrderModel = _orderBll.GetOrderByOrderId(Convert.ToInt32(traInterFaceOrderModel.Orderid));
                List<TraOrderDetailModel> traOrderDetailModels = _orderDetailBll.GetOrderDetailListByOrderId(traOrderModel.OrderId);

                List<int> odIdList = new List<int>();
                foreach (var detail in traOrderDetailModels)
                {
                    detail.OrderId12306 = e.Obj.OrderNumber;
                    odIdList.Add(detail.OdId);
                }
                List<TraPassengerModel> passengerModels = _passengerBll.GetPassengerListByOdId(odIdList);//订单乘车人信息

                decimal totalMoney = 0;
                decimal totalFacePrice = 0;
                foreach (var p in passengerModels)
                {
                    TraOrderSubmitPassengerModel pp = traInterFaceOrderModel.Passengers.Find(n => n.passportseno == p.CardNo);
                    p.PlaceCar = !string.IsNullOrEmpty(pp.cxin) ? pp.cxin.Split(',')[0] : "";
                    p.PlaceSeatNo = !string.IsNullOrEmpty(pp.cxin) ? pp.cxin.Split(',')[1] : "";
                    p.TicketNo = pp.ticket_no;
                    p.PlaceGrade = pp.zwname;
                    p.FacePrice = Convert.ToDecimal(pp.price);
                    totalMoney+= Convert.ToDecimal(pp.price);
                    totalFacePrice+= Convert.ToDecimal(pp.price);
                    if (p.ServiceFee.HasValue)
                        totalMoney += p.ServiceFee.Value;
                }
                //重新计算价格
                traOrderModel.TotalMoney = totalMoney;
                traOrderModel.PayAmount = traOrderModel.TotalMoney;
                traOrderModel.OrderType = 0;
                traOrderModel.TransactionId = e.Obj.Transactionid;

                foreach (var detail in traOrderDetailModels)
                {
                    detail.FacePrice = (totalFacePrice / detail.TicketNum);
                    detail.TotalPrice = totalFacePrice + (detail.ServiceFee*detail.TicketNum);
                    odIdList.Add(detail.OdId);
                }

                _orderBll.UpdateOrder(traOrderModel, new[] {"TotalMoney", "PayAmount", "OrderType", "TransactionId"});//更新订单
                //traOrderDetailModels[0].OrderId
                _orderDetailBll.UpdateOrderDetail(traOrderDetailModels,
                    new[] {"OrderId12306", "FacePrice", "TotalPrice"});//更新行程
                _passengerBll.UpdatePassengerList(passengerModels, new[] { "PlaceCar", "PlaceSeatNo", "TicketNo", "PlaceGrade", "FacePrice" });//更新乘车人

                scope.Complete();
            }

        }
        public void DoOrderConfirmEvent(object o, TraServerEventArgs<TraOrderConfirmModel> e)
        {
            //更新系统订单的状态为0，并且设置已付款，已采购
            _orderBll.UpdateOrder(new TraOrderModel()
            {
                OrderId = Convert.ToInt32(e.Obj.orderid),
                OrderType = 0
            }, new[] { "OrderType"});

        }
        public void RefundTicketCallBackEvent(object o, TraServerEventArgs<TraRefundTicketCallBackLogModel> e)
        {
            //1.根据正单号+退票人，找到正单对应的退单信息
            TraRefundTicketCallBackLogModel refundTicketCallBackModel = e.Obj;
            List<string> ticketNoList =
                (from t in refundTicketCallBackModel.ReturnTickets
                    where !string.IsNullOrEmpty(t.ReturnSuccess) && t.ReturnSuccess.ToLower() == "true"
                    select t.Ticket_No)
                    .ToList();

            TraOrderModel retOrderModel = null;
            List< TraOrderModel> retOrderModelList =
                _orderBll.GetTraRetOrderListByOrderRootAndTicketNo(Convert.ToInt32(refundTicketCallBackModel.ApiorderId),
                    ticketNoList);
            if (retOrderModelList != null && retOrderModelList.Count > 0)
                retOrderModel = retOrderModelList.Find(n => !n.IsModRefund.HasValue || !n.IsModRefund.Value);

            if (retOrderModel!=null)
            {
                TraOrderStatusModel traOrderStatusModel = _orderStatusBll.GetOrderStatusByOrderId(retOrderModel.OrderId);
                if ((traOrderStatusModel.ProccessStatus & 1)==1)
                {
                    return;
                }

                //更新供应商退款金额
                List<TraOrderDetailModel> traOrderDetailModels =
                    _orderDetailBll.GetOrderDetailListByOrderId(retOrderModel.OrderId);
                foreach (var d in traOrderDetailModels)
                {
                    d.SupplierMoney = string.IsNullOrEmpty(refundTicketCallBackModel.ReturnTickets[0].ReturnMoney)
                        ? 0
                        : Convert.ToDecimal(refundTicketCallBackModel.ReturnTickets[0].ReturnMoney);//供应商退款 正值
                    d.RefundFee = (d.FacePrice*-1 - d.SupplierMoney);//退票费正值
                    d.TotalPrice = (d.SupplierMoney ?? 0)*-1; //小计 负值
                }
               
                TransactionOptions option = new TransactionOptions().GetTransactionScope();
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    _orderBll.UpdateOrder(new TraOrderModel()
                    {
                        OrderId = retOrderModel.OrderId,
                        TotalMoney = traOrderDetailModels.Sum(n => n.TotalPrice),
                        PayAmount = -1*traOrderDetailModels.Sum(n => n.TotalPrice)
                    }, new[] {"TotalMoney", "PayAmount"});
                    _orderDetailBll.UpdateOrderDetail(traOrderDetailModels,
                        new[] { "RefundFee", "SupplierMoney", "TotalPrice" });
                    
                    //更新已退票
                    _orderStatusBll.UpdateOrderStatus(new TraOrderStatusModel()
                    {
                        Sid = traOrderStatusModel.Sid,
                        ProccessStatus = traOrderStatusModel.ProccessStatus+64,
                        Status4 = 1,
                        WaitHandle = 1
                    }, new[] {"ProccessStatus", "Status4", "WaitHandle"});
                    //CollectSupplierEvent?.Invoke(this, new CommonEventArgs<AccountDetailModel>(new AccountDetailModel()
                    //{
                    //    Aid = 81,
                    //    Amount = traOrderDetailModels.Sum(n => n.SupplierMoney ?? 0),
                    //    Detailtype = "火车票收供应商款",
                    //    Oid = "sys",
                    //    CreateTime = DateTime.Now,
                    //    Source = "火车票收供应商款",
                    //    OrderId = traOrderStatusModel.OrderId,
                    //    OrderType = "Tra",
                    //    Provider = 0,
                    //    CollectionRemark = "",
                    //    EstimateId = 0
                    //}));
                    _traOrderLogBll.AddLog(new TraOrderLogModel()
                    {
                        OrderId = retOrderModel.OrderId,
                        CreateOid = string.IsNullOrEmpty(retOrderModel.CreateOid)?"sys": retOrderModel.CreateOid,
                        CreateTime = DateTime.Now,
                        LogType = "修改",
                        LogContent = "线上退票成功，自动设置已处理、已退票、已申请退票打印"
                    });

                    //发送app退票信息
                    _addSendAppMessageServiceBll.AddAppPrintTicketMessage(new SendAppMessageModel()
                    {
                        OrderId = retOrderModel.OrderId,
                        Cid = retOrderModel.Cid,
                        OrderType = OrderSourceTypeEnum.TraRet,
                        SendType = SendAppMessageTypeEnum.RefundedCustomerNotice
                    });

                    scope.Complete();
                }
            }

        }
        public void DoModCallBackEvent(object o, TraServerEventArgs<TraModHoldSeatCallBackLogModel> e)
        {
            TransactionOptions option = new TransactionOptions().GetTransactionScope();
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                TraModOrderModel traModOrderModel = _traModOrderBll.GetModOrderBycorderid(e.RefundOrderId);//改签订单信息
                List<TraModOrderDetailModel> traModOrderDetailModels =
                    _traModOrderDetailBll.GetTraModOrderDetailListByCorderid(traModOrderModel.CorderId);//改签乘车人信息

                TraOrderModel traOrderModel= _orderBll.GetOrderByOrderId(traModOrderModel.OrderId.Value);//原订单信息
                List<TraOrderDetailModel> oldOrderDetailModels =
                    _orderDetailBll.GetOrderDetailListByOrderId(traModOrderModel.OrderId.Value);//原订单行程信息
                List<int> odIdList = new List<int>();
                oldOrderDetailModels.ForEach(n => odIdList.Add(n.OdId));
                List<TraPassengerModel> oldTraPassengerModels = _passengerBll.GetPassengerListByOdId(odIdList);//原订单乘车人信息

                foreach (var detail in oldOrderDetailModels)
                {
                    detail.PassengerList = oldTraPassengerModels.FindAll(n => n.OdId == detail.OdId);
                }

                decimal totalFacePrice = 0;
                #region 更新改签订单信息，价格，更新票号，更新坐席

                foreach (var p in traModOrderDetailModels)
                {
                    TraPassengerModel pp = oldTraPassengerModels.Find(n => n.Pid.ToString() == p.Pid);//原订单
                    var ppp = e.Obj.newtickets.Find(n => n.passportseno == pp.CardNo);//改签后的信息
                    p.PlaceGrade = ppp.zwname;
                    p.TrainMoney = Convert.ToDecimal(ppp.price);
                    p.SumPrice = p.TrainMoney; 
                    p.PlaceCar = string.IsNullOrEmpty(ppp.cxin) && ppp.cxin.Split(',').Length == 2 ? "" : ppp.cxin.Split(',')[0];
                    p.PlaceSeatNo = string.IsNullOrEmpty(ppp.cxin) && ppp.cxin.Split(',').Length == 2 ? "" : ppp.cxin.Split(',')[1];
                    p.TicketNo = ppp.new_ticket_no;
                    totalFacePrice += p.SumPrice ?? 0;
                }
                traModOrderModel.OrderStatus = "W";
                traModOrderModel.PayAmount = totalFacePrice;
                traModOrderModel.CreateOid = traOrderModel.CreateOid;
                _traModOrderBll.UpdateModOrder(traModOrderModel, new[] {"OrderStatus", "PayAmount", "CreateOid"});
                _traModOrderDetailBll.UpdateTraModOrderDetail(traModOrderDetailModels,
                    new[] { "PlaceGrade", "TrainMoney", "SumPrice", "PlaceCar", "PlaceSeatNo", "TicketNo" });
                #endregion

                #region 新增一张临时的退票单信息，一旦确认改签出票后，则变成正式的退票信息
                /*
                 * 注意：改签分为高价格改低价格，和低价格改高价格，和平价改签三种
                 * 1.低价格改高价格：第三方接口会原订单退全价，同时再收改签单的面价，此时退票信息的价格应该是原订单乘车人价格*-1
                 * 2.高价格改低价格：第三方接口会返回一个差价和实际价格，实际价格和差价是可能存在差异的；
                 *    一旦有差异，这个差异价格就是改签手续费，退票价格应该是原订单乘车人的价格-这个差异价格
                 * 3.平价改签：参考高价格改低价格
                 * 
                 * 其实说白了就是原定的乘车人价格-改签手续费，然后再取反，当作退票单的价格。。。。
                 */
                AddRetOrderOnMod(traModOrderModel, traModOrderDetailModels, oldOrderDetailModels, oldTraPassengerModels,
                    Convert.ToDecimal(e.Obj.fee),TraOrderFromEnum.Interface.ToString());

                #endregion




                scope.Complete();
            }
           
        }
        public void DoModComfireEvent(object o, TraServerEventArgs<TraRequestConfirmModel> e)
        {
            //更新改签订单状态 
            TraModOrderModel traModOrderModel = _traModOrderBll.GetModOrderBycorderid(e.RefundOrderId);
            traModOrderModel.OrderStatus = "W";
            //traModOrderModel.ProcessStatus = "ACH";
            _traModOrderBll.UpdateModOrder(traModOrderModel, new[] {"OrderStatus"});
        }
        public void DoModPrintTicketEvent(object o, TraServerEventArgs<TraModPrintTicketCallBackLogModel> e)
        {
            //将改签订单中，原订单对应的乘车人的临时退票单，改为正式退票订单，并且勾已退票，已收供应商款，已付客户款，已记账
            TraModPrintTicketCallBackLogModel modTicketCallBackModel = e.Obj;

            List<TraOrderModel> retOrderModels = _orderBll.GetRetOrderByRootOrderId(Convert.ToInt32(modTicketCallBackModel.orderid));
            if(retOrderModels==null|| retOrderModels.Count==0)
                throw new Exception("查询订单异常");
            TraModOrderModel traModOrderModel = _traModOrderBll.GetModOrderBycorderid(e.RefundOrderId);//改签单信息
            TraOrderModel retOrderModel =
                retOrderModels.Find(n => n.CorderId == traModOrderModel.CorderId && n.OrderType == 3);//改签对应的退票单
         
            if (retOrderModel != null)
            {
                TraOrderStatusModel traOrderStatusModel = _orderStatusBll.GetOrderStatusByOrderId(retOrderModel.OrderId);
                if ((traOrderStatusModel.ProccessStatus & 1) == 1)
                {
                    return;
                }
                //var traRetOrder = _orderBll.GetOrderByOrderId(traOrderStatusModel.OrderId);
                TransactionOptions option = new TransactionOptions().GetTransactionScope();
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    //改为正式退票订单，并且勾已退票，已收供应商款，已付客户款，已记账
                    _orderBll.UpdateOrder(new TraOrderModel()
                    {
                        OrderId = retOrderModel.OrderId,
                        OrderType = 2
                    }, new[] {"OrderType"});

                    _orderStatusBll.UpdateOrderStatus(new TraOrderStatusModel()
                    {
                        Sid = traOrderStatusModel.Sid,
                        ProccessStatus = traOrderStatusModel.ProccessStatus + 64, 
                        Status4 = 1, //已退票
                        WaitHandle = 1 //申请退票打印
                    },
                        new[] {"ProccessStatus", "Status4", "WaitHandle"});


                    _traOrderLogBll.AddLog(new TraOrderLogModel()
                    {
                        OrderId = retOrderModel.OrderId,
                        CreateOid = string.IsNullOrEmpty(retOrderModel.CreateOid) ? "sys" : retOrderModel.CreateOid,
                        CreateTime = DateTime.Now,
                        LogType = "修改",
                        LogContent = "线上火车票改签，自动生成退票单，并且设置已处理、已退票"
                    });

                    //更新改签订单状态 
                    traModOrderModel.ProcessStatus = "ACH";
                    traModOrderModel.OrderStatus = "P";
                    _traModOrderBll.UpdateModOrder(traModOrderModel,
                        new[] { "ProcessStatus", "OrderStatus" });

                    //发送app出票信息
                    _addSendAppMessageServiceBll.AddAppPrintTicketMessage(new SendAppMessageModel()
                    {
                        OrderId = traModOrderModel.CorderId,
                        Cid = retOrderModel.Cid,
                        OrderType = OrderSourceTypeEnum.TraMod,
                        SendType = SendAppMessageTypeEnum.PrintTicketNotice
                    });

                    scope.Complete();
                }
            }

        }
        public void DoOrderTicketEvent(object o, TraServerEventArgs<TraPrintTicketCallBackLogModel> e)
        {
            if (e.Obj.isSuccess)//出票成功
            {
                TraOrderModel traOrderModel = _orderBll.GetOrderByOrderId(Convert.ToInt32(e.Obj.orderid));
                TraOrderStatusModel traOrderStatusModel =
                    _orderStatusBll.GetOrderStatusByOrderId(Convert.ToInt32(e.Obj.orderid));
                List<TraOrderDetailModel> traOrderDetailModels =
                    _orderDetailBll.GetOrderDetailListByOrderId(traOrderModel.OrderId);
                List<int> odIdList = new List<int>();
                traOrderDetailModels.ForEach(n => odIdList.Add(n.OdId));
                List<TraPassengerModel> passengerModels = _passengerBll.GetPassengerListByOdId(odIdList);
                if (traOrderStatusModel != null)
                {
                    bool isPrintTicket = false;
                    if ((traOrderStatusModel.ProccessStatus & 1) != 1)
                    {
                        isPrintTicket = true;
                        traOrderStatusModel.ProccessStatus = traOrderStatusModel.ProccessStatus + 1; //已付款
                    }

                    if ((traOrderStatusModel.ProccessStatus & 8) != 8)
                    {
                        traOrderStatusModel.ProccessStatus = traOrderStatusModel.ProccessStatus + 8;//已预定
                    }

                    _orderStatusBll.UpdateOrderStatus(new TraOrderStatusModel()
                    {
                        Sid = traOrderStatusModel.Sid,
                        IsBuy = 1,
                        ProccessStatus = traOrderStatusModel.ProccessStatus,
                        RealPayOid = "sys",
                        RealPayDatetime = DateTime.Now
                    }, new[] { "IsBuy", "ProccessStatus", "RealPayOid", "RealPayDatetime" });

                    if (isPrintTicket)
                    {
                        //更新账户信息
                        PaySupplierEvent?.Invoke(this, new CommonEventArgs<AccountDetailModel>(new AccountDetailModel()
                        {
                            Aid = 81,
                            Amount = passengerModels.Sum(n => n.FacePrice ?? 0),
                            Detailtype = "火车票付票款",
                            Oid = "sys",
                            CreateTime = DateTime.Now,
                            Source = "火车票付票款",
                            OrderId = traOrderStatusModel.OrderId,
                            OrderType = "Tra",
                            Provider = 0,
                            CollectionRemark = "",
                            EstimateId = 0
                        }));
                        //记录日志
                        _traOrderLogBll.AddLog(new TraOrderLogModel()
                        {
                            OrderId = traOrderStatusModel.OrderId,
                            CreateOid = "sys",
                            CreateTime = DateTime.Now,
                            LogContent = "接口出票回调，自动勾已预定、已付票款、已采购",
                            LogType = "修改"
                        });

                        //发送app出票信息
                        _addSendAppMessageServiceBll.AddAppPrintTicketMessage(new SendAppMessageModel()
                        {
                            OrderId = traOrderModel.OrderId,
                            Cid= traOrderModel.Cid,
                            OrderType = OrderSourceTypeEnum.Tra,
                            SendType = SendAppMessageTypeEnum.PrintTicketNotice
                        });
                    }

                }
            }
        }

        #endregion

        #region 构造方法

        public OrderDomain()
        {
        }

        public OrderDomain(ITraOrderListBLL<TraOrderListDataModel> orderListBll, ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll,
            ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll, ITraPassengerBLL<TraPassengerModel> passengerBll
            , IProjectNameBLL<ProjectNameModel> projectNameBll, ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> traInterFaceOrderServerBll,
             ITraModOrderBLL<TraModOrderModel> traModOrderBll, ITraOrderBLL<TraOrderModel> orderBll)
        {
            _orderListBll = orderListBll;
            _orderStatusBll = orderStatusBll;
            _orderDetailBll = orderDetailBll;
            _passengerBll = passengerBll;
            _projectNameBll = projectNameBll;
            _traInterFaceOrderServerBll = traInterFaceOrderServerBll;
            _traModOrderBll = traModOrderBll;
            _orderBll = orderBll;
        }

        public OrderDomain(ITraOrderListBLL<TraOrderListDataModel> orderListBll, ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll,
           ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll, ITraPassengerBLL<TraPassengerModel> passengerBll
           , IProjectNameBLL<ProjectNameModel> projectNameBll, ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> traInterFaceOrderServerBll)
        {
            _orderListBll = orderListBll;
            _orderStatusBll = orderStatusBll;
            _orderDetailBll = orderDetailBll;
            _passengerBll = passengerBll;
            _projectNameBll = projectNameBll;
            _traInterFaceOrderServerBll = traInterFaceOrderServerBll;
        }

        public OrderDomain(ITraOrderBLL<TraOrderModel> orderBll, ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll,
           ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll, ITraPassengerBLL<TraPassengerModel> passengerBll,
           ITraOrderLogBLL<TraOrderLogModel> traOrderLogBll, ITraModOrderBLL<TraModOrderModel> traModOrderBll,
           IAddSendAppMessageServiceBll addSendAppMessageServiceBll)
        {
            _orderBll = orderBll;
            _orderStatusBll = orderStatusBll;
            _orderDetailBll = orderDetailBll;
            _passengerBll = passengerBll;
            _traOrderLogBll = traOrderLogBll;
            _traModOrderBll = traModOrderBll;
            _addSendAppMessageServiceBll = addSendAppMessageServiceBll;
        }

        public OrderDomain(ITraOrderBLL<TraOrderModel> orderBll, ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll,
           ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll, ITraPassengerBLL<TraPassengerModel> passengerBll,
           ITraOrderLogBLL<TraOrderLogModel> traOrderLogBll, ICustomerBLL<CustomerInfoModel> customerBll,
            ICorporationBLL<CorporationModel> corporationBll)
        {
            _orderBll = orderBll;
            _orderStatusBll = orderStatusBll;
            _orderDetailBll = orderDetailBll;
            _passengerBll = passengerBll;
            _traOrderLogBll = traOrderLogBll;
            _customerBll = customerBll;
            _corporationBll = corporationBll;
        }

        public OrderDomain(ITraOrderBLL<TraOrderModel> orderBll, ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll,
          ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll, ITraPassengerBLL<TraPassengerModel> passengerBll,
          ITraOrderLogBLL<TraOrderLogModel> traOrderLogBll, ITraModOrderBLL<TraModOrderModel> traModOrderBll,
           ITraModOrderDetailBLL<TraModOrderDetailModel> traModOrderDetailBll)
        {
            _orderBll = orderBll;
            _orderStatusBll = orderStatusBll;
            _orderDetailBll = orderDetailBll;
            _passengerBll = passengerBll;
            _traOrderLogBll = traOrderLogBll;
            _traModOrderBll = traModOrderBll;
            _traModOrderDetailBll = traModOrderDetailBll;

        }

        public OrderDomain(ITraOrderBLL<TraOrderModel> orderBll, ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll,
            ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll, ITraPassengerBLL<TraPassengerModel> passengerBll,
             ITraModOrderBLL<TraModOrderModel> traModOrderBll, ITraOrderLogBLL<TraOrderLogModel> traOrderLogBll,
             ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> traInterFaceOrderServerBll, ITraModOrderDetailBLL<TraModOrderDetailModel> traModOrderDetailBll)
        {
            _orderBll = orderBll;
            _orderStatusBll = orderStatusBll;
            _orderDetailBll = orderDetailBll;
            _passengerBll = passengerBll;
            _traModOrderBll = traModOrderBll;
            _traOrderLogBll = traOrderLogBll;
            _traInterFaceOrderServerBll = traInterFaceOrderServerBll;
            _traModOrderDetailBll = traModOrderDetailBll;
        }

        public OrderDomain(ITraOrderBLL<TraOrderModel> orderBll, ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll,
           ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll, ITraPassengerBLL<TraPassengerModel> passengerBll,
           ICustomerBLL<CustomerInfoModel> customerBll, IProjectNameBLL<ProjectNameModel> projectNameBll,
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> traInterFaceOrderServerBll)
        {
            _orderBll = orderBll;
            _orderStatusBll = orderStatusBll;
            _orderDetailBll = orderDetailBll;
            _passengerBll = passengerBll;
            _customerBll = customerBll;
            _projectNameBll = projectNameBll;
            _traInterFaceOrderServerBll = traInterFaceOrderServerBll;
        }

        public OrderDomain(ITraOrderBLL<TraOrderModel> orderBll, ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll,
           ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll, ITraPassengerBLL<TraPassengerModel> passengerBll,
           ICustomerBLL<CustomerInfoModel> customerBll, IProjectNameBLL<ProjectNameModel> projectNameBll,
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> traInterFaceOrderServerBll, ITraModOrderBLL<TraModOrderModel> traModOrderBll,
             ITraModOrderDetailBLL<TraModOrderDetailModel> traModOrderDetailBll, IGetCorpAduitOrderServiceBll getCorpAduitOrderServiceBll)
        {
            _orderBll = orderBll;
            _orderStatusBll = orderStatusBll;
            _orderDetailBll = orderDetailBll;
            _passengerBll = passengerBll;
            _customerBll = customerBll;
            _projectNameBll = projectNameBll;
            _traInterFaceOrderServerBll = traInterFaceOrderServerBll;
            _traModOrderBll = traModOrderBll;
            _traModOrderDetailBll = traModOrderDetailBll;
            _getCorpAduitOrderServiceBll = getCorpAduitOrderServiceBll;
        }

        public OrderDomain(ITraOrderBLL<TraOrderModel> orderBll, ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll,
          ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll, ITraPassengerBLL<TraPassengerModel> passengerBll,
          ITraModOrderBLL<TraModOrderModel> traModOrderBll, ITraModOrderDetailBLL<TraModOrderDetailModel> traModOrderDetailBll)
        {
            _orderBll = orderBll;
            _orderStatusBll = orderStatusBll;
            _orderDetailBll = orderDetailBll;
            _passengerBll = passengerBll;
            _traModOrderBll = traModOrderBll;
            _traModOrderDetailBll = traModOrderDetailBll;
        }
        public OrderDomain(ITraOrderBLL<TraOrderModel> orderBll, ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll,
           ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll, ITraPassengerBLL<TraPassengerModel> passengerBll,
           ITraModOrderBLL<TraModOrderModel> traModOrderBll, ITraModOrderDetailBLL<TraModOrderDetailModel> traModOrderDetailBll,
           ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> traInterFaceOrderServerBll, ITraOrderLogBLL<TraOrderLogModel> traOrderLogBll,
           ICorporationBLL<CorporationModel> corporationBll, ICustomerBLL<CustomerInfoModel> customerBll)
        {
            _orderBll = orderBll;
            _orderStatusBll = orderStatusBll;
            _orderDetailBll = orderDetailBll;
            _passengerBll = passengerBll;
            _traModOrderBll = traModOrderBll;
            _traModOrderDetailBll = traModOrderDetailBll;
            _traInterFaceOrderServerBll = traInterFaceOrderServerBll;
            _traOrderLogBll = traOrderLogBll;
            _corporationBll = corporationBll;
            _customerBll = customerBll;
        }

        public OrderDomain(ITraOrderListBLL<TraModOrderListDataModel> traModOrderListBll,
             ITraModOrderDetailBLL<TraModOrderDetailModel> traModOrderDetailBll,
              ITraPassengerBLL<TraPassengerModel> passengerBll)
        {
            _traModOrderListBll = traModOrderListBll;
            _traModOrderDetailBll = traModOrderDetailBll;
            _passengerBll = passengerBll;
        }

        public OrderDomain(ITraModOrderBLL<TraModOrderModel> traModOrderBll,
            ITraModOrderDetailBLL<TraModOrderDetailModel> traModOrderDetailBll,
             ITraPassengerBLL<TraPassengerModel> passengerBll, ITraOrderBLL<TraOrderModel> orderBll)
        {
            _traModOrderBll = traModOrderBll;
            _traModOrderDetailBll = traModOrderDetailBll;
            _passengerBll = passengerBll;
            _orderBll = orderBll;
        }

        public OrderDomain(ITra12306AccountBll<Tra12306AccountModel> tra12306AccountBll)
        {
            _tra12306AccountBll = tra12306AccountBll;
        }

        #endregion

        #region 公共方法

        #region 正单
        public int AddOrder(TraAddOrderModel newOrder)
        {
            int orderid = 0;
            //如果存在项目名称
            if (newOrder.ProjectName != null && newOrder.ProjectName.ProjectId > 0)
            {
                newOrder.Order.ProjectId = newOrder.ProjectName.ProjectId;
            }

            if (newOrder.CostCenter != null && newOrder.CostCenter.Cid > 0)
            {
                newOrder.Order.CostCenter = newOrder.CostCenter.Depart;
            }
            else
            {
                newOrder.Order.CostCenter = "";
            }
            if (newOrder.OrderStatus == null)
                newOrder.OrderStatus = new TraOrderStatusModel();

            TransactionOptions option = new TransactionOptions().GetTransactionScope();
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                #region 创建订单主体
                newOrder.Order.OrderType = 1;
                if (newOrder.AddOrderType != 0)//非接口创建订单，直接为正单
                {
                    newOrder.Order.OrderType = 0;
                }
                newOrder.Order.TrainPlace = "代售点";
                newOrder.Order.OrderRoot = 0;
                newOrder.Order.CreateTime = DateTime.Now;
                newOrder.OrderStatus.ProccessStatus = 64;
                if (newOrder.Order.IsOnline == "T")//线上订单，不设置开始处理
                {
                    newOrder.OrderStatus.ProccessStatus = 0;
                }
                if (newOrder.AddOrderType == 0)
                {
                   
                    newOrder.Order.OrderFrom = TraOrderFromEnum.Interface.ToString();
                }
                else
                {
                    newOrder.Order.OrderFrom = TraOrderFromEnum.Hand.ToString();
                }

                if (newOrder.Order.PayAmount == 0)
                    newOrder.Order.PayAmount = newOrder.Order.TotalMoney;
                newOrder.Order.OpeartorId = newOrder.Order.CreateOid;

                CustomerInfoModel customerInfoModel = _customerBll.GetCustomerByCid(newOrder.Order.Cid);
                //结算方式+出行类别
                if (!string.IsNullOrEmpty(customerInfoModel.Category) && customerInfoModel.Category.ToUpper() == "D")
                {
                    newOrder.Order.BalanceType = 1;
                    newOrder.Order.TravelType = 0;
                    //判断是否需要打印两联单
                    if (!string.IsNullOrEmpty(customerInfoModel.CorpId) && !newOrder.Order.IsPrint.HasValue)//没有IsPrint,从公司信息中获取
                    {
                        CorporationModel corporationModel = _corporationBll.GetCorpInfoByCorpId(customerInfoModel.CorpId);
                        if (corporationModel != null && corporationModel.IsPrint.HasValue && corporationModel.IsPrint == 1)
                        {
                            newOrder.Order.IsPrint = 1;
                        }
                    }
                }
                else
                {
                    newOrder.Order.BalanceType = 0;
                    newOrder.Order.TravelType = 1;
                }

                if (!newOrder.Order.IsPrint.HasValue)
                {
                    newOrder.Order.IsPrint = 0;
                }

                newOrder.Order.OrderSource = newOrder.OrderSource;
                //ICheckSameTravelBll checkSameTravelBll= CheckSameTravelBllFactory.GetObj();
                //if (checkSameTravelBll.CheckIsExistSameTravel(newOrder))
                //{
                //    throw new Exception("存在相同行程！订单号:" + checkSameTravelBll.Result);
                //}
                orderid = _orderBll.AddOrder(newOrder.Order);
                #endregion
                #region 创建订单状态
                newOrder.OrderStatus.OrderId = orderid;
                int sid = _orderStatusBll.AddOrderStatus(newOrder.OrderStatus);
                #endregion
                #region 创建订单行程+乘车人
                foreach (var detail in newOrder.OrderDetailList)
                {
                    foreach (var p in detail.PassengerList)
                    {
                        p.ServiceFee = detail.ServiceFee;
                        p.PlaceGrade = detail.PlaceGrade;
                        p.AgeType = p.AgeType.HasValue ? p.AgeType : AgeTypeEnum.C;
                        p.FacePrice = detail.FacePrice;
                        if (p.AgeType == AgeTypeEnum.E)
                        {
                            p.FacePrice = p.FacePrice / 2;
                        }
                    }

                  

                    #region 行程
                    detail.OrderId = orderid;
                    detail.TicketNum = detail.PassengerList.Count;
                    int cTicketNum = detail.PassengerList.FindAll(n => n.AgeType == AgeTypeEnum.C).Count;//成人票数
                    int eTicketNum = detail.PassengerList.FindAll(n => n.AgeType == AgeTypeEnum.E).Count;//儿童票数

                    if (eTicketNum==0)
                    {
                        detail.TrainChdSalePrice = 0;
                    }

                    detail.TotalPrice = (detail.FacePrice*cTicketNum) + detail.ServiceFee*detail.TicketNum +
                                        (detail.TrainChdSalePrice*eTicketNum);//行程总价=成人总价+儿童总价+服务费总价

                    detail.PlaceType = GetPlaceType(detail.PlaceGrade);
                    detail.TrainNoRemark = string.IsNullOrEmpty(detail.TrainNoRemark) ? "" : detail.TrainNoRemark;
                    detail.TrainNoStatus = string.IsNullOrEmpty(detail.TrainNoStatus) ? "" : detail.TrainNoStatus;
                    //OnTrainTime
                    detail.OnTrainTimeTemp = detail.StartTime;
                    detail.StartTime = detail.OnTrainTime;
                    int odid = _orderDetailBll.AddOrderDetail(detail);
                    #endregion
                    #region 乘车人
                    List < ContactInfoModel > contactList=new List<ContactInfoModel>();
                    foreach (var p in detail.PassengerList)
                    {
                        p.OdId = odid;
                        if (!string.IsNullOrEmpty(p.Name))
                            p.Name = p.Name.Replace("/", " ");
                        //p.ServiceFee = detail.ServiceFee;
                        //p.PlaceGrade = detail.PlaceGrade;
                        //p.AgeType = p.AgeType.HasValue ? p.AgeType : AgeTypeEnum.C;
                        //p.FacePrice = detail.FacePrice;
                        //if (p.AgeType== AgeTypeEnum.E)
                        //{
                        //    p.FacePrice = p.FacePrice/2;
                        //}
                        contactList.Add(new ContactInfoModel()
                        {
                            ContactId = p.ContactId,
                            CardNo = p.CardNo,
                            CardNoType = (int) p.CardNoType,
                            CName = p.Name,
                            Mobile = p.Mobile,
                            Cid = newOrder.Order.Cid, LastUpdateTime = DateTime.Now,
                            IsDel="F",
                            IsPassenger="T",
                            UpdateOid = newOrder.Order.CreateOid,
                            DelTime = DateTime.Now
                        });
                    }
                    _passengerBll.AddPassengerList(detail.PassengerList);

                    AddContactEvent?.Invoke(this, new CommonEventArgs<List<ContactInfoModel>>(contactList));

                    #endregion
                }
                #endregion



                if (newOrder.Order.TotalMoney != newOrder.OrderDetailList.Sum(n => n.TotalPrice))
                {
                    throw new Exception("订单总价异常！");
                }



                #region 创建订单日志
                _traOrderLogBll.AddLog(new TraOrderLogModel()
                {
                    OrderId = orderid,
                    CreateOid = newOrder.Order.CreateOid,
                    CreateTime = DateTime.Now,
                    LogContent = string.Format("{0}添加火车订单 {1}", newOrder.Order.IsOnline == "T" ? "线上" : "线下", newOrder.Order.IsOnline == "T"?"":",设置开始处理"),
                    LogType = "OI"
                });
                #endregion
                #region 如果是走接口的，提交火车订单后，访问第三方接口的创建订单接口,暂时只支持单程创建订单
                if (orderid > 0 && newOrder.OrderDetailList.Count == 1 && ServerOrderSubmit != null)
                {
                    List<TraOrderSubmitPassengerModel> serverPassengerModels = new List<TraOrderSubmitPassengerModel>();
                    foreach (var p in newOrder.OrderDetailList[0].PassengerList)
                    {
                        TraOrderSubmitPassengerModel pp = new TraOrderSubmitPassengerModel();
                        pp.passengersename = p.Name;
                        pp.passportseno = p.CardNo;
                        pp.passporttypeseidname = p.CardNoType.ToDescription();
                        if (p.CardNoType == CardTypeEnum.Certificate)
                        {
                            pp.passporttypeseid = "1";
                        }
                        else if(p.CardNoType == CardTypeEnum.HongKongAndMacaoPass)
                        {
                            pp.passporttypeseid = "C";
                        }
                        else if (p.CardNoType == CardTypeEnum.Passport)
                        {
                            pp.passporttypeseid = "B";
                        }
                        else if (p.CardNoType == CardTypeEnum.TaiwanEntryPermit || p.CardNoType == CardTypeEnum.MTP)
                        {
                            pp.passporttypeseid = "G";
                            pp.passporttypeseidname = "台湾通行证";
                        }
                        //pp.passporttypeseid = ((int) p.CardNoType).ToString();
                        pp.piaotype = "1";
                        pp.ticket_no = "";
                        pp.piaotypename = "成人票";
                        pp.zwcode = newOrder.OrderDetailList[0].PlaceGradeCode;
                        pp.zwname = newOrder.OrderDetailList[0].PlaceGrade;
                        pp.cxin = "";
                        pp.price = newOrder.OrderDetailList[0].FacePrice.ToString("0.00");
                        serverPassengerModels.Add(pp);
                    }

                    TraOrderSubmitModel serverOrderSubmitModel = new TraOrderSubmitModel()
                    {
                        orderid = orderid.ToString(),
                        checi = newOrder.OrderDetailList[0].TrainNo,
                        from_station_code = newOrder.OrderDetailList[0].StartNameCode,
                        from_station_name = newOrder.OrderDetailList[0].StartName,
                        to_station_code = newOrder.OrderDetailList[0].EndNameCode,
                        to_station_name = newOrder.OrderDetailList[0].EndName,
                        train_date = newOrder.OrderDetailList[0].StartTime.ToString("yyyy-MM-dd"),
                        passengers = serverPassengerModels,
                        LoginUserName = "",
                        LoginUserPassword = "",
                        is_accept_standing = newOrder.IsAcceptStanding,
                        is_choose_seats = newOrder.IsChooseSeats,
                        choose_seats = newOrder.ChooseSeats
                    };

                    ServerOrderSubmit?.Invoke(this, new TraServerEventArgs<TraOrderSubmitModel>(serverOrderSubmitModel));
                }

                #endregion
                scope.Complete();
            }
            return orderid;
        }
        public List<TraOrderListDataModel> GetTraOrderByPageList(TraOrderListQueryModel query, ref int totalCount)
        {
            List<TraOrderListDataModel> orderDataList = _orderListBll.GetOrderListByPage(query, ref totalCount);
            if (orderDataList == null || orderDataList.Count == 0)
                return new List<TraOrderListDataModel>();
            List<int> orderIdList = new List<int>();
            List<int> projectIdList = new List<int>();
            orderDataList.ForEach(n =>
            {
                orderIdList.Add(n.OrderId);
                if (n.ProjectId.HasValue)
                    projectIdList.Add(n.ProjectId.Value);
            });
            List<ProjectNameModel> projectNameModels = _projectNameBll.GetProjectNameByIds(projectIdList);
            foreach (var order in orderDataList)
            {
                if (order.ProjectId.HasValue)
                {
                    var projectName = projectNameModels?.Find(n => n.ProjectId == order.ProjectId.Value);
                    if (projectName != null)
                        order.ProjectName = projectName.ProjectName;
                }
            }
            List<TraOrderStatusModel> orderStatusModels = _orderStatusBll.GetOrderStatusByOrderIds(orderIdList);
            List<TraOrderDetailModel> orderDetailModels = _orderDetailBll.GetOrderDetailListByOrderId(orderIdList);
            if (orderDetailModels == null)
                throw new Exception("行程信息异常");
            List<int> odIdList = new List<int>();
            orderDetailModels.ForEach(n => odIdList.Add(n.OdId));
            List<TraPassengerModel> passengerModels = _passengerBll.GetPassengerListByOdId(odIdList);
            //query.IsFromApp = true;
            //改签数据
            List<TraModOrderModel> traModOrderModels = null;
            if (query.IsFromApp)
            {
                traModOrderModels = _traModOrderBll.GetModOrderByOrderId(orderIdList);
            }
            if (traModOrderModels != null)
            {
                List<string> modOrderList = new List<string>();
                traModOrderModels.ForEach(n => modOrderList.Add(n.CorderId.ToString()));
                List<TraInterFaceOrderModel> modInterFaceOrderModels =
                    _traInterFaceOrderServerBll.GetOrderByOrderIdList(modOrderList);
                foreach (var traModel in traModOrderModels)
                {
                    var modInterOrder = modInterFaceOrderModels.Find(n => n.OrderId == traModel.CorderId.ToString());
                    if (modInterOrder != null)
                        traModel.InterFaceOrderStatus = modInterOrder.Status;
                }
            }


            //退票数据
            List<TraOrderModel> traRetModOrderModels = null;
            if (query.IsFromApp)
            {
                traRetModOrderModels = _orderBll.GetRetOrderByRootOrderId(orderIdList);
            }
            if (traRetModOrderModels != null)
            {
                List<string> retOrderList = new List<string>();
                traRetModOrderModels.ForEach(n => retOrderList.Add(n.OrderId.ToString()));
                List<TraInterFaceOrderModel> retInterFaceOrderModels =
                    _traInterFaceOrderServerBll.GetOrderByOrderIdList(retOrderList);
                foreach (var retModel in traRetModOrderModels)
                {
                    var retInterOrder = retInterFaceOrderModels.Find(n => n.OrderId == retModel.OrderId.ToString());
                    if (retInterOrder != null)
                        retModel.InterFaceOrderStatus = retInterOrder.Status;
                }
            }

            GetCorpAduitOrderServiceBllFactory getCorpAduitOrderServiceBllFactory =
                new GetCorpAduitOrderServiceBllFactory();
            IGetCorpAduitOrderServiceBll getCorpAduitOrderServiceBll= getCorpAduitOrderServiceBllFactory.CreateObj();


            foreach (TraOrderListDataModel orderData in orderDataList)
            {
                orderData.PassengerNameList = new List<string>();
                orderData.TrainNoList = new List<string>();
                orderData.StartTimeList = new List<string>();
                orderData.TravelList = new List<string>();
                var orderStatusModel = orderStatusModels.Find(n => n.OrderId == orderData.OrderId);
                orderData.OrderStatus = orderData.InterfaceOrderStatus.ValueToDescription<OrderTypeEnum>();

                List<CorpAduitOrderInfoModel> corpAduitOrderInfoModels =
                    getCorpAduitOrderServiceBll.GetAduitOrderInfoByOrderId(orderData.OrderId);
                if (corpAduitOrderInfoModels != null && corpAduitOrderInfoModels.Count > 0)
                {
                    orderData.AduitOrderStatus = corpAduitOrderInfoModels[0].Status;
                    if (orderData.AduitOrderStatus != (int) CorpAduitOrderStatusEnum.F &&
                        orderData.AduitOrderStatus != (int) CorpAduitOrderStatusEnum.J)
                    {
                        orderData.OrderStatus = "审批中";
                    }
                    if (!string.IsNullOrEmpty(corpAduitOrderInfoModels[0].NextAduitName))
                        orderData.AuditStatus = string.Format("待{0}审批", corpAduitOrderInfoModels[0].NextAduitName);
                }

                if (string.IsNullOrEmpty(orderData.OrderStatus))
                {
                    if ((orderStatusModel.ProccessStatus & 1) == 1)
                    {
                        orderData.OrderStatus = "出票成功";
                    }
                    else
                    {
                        orderData.OrderStatus = "处理中";
                    }
                }
                if (orderData.IsCancle==1)
                {
                    orderData.OrderStatus = "已取消";
                }
                var traModOrder =
                    traModOrderModels?.FindAll(
                        n =>
                            n.OrderId == orderData.OrderId && n.InterFaceOrderStatus.HasValue);
                if (traModOrder != null && traModOrder.Count > 0 &&
                    traModOrder.Find(n =>
                        n.InterFaceOrderStatus == (int) OrderTypeEnum.RequestChangeConfirm) != null)
                {
                    orderData.IsModed = true;
                }

                var waitConfirmList =
                    traModOrder?.FindAll(n => n.InterFaceOrderStatus == (int) OrderTypeEnum.RequestChangeSuccess);
                if (waitConfirmList != null && waitConfirmList.Count > 0)
                {
                    orderData.WaitConfirmModId = new List<int>();
                    foreach (var traModOrderModel in waitConfirmList)
                    {
                        orderData.WaitConfirmModId.Add(traModOrderModel.CorderId);
                    }
                }


                var traRetOrder =
                    traRetModOrderModels?.FindAll(
                        n =>
                            n.OrderRoot == orderData.OrderId && n.InterFaceOrderStatus.HasValue &&
                            n.InterFaceOrderStatus == (int) OrderTypeEnum.ReturnTicketsSuccess);
                if (traRetOrder != null && traRetOrder.Count > 0)
                {
                    orderData.IsRefunded = true;
                }


                var orderDetailModel = orderDetailModels.FindAll(n => n.OrderId == orderData.OrderId);
                foreach (var orderDetail in orderDetailModel)
                {
                    orderData.TrainNoList.Add(orderDetail.TrainNo);
                    orderData.StartTimeList.Add(orderDetail.StartTime.ToString("yyyy-MM-dd HH:mm"));
                    orderData.TravelList.Add(orderDetail.StartName + "-" + orderDetail.EndName);
                    var passengerModel = passengerModels.FindAll(n => n.OdId == orderDetail.OdId);
                    foreach (var passenger in passengerModel)
                    {
                        orderData.PassengerNameList.Add(passenger.Name);
                    }
                }

            }


            return orderDataList;
        }
        public List<Tra12306AccountModel> GetTra12306AccountList()
        {
            return _tra12306AccountBll.GetTra12306AccountList();
        }
        public TraOrderModel GetTraOrderModelByOrderId(int orderId)
        {
            return _orderBll.GetOrderByOrderId(orderId);
        }
        public TraOrderInfoModel GetTraOrderByOrderId(int orderid)
        {
            TraOrderInfoModel orderInfoModel = new TraOrderInfoModel();
            TraOrderModel orderModel = _orderBll.GetOrderByOrderId(orderid);
            if (orderModel == null)
                throw new Exception("未查询到该订单信息！");
            if (orderModel.ProjectId.HasValue)
            {
                ProjectNameModel projectNameModel = _projectNameBll.GetProjectNameById(orderModel.ProjectId.Value);
                if (projectNameModel != null)
                    orderModel.ProjectName = projectNameModel.ProjectName;
            }
            TraOrderStatusModel orderStatusModel = _orderStatusBll.GetOrderStatusByOrderId(orderid);
            TraInterFaceOrderModel traInterFaceOrderModel =
                _traInterFaceOrderServerBll.GetOrderByOrderId(orderid.ToString());
            if (traInterFaceOrderModel != null)
            {
                orderModel.OrderStatus = traInterFaceOrderModel.Status.ValueToDescription<OrderTypeEnum>();
            }
            else
            {
                if ((orderStatusModel.ProccessStatus & 1) == 1)
                {
                    orderModel.OrderStatus = "出票成功";
                }
                else
                {
                    orderModel.OrderStatus = "处理中";
                }
            }

            if(orderStatusModel.IsCancle==1)
                orderModel.OrderStatus = "已取消";
            if (_getCorpAduitOrderServiceBll != null)
            {
                List<CorpAduitOrderInfoModel> corpAduitOrderInfoModels =
                        _getCorpAduitOrderServiceBll.GetAduitOrderInfoByOrderId((orderModel.OrderId));

                if (corpAduitOrderInfoModels != null && corpAduitOrderInfoModels.Count > 0)
                {
                    orderModel.AduitOrderId = corpAduitOrderInfoModels[0].AduitOrderId;
                }
            }
            CustomerInfoModel customerInfoModel = _customerBll.GetCustomerByCid(orderModel.Cid);
            List<int> orderIdList = new List<int> { orderModel.OrderId };
            List<TraOrderDetailModel> orderDetailModels = _orderDetailBll.GetOrderDetailListByOrderId(orderIdList);
            List<int> odIdList = new List<int>();
            orderDetailModels.ForEach(n => odIdList.Add(n.OdId));
            List<TraPassengerModel> passengerModels = _passengerBll.GetPassengerListByOdId(odIdList);

            foreach (var detail in orderDetailModels)
            {
                detail.PassengerList = new List<TraPassengerModel>();
                var passengerModel = passengerModels.FindAll(n => n.OdId == detail.OdId);
                detail.PassengerList.AddRange(passengerModel);
            }
            orderInfoModel.ShowOnlineOrderId = (orderModel.CopyType == "X" && orderModel.CopyFromOrderId.HasValue &&
                                                (orderStatusModel.ProccessStatus & 1) == 1 &&
                                                orderStatusModel.IsCancle != 1)
                ? orderModel.CopyFromOrderId.Value
                : orderModel.OrderId;

            orderInfoModel.Order = orderModel;
            orderInfoModel.OrderStatus = orderStatusModel;
            orderInfoModel.OrderDetailList = orderDetailModels;
            orderInfoModel.CustomerInfo = customerInfoModel;
            return orderInfoModel;
        }
        public List<TraOrderDetailModel> AutoAnalysis(string analysisArgs)
        {
            List<TraOrderDetailModel> detailModels=new List<TraOrderDetailModel>();
            AnalysisContext context=new AnalysisContext(analysisArgs);
            List<AnalysisBasic> analysis=new List<AnalysisBasic>();
            analysis.Add(new AnalysisDate());//出发日期解析规则
            analysis.Add(new AnalysisTime());//出发时间+到达时间解析规则
            analysis.Add(new AnalysisStation());//出发到达站解析规则
            analysis.Add(new AnalysisTrainNo());//车次解析规则
            analysis.Add(new AnalysisPassenger());//乘车人解析规则
            foreach (var a in analysis)
            {
                a.DoAnalysis(context);//解析字符串
            }
            context.GetDetail().TotalPrice = context.GetDetail().PassengerList.Sum(n => n.FacePrice ?? 0);
            context.GetDetail().TicketNum = context.GetDetail().PassengerList.Count;
            detailModels.Add(context.GetDetail());
            return detailModels;
        }
        #endregion

        #region 退单
        public List<TraOrderListDataModel> GetTraRetOrderByPageList(TraOrderListQueryModel query, ref int totalCount)
        {
            List<TraOrderListDataModel> orderDataList = _orderListBll.GetOrderListByPage(query, ref totalCount);
            if (orderDataList == null || orderDataList.Count == 0)
                return new List<TraOrderListDataModel>();
            List<int> orderIdList = new List<int>();
            List<int> projectIdList = new List<int>();
            orderDataList.ForEach(n =>
            {
                orderIdList.Add(n.OrderId);
                if (n.ProjectId.HasValue)
                    projectIdList.Add(n.ProjectId.Value);
            });
            List<ProjectNameModel> projectNameModels = _projectNameBll.GetProjectNameByIds(projectIdList);
            foreach (var order in orderDataList)
            {
                if (order.ProjectId.HasValue)
                {
                    var projectName = projectNameModels?.Find(n => n.ProjectId == order.ProjectId.Value);
                    if (projectName != null)
                        order.ProjectName = projectName.ProjectName;
                }
            }
            List<TraOrderStatusModel> orderStatusModels = _orderStatusBll.GetOrderStatusByOrderIds(orderIdList);
            List<TraOrderDetailModel> orderDetailModels = _orderDetailBll.GetOrderDetailListByOrderId(orderIdList);
            if (orderDetailModels == null)
                throw new Exception("行程信息异常");
            List<int> odIdList = new List<int>();
            orderDetailModels.ForEach(n => odIdList.Add(n.OdId));
            List<TraPassengerModel> passengerModels = _passengerBll.GetPassengerListByOdId(odIdList);

            foreach (TraOrderListDataModel orderData in orderDataList)
            {
                orderData.PassengerNameList = new List<string>();
                orderData.TrainNoList = new List<string>();
                orderData.StartTimeList = new List<string>();
                orderData.TravelList = new List<string>();
                var orderStatusModel = orderStatusModels.Find(n => n.OrderId == orderData.OrderId);
                orderData.OrderStatus = orderData.InterfaceOrderStatus.ValueToDescription<OrderTypeEnum>();
                if (string.IsNullOrEmpty(orderData.OrderStatus))
                {
                    if ((orderStatusModel.ProccessStatus & 1) == 1)
                    {
                        orderData.OrderStatus = "退票成功";
                    }
                    else
                    {
                        orderData.OrderStatus = "处理中";
                    }
                }


                var orderDetailModel = orderDetailModels.FindAll(n => n.OrderId == orderData.OrderId);
                foreach (var orderDetail in orderDetailModel)
                {
                    orderData.TrainNoList.Add(orderDetail.TrainNo);
                    orderData.StartTimeList.Add(orderDetail.StartTime.ToString("yyyy-MM-dd HH:mm"));
                    orderData.TravelList.Add(orderDetail.StartName + "-" + orderDetail.EndName);
                    var passengerModel = passengerModels.FindAll(n => n.OdId == orderDetail.OdId);
                    foreach (var passenger in passengerModel)
                    {
                        orderData.PassengerNameList.Add(passenger.Name);
                    }
                }

            }


            return orderDataList;
        }
        public TraRetModOrderModel GetAddTraRetOrderView(int orderid, bool isFromOnline, int? corderId = null)
        {
            TraOrderModel orderModel = _orderBll.GetOrderByOrderId(orderid);
            if (orderModel == null)
                throw new Exception("未查询到该订单信息！");
            if (isFromOnline && orderModel.OrderFrom != TraOrderFromEnum.Interface.ToString())
                throw new Exception("该订单不能进行线上退票，请转人工退票！");
            TraOrderStatusModel orderStatusModel = _orderStatusBll.GetOrderStatusByOrderId(orderid);
            //判断该订单是否已经取消，如果取消则抛出异常
            if (orderStatusModel.IsCancle == 1)
            {
                throw new Exception("该订单已被取消，无法进行退票操作");
            }
            //判断该订单是否已采购，如果未采购则抛出异常
            if (orderStatusModel.IsBuy == 0)
            {
                throw new Exception("该订单未出票，无法进行退票操作");
            }
            if (orderModel.IsRefundBy12306.HasValue && !orderModel.IsRefundBy12306.Value)
            {
                throw new Exception("该订单不允许在12306上退票");
            }

            //List<TraOrderModel> retOrderModels = _orderBll.GetRetOrderByRootOrderId(orderid);

            //获取行程信息+乘车人信息
            List<TraOrderDetailModel> orderDetailModels = _orderDetailBll.GetOrderDetailListByOrderId(orderid);
            if (orderDetailModels == null)
                throw new Exception("该订单行程信息异常！");
            if (orderDetailModels.FindAll(n => !string.IsNullOrEmpty(n.OrderId12306)).Count != orderDetailModels.Count)
            {
                throw new Exception("请先输入12306订单号，再进行退票！");
            }
            List<int> odIdList = new List<int>();
            orderDetailModels.ForEach(n => odIdList.Add(n.OdId));
            List<TraPassengerModel> passengerModels = _passengerBll.GetPassengerListByOdId(odIdList);
            TraRetModOrderModel retOrderModel = null;
            if (!corderId.HasValue)
            {
                #region 来自非改签来的退票

                foreach (var detail in orderDetailModels)
                {
                    detail.PassengerList = new List<TraPassengerModel>();
                    var passengerModel = passengerModels.FindAll(n => n.OdId == detail.OdId);
                    decimal refundRate = GetRefundRate(DateTime.Now, detail.StartTime);//退票手续费率
                    detail.RefundRate = refundRate;
                    foreach (var p in passengerModel)
                    {
                        List<string> ticketNoList = new List<string>();
                        if (!string.IsNullOrEmpty(p.TicketNo))
                            ticketNoList.Add(p.TicketNo);
                        if (!string.IsNullOrEmpty(p.ModTicketNo))
                            ticketNoList.Add(p.ModTicketNo);
                        //判断当前乘车人是否已经退票
                        var retModelList = _orderBll.GetTraRetOrderListByOrderRootAndTicketNo(orderid, ticketNoList);
                        if (retModelList == null)
                            p.IsRefund = false;
                        else if (retModelList.FindAll(n => (!n.IsModRefund.HasValue || !n.IsModRefund.Value)).Count == 0)
                            p.IsMod = true;
                        else
                            p.IsRefund = true;
                        p.ServiceFee = 0;
                        p.RefundFee = GetRefundFee(p.FacePrice ?? 0, refundRate);
                        detail.PassengerList.Add(p);

                    }
                }

                #endregion
                retOrderModel = new TraRetModOrderModel { TravelInfoList = orderDetailModels, OrderFrom = orderModel.OrderFrom };
            }
            else
            {
                #region 来自改签的退票

                TraModOrderModel traModOrderModel = _traModOrderBll.GetModOrderBycorderid(corderId.Value);
                if (string.IsNullOrEmpty(traModOrderModel.ProcessStatus) ||
                    !traModOrderModel.ProcessStatus.Contains("H"))
                {
                    throw new Exception("该改签单未设置已采购，不能退票");
                }
                List<TraModOrderDetailModel> traModOrderDetailModels =
                            _traModOrderDetailBll.GetTraModOrderDetailListByCorderid(corderId.Value);//获取改签的行程信息

                List<TraOrderDetailModel> modDetailModels = new List<TraOrderDetailModel>();

                List<string> adport = traModOrderDetailModels.Select(n => n.AddrName + n.EndName).Distinct().ToList();
                foreach (var ad in adport)
                {
                    TraOrderDetailModel modDetailModel = new TraOrderDetailModel();
                    TraPassengerModel ppModel = passengerModels.Find(n => n.Pid.ToString() == traModOrderDetailModels[0].Pid);
                    TraModOrderDetailModel modOrderDetail = traModOrderDetailModels.Find(n => (n.AddrName + n.EndName) == ad);
                    modDetailModel.OdId = ppModel.OdId;
                    modDetailModel.OrderId = orderid;
                    modDetailModel.StartName = modOrderDetail.AddrName;
                    modDetailModel.EndName = modOrderDetail.EndName;
                    modDetailModel.TrainNo = modOrderDetail.TrainNo;
                    modDetailModel.StartTime = modOrderDetail.SendTime ?? Convert.ToDateTime("2001-01-01");
                    modDetailModel.EndTime = modOrderDetail.EndTime ?? Convert.ToDateTime("2001-01-01");
                    modDetailModel.PassengerList = new List<TraPassengerModel>();
                    List<TraModOrderDetailModel> modPassengerList =
                        traModOrderDetailModels.FindAll(n => (n.AddrName + n.EndName) == ad);
                    decimal refundRate = 0;
                    if ((orderDetailModels[0].StartTime - DateTime.Now).TotalHours <= 360 && (modDetailModel.StartTime - DateTime.Now).TotalHours > 360)
                    {
                        refundRate = 0.05m;
                    }
                    else
                    {
                        refundRate = GetRefundRate(DateTime.Now, modDetailModel.StartTime); //退票手续费率
                    }

                    modDetailModel.RefundRate = refundRate;
                    foreach (var modPassenger in modPassengerList)
                    {
                        TraPassengerModel p = passengerModels.Find(n => n.Pid.ToString() == modPassenger.Pid);
                        p.PlaceCar = modPassenger.PlaceCar;
                        p.PlaceSeatNo = modPassenger.PlaceSeatNo;
                        p.TicketNo = modPassenger.TicketNo;
                        p.FacePrice = modPassenger.TrainMoney;
                        p.PlaceGrade = modPassenger.PlaceGrade;

                        List<string> ticketNoList = new List<string>();
                        if (!string.IsNullOrEmpty(p.TicketNo))
                            ticketNoList.Add(p.TicketNo);
                        if (!string.IsNullOrEmpty(p.ModTicketNo))
                            ticketNoList.Add(p.ModTicketNo);
                        //判断当前乘车人是否已经退票
                        var retModelList = _orderBll.GetTraRetOrderListByOrderRootAndTicketNo(orderid, ticketNoList);
                        if (retModelList == null)
                            p.IsRefund = false;
                        else if (retModelList.FindAll(n => (!n.IsModRefund.HasValue || !n.IsModRefund.Value)).Count == 0)
                            p.IsRefund = false;
                        else
                            p.IsRefund = true;
                        p.ServiceFee = 0;
                        //计算退票费用
                        p.RefundFee = GetRefundFee(p.FacePrice ?? 0, refundRate);
                        modDetailModel.PassengerList.Add(p);
                    }
                    modDetailModels.Add(modDetailModel);
                }
                #endregion
                retOrderModel = new TraRetModOrderModel { TravelInfoList = modDetailModels, OrderFrom = orderModel.OrderFrom };
            }






            return retOrderModel;
        }
        public int AddRetOrder(TraAddRetModOrderModel newOrder)
        {
            int orderid = 0;
            if (newOrder.OrderId == 0)
            {
                throw new Exception("请传入原订单号");
            }
            TransactionOptions option = new TransactionOptions().GetTransactionScope();
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                #region 原订单信息
                TraOrderModel originalOrder = _orderBll.GetOrderByOrderId(newOrder.OrderId);//对应正单信息
                if (originalOrder.Cid != newOrder.Cid)
                    throw new Exception("当前订单不属于该客户");

                //获取原订单行程
                List<TraOrderDetailModel> originalDetailModels =
                    _orderDetailBll.GetOrderDetailListByOrderId(newOrder.OrderId);
                List<int> odIdList = new List<int>();
                originalDetailModels.ForEach(n => odIdList.Add(n.OdId));
                //获取原订单乘车人
                List<TraPassengerModel> originalPassengerModels = _passengerBll.GetPassengerListByOdId(odIdList);

                //如果是手工订单，则不需要调用第三方退票接口
                if (originalOrder.OrderFrom == TraOrderFromEnum.Hand.ToString() || newOrder.IsUserHandRefund)
                {
                    newOrder.IsRequestInterface = false;
                    if (newOrder.IsFromOnline) //如果是线上退票请求
                        throw new Exception("该订单不能进行线上退票，请转人工退票！");
                }

                #endregion

                #region 退票订单信息

                if (originalOrder.OrderFrom == TraOrderFromEnum.Interface.ToString()) //如果来自接口订单的退票提交
                {
                    newOrder.Order.PayType = PayTypeEnum.Cro;
                    newOrder.Order.SendType = (int)SendTicketTypeEnum.TraBefore; ;
                    newOrder.Order.OrderType = 3;
                }
                else
                {
                    //手工订单的退票提交
                    newOrder.Order.PayType = originalOrder.PayType;
                    newOrder.Order.SendType = originalOrder.SendType;
                    newOrder.Order.OrderType = 2;
                }
                newOrder.Order.Remark = newOrder.Remark;
                newOrder.Order.CreateOid = originalOrder.CreateOid;
                newOrder.Order.TrainPlace = "代售点";
                newOrder.Order.OrderRoot = newOrder.OrderId;
                newOrder.Order.CreateTime = DateTime.Now;
                newOrder.Order.Cid = originalOrder.Cid;
                newOrder.Order.OpeartorId = newOrder.Order.CreateOid;
                newOrder.Order.NumberIdentity = GetNumberIdentity(newOrder.OrderId);
                newOrder.Order.TotalMoney = 0;
                newOrder.Order.PayAmount = 0;
                newOrder.Order.CostCenter = originalOrder.CostCenter;
                newOrder.Order.ProjectId = originalOrder.ProjectId;
                newOrder.Order.BalanceType = originalOrder.BalanceType;
                newOrder.Order.TravelType = originalOrder.TravelType;
                if (string.IsNullOrEmpty(newOrder.Order.CName))
                {
                    newOrder.Order.CName = originalOrder.CName;
                }
                if (string.IsNullOrEmpty(newOrder.Order.CMobile))
                {
                    newOrder.Order.CMobile = originalOrder.CMobile;
                }
                if (string.IsNullOrEmpty(newOrder.Order.CEmail))
                {
                    newOrder.Order.CEmail = originalOrder.CEmail;
                }
                newOrder.Order.OrderSource = newOrder.OrderSource;
                newOrder.Order.RefundType = newOrder.RefundType;
                orderid = _orderBll.AddOrder(newOrder.Order);
                #endregion

                #region 退票订单状态信息
                if (newOrder.OrderStatus == null)
                    newOrder.OrderStatus = new TraOrderStatusModel();
                newOrder.OrderStatus.OrderId = orderid;
                newOrder.OrderStatus.ProccessStatus = 0;
                int sid = _orderStatusBll.AddOrderStatus(newOrder.OrderStatus);
                #endregion

                List<TraModOrderDetailModel> traModOrderDetailModels = null;
                if (newOrder.CorderId.HasValue)//来自改签的退票
                {
                    traModOrderDetailModels =
                        _traModOrderDetailBll.GetTraModOrderDetailListByCorderid(newOrder.CorderId.Value);
                }

                foreach (var detail in newOrder.OrderDetailList)
                {
                    var originalDetailModel = originalDetailModels.Find(n => n.OdId == detail.OdId);
                    if (originalDetailModel == null)
                        throw new Exception("无法查询到原订单的行程信息！");
                    List<TraModOrderDetailModel> modPasses = null;
                    if (traModOrderDetailModels != null)
                    {
                        #region 来自创建改签订单时，自动生成的退票信息的条件
                        //modPasses = traModOrderDetailModels.FindAll(
                        //                    n => n.AddrName + n.EndName == originalDetailModel.StartName + originalDetailModel.EndName);

                        List<string> pidStrList =
                            originalPassengerModels.FindAll(n => n.OdId == originalDetailModel.OdId)
                                .Select(n => n.Pid.ToString())
                                .Distinct()
                                .ToList();
                        modPasses=traModOrderDetailModels.FindAll(n => pidStrList.Contains(n.Pid));

                        foreach (var p in detail.PassengerList)
                        {
                            TraModOrderDetailModel modPass = modPasses.Find(n => n.Pid == p.Pid.ToString());
                            if (modPass != null)
                                detail.FacePrice = (modPass.TrainMoney ?? 0)*-1; //来自改签单乘车人的票面价
                        }
                        detail.StartName = modPasses[0].AddrName;
                        detail.EndName = modPasses[0].EndName;
                        detail.StartTime = modPasses[0].SendTime ?? Convert.ToDateTime("2002-01-01");
                        detail.EndTime = modPasses[0].EndTime ?? Convert.ToDateTime("2002-01-01");
                        detail.TrainNo = modPasses[0].TrainNo;
                        detail.PlaceType = modPasses[0].PlaceType;
                        detail.PlaceGrade = modPasses[0].PlaceGrade;
                        detail.TrainNoRemark = "";
                        detail.TrainNoStatus = "";
                        detail.StartCode = modPasses[0].StartCode;
                        detail.EndCode = modPasses[0].EndCode;
                        #endregion
                    }
                    else
                    {
                        #region 非创建改签订单

                        foreach (var p in detail.PassengerList)
                        {
                            TraPassengerModel traPass = originalPassengerModels.Find(n => n.Pid == p.Pid);
                            if (traPass != null)
                                detail.FacePrice = (traPass.FacePrice ?? 0) * -1; //来自原订单乘车人的票面价
                        }
                        detail.StartName = originalDetailModel.StartName;

                        detail.EndName = originalDetailModel.EndName;

                        detail.StartTime = originalDetailModel.StartTime;
                        detail.EndTime = originalDetailModel.EndTime;
                        detail.TrainNo = originalDetailModel.TrainNo;
                        detail.PlaceType = originalDetailModel.PlaceType;
                        detail.PlaceGrade = originalDetailModel.PlaceGrade;
                        detail.TrainNoRemark = originalDetailModel.TrainNoRemark;
                        detail.TrainNoStatus = originalDetailModel.TrainNoStatus;
                        detail.StartCode = originalDetailModel.StartCode;
                        detail.EndCode = originalDetailModel.EndCode;
                        #endregion
                    }

                    #region 退票行程信息
                    detail.StartNameId = originalDetailModel.StartNameId;
                    detail.EndNameId = originalDetailModel.EndNameId;
                    detail.OrderId = orderid;
                    detail.TicketNum = detail.PassengerList.Count;
                    detail.ServiceFee = 0;
                    detail.SupplierMoney = detail.SupplierMoney ?? 0;//供应商款0
                    detail.RefundFee = detail.RefundFee ?? 0;//退票手续费为0
                    detail.TotalPrice = (detail.SupplierMoney*-1) ?? 0;
                    if (string.IsNullOrEmpty(detail.PlaceGrade))
                        detail.PlaceGrade = "";
                    int odid = _orderDetailBll.AddOrderDetail(detail);
                    #endregion

                    //插入乘车人
                    #region 退票乘车人信息
                    detail.PassengerList.ForEach(n => n.OdId = odid);

                    for (int j = 0; j < detail.PassengerList.Count; j++)
                    {
                        var passenger = originalPassengerModels.Find(n => n.Pid == detail.PassengerList[j].Pid);
                        detail.PassengerList[j] = passenger;
                        passenger.OdId = odid;

                        if (modPasses != null)//来自改签自动生成的退票单
                        {
                            TraModOrderDetailModel modPass = modPasses.Find(n => n.Pid == detail.PassengerList[j].Pid.ToString());
                            passenger.PlaceCar = modPass.PlaceCar;
                            passenger.PlaceSeatNo = modPass.PlaceSeatNo;
                            passenger.TicketNo = modPass.TicketNo;
                            passenger.FacePrice = modPass.TrainMoney ?? 0;
                            passenger.PlaceGrade = modPass.PlaceGrade;
                        }
                        passenger.Pid = 0;
                        passenger.ServiceFee = 0;
                    }
                    _passengerBll.AddPassengerList(detail.PassengerList);
                    #endregion
                }
                if (newOrder.IsRequestInterface)//是否需要调用第三方退票接口
                {
                    #region 调用第三方接口的退票接口

                    TraInterFaceOrderModel traInterFaceOrderModel =
                        _traInterFaceOrderServerBll.GetOrderByOrderId(newOrder.Order.OrderRoot.ToString());
                    if (traInterFaceOrderModel == null)
                        throw new Exception("该订单不是线上订单，请转人工退票！");
                    if (string.IsNullOrEmpty(traInterFaceOrderModel.OrderNumber))
                        throw new Exception("该订单没有取票单号，不能退票！");
                    TraTicketRefundModel refundObj = new TraTicketRefundModel()
                    {
                        orderid = newOrder.Order.OrderRoot.ToString(),
                        transactionid = traInterFaceOrderModel.Transactionid,
                        ordernumber = traInterFaceOrderModel.OrderNumber,
                        reqtoken = DateTime.Now.ToString("yyyyMMddHHmmss"),
                        tickets = new List<RefundTicketDetailModel>()
                    };
                    //TODO:退票选择的需要修改
                    foreach (var p in newOrder.OrderDetailList[0].PassengerList)
                    {
                        if (string.IsNullOrEmpty(p.ModTicketNo) && string.IsNullOrEmpty(p.TicketNo))
                            throw new Exception(p.Name + "不存在票号，不能退票");

                        RefundTicketDetailModel pp = new  RefundTicketDetailModel();
                        pp.passengername = p.Name;
                        pp.passporttypeseid = ((int) p.CardNoType).ToString();

                        if (p.CardNoType == CardTypeEnum.Certificate)
                        {
                            pp.passporttypeseid = "1";
                        }
                        else if (p.CardNoType == CardTypeEnum.HongKongAndMacaoPass)
                        {
                            pp.passporttypeseid = "C";
                        }
                        else if (p.CardNoType == CardTypeEnum.Passport)
                        {
                            pp.passporttypeseid = "B";
                        }
                        else if (p.CardNoType == CardTypeEnum.TaiwanEntryPermit || p.CardNoType == CardTypeEnum.MTP)
                        {
                            pp.passporttypeseid = "G";
                        }

                        pp.passportseno = p.CardNo;
                        pp.ticket_no = (!string.IsNullOrEmpty(p.ModTicketNo) ? p.ModTicketNo : p.TicketNo);
                        refundObj.tickets.Add(pp);
                    }
                    //输入请求实体，和退票单号
                    ServerRefundSubmit?.Invoke(this, new TraServerEventArgs<TraTicketRefundModel>(refundObj, orderid));

                    #endregion
                }

                #region 更新订单状态
                //1.如果不需要访问第三方接口的退票接口的退票单，则还是临时订单；
                bool a = (originalOrder.OrderFrom == TraOrderFromEnum.Hand.ToString() || newOrder.IsUserHandRefund);
                _orderBll.UpdateOrder(new TraOrderModel()
                {
                    OrderId = orderid,
                    OrderType =
                        (newOrder.IsRequestInterface || a)
                            ? 2
                            : 3,
                    TotalMoney = newOrder.OrderDetailList.Sum(n => n.TotalPrice),
                    PayAmount = newOrder.OrderDetailList.Sum(n => n.TotalPrice)*-1
                }, new[] {"OrderType", "TotalMoney", "PayAmount"});

                //2.如果是手动订单，记日志
                if (newOrder.Order.IsModRefund.HasValue && newOrder.Order.IsModRefund.Value &&
                    originalOrder.OrderFrom == TraOrderFromEnum.Hand.ToString())
                {
                    _traOrderLogBll.AddLog(new TraOrderLogModel()
                    {
                        OrderId = orderid,
                        CreateOid = newOrder.Order.CreateOid,
                        CreateTime = DateTime.Now,
                        LogType = "修改",
                        LogContent = "火车票改签，自动生成退票单"
                    });
                }

                #endregion
                scope.Complete();

            }


            return orderid;
        }
        /// <summary>
        /// 根据原订单号获取对应的退票单信息
        /// </summary>
        /// <param name="rootOrderid"></param>
        /// <returns></returns>
        public List<TraOrderInfoModel> GetTraRetOrderByRootOrderId(int rootOrderid)
        {
            List<TraOrderModel> traRetOrderModels = _orderBll.GetRetOrderByRootOrderId(rootOrderid);
            if (traRetOrderModels == null)
                return null;
            traRetOrderModels =
                traRetOrderModels.FindAll(n => n.OrderType == 2 && (!n.IsModRefund.HasValue || !n.IsModRefund.Value))
                    .ToList();

            return traRetOrderModels.Select(traRetOrder => GetTraOrderByOrderId(traRetOrder.OrderId)).Where(orderInfoModel => orderInfoModel != null).ToList();
        }
        #endregion

        #region 改签
        public List<TraModOrderListDataModel> GetTraModOrderByPageList(TraModOrderListQueryModel query,
            ref int totalCount)
        {
            List<TraModOrderListDataModel> modOrderDataList = _traModOrderListBll.GetTraModOrderByPageList(query, ref totalCount);
            if (modOrderDataList == null || modOrderDataList.Count == 0)
                return new List<TraModOrderListDataModel>();
            List<int> corderIdList=new List<int>();
            modOrderDataList.ForEach(n=> corderIdList.Add(n.CorderId));
            List<TraModOrderDetailModel> traModOrderDetailModels =
                _traModOrderDetailBll.GetTraModOrderDetailListByCorderid(corderIdList);//改签行程
            List<int>pidList=new List<int>();
            traModOrderDetailModels.ForEach(n=> pidList.Add(Convert.ToInt32(n.Pid)));
            List<TraPassengerModel> traPassengerModels = _passengerBll.GetPassengerListByPid(pidList);//改签对应的原订单乘车人

            foreach (TraModOrderListDataModel modOrderData in modOrderDataList)
            {
                modOrderData.PassengerNameList = new List<string>();
                modOrderData.TrainNoList = new List<string>();
                modOrderData.StartTimeList = new List<string>();
                modOrderData.TravelList = new List<string>();

                if (modOrderData.OrderStatus == "C")
                    modOrderData.OrderStatus = "已取消";
                else
                {
                    modOrderData.OrderStatus = modOrderData.InterfaceOrderStatus.ValueToDescription<OrderTypeEnum>();
                }
                if (string.IsNullOrEmpty(modOrderData.OrderStatus))
                    modOrderData.OrderStatus = "处理中";

              

                List<TraModOrderDetailModel> selectModOrderDetailModels =
                    traModOrderDetailModels.FindAll(n => n.CorderId == modOrderData.CorderId);


                foreach (var selected in selectModOrderDetailModels)
                {
                    modOrderData.TrainNoList.Add(selected.TrainNo);
                    modOrderData.StartTimeList.Add(selected.SendTime?.ToString("yyyy-MM-dd HH:mm"));
                    modOrderData.TravelList.Add(selected.AddrName + "-" + selected.EndName);
                    if (selected.TrainMoney != null) modOrderData.ModFacePrice += selected.TrainMoney.Value;
                    List<TraPassengerModel> selectedPassengerModels =
                        traPassengerModels.FindAll(n => n.Pid.ToString() == selected.Pid);
                    selectedPassengerModels.ForEach(n => modOrderData.PassengerNameList.Add(n.Name));
                }

            }

            return modOrderDataList;
        }
        /// <summary>
        /// 根据原订单号获取对应的改签单信息
        /// </summary>
        /// <param name="rootOrderid"></param>
        /// <returns></returns>
        public List<TraModOrderInfoModel> GetTraModOrderByRootOrderId(int rootOrderid)
        {
            List<TraModOrderModel> traModOrderModels = _traModOrderBll.GetModOrderByOrderId(rootOrderid);
            if (traModOrderModels == null)
                return null;
            traModOrderModels = traModOrderModels.FindAll(n => (n.OrderStatus != "N"&& n.OrderStatus != "C")).ToList();
            return traModOrderModels.Select(traModOrder => GetTraModOrderByCorderId(traModOrder.CorderId)).Where(order => order != null).ToList();
        }
        public TraRetModOrderModel GetAddTraModOrderView(int orderid, bool isFromOnline)
        {
            TraOrderModel orderModel = _orderBll.GetOrderByOrderId(orderid);
            if (orderModel == null)
                throw new Exception("未查询到该订单信息！");
            if (isFromOnline && orderModel.OrderFrom != TraOrderFromEnum.Interface.ToString())
                throw new Exception("该订单不能进行线上退票，请转人工退票！");
            TraOrderStatusModel orderStatusModel = _orderStatusBll.GetOrderStatusByOrderId(orderid);
            //判断该订单是否已经取消，如果取消则抛出异常
            if (orderStatusModel.IsCancle == 1)
            {
                throw new Exception("该订单已被取消，无法进行改签操作");
            }

            //判断该订单是否已采购，如果未采购则抛出异常
            if (orderStatusModel.IsBuy == 0)
            {
                throw new Exception("该订单未出票，无法进行改签操作");
            }

            //获取行程信息+乘车人信息
            List<TraOrderDetailModel> orderDetailModels = _orderDetailBll.GetOrderDetailListByOrderId(orderid);//原订单行程
            if (orderDetailModels == null)
                throw new Exception("该订单行程信息异常！");
            if (orderDetailModels.FindAll(n => !string.IsNullOrEmpty(n.OrderId12306)).Count != orderDetailModels.Count)
            {
                throw new Exception("请先输入12306订单号，再进行改签！");
            }
            List<int> odIdList = new List<int>();
            orderDetailModels.ForEach(n => odIdList.Add(n.OdId));
            List<TraPassengerModel> passengerModels = _passengerBll.GetPassengerListByOdId(odIdList);//原订单乘车人

            foreach (var detail in orderDetailModels)
            {
                if (orderModel.OrderFrom == TraOrderFromEnum.Interface.ToString() &&
                    DateTime.Now.AddMinutes(30) >= detail.StartTime) //改签必须提前30分钟
                {
                    throw new Exception("该班次在30分钟以内，无法在线改期，建议车站自行处理");
                }
                detail.PassengerList = new List<TraPassengerModel>();
                var passengerModel = passengerModels.FindAll(n => n.OdId == detail.OdId);

                foreach (var p in passengerModel)
                {
                    List<string> ticketNoList = new List<string>();
                    if (!string.IsNullOrEmpty(p.TicketNo))
                        ticketNoList.Add(p.TicketNo);
                    if (!string.IsNullOrEmpty(p.ModTicketNo))
                        ticketNoList.Add(p.ModTicketNo);
                    //判断当前乘车人是否已经退票
                    //var retModel = _orderBll.GetTraRetOrderListByOrderRootAndTicketNo(orderid, ticketNoList);
                    TraOrderModel retModel = null;
                    List<TraOrderModel> retOrderModelList =
                        _orderBll.GetTraRetOrderListByOrderRootAndTicketNo(orderid, ticketNoList);
                    if (retOrderModelList != null)
                        retModel = retOrderModelList.Find(n => !n.IsModRefund.HasValue || !n.IsModRefund.Value);

                    var modModel=_traModOrderBll.GetTraModOrderByOrderIdAndTicketNo(orderid, ticketNoList);

                    if (retModel != null)
                    {
                        p.IsRefund = true;
                    }

                    if (modModel != null&& !"N,C".Contains(modModel.OrderStatus))
                    {
                        p.IsMod = true;
                    }

                    detail.PassengerList.Add(p);
                }
            }

            TraRetModOrderModel retOrderModel = new TraRetModOrderModel
            {
                TravelInfoList = orderDetailModels,
                OrderFrom = orderModel.OrderFrom
            };


            return retOrderModel;
        }
        public int AddModOrder(TraAddRetModOrderModel newOrder)
        {
            int corderid = 0;
            if (newOrder.OrderId == 0)
            {
                throw new Exception("请传入原订单号");
            }
            TransactionOptions option = new TransactionOptions().GetTransactionScope();
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, option))
            {
                TraOrderModel originalOrder = _orderBll.GetOrderByOrderId(newOrder.OrderId);//对应正单信息
                if (originalOrder.Cid != newOrder.Cid)
                    throw new Exception("当前订单不属于该客户");
                if (originalOrder.OrderFrom == TraOrderFromEnum.Hand.ToString())//如果是手工订单，则不需要调用第三方退票接口
                {
                    if (newOrder.IsFromOnline)//如果是线上退票请求
                        throw new Exception("该订单不能进行线上改签，请转人工退票！");
                }
                TraInterFaceOrderModel traInterFaceOrderModel = _traInterFaceOrderServerBll.GetOrderByOrderId(newOrder.OrderId.ToString());//获取接口订单信息
                if (originalOrder.OrderFrom == TraOrderFromEnum.Interface.ToString())
                {
                    if (traInterFaceOrderModel == null)
                        throw new Exception("该订单不支持自动改签！");
                    if (traInterFaceOrderModel.Status != (int) OrderTypeEnum.TicketSuccess)
                        throw new Exception("当前订单未出票成功，不允许改签！");
                }
                if (newOrder.IsFromOnline)
                {
                    newOrder.Order.CreateOid = "sys";
                    newOrder.Order.PayType = PayTypeEnum.Cro;
                    newOrder.Order.IsOnline = "T";
                }
                else
                {
                    newOrder.Order.PayType = originalOrder.PayType;
                    newOrder.Order.IsOnline = "F";
                }

                #region 根据订单号获取改签数据
                List<TraModOrderModel> traModOrderModels = _traModOrderBll.GetModOrderByOrderId(newOrder.OrderId);//获取正单对应的改签订单
                #endregion

                List<int> pidList = new List<int>();
                foreach (var detail in newOrder.OrderDetailList)
                {
                    foreach (var p in detail.PassengerList)
                    {
                        pidList.Add(p.Pid);
                    }
                }
                List<TraPassengerModel> traPassengerModels = _passengerBll.GetPassengerListByPid(pidList);//原订单乘车人
                int cCount=traPassengerModels.FindAll(n => n.AgeType == AgeTypeEnum.C).Count;
                int eCount = traPassengerModels.FindAll(n => n.AgeType == AgeTypeEnum.E).Count;
                if (cCount > 0 && eCount > 0)
                {
                    throw new Exception("成人儿童请分开提交改签！");
                }

                List<TraOrderDetailModel> originalOrderDetailList =
                    _orderDetailBll.GetOrderDetailListByOrderId(originalOrder.OrderId);
                foreach (var detail in originalOrderDetailList)
                {
                    detail.PassengerList = traPassengerModels.FindAll(n => n.OdId == detail.OdId);
                }

                if (originalOrder.Cid != newOrder.Cid)
                    throw new Exception("当前订单不属于登录者");


                #region 改签订单信息
                TraModOrderModel modOrder = new TraModOrderModel();
                modOrder.OrderStatus = "W";
                if (originalOrder.OrderFrom == TraOrderFromEnum.Interface.ToString())//如果是接口订单，则状态为N
                {
                    modOrder.OrderStatus = "N";
                }

                if (newOrder.Order.IsOnline == "F"&& originalOrder.OrderFrom == TraOrderFromEnum.Hand.ToString())
                {
                    modOrder.OrderStatus = "P";
                }

                if (traModOrderModels != null)
                    modOrder.Squence = traModOrderModels.Count + 1;
                else
                    modOrder.Squence = 0;
                modOrder.TravelRemark = newOrder.TravelRemark;
                modOrder.OrderId = newOrder.OrderId;
                modOrder.CreateTime = DateTime.Now;
                modOrder.CreateOid = originalOrder.CreateOid;
                modOrder.Oid = modOrder.CreateOid;
                modOrder.IsOnlineRefund = newOrder.Order.IsOnline;
                modOrder.PayMethod = newOrder.Order.PayType.ToDescription();
                if (originalOrder.SendType.HasValue)
                    modOrder.GetTickets = originalOrder.SendType.Value.ValueToDescription<SendTicketTypeEnum>();
                else
                    modOrder.GetTickets = SendTicketTypeEnum.Not.ToString();
                modOrder.CName = originalOrder.CName;
                modOrder.CMobile = originalOrder.CMobile;
                modOrder.CEmail = originalOrder.CEmail;
                modOrder.Cid = originalOrder.Cid.ToString();
                modOrder.Coid = modOrder.OrderId + GetNumberIdentity(newOrder.OrderId);
                modOrder.CalcPrice = 0;//改签差价
                modOrder.PayAmount = newOrder.OrderDetailList.Sum(n => n.FacePrice)*
                                     newOrder.OrderDetailList.Sum(n => n.PassengerList.Count);
                modOrder.BalanceType = originalOrder.BalanceType;
                modOrder.TravelType = originalOrder.TravelType;
                modOrder.OrderSource = newOrder.OrderSource;


                CustomerInfoModel customerInfoModel = _customerBll.GetCustomerByCid(originalOrder.Cid);
                //判断是否需要打印两联单
                if (!string.IsNullOrEmpty(customerInfoModel.CorpId) && !newOrder.Order.IsPrint.HasValue)//没有IsPrint,从公司信息中获取
                {
                    CorporationModel corporationModel = _corporationBll.GetCorpInfoByCorpId(customerInfoModel.CorpId);
                    if (corporationModel != null && corporationModel.IsPrint.HasValue && corporationModel.IsPrint == 1)
                    {
                        modOrder.IsPrint = 1;
                    }
                }

                if (!modOrder.IsPrint.HasValue)
                {
                    modOrder.IsPrint = 0;
                }


                corderid = _traModOrderBll.AddModOrder(modOrder);

                #endregion
                #region 改签行程信息
                List<TraModOrderDetailModel> detailList = new List<TraModOrderDetailModel>();
                foreach (var detail in newOrder.OrderDetailList)
                {
                    var originalOrderDetail = originalOrderDetailList.Find(n => n.OdId == detail.OdId);
                    foreach (var p in detail.PassengerList)
                    {
                        TraModOrderDetailModel detailModel = new TraModOrderDetailModel();
                        detailModel.OrderId = newOrder.OrderId.ToString();
                        detailModel.Pid = p.Pid.ToString();
                        detailModel.AddrName = detail.StartName;
                        detailModel.EndName = detail.EndName;
                        detailModel.SendTime = detail.OnTrainTime;
                        detailModel.EndTime = detail.EndTime;
                        detailModel.TrainNo = detail.TrainNo;
                        detailModel.TrainType = "";
                        detailModel.PlaceGrade = detail.PlaceGrade;
                        detailModel.PlaceType = GetPlaceType(detail.PlaceGrade);
                        detailModel.TicketNum = 1;
                        detailModel.TrainMoney = detail.FacePrice;//改签票面价
                        detailModel.SumPrice = detailModel.TrainMoney;//
                        detailModel.CorderId = corderid;
                        detailModel.PlaceCar = (string.IsNullOrEmpty(p.PlaceCar) ? "" : p.PlaceCar);
                        detailModel.PlaceSeatNo = (string.IsNullOrEmpty(p.PlaceSeatNo) ? "" : p.PlaceSeatNo);
                        detailModel.StartCode = originalOrderDetail.StartCode;
                        detailModel.EndCode = originalOrderDetail.EndCode;
                        detailModel.ModFee = detail.ModFee/detail.PassengerList.Count;
                        if (originalOrder.OrderFrom == TraOrderFromEnum.Hand.ToString())
                        {
                            detailModel.TicketNo = originalOrderDetail.OrderId12306+ DateTime.Now.ToString("mmssfff");
                            Thread.Sleep(1);
                        }
                        detailList.Add(detailModel);
                    }
                }
                _traModOrderDetailBll.AddTraModOrderDetail(detailList); 
                #endregion

                if (originalOrder.OrderFrom == TraOrderFromEnum.Interface.ToString())//从接口下的订单，统一走第三方改签接口
                {
                    #region 访问第三方接口的改签接口
                    Thread.Sleep(1000);
                    TraRequestChangeModel requestChangeModel = new TraRequestChangeModel()
                    {
                        change_checi = newOrder.OrderDetailList[0].TrainNo,
                        change_datetime = newOrder.OrderDetailList[0].StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
                        change_zwcode = TrainTypeEnum.GetTypeCodeByName(newOrder.OrderDetailList[0].PlaceGrade), //坐席编码
                        from_station_code = newOrder.OrderDetailList[0].StartCode,
                        from_station_name = newOrder.OrderDetailList[0].StartName,
                        old_zwcode = TrainTypeEnum.GetTypeCodeByName(newOrder.OldPlaceGrade), //原订单坐席编码
                        orderid = newOrder.OrderId.ToString(),
                        ordernumber = traInterFaceOrderModel.OrderNumber, //12306订单号
                        reqtoken = DateTime.Now.ToString("yyyyMMddHHmmss"),
                        to_station_code = newOrder.OrderDetailList[0].EndCode,
                        to_station_name = newOrder.OrderDetailList[0].EndName,
                        transactionid = traInterFaceOrderModel.Transactionid, //第三方接口订单号
                        isasync = "Y",
                        isTs = false,
                        is_choose_seats = newOrder.IsChooseSeats,
                        choose_seats = newOrder.ChooseSeats,
                        is_accept_standing = newOrder.IsAcceptStanding,
                        ticketinfo = new List<TraRequestChangeTicketInfoModel>()
                    };

                    foreach (var p in detailList)
                    {
                        var traPassenger = traPassengerModels.Find(n => n.Pid.ToString() == p.Pid);
                        TraRequestChangeTicketInfoModel pp = new TraRequestChangeTicketInfoModel();
                        pp.old_ticket_no = traPassenger.TicketNo;
                        pp.passengersename = traPassenger.Name;
                        pp.passportseno = traPassenger.CardNo;
                        pp.passporttypeseid = ((int) traPassenger.CardNoType).ToString();
                        pp.piaotype = "1";

                        if (traPassenger.CardNoType == CardTypeEnum.Certificate)
                        {
                            pp.passporttypeseid = "1";
                        }
                        else if (traPassenger.CardNoType == CardTypeEnum.HongKongAndMacaoPass)
                        {
                            pp.passporttypeseid = "C";
                        }
                        else if (traPassenger.CardNoType == CardTypeEnum.Passport)
                        {
                            pp.passporttypeseid = "B";
                        }
                        else if (traPassenger.CardNoType == CardTypeEnum.TaiwanEntryPermit ||
                                 traPassenger.CardNoType == CardTypeEnum.MTP)
                        {
                            pp.passporttypeseid = "G";
                        }

                        requestChangeModel.ticketinfo.Add(pp);
                    }


                    ServerModSubmit?.Invoke(this,
                            new TraServerEventArgs<TraRequestChangeModel>(requestChangeModel, corderid));

                    //测试环境补充一个改签生成的退票单，方便测试；生产环境不需要这步骤，回调接口会生成的！
                    string isServer = AppSettingsHelper.GetAppSettings(AppSettingsEnum.IsServer);
                    if (isServer=="F")
                    {
                        modOrder.CorderId = corderid;
                        AddRetOrderOnMod(modOrder, detailList, originalOrderDetailList, traPassengerModels,
                            newOrder.OrderDetailList.Sum(n => n.ModFee ?? 0), TraOrderFromEnum.Interface.ToString());
                    }
                    #endregion
                }

                if (originalOrder.OrderFrom == TraOrderFromEnum.Hand.ToString())//手工订单改签，创建一个对应的退票单信息
                {
                    modOrder.CorderId = corderid;
                    AddRetOrderOnMod(modOrder, detailList, originalOrderDetailList, traPassengerModels,
                        newOrder.OrderDetailList.Sum(n => n.ModFee ?? 0), TraOrderFromEnum.Hand.ToString());
                }
                scope.Complete();
            }

            return corderid;
        }
        public TraModOrderInfoModel GetTraModOrderByCorderId(int corderId)
        {
            TraModOrderModel traOrderModel = _traModOrderBll.GetModOrderBycorderid(corderId);
            List<TraModOrderDetailModel> traModOrderDetailModels =
                _traModOrderDetailBll.GetTraModOrderDetailListByCorderid(corderId);
            List<int> pidList=new List<int>();
            traModOrderDetailModels.ForEach(n=> pidList.Add(Convert.ToInt32(n.Pid)));
            List<TraPassengerModel> passengerModels = _passengerBll.GetPassengerListByPid(pidList);

            List<string> daportList=new List<string>();
            foreach (var traModOrderDetailModel in traModOrderDetailModels)
            {
                daportList.Add(traModOrderDetailModel.AddrName+ traModOrderDetailModel.EndName);
                if (traModOrderDetailModel.TrainMoney.HasValue)
                    traOrderModel.ModFacePrice += traModOrderDetailModel.TrainMoney;
            }
          
            TraInterFaceOrderModel traInterFaceOrderModel =
                _traInterFaceOrderServerBll.GetOrderByOrderId(traOrderModel.CorderId.ToString());
            if (traInterFaceOrderModel != null)
            {
                traOrderModel.OrderStatusDesc = traInterFaceOrderModel.Status.ValueToDescription<OrderTypeEnum>();
            }
            else
            {
                if (!string.IsNullOrEmpty(traOrderModel.ProcessStatus) &&traOrderModel.ProcessStatus.Contains("H"))
                {
                    traOrderModel.OrderStatusDesc = "改签订单已出票";
                }
                else
                {
                    traOrderModel.OrderStatusDesc = "处理中";
                    traOrderModel.OrderStatus = "处理中";
                }
            }

            if(traOrderModel.OrderStatus=="C")
                traOrderModel.OrderStatusDesc = "已取消";

            daportList = daportList.Distinct().ToList();
            List<TraModOrderDetailModel> traModOrderDetailList = new List<TraModOrderDetailModel>();
            foreach (var daport in daportList)
            {
               var temp= traModOrderDetailModels.Find(n => n.AddrName + n.EndName == daport);
                traModOrderDetailList.Add(temp);
            }
            decimal totalFacePrice = 0;
            foreach (var traModOrderDetail in traModOrderDetailList)
            {
                var tempList = traModOrderDetailModels.FindAll(
                    n => n.AddrName == traModOrderDetail.AddrName && n.EndName == traModOrderDetail.EndName);
                List< TraPassengerModel > ppList=new List<TraPassengerModel>();
                foreach (var temp in tempList)
                {
                    var pp = passengerModels.Find(n => n.Pid.ToString() == temp.Pid);
                    pp.PlaceCar = temp.PlaceCar;
                    pp.PlaceSeatNo = temp.PlaceSeatNo;
                    pp.FacePrice = temp.TrainMoney ?? 0;
                    pp.ServiceFee = 0;
                    pp.TicketNo = temp.TicketNo;
                    totalFacePrice += pp.FacePrice ?? 0;
                    List<string> ticketNoList=new List<string>();
                    ticketNoList.Add(pp.TicketNo);
                    var retModelList = _orderBll.GetTraRetOrderListByOrderRootAndTicketNo(traOrderModel.OrderId.Value, ticketNoList);
                    if (retModelList == null)
                        pp.IsRefund = false;
                    else if (retModelList.FindAll(n => (!n.IsModRefund.HasValue || !n.IsModRefund.Value)).Count == 0)
                        pp.IsRefund = false;
                    else
                        pp.IsRefund = true;
                    
                    ppList.Add(pp);
                }
                traModOrderDetail.PassengerList = ppList;
            }
            traOrderModel.ModFacePrice = totalFacePrice;

           TraModOrderInfoModel orderInfoModel = new TraModOrderInfoModel()
            {
                Order = traOrderModel,
                OrderDetailList = traModOrderDetailList
            };

            return orderInfoModel;
        }
        public string GetModFeeRate(List<decimal> facePriceList, decimal modFacePrice, DateTime modStartTime,DateTime startTime)
        {
            string result = string.Empty;
            if (facePriceList.Count == 0)
                return result;
            
            if (facePriceList[0]> modFacePrice)//高面价改低面价,退差价
            {
                decimal diffPrice = facePriceList[0] - modFacePrice;
                //如果改签到春运时间段，则20%
                string chunYun = AppSettingsHelper.GetAppSettings(AppSettingsEnum.ChunYun);
                decimal modRate = 0;
                decimal modFee = 0;
                if (modStartTime >= Convert.ToDateTime(chunYun.Split('|')[0]) &&
                    modStartTime < Convert.ToDateTime(chunYun.Split('|')[1]))
                {
                    modRate = 0.2m;
                    modFee = diffPrice*modRate;
                }
                else
                {
                    modRate = GetModRate(modStartTime, startTime);
                    modFee = GetRefundFee(diffPrice, modRate);
                }

                return string.Format("票款差额：{0}元，退票费率：{1}%，实际退还票款：{2}元", diffPrice, modRate*100,
                    (diffPrice - modFee) * facePriceList.Count < 0 ? 0 : (diffPrice - modFee)* facePriceList.Count);
            }
            else//低面价改高面价
            {
                return string.Format("收取新票款：{0}元，退还原票款(不含服务费)：{1}元", modFacePrice*facePriceList.Count, facePriceList.Sum());
            }

          
        }
        #endregion

        #endregion

        #region 私有方法
        /// <summary>
        /// 获取副单序号
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        private string GetNumberIdentity(int orderid)
        {
            //TODO:获取副单序号
            List<TraOrderModel> reOrderModels = _orderBll.GetRetOrderByRootOrderId(orderid);//退票单
            List<TraModOrderModel> traModOrderModels = _traModOrderBll.GetModOrderByOrderId(orderid);
            //TODO:改签单
            int a = 65;
            a = a + (reOrderModels?.Count ?? 0) + (traModOrderModels?.Count ?? 0);
            return Convert.ToChar(a).ToString();
        }
        /// <summary>
        /// 根据座位等级获取对应的座位类别
        /// </summary>
        /// <param name="placeGrade"></param>
        /// <returns></returns>
        private string GetPlaceType(string placeGrade)
        {
            if(string.IsNullOrEmpty(placeGrade))
                return string.Empty;
            if (placeGrade.Contains("座"))
                return "座位";
            if (placeGrade.Contains("铺"))
                return "卧铺";
            return string.Empty;
        }
        /// <summary>
        /// 计算退票费率
        /// </summary>
        /// <param name="refundDate"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        private decimal GetRefundRate(DateTime refundDate,DateTime startTime)
        {
            double hour = (startTime - refundDate).TotalHours;
            if (hour > 360)
                return 0;
            else if (hour > 48 && hour <= 360)
                return 0.05m;
            else if (hour > 24 && hour <= 48)
                return 0.1m;
            else
                return 0.2m;
        }
        /// <summary>
        /// 计算退票费
        /// </summary>
        /// <param name="facePrice"></param>
        /// <param name="refundRate"></param>
        /// <returns></returns>
        private decimal GetRefundFee(decimal facePrice,decimal refundRate)
        {
            if (refundRate == 0)
                return 0;

            decimal refundFee = facePrice*refundRate;
            decimal xiaoshu = Convert.ToDecimal("0." + refundFee.ToString("0.00").Split('.')[1]);
            refundFee = Convert.ToDecimal(refundFee.ToString("0.00").Split('.')[0]);
            if (xiaoshu < 0.25m)
            {
                xiaoshu = 0m;
            }
            else if (xiaoshu >= 0.25m && xiaoshu < 0.75m)
            {
                xiaoshu = 0.5m;
            }
            else
            {
                xiaoshu = 1m;
            }
            //当前退票手续费，比2块钱小的时候，如果退票手续费比票价小，则退2块，否则退全部票价
            if ((refundFee + xiaoshu) < 2 && (refundFee + xiaoshu) < facePrice)
                return 2;
            if ((refundFee + xiaoshu) < 2 && (refundFee + xiaoshu) >= facePrice)
                return facePrice;
            return refundFee + xiaoshu;
        }
        /// <summary>
        /// 计算改签费率
        /// </summary>
        /// <param name="modStartTime"></param>
        /// <param name="startTime"></param>
        /// <returns></returns>
        private decimal GetModRate(DateTime modStartTime, DateTime startTime)
        {
            decimal modRate = 0;
            DateTime nowTime = DateTime.Now;
            double h = (modStartTime - nowTime).TotalHours;//改签后的发车时间-现在时间
            double h2 = (startTime - nowTime).TotalHours;//原订单发车时间-现在时间
                                                         //1、15t以上  改退 0%
            if (h > 360 && h2 > 360)
            {
                modRate = 0;
            }
            else if ((h2 > 48 && h2 <= 360))// && (h > 360)
            {
                //2、48h~15t 改 15t以后 改签收差价5%（高改低）  退票5 %
                modRate = 0.05m;
            }
            else if (h2 > 360 && h <= 360)
            {
                //3、15t以上 改15天内  改0% 退根据改签后票的时间计算退票
                modRate = 0;
            }
            else if (h2 > 24 && h2 <= 48)
            {
                modRate = 0.1m;
            }
            else if (h2 <= 24)
            {
                modRate = 0.2m;
            }
            return modRate;
        }
        /// <summary>
        /// 改签时候，自动生成一个退票信息
        /// </summary>
        /// <param name="traModOrderModel">改签订单信息</param>
        /// <param name="traModOrderDetailModels">改签行程信息</param>
        /// <param name="oldOrderDetailModels">改签对应原订单行程信息</param>
        /// <param name="fee">改签手续费</param>
        /// <param name="orderFrom">订单来源</param>
        /// <returns></returns>
        private int AddRetOrderOnMod(TraModOrderModel traModOrderModel, List<TraModOrderDetailModel> traModOrderDetailModels
            , List<TraOrderDetailModel> oldOrderDetailModels, List<TraPassengerModel> oldTraPassengerModels, decimal fee,string orderFrom)
        {
            if(traModOrderModel==null)
                throw new Exception("改签订单异常");
            if (!traModOrderModel.OrderId.HasValue)
                throw new Exception("改签订单对应正单号异常");
            TraAddRetModOrderModel traRetOrder = new TraAddRetModOrderModel();
            traRetOrder.IsRequestInterface = false;
            traRetOrder.OrderId = traModOrderModel.OrderId.Value;
            traRetOrder.Order = new TraOrderModel();
            traRetOrder.Order.IsOnline = traModOrderModel.IsOnlineRefund;
            if (traRetOrder.Order.IsOnline == "T")
            {
                traRetOrder.Order.PayType = PayTypeEnum.Cro;
                traRetOrder.Order.SendType = (int)SendTicketTypeEnum.TraBefore;
            }
            else
            {
               
                traRetOrder.Order.PayType = traModOrderModel.PayMethod.DescriptionToEnum< PayTypeEnum>();
                traRetOrder.Order.SendType = (int) traModOrderModel.GetTickets.DescriptionToEnum<SendTicketTypeEnum>();
            }
            traRetOrder.Order.CreateOid = traModOrderModel.CreateOid;
            traRetOrder.Order.IsModRefund = true;
            traRetOrder.Order.CorderId = traModOrderModel.CorderId;
            traRetOrder.Order.Cid = Convert.ToInt32(traModOrderModel.Cid);
            traRetOrder.Cid = traRetOrder.Order.Cid;
            traRetOrder.Order.OrderFrom = orderFrom;
            traRetOrder.OrderDetailList = new List<TraOrderDetailModel>();

           // List<string> modAddrNameList = traModOrderDetailModels.Select(n => n.AddrName).Distinct().ToList();//获取改签出发地点

            List<string> pidList = traModOrderDetailModels.Select(n => n.Pid).ToList();
            List<int> odIdList =
                oldTraPassengerModels.FindAll(n => pidList.Contains(n.Pid.ToString())).Select(n => n.OdId).Distinct().ToList();

            List<string> modAddrNameList =
                oldOrderDetailModels.FindAll(n => odIdList.Contains(n.OdId))
                    .Select(n => n.StartName)
                    .Distinct()
                    .ToList();

            foreach (var addrName in modAddrNameList)
            {
                TraOrderDetailModel detail = new TraOrderDetailModel();
                var oldDetail=oldOrderDetailModels.Find(n => n.StartName == addrName);//通过改签出发匹配原订单行程
                detail.OdId = oldDetail.OdId;
                detail.PassengerList = new List<TraPassengerModel>();
                detail.RefundFee = fee / traModOrderDetailModels.Count;
                decimal supplierMoney = 0;
                foreach (TraModOrderDetailModel traModOrderDetail in traModOrderDetailModels)
                {
                    detail.PassengerList.Add(new TraPassengerModel() { Pid = Convert.ToInt32(traModOrderDetail.Pid) });
                    var pp=oldDetail.PassengerList.Find(n => n.Pid == Convert.ToInt32(traModOrderDetail.Pid));//找到改签对应的乘车人信息
                    if (pp != null)
                        supplierMoney = supplierMoney + (pp.FacePrice ?? 0);
                }
                traRetOrder.OrderDetailList.Add(detail);
                detail.SupplierMoney = supplierMoney - fee;//获取行程中乘车人总票面价（这里不取行程总价）
                detail.TotalPrice = detail.SupplierMoney ?? 0;
            }
            return AddRetOrder(traRetOrder);
        }

        #endregion
    }
}
