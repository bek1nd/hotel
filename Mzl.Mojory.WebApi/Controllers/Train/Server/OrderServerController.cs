using Mzl.Application.Train.Order.Factory;
using Mzl.Common.AutoMapperHelper;
using Mzl.Common.JsonHelper;
using Mzl.DomainModel.Train.Server;
using Mzl.IApplication.Train.Order.Domain;
using Mzl.IApplication.Train.Order.Factory;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Customer.Login;
using Mzl.UIModel.Search;
using Mzl.UIModel.Train.Order;
using Mzl.UIModel.Train.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using Mzl.Common.ConfigHelper;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Enum;

namespace Mzl.Mojory.WebApi.Controllers.Train.Server
{
    public class OrderServerController : ApiController
    {



        private IServerDomain domain = null;
        private IServerDomainFactory factory = null;


        /// <summary>
        /// 车票查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<SearchTrainResponseViewModel> GetQueryTrain([FromBody]SearchTrainRequestViewModel request)
        {
            factory = new QueryTrainFactory();
            domain = factory.CreateDomainObj();

            TraQueryTrainModel queryTrainModel = new TraQueryTrainModel()
            {
                from_station = request.FromStation,
                needdistance = request.NeedDistance,
                purpose_codes = request.PurposeCodes,
                to_station = request.ToStation,
                train_date = request.TrainDate

            };



            var obj = domain.DoQueryTrain(queryTrainModel);

            #region 格式变换
            //生成新的格式
            SearchTrainResponseViewModel exa = new SearchTrainResponseViewModel();
            List<string> formStation = new List<string>();
            List<string> toStation = new List<string>();
            List<string> trainType = new List<string>();
            //遍历
            foreach (var item in obj)
            {
                trainType.Add(item.train_type);
                formStation.Add(item.from_station_name);
                toStation.Add(item.to_station_name);
            }
            //去重
            HashSet<string> hTrainType = new HashSet<string>(trainType);
            HashSet<string> hFormStation = new HashSet<string>(formStation);
            HashSet<string> hToStation = new HashSet<string>(toStation);
            //引用
            List<TraTravelInfoViewModel> travelInfo = new List<TraTravelInfoViewModel>();
            foreach (var item in obj)
            {
                TraTravelInfoViewModel travelInfoViewModel = new TraTravelInfoViewModel()
                {

                    AccessByidCard = item.access_byidcard,
                    ArriveDays = item.arrive_days,
                    ArriveTime = item.arrive_time,
                    CanBuyNow = item.can_buy_now,
                    DetailList = AutoMapperHelper.DoMapList<TraTravelInfoDetailModel, TraTravelInfoDetailViewModel>(item.DetailList).ToList(),
                    Distance = item.distance,
                    EndStationName = item.end_station_name,
                    FromStationCode = item.from_station_code,
                    FromStationName = item.from_station_name,
                    Note = item.note,
                    RunTime = item.run_time,
                    RunTimeMinute = item.run_time_minute,
                    SaleDateTime = item.sale_date_time,
                    StartStationName = item.start_station_name,
                    StartTime = item.start_time,
                    ToStationCode = item.to_station_code,
                    ToStationName = item.to_station_name,
                    TrainCode = item.train_code,
                    TrainNo = item.train_no,
                    TrainStartDate = Convert.ToDateTime(queryTrainModel.train_date).ToString("yyyy-MM-dd"),//item.train_start_date,
                    TrainType = item.train_type

                };
                travelInfo.Add(travelInfoViewModel);
            }
           


            exa.TravelInfo = travelInfo;
            exa.FormStation = hFormStation.ToList();
            exa.ToStation = hToStation.ToList();
            exa.TrainType = hTrainType .ToList();
            #endregion

            var UIModel = new ResponseBaseViewModel<SearchTrainResponseViewModel>();
            var Flag = new ResponseCodeViewModel();
            UIModel.Flag = Flag;
            UIModel.Data = exa;
            if (exa.TravelInfo.Count > 0)
            {
                UIModel.Flag.Code = 0;

            }

            return UIModel;
        }

        /// <summary>
        /// 订单提交
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraOrderSubmitResponseViewModel> GetOrderSubmit([FromBody]TraOrderSubmitViewModel request)
        {
            factory = new OrderSubmitFactory();
            domain = factory.CreateDomainObj();

            TraOrderSubmitModel orderSubmitModel = new TraOrderSubmitModel()
            {
                train_date = request.TrainDate,
                to_station_name = request.ToStationName,
                checi = request.CheCi,
                choose_seats = request.ChooseSeats,
                from_station_code = request.FromStationCode,
                from_station_name = request.FromStationName,
                is_accept_standing = request.IsAcceptStanding,
                is_choose_seats = request.IsChooseSeats,
                LoginUserName = request.LoginUserName,
                LoginUserPassword = request.LoginUserPassword,
                passengers =
                    (List<TraOrderSubmitPassengerModel>)
                        AutoMapperHelper.DoMapList<TraOrderSubmitPassengerViewModel, TraOrderSubmitPassengerModel>(
                            request.Passengers),
                to_station_code = request.ToStationCode,
                orderid = request.Orderid
            };





            var obj = domain.DoOrderSubmit(orderSubmitModel);
            var UIModel = new ResponseBaseViewModel<TraOrderSubmitResponseViewModel>();
            var Flag = new ResponseCodeViewModel();
            UIModel.Flag = Flag;

            TraOrderSubmitResponseViewModel viewModel = new TraOrderSubmitResponseViewModel()
            {
                OrderID = obj.orderid
            };


            UIModel.Data = viewModel;
            if (obj.code == 100)
            {
                UIModel.Flag.Code = 0;

            }
            else
            {
                UIModel.Flag.Code = Convert.ToInt32(obj.code);
            }
            UIModel.Flag.Message = obj.msg;
            return UIModel;
        }

        /// <summary>
        /// 订单取消
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraOrderCancelResponseViewModel> GetOrderCancel([FromBody]TraOrderCancelViewModel request)
        {
            factory = new OrderCancelFactory();
            domain = factory.CreateDomainObj();
            TraOrderCancelModel orderCancelModel = new TraOrderCancelModel()
            {

                transactionid = request.TransactionID,
                orderid = request.OrderID,

            };



            var obj = domain.DoOrderCancel(orderCancelModel);
            var UIModel = new ResponseBaseViewModel<TraOrderCancelResponseViewModel>();
            var Flag = new ResponseCodeViewModel();
            UIModel.Flag = Flag;
            TraOrderCancelResponseViewModel model = new TraOrderCancelResponseViewModel()
            {
                OrderID = obj.orderid
            };


            UIModel.Data = model;
            if (obj.code == 100)
            {
                UIModel.Flag.Code = 0;

            }
            else
            {
                UIModel.Flag.Code = Convert.ToInt32(obj.code);
            }
            UIModel.Flag.Message = obj.msg;
            return UIModel;
        }

        /// <summary>
        /// 经停信息信息查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<List<TraTrainInfoResponseDateDetailViewModel>> GetTrainInfo(
            [FromBody] TraTrainInfoViewModel request)
        {
            factory = new TrainInfoFactory();
            domain = factory.CreateDomainObj();

            TraTrainInfoModel trainInfoModel = new TraTrainInfoModel()
            {
                from_station = request.FromStation,
                to_station = request.ToStation,
                train_code = request.TrainCode,
                train_date = request.TrainDate,
                train_no = request.TrainNo


            };


            var obj = domain.DoTrainInfo(trainInfoModel);
            var uiModel = new ResponseBaseViewModel<List<TraTrainInfoResponseDateDetailViewModel>>();
            if (obj == null)
            {
                throw new Exception("无经停信息");
            }
            var flag = new ResponseCodeViewModel();
            uiModel.Flag = flag;
            List<TraTrainInfoResponseDateDetailViewModel> listModel =
                new List<TraTrainInfoResponseDateDetailViewModel>();

            foreach (var item in obj)
            {
                TraTrainInfoResponseDateDetailViewModel model = new TraTrainInfoResponseDateDetailViewModel()
                {
                    ArriveDays = item.arrive_days,
                    ArriveTime = item.arrive_time,
                    StartTime = item.start_time,
                    StationName = item.station_name,
                    StationNo = item.station_no,
                    StopOverTime = item.stopover_time
                };
                listModel.Add(model);


            }




            uiModel.Data = listModel;

            if (obj.Count == 1)
            {
                uiModel.Flag.Code = 0;

            }




            return uiModel;
        }

        /// <summary>
        /// 火车票确认出票
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraOrderConfirmResponseViewModel> GetOrderConfirm([FromBody]TraOrderConfirmViewModel request)
        {
            #region 生产环境，测试帐号不许出票，直接返回
            string testCid = AppSettingsHelper.GetAppSettings(AppSettingsEnum.TestCid);//生产环境，测试帐号不许出票
            if (testCid == this.GetCid().ToString())
            {
                return new ResponseBaseViewModel<TraOrderConfirmResponseViewModel>()
                {
                    Flag = new ResponseCodeViewModel() { Code = 0 },
                    Data = new TraOrderConfirmResponseViewModel()
                    {
                        OrderID = request.OrderID,
                        OrderNumber = request.TransactionID
                    }
                };
            } 
            #endregion

            factory = new OrderConfirmFactory();
            domain = factory.CreateDomainObj();
            TraOrderConfirmModel orderConfirmModel = new TraOrderConfirmModel()
            {

                orderid = request.OrderID,
                transactionid = request.TransactionID
            };

            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain orderDomain = orderDomainFactory.CreateUpdateOrderDomainObj();

            domain.OrderConfirmEvent += orderDomain.DoOrderConfirmEvent;
            var obj = domain.DoOrderConfirm(orderConfirmModel);
            domain.OrderConfirmEvent -= orderDomain.DoOrderConfirmEvent;

            var uiModel = new ResponseBaseViewModel<TraOrderConfirmResponseViewModel>();
            var flag = new ResponseCodeViewModel();
            uiModel.Flag = flag;
            TraOrderConfirmResponseViewModel model = new TraOrderConfirmResponseViewModel()
            {

                OrderID = obj.orderid,
                OrderNumber = obj.ordernumber
                
            };
            uiModel.Flag.Message = obj.msg;
            uiModel.Data = model;
            if (obj.code == 100)
            {
                uiModel.Flag.Code = 0;

            }

            return uiModel;
        }

        /// <summary>
        /// 火车票线上退票
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraTicketRefundResponseViewModel> GetTichetRefund([FromBody]TraTicketRefundViewModel request)
        {
            #region 生产环境，测试帐号不许退票，直接返回
            string testCid = AppSettingsHelper.GetAppSettings(AppSettingsEnum.TestCid);//生产环境，测试帐号不许出票
            if (testCid == this.GetCid().ToString())
            {
                return new ResponseBaseViewModel<TraTicketRefundResponseViewModel>()
                {
                    Flag = new ResponseCodeViewModel() { Code = 0 },
                    Data = new TraTicketRefundResponseViewModel()
                    {
                        OrderId = request.Orderid,
                        OrderNumber = request.OrderNumber,
                        ReqToken = request.ReqToken
                    }
                };
            }
            #endregion
            factory = new TicketRefundFactory();
            domain = factory.CreateDomainObj();
            TraTicketRefundModel ticketRefundModel = new TraTicketRefundModel()
            {     
                LoginUserName = request.LoginUserName,
                orderid = request.Orderid,
                transactionid = request.TransactionId,
                LoginUserPassword = request.LoginUserPassword,
                ordernumber = request.OrderNumber,
                reqtoken = request.ReqToken,
                tickets = new List<RefundTicketDetailModel>()
                      
            };
            foreach (var item in request.Tickets)
            {
                RefundTicketDetailModel model = new RefundTicketDetailModel();
                model.passengername = item.PassengerName;
                model.passportseno = item.PassportseNo;
                model.passporttypeseid = item.PassportTypeseId;
                model.ticket_no = item.TicketNo;
                ticketRefundModel.tickets.Add(model);
                
            }



            
            var obj = domain.DoTicketRefund(ticketRefundModel);

            var uiModel = new ResponseBaseViewModel<TraTicketRefundResponseViewModel>();
            var flag = new ResponseCodeViewModel();
            uiModel.Flag = flag;
            TraTicketRefundResponseViewModel tmodel = new TraTicketRefundResponseViewModel()
            {

                OrderId = obj.orderid,
                OrderNumber = obj.ordernumber,
                ReqToken = obj.reqtoken,
                ToolTip = obj.tooltip
            };

            uiModel.Data = tmodel;
            if (obj.code == 100)
            {
                uiModel.Flag.Code = 0;

            }

            return uiModel;
        }

        /// <summary>
        /// 查询接口火车票状态
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<QueryTraInterfaceOrderStatusResponseViewMode> QueryTraInterfaceOrderStatus([FromBody]TraOrderRequestViewModel request)
        {
            if (!request.OrderId.HasValue)
                throw new Exception("请求参数需要orderid");
            IHoldSeatServerDomainFactory serverDomainFactory = new HoldSeatFactory();
            var statusDomain = serverDomainFactory.CreateQueryTraInterFaceOrderStatusObj();
            QueryTraInterfaceOrderStatusResponseViewMode viewMode = statusDomain.QueryHoldSeatStatus(request.OrderId.Value);
            ResponseBaseViewModel<QueryTraInterfaceOrderStatusResponseViewMode> v = new ResponseBaseViewModel<QueryTraInterfaceOrderStatusResponseViewMode>()
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = viewMode
            };

            return v;
        }
       

        /// <summary>
        /// 火车票改签创建
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraRequestChangeResponseViewModel> GetRequestChange([FromBody]TraRequestChangeViewModel request)
        {
            factory = new RequestChangeFactory();
            domain = factory.CreateDomainObj();
            TraRequestChangeModel rModel = new TraRequestChangeModel()
            { 
                change_checi = request.ChangeCheci,
                change_datetime = request.ChangeDatetime,
                change_zwcode = request.ChangeZwcode,
                from_station_code = request.FromStationCode,
                from_station_name = request.FromStationName,
                isasync = request.IsAsync,
                isTs = request.IsTs,
                LoginUserName = request.LoginUserName,
                LoginUserPassword = request.LoginUserPassword,
                old_zwcode = request.OldZwcode,
                orderid = request.OrderId,
                ordernumber = request.OrderNumber,
                reqtoken = request.ReqToken,
                ticketinfo = new List<TraRequestChangeTicketInfoModel>(),
                to_station_code = request.ToStationCode,
                to_station_name = request.ToStationName,
                transactionid = request.TransactionId
            };
            foreach (var item in request.TicketInfo)
            {
                TraRequestChangeTicketInfoModel infoModel = new TraRequestChangeTicketInfoModel()
                {  
                    old_ticket_no = item.OldTicketNo,
                    passengersename = item.PassengerseName,
                    passportseno = item.PassportseNo,
                    passporttypeseid = item.PassportTypeseId,
                    piaotype = item.PiaoType
                };
                rModel.ticketinfo.Add(infoModel);



            }

            var obj = domain.DoRequestChange(rModel);

            var uiModel = new ResponseBaseViewModel<TraRequestChangeResponseViewModel>();
            var flag = new ResponseCodeViewModel();
            uiModel.Flag = flag;
            TraRequestChangeResponseViewModel tmodel = new TraRequestChangeResponseViewModel()
            {
                HelpInfo = obj.help_info,
                OrderId = obj.orderid,
                ReqToken = obj.reqtoken,
                TransactionId = obj.transactionid

            };

            uiModel.Data = tmodel;
            if (obj.code == 100)
            {
                uiModel.Flag.Code = 0;

            }

            return uiModel;
        }


        /// <summary>
        /// 火车票改签取消
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraRequestCancelResponseViewModel> GetRequestCancel([FromBody]TraRequestCancelViewModel request)
        {
            factory = new RequestCancelFactory();
            domain = factory.CreateDomainObj();
            TraRequestCancelModel rcModel = new TraRequestCancelModel()
            {
                  transactionid = request.TransactionId,
                 orderid = request.OrderId,
                 reqtoken = request.ReqToken
            };

            TraRequestCancelResponseModel obj = domain.DoRequestCancel(rcModel);
            //obj.code = 100;


            var uiModel = new ResponseBaseViewModel<TraRequestCancelResponseViewModel>();
            var flag = new ResponseCodeViewModel();
            uiModel.Flag = flag;
            TraRequestCancelResponseViewModel tmodel = new TraRequestCancelResponseViewModel()
            {
                 
                OrderId = obj.orderid,
                
                TransactionId = obj.transactionid

            };

            uiModel.Data = tmodel;
            if (obj.code == 100)
            {
                uiModel.Flag.Code = 0;
            }
            else
            {
                throw new Exception(obj.msg);
            }

            return uiModel;

        }






        /// <summary>
        /// 火车票改签确认
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraRequestConfirmResponseViewModel> GetRequestConfirm([FromBody]TraRequestConfirmViewModel request)
        {
            #region 生产环境，测试帐号不许出票，直接返回
            string testCid = AppSettingsHelper.GetAppSettings(AppSettingsEnum.TestCid);//生产环境，测试帐号不许出票
            if (testCid == this.GetCid().ToString())
            {
                return new ResponseBaseViewModel<TraRequestConfirmResponseViewModel>()
                {
                    Flag = new ResponseCodeViewModel() { Code = 0 },
                    Data = new TraRequestConfirmResponseViewModel()
                    {
                        OrderId = request.OrderId,
                        TransactionId = request.TransactionId
                    }
                };
            }
            #endregion
            factory = new RequestConfirmFactory();
            domain = factory.CreateDomainObj();
            TraRequestConfirmModel rcModel = new TraRequestConfirmModel()
            {
                transactionid = request.TransactionId,
                orderid = request.OrderId,
                reqtoken = DateTime.Now.ToString("yyyyMMddHHmmss"),
                isasync = (string.IsNullOrEmpty(request.IsAsync) ? "Y" : request.IsAsync),
            };
            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain traOrderDomain = orderDomainFactory.CreateAddModOrderDomainObj();

            domain.ModComfireEvent += traOrderDomain.DoModComfireEvent;
            var obj = domain.DoRequestConfirm(rcModel);
            domain.ModComfireEvent -= traOrderDomain.DoModComfireEvent;

            var uiModel = new ResponseBaseViewModel<TraRequestConfirmResponseViewModel>();
            var flag = new ResponseCodeViewModel();
            uiModel.Flag = flag;
            TraRequestConfirmResponseViewModel tmodel = new TraRequestConfirmResponseViewModel()
            {

                OrderId = obj.orderid,
                 ReqToken =  obj.reqtoken,

                TransactionId = obj.transactionid

            };

            uiModel.Data = tmodel;
            if (obj.code == 100)
            {
                uiModel.Flag.Code = 0;

            }

            return uiModel;

        }



        /// <summary>
        /// 通过对方接口查询火车票信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraSearchOrderInfoResponseViewModel> GetOrderInfo([FromBody]TraSearchOrderInfoViewModel request)
        {

            factory = new OrderInfoFactory();
            domain = factory.CreateDomainObj();
            TraSearchOrderInfoModel rcModel = new TraSearchOrderInfoModel()
            {
                  transactionid =request.TransactionId,
                   orderid  =request.OrderId
                   

            };

            var obj = domain.DoSearchOrderInfo(rcModel);
            var uiModel = new ResponseBaseViewModel<TraSearchOrderInfoResponseViewModel>();
            var flag = new ResponseCodeViewModel();
            uiModel.Flag = flag;
            TraSearchOrderInfoResponseViewModel tmodel = new TraSearchOrderInfoResponseViewModel()
            { 
                 CashChange = obj.cashchange,
                CheCi = obj.checi, OrderId = obj.orderid,
                TransactionId = obj.transactionid,
                FromStation = obj.fromstation,
                OrderNumber = obj.ordernumber,
                OrderStatusName = obj.orderstatusname,
                ToStation = obj.tostation,
                TrainTime = obj.traintime,
                TicketStatus = new List<TicketStatusViewModel>()
                  
            };
            foreach (var item in obj.ticketstatus)
            {
                TicketStatusViewModel mo = new TicketStatusViewModel();
                mo.Cxin = item.cxin;
                mo.PassengerseName = item.passengersename;
                mo.PiaoTypeName = item.piaotypename;
                mo.Price = item.price;
                mo.Status = item.status;
                mo.StatusId = item.statusid;
                mo.TicketNo = item.ticket_no;
                
                tmodel.TicketStatus.Add(mo);

            }
            




            uiModel.Data = tmodel;
            if (obj.code == 100)
            {
                uiModel.Flag.Code = 0;

            }

            return uiModel;

        }
        

    }
}