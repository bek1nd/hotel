using Mzl.UIModel.Base;
using Mzl.UIModel.Train.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.Application.Customer.Factory;
using Mzl.DomainModel.Customer.Passenger;
using Mzl.IApplication.Customer.Factory;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Passenger;
using Mzl.Common.AutoMapperHelper;
using Mzl.DomainModel.Customer.Identification;
using Mzl.UIModel.Customer.Identification;
using Mzl.DomainModel.Customer.CostCenter;
using Mzl.UIModel.Customer.Corporation;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.DomainModel.Train.Order;
using Mzl.IApplication.Train.Order.Factory;
using Mzl.Application.Train.Order.Factory;
using Mzl.IApplication.Train.Order.Domain;
using Mzl.Common.Exceptions;
using Mzl.Common.EnumHelper;
using Mzl.IApplication.Customer.Domain;
using Mzl.DomainModel.Enum;
using Mzl.Application.Train.Order.Domain;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.Corp;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.UIModel.Customer.Customer;
using Mzl.DomainModel.Train.BaseMaintenance;
using Mzl.UIModel.Train.BaseMaintenance;
using System.Configuration;
using AutoMapper;
using Mzl.Common.ConfigHelper;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Net.Http.Headers;

namespace Mzl.Mojory.WebApi.Controllers.Train.Order
{
    /// <summary>
    /// 火车票业务
    /// </summary>
    public class TraOrderController : ApiController
    {

        #region 正单
        /// <summary>
        /// 获取火车确认订单视图api
        /// </summary>
        /// <returns></returns>
        [Obsolete("该api已经废弃，使用ConfirmTraOrderView/GetConfirmTraOrderView代替")]
        [HttpPost]
        public ResponseBaseViewModel<ConfirmTraOrderResponseViewModel> TraComfireOrderView([FromBody]TraOrderRequestViewModel request)
        {
            if (request == null)
                throw new Exception("请检查Post数据格式");
            int cid = this.GetCid();

            #region 联系人信息
            ICustomerDomainFactory factory = new CustomerDomainFactory();
            var domain = factory.CreatePassengerInfoDomainObj();
            var customerInfo = domain.GetCustomerInfo(cid);
            List<PassengerViewModel> passengerViewModels = new List<PassengerViewModel>();

            List<PassengerInfoModel> passengerList = domain.GetPassengerInfoList(cid, request.DepartId);
            foreach (var p in passengerList)
            {
                PassengerViewModel passengerViewModel = new PassengerViewModel();
                passengerViewModel.ContactId = p.ContactId;
                passengerViewModel.PassengerName = p.PassengerName;
                passengerViewModel.Mobile = p.Mobile;
                passengerViewModel.Phone = p.Phone;
                passengerViewModel.Email = p.Email;
                passengerViewModel.Fax = p.Fax;
                passengerViewModel.IdentificationList = (List<IdentificationViewModel>)
                    AutoMapperHelper.DoMapList<IdentificationModel, IdentificationViewModel>(p.IdentificationList);
                passengerViewModels.Add(passengerViewModel);
            }
            #endregion

            #region 成本中心/项目名称/服务费
            List<CostCenterViewModel> costCenterViewModels = null;
            List<ProjectNameViewModel> projectNameViewModels = null;
            decimal serviceFee = 0;
            ICorporationDomainFactory corporationDomainFactory = new CorporationDomainFactory();
            var corporationDomain = corporationDomainFactory.CreateComfireOrderViewObj();
            int IsPrint = 0;
            if (!string.IsNullOrEmpty(customerInfo.CorpId))
            {
                CorporationModel corporationModel = corporationDomain.GetCorporationByCorId(customerInfo.CorpId);
                IsPrint = corporationModel.IsPrint ?? 0;
                List<CostCenterModel> costCenterModels = corporationDomain.GetCostCenter(customerInfo.CorpId);
                costCenterViewModels = (List<CostCenterViewModel>)
                    AutoMapperHelper.DoMapList<CostCenterModel, CostCenterViewModel>(costCenterModels);

                List<ProjectNameModel> projectNameModels = corporationDomain.GetProjectName(customerInfo.CorpId);
                projectNameViewModels = (List<ProjectNameViewModel>)
                    AutoMapperHelper.DoMapList<ProjectNameModel, ProjectNameViewModel>(projectNameModels);
            }

            //服务费
            string type = "tra";
            if(request.IsGrabTicket)
                type = "traGrab";
            serviceFee = corporationDomain.GetServiceFeeByCorpId(customerInfo.Cid, type);
        

            #endregion

            List<SortedListViewModel> accountViewModels = null;
            List<SortedListViewModel> sendTicketTypeList = null;
            List<SortedListViewModel> payTypeList = null;
            //火车票订单确认信息
            if (request.RequestType == OrderSourceTypeEnum.Tra.ToString())
            {
                #region 12306帐号
                IOrderDomainFactory traOrderDomainFactory = new OrderDomainFactory();
                IOrderDomain accountOrderDomain = traOrderDomainFactory.Create12306AccountDomainObj();
                List<Tra12306AccountModel> accountModels = accountOrderDomain.GetTra12306AccountList();
                accountViewModels = (from n in accountModels
                    select new SortedListViewModel()
                    {
                        Key = n.PassId,
                        Value = n.UserName
                    }).ToList();
                #endregion
                #region 配送信息
                SortedList<int, string> sendTicketList = EnumConvert.QueryEnum<SendTicketTypeEnum>();
                sendTicketTypeList= (from sendTicket in sendTicketList
                    where sendTicket.Key != (int) SendTicketTypeEnum.Not
                    select new SortedListViewModel()
                    {
                        Key = sendTicket.Key, Value = sendTicket.Value
                    }).ToList();
                #endregion
                #region 支付方式

                payTypeList = new List<SortedListViewModel>
                {
                    new SortedListViewModel()
                    {
                        Key = PayTypeEnum.Cas.ToString(),
                        Value = PayTypeEnum.Cas.ToDescription()
                    },
                    new SortedListViewModel()
                    {
                        Key = PayTypeEnum.Chk.ToString(),
                        Value = PayTypeEnum.Chk.ToDescription()
                    }
                };
                if (!string.IsNullOrEmpty(customerInfo.CorpId))
                {
                    payTypeList.Add(new SortedListViewModel()
                    {
                        Key = PayTypeEnum.Cro.ToString(),
                        Value = PayTypeEnum.Cro.ToDescription()
                    });
                }

                #endregion
            }

            #region 乘车人/乘机人类型
            SortedList<int, string> ageTypeSortedList = EnumConvert.QueryEnum<AgeTypeEnum>();
            List<SortedListViewModel> passengerTypeList = (from n in ageTypeSortedList
                select new SortedListViewModel()
                {
                    Key = n.Key,
                    Value = n.Value
                }).ToList();
            #endregion
            #region 证件类型
            SortedList<int, string> cardTypeSortedList = EnumConvert.QueryEnum<CardTypeEnum>();
            List<SortedListViewModel> cardTypeList = (from n in cardTypeSortedList
                select new SortedListViewModel()
                {
                    Key = n.Key,
                    Value = n.Value
                }).ToList();
            #endregion
            ResponseBaseViewModel<ConfirmTraOrderResponseViewModel> v = new ResponseBaseViewModel<ConfirmTraOrderResponseViewModel>();
            v.Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() };
            v.Data = new ConfirmTraOrderResponseViewModel()
            {
                IsMaster = customerInfo.IsMaster,
                PassengerList = passengerViewModels,
                CostCenterList = costCenterViewModels,
                ProjectNameList = projectNameViewModels,
                CName = customerInfo.RealName,
                EMail = customerInfo.EMail,
                Mobile = customerInfo.Mobile,
                ServiceFee = serviceFee,
                AccountList = accountViewModels,
                SendTicketTypeList = sendTicketTypeList,
                PayTypeList = payTypeList,
                PassengerTypeList = passengerTypeList,
                CardTypeList = cardTypeList,
                IsPrint = IsPrint
            };
            return v;
        }
        /// <summary>
        /// 火车票新增订单api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Obsolete("已废弃，改为AddTraOrder/AddTraOrder")]
        public ResponseBaseViewModel<string> AddTraOrder([FromBody]TraAddOrderModel request)
        {
            if (request == null)
                throw new Exception("请检查Post数据格式");
            if (request.Order == null)
                throw new Exception("传入订单参数异常");
            //判断当前提交信息中的乘车人信息是否完全
            if (request.OrderDetailList.SelectMany(detail => detail.PassengerList).Any(p => string.IsNullOrEmpty(p.CardNo)))
            {
                throw new Exception("乘机人证件信息不能为空！");
            }

            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain orderDomain = orderDomainFactory.CreateAddOrderDomainObj();
            IServerDomainFactory serverDomainfactory = new OrderSubmitFactory();
            IServerDomain serverDomain = serverDomainfactory.CreateDomainObj();

            ICustomerDomainFactory customerDomainFactory = new CustomerDomainFactory();
            ICustomerDomain customerDomain = customerDomainFactory.CreatePassengerInfoDomainObj();

            request.Order.Cid = this.GetCid();
            request.OrderSource = this.GetOrderSource();
            if (!string.IsNullOrEmpty(request.Order.IsOnline) && request.Order.IsOnline.ToUpper() == "T")
                request.Order.CreateOid = "sys";
            else
                request.Order.CreateOid = this.GetOid();

            if (!request.Order.SendType.HasValue)
                request.Order.SendType = 3;
            if (!request.Order.PayType.HasValue)
                request.Order.PayType = PayTypeEnum.Cro;
            if (string.IsNullOrEmpty(request.Order.IsOnline))
                request.Order.IsOnline = "F";

            orderDomain.AddContactEvent += customerDomain.AddContactEventListener;
            int orderid = 0;
            //判断是否是生产环境，如果不是则强制request.AddOrderType=1，不走接口
            string isServer = AppSettingsHelper.GetAppSettings(AppSettingsEnum.IsServer);
            if (isServer != "T")
            {
                request.AddOrderType = 1;
            }
            /*
             * 这里创建订单分为两种情况，为0是走接口，不为0是不走接口
             */
            if (request.AddOrderType != 0) //不走接口创建订单
            {
                orderid = orderDomain.AddOrder(request);
            }
            else
            {
                //走接口创建订单
                orderDomain.ServerOrderSubmit += serverDomain.DoOrderSubmitrEvent; //添加访问第三方创建订单接口事件
                orderid = orderDomain.AddOrder(request);
                orderDomain.ServerOrderSubmit -= serverDomain.DoOrderSubmitrEvent;
            }
            orderDomain.AddContactEvent -= customerDomain.AddContactEventListener;
            ResponseBaseViewModel<string> v = new ResponseBaseViewModel<string>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = orderid.ToString()
            };
            return v;
        }
        /// <summary>
        /// 火车票列表视图api
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraOrderListQueryViewModel> OrderListView()
        {

            ICustomerDomainFactory customerDomainFactory = new CustomerDomainFactory();
            var customerDomain = customerDomainFactory.CreateDomainObj();
            var customerInfo = customerDomain.GetCustomerInfo(this.GetCid());

            ICorporationDomainFactory corporationDomainFactory = new CorporationDomainFactory();
            ICorporationDomain corporationDomain = corporationDomainFactory.CreateDomainProjectNameAndCostCenterObj();
            List<CostCenterModel> costCenterModels = corporationDomain.GetCostCenter(customerInfo.CorpId);
            List<ProjectNameModel> projectNameModels = corporationDomain.GetProjectName(customerInfo.CorpId);

            List<CostCenterViewModel> costCenterViewModels =
                (List<CostCenterViewModel>)
                    AutoMapperHelper.DoMapList<CostCenterModel, CostCenterViewModel>(costCenterModels);
            List<ProjectNameViewModel> projectNameViewModels =
                (List<ProjectNameViewModel>)
                    AutoMapperHelper.DoMapList<ProjectNameModel, ProjectNameViewModel>(projectNameModels);

            List<SortedListViewModel> orderStatuslist = new List<SortedListViewModel>();
            SortedList<int, string> orderSortedList = new SortedList<int, string>();// EnumConvert.QueryEnum<OrderTypeEnum>();
            orderSortedList.Add((int)OrderTypeEnum.ApplyHoldSeat, OrderTypeEnum.ApplyHoldSeat.ToDescription());
            orderSortedList.Add((int)OrderTypeEnum.HoldSeatSuccess, OrderTypeEnum.HoldSeatSuccess.ToDescription());
            orderSortedList.Add((int)OrderTypeEnum.MakingTicket, OrderTypeEnum.MakingTicket.ToDescription());
            orderSortedList.Add((int)OrderTypeEnum.TicketSuccess, OrderTypeEnum.TicketSuccess.ToDescription());
            orderSortedList.Add(99, "审批中");
            orderSortedList.Add(98, "已取消");

            foreach (var l in orderSortedList)
            {
                orderStatuslist.Add(new SortedListViewModel()
                {
                    Key = l.Key,
                    Value = l.Value
                });
            }
            orderStatuslist.Add(new SortedListViewModel() { Key = -1, Value = "处理中" });

            ResponseBaseViewModel<TraOrderListQueryViewModel> v = new ResponseBaseViewModel<TraOrderListQueryViewModel>()
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = new TraOrderListQueryViewModel
                {
                    CostCenterList = costCenterViewModels,
                    ProjectNameList = projectNameViewModels,
                    TraOrderStatusList = orderStatuslist
                }
            };
            return v;
        }
        /// <summary>
        /// 订单列表查询api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<ListBaseViewModel<List<TraOrderListDataViewModel>>> GetOrderList([FromBody] TraOrderListQueryModel request)
        {
            if (request == null)
                throw new Exception("请检查Post数据格式");
            int totalCount = 0;
            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain domain = orderDomainFactory.CreateOrderListDomainObj();
            request.Cid = this.GetCid();

            ICustomerDomainFactory customerDomainFactory = new CustomerDomainFactory();
            var customerDomain = customerDomainFactory.CreateDomainObj();
            var customerInfo = customerDomain.GetCustomerInfo(request.Cid.Value);
            request.CorpId = customerInfo.CorpId;
            request.UserId = customerInfo.UserId;
            if (!string.IsNullOrEmpty(request.CorpId))
            {
                ICorporationDomainFactory corporationDomainFactory = new CorporationDomainFactory();
                var corporationDomain = corporationDomainFactory.CreateDomainObj();
                request.AllowShowDataBeginTime =
                    corporationDomain.GetCorporationByCorId(request.CorpId)?.AllowShowDataBeginTime;
            }

            List<TraOrderListDataModel> orderList = domain.GetTraOrderByPageList(request, ref totalCount);
            ResponseBaseViewModel<ListBaseViewModel<List<TraOrderListDataViewModel>>> v =
                new ResponseBaseViewModel<ListBaseViewModel<List<TraOrderListDataViewModel>>>
                {
                    Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                    Data = new ListBaseViewModel<List<TraOrderListDataViewModel>>()
                    {
                        ListData = (List<TraOrderListDataViewModel>)AutoMapperHelper.DoMapList<TraOrderListDataModel, TraOrderListDataViewModel>(orderList),
                        TotalCount = totalCount
                    }
                };
            return v;
        }
        /// <summary>
        /// 火车票订单列表导出
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ExportOrderList([FromUri]TraOrderListQueryModel request)
        {
            if (request == null)
                throw new Exception("请检查Post数据格式");
            request.IsExport = 1;
            int totalCount = 0;
            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain domain = orderDomainFactory.CreateOrderListDomainObj();
            request.Cid = this.GetCid();

            ICustomerDomainFactory customerDomainFactory = new CustomerDomainFactory();
            var customerDomain = customerDomainFactory.CreateDomainObj();
            var customerInfo = customerDomain.GetCustomerInfo(request.Cid.Value);
            request.CorpId = customerInfo.CorpId;
            request.UserId = customerInfo.UserId;
            if (!string.IsNullOrEmpty(request.CorpId))
            {
                ICorporationDomainFactory corporationDomainFactory = new CorporationDomainFactory();
                var corporationDomain = corporationDomainFactory.CreateDomainObj();
                request.AllowShowDataBeginTime =
                    corporationDomain.GetCorporationByCorId(request.CorpId)?.AllowShowDataBeginTime;
            }

            List<TraOrderListDataModel> orderList = domain.GetTraOrderByPageList(request, ref totalCount);
            ResponseBaseViewModel<ListBaseViewModel<List<TraOrderListDataViewModel>>> v =
                new ResponseBaseViewModel<ListBaseViewModel<List<TraOrderListDataViewModel>>>
                {
                    //, MojoryToken = this.GetToken() 
                    Flag = new ResponseCodeViewModel() { Code = 0},
                    Data = new ListBaseViewModel<List<TraOrderListDataViewModel>>()
                    {
                        ListData = (List<TraOrderListDataViewModel>)AutoMapperHelper.DoMapList<TraOrderListDataModel, TraOrderListDataViewModel>(orderList),
                        TotalCount = totalCount
                    }
                };

            var file = ExcelStream(v.Data.ListData);
            //string csv = _service.GetData(model);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(file);
            //a text file is actually an octet-stream (pdf, etc)
            //result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            //we used attachment to force download
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = "火车票订单列表.xls";
            return result;
        }
        private Stream ExcelStream(List<TraOrderListDataViewModel> orderList)
        {
            //var list = dc.v_bs_dj_bbcdd1.Where(eps).ToList();
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("火车票订单");


            IRow rowHeader = sheet1.CreateRow(0);

            //生成excel标题
            rowHeader.CreateCell(0).SetCellValue("订单号");
            rowHeader.CreateCell(1).SetCellValue("成本中心");
            rowHeader.CreateCell(2).SetCellValue("项目名称");
            rowHeader.CreateCell(3).SetCellValue("出行人");
            rowHeader.CreateCell(4).SetCellValue("行程");
            rowHeader.CreateCell(5).SetCellValue("发车时间");
            rowHeader.CreateCell(6).SetCellValue("订票时间");
            rowHeader.CreateCell(7).SetCellValue("票价（含服务费）");
            rowHeader.CreateCell(8).SetCellValue("订单状态");
            int j = 0;
            //生成excel内容
            foreach (var item in orderList)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(1 + j);
                rowtemp.CreateCell(0).SetCellValue(item.OrderId);
                rowtemp.CreateCell(1).SetCellValue(item.CostCenter);
                //string 
                rowtemp.CreateCell(2).SetCellValue(item.ProjectName);
                rowtemp.CreateCell(3).SetCellValue(item.PassengerNameListDesc);
                rowtemp.CreateCell(4).SetCellValue(item.TravelListDesc);
                rowtemp.CreateCell(5).SetCellValue(item.StartTimeListDesc);
                rowtemp.CreateCell(6).SetCellValue(item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                rowtemp.CreateCell(7).SetCellValue(item.TotalMoney.ToString());
                rowtemp.CreateCell(8).SetCellValue(item.OrderStatus.ToString());
                j++;
            }

            for (int i = 0; i < 10; i++)
                sheet1.AutoSizeColumn(i);

            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            file.Seek(0, SeekOrigin.Begin);
            return file;
        }


        /// <summary>
        /// 火车订单详情api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraOrderInfoViewModel> GetOrderInfo([FromBody]TraOrderRequestViewModel request)
        {
            if (request == null)
                throw new Exception("请检查Post数据格式");
            if (!request.OrderId.HasValue)
                throw new Exception("请传入订单号");

            int cid = this.GetCid();
            ICustomerDomainFactory customerDomainFactory = new CustomerDomainFactory();
            ICustomerDomain customerDomain = customerDomainFactory.CreateDomainObj();
            CustomerInfoModel customerInfo = customerDomain.GetCustomerInfo(cid);

           

            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain orderDomain = null;
            TraOrderInfoModel traOrderInfo = null;
            List<TraOrderInfoModel> traRetModels = null;
            List<TraModOrderInfoModel> traModModels = null;
            orderDomain = orderDomainFactory.CreateAppOrderInfoDomainObj();
            traOrderInfo = orderDomain.GetTraOrderByOrderId(request.OrderId.Value);
            traRetModels = orderDomain.GetTraRetOrderByRootOrderId(request.OrderId.Value);
            traModModels = orderDomain.GetTraModOrderByRootOrderId(request.OrderId.Value);

            if (!string.IsNullOrEmpty(customerInfo.CorpId))
            {
                ICorporationDomainFactory corporationDomainFactory = new CorporationDomainFactory();
                var corporationDomain = corporationDomainFactory.CreateDomainObj();
                CorporationModel  corporationModel= corporationDomain.GetCorporationByCorId(customerInfo.CorpId);
                if (corporationModel != null && corporationModel.AllowShowDataBeginTime.HasValue &&
                    traOrderInfo.Order != null)
                {
                    if (corporationModel.AllowShowDataBeginTime > traOrderInfo.Order.CreateTime)
                    {
                        throw new Exception("查无此订单");
                    }
                }
            }

            #region 判断/当前登录用户是administrator，如果订单所属的公司不等于当前公司

            //当前登录用户是administrator，如果订单所属的公司不等于当前公司
            if (customerInfo.UserId.ToLower() == "administrator" && traOrderInfo.CustomerInfo.CorpId != customerInfo.CorpId)
            {
                throw new Exception("该订单不属于当前用户");
            }
            if ((customerInfo.IsShowAllOrder ?? 0) == 0)//如果当前用户没有查看公司全部订单的权限
            {
                if (customerInfo.UserId.ToLower() != "administrator" && traOrderInfo.CustomerInfo.Cid != customerInfo.Cid)
                {
                    throw new Exception("该订单不属于当前用户");
                }
            }

            #endregion

            TraOrderInfoViewModel viewModel = new TraOrderInfoViewModel();
            viewModel.Order = AutoMapperHelper.DoMap<TraOrderModel, TraOrderViewModel>(traOrderInfo.Order);
            viewModel.Order.ShowOnlineOrderId = traOrderInfo.ShowOnlineOrderId;
            viewModel.CustomerInfo = AutoMapperHelper.DoMap<CustomerInfoModel, CustomerInfoViewModel>(traOrderInfo.CustomerInfo);
            viewModel.OrderDetailList = new List<TraOrderDetailViewModel>();
            foreach (var d in traOrderInfo.OrderDetailList)
            {
                #region 正单行程信息

                TraOrderDetailViewModel dd = new TraOrderDetailViewModel()
                {
                    OdId = d.OdId,
                    OrderId = d.OrderId,
                    EndCity = d.EndCity,
                    EndCode = d.EndCode,
                    EndName = d.EndName,
                    EndNameCode = d.EndNameCode,
                    EndTime = d.EndTime,
                    FacePrice = d.FacePrice,
                    PlaceGrade = d.PlaceGrade,
                    PlaceGradeCode = d.PlaceGradeCode,
                    PlaceType = d.PlaceType,
                    RefundFee = d.RefundFee,
                    StartCity = d.StartCity,
                    StartCode = d.StartCode,
                    StartName = d.StartName,
                    StartNameCode = d.StartNameCode,
                    StartNameId = d.StartNameId,
                    StartTime = d.StartTime,
                    SupplierMoney = d.SupplierMoney,
                    TicketNum = d.TicketNum,
                    TotalPrice = d.TotalPrice,
                    TrainNo = d.TrainNo,
                    TicketNo = d.OrderId12306,
                    CorpPolicy = d.CorpPolicy,
                    ChoiceReason = d.ChoiceReason
                };
                #endregion
                dd.PassengerList = new List<TraPassengerViewModel>();
                foreach (var p in d.PassengerList)
                {
                    TraPassengerViewModel pp = AutoMapperHelper.DoMap<TraPassengerModel, TraPassengerViewModel>(p);
                    pp.PassengerStatus = traOrderInfo.Order.OrderStatus;
                    #region 乘车人改签信息
                    if (traModModels != null)
                    {
                        foreach (var modOrder in traModModels)
                        {
                            foreach (var modDetail in modOrder.OrderDetailList)
                            {
                                foreach (var modPass in modDetail.PassengerList)
                                {
                                    if (modPass.Name == pp.Name)
                                    {
                                        pp.PassengerStatus = modOrder.Order.OrderStatusDesc;
                                        pp.ModTravelInfo = new TrainPassengerModRetTravelViewModel()
                                        {
                                            StartName = modDetail.AddrName,
                                            EndName = modDetail.EndName,
                                            StartTime = modDetail.SendTime ?? Convert.ToDateTime("2000-01-01"),
                                            EndTime = modDetail.EndTime ?? Convert.ToDateTime("2000-01-01"),
                                            TrainNo = modDetail.TrainNo,
                                            PlaceType = modDetail.PlaceType,
                                            PlaceGrade = modDetail.PlaceGrade,
                                            PlaceCar = modDetail.PlaceCar,
                                            PlaceSeatNo = modDetail.PlaceSeatNo,
                                            ModFacePrice = modDetail.TrainMoney,
                                            ModOrderTime = modOrder.Order.CreateTime,
                                            CorderId = modDetail.CorderId,
                                            TicketNo = modPass.TicketNo
                                        };
                                        if (pp.ModTravelInfo != null)
                                        {
                                            pp.IsMod = true;
                                        }
                                    }
                                }
                            }

                        }

                    }
                    #endregion
                    #region 乘车人退票信息
                    if (traRetModels != null)
                    {
                        foreach (var ret in traRetModels)
                        {
                            foreach (var retDetail in ret.OrderDetailList)
                            {
                                foreach (var retPass in retDetail.PassengerList)
                                {
                                    if (retPass.Name == pp.Name)
                                    {
                                        pp.PassengerStatus = ret.Order.OrderStatus;
                                        pp.RefundTravelInfo = new TrainPassengerModRetTravelViewModel()
                                        {
                                            StartName = ret.OrderDetailList[0].StartName,
                                            EndName = ret.OrderDetailList[0].EndName,
                                            StartTime = ret.OrderDetailList[0].StartTime,
                                            EndTime = ret.OrderDetailList[0].EndTime,
                                            TrainNo = ret.OrderDetailList[0].TrainNo,
                                            PlaceType = ret.OrderDetailList[0].PlaceType,
                                            PlaceGrade = ret.OrderDetailList[0].PlaceGrade,
                                            PlaceCar = retPass.PlaceCar,
                                            PlaceSeatNo = retPass.PlaceSeatNo,
                                            RefundPrice = ret.OrderDetailList[0].FacePrice,
                                            RefundOrderTime = ret.Order.CreateTime,
                                            RefundOrderId= ret.OrderDetailList[0].OrderId,
                                            TicketNo = retPass.TicketNo
                                        };

                                        if (pp.RefundTravelInfo != null)
                                        {
                                            pp.IsRefund = true;
                                        }
                                    }
                                }
                            }
                        }



                    }
                    #endregion
                    dd.PassengerList.Add(pp);
                }

                viewModel.OrderDetailList.Add(dd);
            }
            ResponseBaseViewModel<TraOrderInfoViewModel> v = new ResponseBaseViewModel<TraOrderInfoViewModel>()
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        /// <summary>
        /// 查询火车车次信息视图api
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<QueryTraTravelViewModel> QueryTrainView()
        {
            int cid = this.GetCid();
            ICustomerDomainFactory customerDomainFactory = new CustomerDomainFactory();
            ICustomerDomain domain = customerDomainFactory.CreateQueryTravelViewDomainObj();
            BaseQueryTravelModel travelModel = domain.GetQueryTravelView(cid);
            QueryTraTravelViewModel viewModel = new QueryTraTravelViewModel();
            viewModel.IsMaster = travelModel.IsMaster;
            viewModel.IsCorpSystemCustomer = travelModel.IsCorpSystemCustomer;
            viewModel.DepartmentList =
                (List<CorpDepartmentViewModel>)AutoMapperHelper.DoMapList<CorpDepartmentModel, CorpDepartmentViewModel>(travelModel.DepartmentList);
            viewModel.PlaceGradeList=new List<SortedListViewModel>();
            var placeList = EnumConvert.QueryEnum<TrainPlaceGradeEnum>(); 
            foreach (var place in placeList)
            {
                viewModel.PlaceGradeList.Add(new SortedListViewModel()
                {
                    Key = place.Key.ValueToDescription<TrainPlaceGradeEnum>(),
                    Value = place.Key.ValueToDescription<TrainPlaceGradeEnum>()
                });
            }
            ResponseBaseViewModel<QueryTraTravelViewModel> v = new ResponseBaseViewModel<QueryTraTravelViewModel>()
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };

            return v;
        }
        /// <summary>
        /// 自动解析12306订单格式
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ResponseBaseViewModel<List<TraOrderDetailViewModel>> AutoAnalysis([FromBody]TraOrderRequestViewModel request)
        {
            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain orderDomain = orderDomainFactory.CreateDomainObj();
            List<TraOrderDetailModel> detail = orderDomain.AutoAnalysis(request.AnalysisArgs);

            List<TraOrderDetailViewModel> viewModel = new List<TraOrderDetailViewModel>();
            foreach (var d in detail)
            {
                TraOrderDetailViewModel dd = new TraOrderDetailViewModel()
                {
                    OdId = d.OdId,
                    OrderId = d.OrderId,
                    EndCity = d.EndCity,
                    EndCode = d.EndCode,
                    EndName = d.EndName,
                    EndNameCode = d.EndNameCode,
                    EndTime = d.EndTime,
                    FacePrice = d.FacePrice,
                    PlaceGrade = d.PlaceGrade,
                    PlaceGradeCode = d.PlaceGradeCode,
                    PlaceType = d.PlaceType,
                    RefundFee = d.RefundFee,
                    StartCity = d.StartCity,
                    StartCode = d.StartCode,
                    StartName = d.StartName,
                    StartNameCode = d.StartNameCode,
                    StartNameId = d.StartNameId,
                    StartTime = d.StartTime,
                    SupplierMoney = d.SupplierMoney,
                    TicketNum = d.TicketNum,
                    TotalPrice = d.TotalPrice,
                    TrainNo = d.TrainNo
                };
                dd.PassengerList = (List<TraPassengerViewModel>)AutoMapperHelper.DoMapList<TraPassengerModel, TraPassengerViewModel>(d.PassengerList);
                viewModel.Add(dd);
            }


            ResponseBaseViewModel<List<TraOrderDetailViewModel>> v = new ResponseBaseViewModel<List<TraOrderDetailViewModel>>()
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }

        #endregion

        #region 退单
        /// <summary>
        /// 火车票退票提交视图api
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraRetModOrderViewModel> TraRetOrderView([FromBody]TraOrderRequestViewModel request)
        {
            if (request == null)
                throw new Exception("请检查Post数据格式");
            if (!request.OrderId.HasValue)
                throw new Exception("请传入订单号");
            bool isFromOnline = this.CheckIsFromOnline();
            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain orderDomain = orderDomainFactory.CreateAddRetOrderViewDomainObj();
            TraRetModOrderModel retOrderModel = orderDomain.GetAddTraRetOrderView(request.OrderId.Value, isFromOnline,
                request.CorderId);

            TraRetModOrderViewModel viewModel=new TraRetModOrderViewModel();
            viewModel.TravelInfoList =new List<TraOrderDetailViewModel>();
            viewModel.OrderFrom = retOrderModel.OrderFrom;
            foreach (var travel in retOrderModel.TravelInfoList)
            {
                TraOrderDetailViewModel detailView = new TraOrderDetailViewModel()
                {
                    OdId = travel.OdId,
                    OrderId = travel.OrderId,
                    StartNameId = travel.StartNameId,
                    StartName = travel.StartName,
                    StartNameCode = travel.StartNameCode,
                    StartCity = travel.StartCity,
                    EndName = travel.EndName,
                    EndNameCode = travel.EndNameCode,
                    EndCity = travel.EndCity,
                    StartTime = travel.StartTime,
                    EndTime = travel.EndTime,
                    TrainNo = travel.TrainNo,
                    PlaceType = travel.PlaceType,
                    PlaceGrade = travel.PlaceGrade,
                    TicketNum = travel.TicketNum,
                    FacePrice = travel.FacePrice,
                    TotalPrice = travel.TotalPrice,
                    SupplierMoney = travel.SupplierMoney,
                    RefundFee = travel.RefundFee,
                    PlaceGradeCode = travel.PlaceGradeCode,
                    StartCode = travel.StartCode,
                    EndCode = travel.EndCode,
                    RefundRate= travel.RefundRate,
                    PassengerList = new List<TraPassengerViewModel>()
                };

                foreach (var p in travel.PassengerList)
                {
                    detailView.PassengerList.Add(new TraPassengerViewModel()
                    {
                        Pid = p.Pid,
                        Name = p.Name,
                        CardNo = p.CardNo,
                        CardNoType = (int)p.CardNoType,
                        CardNoTypeDesc = p.CardNoTypeDesc,
                        Mobile = p.Mobile,
                        PlaceCar = p.PlaceCar,
                        PlaceSeatNo = p.PlaceSeatNo,
                        TicketNo = p.TicketNo,
                        ServiceFee = p.ServiceFee,
                        FacePrice = p.FacePrice,
                        PlaceGrade = p.PlaceGrade,
                        IsRefund = p.IsRefund,
                        IsMod = p.IsMod,
                        RefundFee=p.RefundFee
                    });
                }

                viewModel.TravelInfoList.Add(detailView);

               
            }

        

            ResponseBaseViewModel<TraRetModOrderViewModel> v = new ResponseBaseViewModel<TraRetModOrderViewModel>()
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };

            return v;
        }
        /// <summary>
        /// 创建火车票退票订单api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<List<string>> AddTraRetOrder([FromBody]TraAddRetModOrderModel request)
        {
            if (request == null)
                throw new Exception("请检查Post数据格式");

            if (request.Order == null)
                throw new Exception("传入订单参数异常");
            if (request.OrderDetailList == null)
                throw new Exception("传入订单参数异常");
            if (request.OrderDetailList.Count != 1)
                throw new Exception("只支持同行程退票");

            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain orderDomain = orderDomainFactory.CreateAddRetOrderDomainObj();

            IServerDomainFactory serverDomainFactory = new TicketRefundFactory();
            IServerDomain serverDomain = serverDomainFactory.CreateDomainObj();

            request.Cid = this.GetCid();
            request.IsFromOnline = this.CheckIsFromOnline();
            request.OrderSource = this.GetOrderSource();
            request.IsRequestInterface = true;
            List<string> orderidList = new List<string>();


            //判断退票对应的原订单是否是手工下单
            TraOrderModel traOrderModel = orderDomain.GetTraOrderModelByOrderId(request.OrderId);
            if (request.IsUserHandRefund || traOrderModel.OrderFrom == TraOrderFromEnum.Hand.ToString() ||
                traOrderModel.RefundType == 1) //手动下单
            {
                orderDomain.ServerRefundSubmit += serverDomain.DoRefundSubmitrEvent;
                int orderid = orderDomain.AddRetOrder(request);
                orderDomain.ServerRefundSubmit -= serverDomain.DoRefundSubmitrEvent;
                orderidList.Add(orderid.ToString());
            }
            else
            {
                foreach (var detail in request.OrderDetailList)
                {
                    foreach (var p in detail.PassengerList)
                    {
                        TraAddRetModOrderModel newOrder = new TraAddRetModOrderModel();
                        newOrder = request;
                        newOrder.OrderDetailList[0].PassengerList = new List<TraPassengerModel>();
                        newOrder.OrderDetailList[0].PassengerList.Add(p);
                        orderDomain.ServerRefundSubmit += serverDomain.DoRefundSubmitrEvent;
                        int orderid = orderDomain.AddRetOrder(request);
                        orderDomain.ServerRefundSubmit -= serverDomain.DoRefundSubmitrEvent;
                        orderidList.Add(orderid.ToString());
                    }
                }
            }




            ResponseBaseViewModel<List<string>> v = new ResponseBaseViewModel<List<string>>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = orderidList
            };
            return v;
        }
        /// <summary>
        /// 退票订单列表查询api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<ListBaseViewModel<List<TraRetOrderListDataViewModel>>> GetRetOrderList([FromBody] TraOrderListQueryModel request)
        {
            if (request == null)
                throw new Exception("请检查Post数据格式");
            if (request.OrderType != 2)
                throw new Exception("OrderType不正确");
            int totalCount = 0;
            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain domain = orderDomainFactory.CreateRetOrderListDomainObj();
            request.Cid = this.GetCid();

            ICustomerDomainFactory customerDomainFactory = new CustomerDomainFactory();
            var customerDomain = customerDomainFactory.CreateDomainObj();
            var customerInfo = customerDomain.GetCustomerInfo(request.Cid.Value);
            request.CorpId = customerInfo.CorpId;
            request.UserId = customerInfo.UserId;
            if (!string.IsNullOrEmpty(request.CorpId))
            {
                ICorporationDomainFactory corporationDomainFactory = new CorporationDomainFactory();
                var corporationDomain = corporationDomainFactory.CreateDomainObj();
                request.AllowShowDataBeginTime =
                    corporationDomain.GetCorporationByCorId(request.CorpId)?.AllowShowDataBeginTime;
            }
            List<TraOrderListDataModel> orderList = domain.GetTraRetOrderByPageList(request, ref totalCount);
            ResponseBaseViewModel<ListBaseViewModel<List<TraRetOrderListDataViewModel>>> v =
                new ResponseBaseViewModel<ListBaseViewModel<List<TraRetOrderListDataViewModel>>>
                {
                    Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                    Data = new ListBaseViewModel<List<TraRetOrderListDataViewModel>>()
                    {
                        ListData = (List<TraRetOrderListDataViewModel>)AutoMapperHelper.DoMapList<TraOrderListDataModel, TraRetOrderListDataViewModel>(orderList),
                        TotalCount = totalCount
                    }
                };
            return v;
        }

        /// <summary>
        /// 火车票 退票列表导出
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ExportRetOrderList([FromUri] TraOrderListQueryModel request)
        {
            if (request == null)
                throw new Exception("请检查Post数据格式");
            if (request.OrderType != 2)
                throw new Exception("OrderType不正确");
            request.IsExport = 1;
            int totalCount = 0;
            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain domain = orderDomainFactory.CreateRetOrderListDomainObj();
            request.Cid = this.GetCid();

            ICustomerDomainFactory customerDomainFactory = new CustomerDomainFactory();
            var customerDomain = customerDomainFactory.CreateDomainObj();
            var customerInfo = customerDomain.GetCustomerInfo(request.Cid.Value);
            request.CorpId = customerInfo.CorpId;
            request.UserId = customerInfo.UserId;
            if (!string.IsNullOrEmpty(request.CorpId))
            {
                ICorporationDomainFactory corporationDomainFactory = new CorporationDomainFactory();
                var corporationDomain = corporationDomainFactory.CreateDomainObj();
                request.AllowShowDataBeginTime =
                    corporationDomain.GetCorporationByCorId(request.CorpId)?.AllowShowDataBeginTime;
            }
            List<TraOrderListDataModel> orderList = domain.GetTraRetOrderByPageList(request, ref totalCount);
            ResponseBaseViewModel<ListBaseViewModel<List<TraRetOrderListDataViewModel>>> v =
                new ResponseBaseViewModel<ListBaseViewModel<List<TraRetOrderListDataViewModel>>>
                {
                    Flag = new ResponseCodeViewModel() { Code = 0 },
                    Data = new ListBaseViewModel<List<TraRetOrderListDataViewModel>>()
                    {
                        ListData = (List<TraRetOrderListDataViewModel>)AutoMapperHelper.DoMapList<TraOrderListDataModel, TraRetOrderListDataViewModel>(orderList),
                        TotalCount = totalCount
                    }
                };

            var file = ExcelStreamRet(v.Data.ListData);
            //string csv = _service.GetData(model);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(file);
            //a text file is actually an octet-stream (pdf, etc)
            //result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            //we used attachment to force download
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = "火车票退票订单列表.xls";
            return result;
        }
        private Stream ExcelStreamRet(List<TraRetOrderListDataViewModel> orderList)
        {
            //var list = dc.v_bs_dj_bbcdd1.Where(eps).ToList();
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("火车票退票订单");


            IRow rowHeader = sheet1.CreateRow(0);

            //生成excel标题
            rowHeader.CreateCell(0).SetCellValue("退票订单号");
            rowHeader.CreateCell(1).SetCellValue("出行人");
            rowHeader.CreateCell(2).SetCellValue("班次");
            rowHeader.CreateCell(3).SetCellValue("行程");
            rowHeader.CreateCell(4).SetCellValue("发车时间");
            rowHeader.CreateCell(5).SetCellValue("订单时间");
            rowHeader.CreateCell(6).SetCellValue("订单状态");
            int j = 0;
            //生成excel内容
            foreach (var item in orderList)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(1 + j);
                rowtemp.CreateCell(0).SetCellValue(item.OrderId);
                rowtemp.CreateCell(1).SetCellValue(item.PassengerNameListDesc);
                //string 
                rowtemp.CreateCell(2).SetCellValue(item.TrainNoListDesc);
                rowtemp.CreateCell(3).SetCellValue(item.TravelListDesc);
                rowtemp.CreateCell(4).SetCellValue(item.StartTimeListDesc);
                rowtemp.CreateCell(5).SetCellValue(item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                rowtemp.CreateCell(6).SetCellValue(item.OrderStatus);
                j++;
            }

            for (int i = 0; i < 10; i++)
                sheet1.AutoSizeColumn(i);

            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            file.Seek(0, SeekOrigin.Begin);
            return file;
        }


        /// <summary>
        /// 退票订单详情api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraOrderInfoViewModel> GetRetOrderInfo([FromBody]TraOrderRequestViewModel request)
        {
            if (request == null)
                throw new Exception("请检查Post数据格式");
            if (!request.OrderId.HasValue)
                throw new Exception("请传入订单号");

            int cid = this.GetCid();
            ICustomerDomainFactory customerDomainFactory = new CustomerDomainFactory();
            ICustomerDomain customerDomain = customerDomainFactory.CreateDomainObj();
            CustomerInfoModel customerInfo = customerDomain.GetCustomerInfo(cid);

            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain orderDomain = orderDomainFactory.CreateOrderInfoDomainObj();
            TraOrderInfoModel traOrderInfo = orderDomain.GetTraOrderByOrderId(request.OrderId.Value);
            //当前登录用户是administrator，如果订单所属的公司不等于当前公司，抛出异常
            if (customerInfo.UserId.ToLower() == "administrator" && traOrderInfo.CustomerInfo.CorpId != customerInfo.CorpId)
            {
                throw new Exception("该订单不属于当前用户");
            }
            if ((customerInfo.IsShowAllOrder ?? 0) == 0)
            {
                if (customerInfo.UserId.ToLower() != "administrator" && traOrderInfo.CustomerInfo.Cid != customerInfo.Cid)
                {
                    throw new Exception("该订单不属于当前用户");
                }
            }

            if (!string.IsNullOrEmpty(customerInfo.CorpId))
            {
                ICorporationDomainFactory corporationDomainFactory = new CorporationDomainFactory();
                var corporationDomain = corporationDomainFactory.CreateDomainObj();
                CorporationModel corporationModel = corporationDomain.GetCorporationByCorId(customerInfo.CorpId);
                if (corporationModel != null && corporationModel.AllowShowDataBeginTime.HasValue &&
                    traOrderInfo.Order != null)
                {
                    if (corporationModel.AllowShowDataBeginTime > traOrderInfo.Order.CreateTime)
                    {
                        throw new Exception("查无此退票单");
                    }
                }
            }

            TraOrderInfoViewModel viewModel = new TraOrderInfoViewModel();
            viewModel.Order = AutoMapperHelper.DoMap<TraOrderModel, TraOrderViewModel>(traOrderInfo.Order);
            viewModel.OrderDetailList = new List<TraOrderDetailViewModel>();
            foreach (var d in traOrderInfo.OrderDetailList)
            {
                TraOrderDetailViewModel dd = new TraOrderDetailViewModel()
                {
                    OdId = d.OdId,
                    OrderId = d.OrderId,
                    EndCity = d.EndCity,
                    EndCode = d.EndCode,
                    EndName = d.EndName,
                    EndNameCode = d.EndNameCode,
                    EndTime = d.EndTime,
                    FacePrice = d.FacePrice,
                    PlaceGrade = d.PlaceGrade,
                    PlaceGradeCode = d.PlaceGradeCode,
                    PlaceType = d.PlaceType,
                    RefundFee = d.RefundFee,
                    StartCity = d.StartCity,
                    StartCode = d.StartCode,
                    StartName = d.StartName,
                    StartNameCode = d.StartNameCode,
                    StartNameId = d.StartNameId,
                    StartTime = d.StartTime,
                    SupplierMoney = d.SupplierMoney,
                    TicketNum = d.TicketNum,
                    TotalPrice = d.TotalPrice,
                    TrainNo = d.TrainNo
                };
                dd.PassengerList = (List<TraPassengerViewModel>)AutoMapperHelper.DoMapList<TraPassengerModel, TraPassengerViewModel>(d.PassengerList);
                viewModel.OrderDetailList.Add(dd);
            }

            ResponseBaseViewModel<TraOrderInfoViewModel> v = new ResponseBaseViewModel<TraOrderInfoViewModel>()
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        /// <summary>
        /// 火车票退票列表视图api
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraOrderListQueryViewModel> RetOrderListView()
        {

            List<SortedListViewModel> orderStatuslist = new List<SortedListViewModel>();
            SortedList<int, string> orderSortedList = new SortedList<int, string>();
            orderSortedList.Add((int)OrderTypeEnum.ReturnTickets, OrderTypeEnum.ReturnTickets.ToDescription());
            orderSortedList.Add((int)OrderTypeEnum.ReturnTicketsSuccess, OrderTypeEnum.ReturnTicketsSuccess.ToDescription());
            orderSortedList.Add((int)OrderTypeEnum.ReturnTicketsFail, OrderTypeEnum.ReturnTicketsFail.ToDescription());
            foreach (var l in orderSortedList)
            {
                orderStatuslist.Add(new SortedListViewModel()
                {
                    Key = l.Key,
                    Value = l.Value
                });
            }
            orderStatuslist.Add(new SortedListViewModel() { Key = -1, Value = "处理中" });

            ResponseBaseViewModel<TraOrderListQueryViewModel> v = new ResponseBaseViewModel<TraOrderListQueryViewModel>()
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = new TraOrderListQueryViewModel
                {
                    TraOrderStatusList = orderStatuslist
                }
            };
            return v;
        }
        #endregion

        #region 改签单
        /// <summary>
        /// 火车票改签提交视图api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraRetModOrderViewModel> TraModOrderView([FromBody]TraOrderRequestViewModel request)
        {
            if(request==null)
                throw new Exception("请检查Post数据格式");
            if (!request.OrderId.HasValue)
                throw new Exception("请传入订单号");
            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain orderDomain = orderDomainFactory.CreateAddModOrderViewDomainObj();
            TraRetModOrderModel retOrderModel = orderDomain.GetAddTraModOrderView(request.OrderId.Value,
                this.CheckIsFromOnline());

            TraRetModOrderViewModel viewModel = new TraRetModOrderViewModel();
            viewModel.TravelInfoList = new List<TraOrderDetailViewModel>();
            viewModel.OrderFrom = retOrderModel.OrderFrom;
            viewModel.PlaceGradeList = new List<SortedListViewModel>();
            var placeList = EnumConvert.QueryEnum<TrainPlaceGradeEnum>();
            foreach (var place in placeList)
            {
                viewModel.PlaceGradeList.Add(new SortedListViewModel()
                {
                    Key = place.Key.ValueToDescription<TrainPlaceGradeEnum>(),
                    Value = place.Key.ValueToDescription<TrainPlaceGradeEnum>()
                });
            }

            foreach (var travel in retOrderModel.TravelInfoList)
            {
                TraOrderDetailViewModel detailView = new TraOrderDetailViewModel()
                {
                    OdId = travel.OdId,
                    OrderId = travel.OrderId,
                    StartNameId = travel.StartNameId,
                    StartName = travel.StartName,
                    StartNameCode = travel.StartNameCode,
                    StartCity = travel.StartCity,
                    EndName = travel.EndName,
                    EndNameCode = travel.EndNameCode,
                    EndCity = travel.EndCity,
                    StartTime = travel.StartTime,
                    EndTime = travel.EndTime,
                    TrainNo = travel.TrainNo,
                    PlaceType = travel.PlaceType,
                    PlaceGrade = travel.PlaceGrade,
                    TicketNum = travel.TicketNum,
                    FacePrice = travel.FacePrice,
                    TotalPrice = travel.TotalPrice,
                    SupplierMoney = travel.SupplierMoney,
                    RefundFee = travel.RefundFee,
                    PlaceGradeCode = travel.PlaceGradeCode,
                    StartCode = travel.StartCode,
                    EndCode = travel.EndCode,
                    RefundRate = travel.RefundRate,
                    PassengerList = new List<TraPassengerViewModel>()
                };

                foreach (var p in travel.PassengerList)
                {
                    detailView.PassengerList.Add(new TraPassengerViewModel()
                    {
                        Pid = p.Pid,
                        Name = p.Name,
                        CardNo = p.CardNo,
                        CardNoType = (int)p.CardNoType,
                        CardNoTypeDesc = p.CardNoTypeDesc,
                        Mobile = p.Mobile,
                        PlaceCar = p.PlaceCar,
                        PlaceSeatNo = p.PlaceSeatNo,
                        TicketNo = p.TicketNo,
                        ServiceFee = p.ServiceFee,
                        FacePrice = p.FacePrice,
                        PlaceGrade = p.PlaceGrade,
                        IsRefund = p.IsRefund,
                        IsMod = p.IsMod,
                        RefundFee = p.RefundFee
                    });
                }

                viewModel.TravelInfoList.Add(detailView);


            }

            ResponseBaseViewModel<TraRetModOrderViewModel> v = new ResponseBaseViewModel<TraRetModOrderViewModel>()
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };

            return v;
        }
        /// <summary>
        /// 创建火车票改签订单api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<string> AddTraModOrder([FromBody]TraAddRetModOrderModel request)
        {
            if (request == null)
                throw new Exception("请检查Post数据格式");
            if(request.OrderDetailList==null)
                throw new Exception("请检查Post数据格式");
            if (request.OrderDetailList.Count != 1)
                throw new Exception("只能同行程改签");
            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain orderDomain = orderDomainFactory.CreateAddModOrderDomainObj();

            IServerDomainFactory serverDomainFactory = new RequestChangeFactory();
            IServerDomain serverDomain = serverDomainFactory.CreateDomainObj();

            request.Cid = this.GetCid();
            request.OrderSource = this.GetOrderSource();
            if (request.Order==null)
                request.Order=new TraOrderModel();

            request.IsFromOnline = this.CheckIsFromOnline();
            if (!request.IsFromOnline)//如果不是线上提交
            {
                request.Order.CreateOid = this.GetOid();
            }
            int orderid = 0;
            orderDomain.ServerModSubmit += serverDomain.DoModSubmitrEvent;
            orderid = orderDomain.AddModOrder(request);
            orderDomain.ServerModSubmit -= serverDomain.DoModSubmitrEvent;



            ResponseBaseViewModel<string> v = new ResponseBaseViewModel<string>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = orderid.ToString()
            };
            return v;
        }
        /// <summary>
        /// 改签订单列表api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<ListBaseViewModel<List<TraModOrderListDataViewModel>>> GetModOrderList([FromBody] TraModOrderListQueryModel request)
        {
            if (request == null)
                throw new Exception("请检查Post数据格式");
            int totalCount = 0;
            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain domain = orderDomainFactory.CreateModOrderListDomainObj();
            request.Cid = this.GetCid();

            ICustomerDomainFactory customerDomainFactory = new CustomerDomainFactory();
            var customerDomain = customerDomainFactory.CreateDomainObj();
            var customerInfo = customerDomain.GetCustomerInfo(request.Cid.Value);
            request.CorpId = customerInfo.CorpId;
            request.UserId = customerInfo.UserId;
            if (!string.IsNullOrEmpty(request.CorpId))
            {
                ICorporationDomainFactory corporationDomainFactory = new CorporationDomainFactory();
                var corporationDomain = corporationDomainFactory.CreateDomainObj();
                request.AllowShowDataBeginTime =
                    corporationDomain.GetCorporationByCorId(request.CorpId)?.AllowShowDataBeginTime;
            }

            List<TraModOrderListDataModel> orderList = domain.GetTraModOrderByPageList(request, ref totalCount);
            ResponseBaseViewModel<ListBaseViewModel<List<TraModOrderListDataViewModel>>> v =
                new ResponseBaseViewModel<ListBaseViewModel<List<TraModOrderListDataViewModel>>>
                {
                    Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                    Data = new ListBaseViewModel<List<TraModOrderListDataViewModel>>()
                    {
                        ListData = (List<TraModOrderListDataViewModel>) AutoMapperHelper.DoMapList<TraModOrderListDataModel, TraModOrderListDataViewModel>(orderList) ,
                        TotalCount = totalCount
                    }
                };
            return v;
        }
        /// <summary>
        /// 改签订单导出
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ExportModOrderList([FromUri] TraModOrderListQueryModel request)
        {
            if (request == null)
                throw new Exception("请检查Post数据格式");
            request.IsExport = 1;
            int totalCount = 0;
            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain domain = orderDomainFactory.CreateModOrderListDomainObj();
            request.Cid = this.GetCid();

            ICustomerDomainFactory customerDomainFactory = new CustomerDomainFactory();
            var customerDomain = customerDomainFactory.CreateDomainObj();
            var customerInfo = customerDomain.GetCustomerInfo(request.Cid.Value);
            request.CorpId = customerInfo.CorpId;
            request.UserId = customerInfo.UserId;
            if (!string.IsNullOrEmpty(request.CorpId))
            {
                ICorporationDomainFactory corporationDomainFactory = new CorporationDomainFactory();
                var corporationDomain = corporationDomainFactory.CreateDomainObj();
                request.AllowShowDataBeginTime =
                    corporationDomain.GetCorporationByCorId(request.CorpId)?.AllowShowDataBeginTime;
            }

            List<TraModOrderListDataModel> orderList = domain.GetTraModOrderByPageList(request, ref totalCount);
            ResponseBaseViewModel<ListBaseViewModel<List<TraModOrderListDataViewModel>>> v =
                new ResponseBaseViewModel<ListBaseViewModel<List<TraModOrderListDataViewModel>>>
                {
                    Flag = new ResponseCodeViewModel() { Code = 0 },
                    Data = new ListBaseViewModel<List<TraModOrderListDataViewModel>>()
                    {
                        ListData = (List<TraModOrderListDataViewModel>)AutoMapperHelper.DoMapList<TraModOrderListDataModel, TraModOrderListDataViewModel>(orderList),
                        TotalCount = totalCount
                    }
                };
            var file = ExcelStreamMod(v.Data.ListData);
            //string csv = _service.GetData(model);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(file);
            //a text file is actually an octet-stream (pdf, etc)
            //result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            //we used attachment to force download
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = "火车改签订单列表.xls";
            return result;
        }

        private Stream ExcelStreamMod(List<TraModOrderListDataViewModel> orderList)
        {
            //var list = dc.v_bs_dj_bbcdd1.Where(eps).ToList();
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("火车改签订单");


            IRow rowHeader = sheet1.CreateRow(0);

            //生成excel标题
            rowHeader.CreateCell(0).SetCellValue("改签订单号");
            rowHeader.CreateCell(1).SetCellValue("出行人");
            rowHeader.CreateCell(2).SetCellValue("班次");
            rowHeader.CreateCell(3).SetCellValue("行程");
            rowHeader.CreateCell(4).SetCellValue("发车时间");
            rowHeader.CreateCell(5).SetCellValue("订票时间");
            rowHeader.CreateCell(6).SetCellValue("改签总费用");
            rowHeader.CreateCell(7).SetCellValue("改签状态");
            int j = 0;
            //生成excel内容
            foreach (var item in orderList)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(1 + j);
                rowtemp.CreateCell(0).SetCellValue(item.Coid);
                rowtemp.CreateCell(1).SetCellValue(item.PassengerNameListDesc);
                //string 
                rowtemp.CreateCell(2).SetCellValue(item.TrainNoListDesc);
                rowtemp.CreateCell(3).SetCellValue(item.TravelListDesc);
                rowtemp.CreateCell(4).SetCellValue(item.StartTimeListDesc);
                rowtemp.CreateCell(5).SetCellValue(item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                rowtemp.CreateCell(6).SetCellValue(item.ModFacePrice.ToString());
                rowtemp.CreateCell(7).SetCellValue(item.OrderStatus);
                j++;
            }

            for (int i = 0; i < 10; i++)
                sheet1.AutoSizeColumn(i);

            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            file.Seek(0, SeekOrigin.Begin);
            return file;
        }
        /// <summary>
        /// 改签订单详情api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraModOrderInfoViewModel> GetModOrderInfo([FromBody]TraOrderRequestViewModel request)
        {
            if (request.CorderId == null)
                throw new Exception("请传入CorderId");
            int cid = this.GetCid();
            ICustomerDomainFactory customerDomainFactory = new CustomerDomainFactory();
            ICustomerDomain customerDomain = customerDomainFactory.CreateDomainObj();
            CustomerInfoModel customerInfo = customerDomain.GetCustomerInfo(cid);

            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain orderDomain= orderDomainFactory.CreateAppOrderInfoDomainObj();
            TraModOrderInfoModel traModOrderInfoModel = orderDomain.GetTraModOrderByCorderId(request.CorderId.Value);

            TraModOrderInfoViewModel viewModel=new TraModOrderInfoViewModel();
            viewModel.Order = AutoMapperHelper.DoMap<TraModOrderModel, TraModOrderViewModel > (traModOrderInfoModel.Order);
            viewModel.OrderDetailList =new List<TraModOrderDetailViewModel>();

            List<TraOrderInfoModel> traRetModels = null;
            traRetModels = orderDomain.GetTraRetOrderByRootOrderId(traModOrderInfoModel.Order.OrderId.Value);

            if (!string.IsNullOrEmpty(customerInfo.CorpId))
            {
                ICorporationDomainFactory corporationDomainFactory = new CorporationDomainFactory();
                var corporationDomain = corporationDomainFactory.CreateDomainObj();
                CorporationModel corporationModel = corporationDomain.GetCorporationByCorId(customerInfo.CorpId);
                if (corporationModel != null && corporationModel.AllowShowDataBeginTime.HasValue)
                {
                    if (corporationModel.AllowShowDataBeginTime > traModOrderInfoModel.Order.CreateTime)
                    {
                        throw new Exception("查无此改签单");
                    }
                }
            }

            foreach (var dd in traModOrderInfoModel.OrderDetailList)
            {
                TraModOrderDetailViewModel ss = new TraModOrderDetailViewModel()
                {
                    TrainNo = dd.TrainNo,
                    AddrName = dd.AddrName,
                    EndName = dd.EndName,
                    SendTime = dd.SendTime,
                    EndTime = dd.EndTime,
                    PlaceType = dd.PlaceType,
                    PlaceGrade = dd.PlaceGrade,
                    TicketNum = dd.TicketNum,
                    TrainMoney = dd.TrainMoney
                };
                ss.PassengerList = (List<TraPassengerViewModel>) AutoMapperHelper.DoMapList<TraPassengerModel, TraPassengerViewModel>(dd.PassengerList);
                foreach (var pp in ss.PassengerList)
                {
                    #region 乘车人退票信息
                    if (traRetModels != null)
                    {
                        foreach (var ret in traRetModels)
                        {
                            foreach (var retDetail in ret.OrderDetailList)
                            {
                                foreach (var retPass in retDetail.PassengerList)
                                {
                                    if (retPass.Name == pp.Name)
                                    {
                                        pp.PassengerStatus = "已退票";
                                        pp.RefundTravelInfo = new TrainPassengerModRetTravelViewModel()
                                        {
                                            StartName = ret.OrderDetailList[0].StartName,
                                            EndName = ret.OrderDetailList[0].EndName,
                                            StartTime = ret.OrderDetailList[0].StartTime,
                                            EndTime = ret.OrderDetailList[0].EndTime,
                                            TrainNo = ret.OrderDetailList[0].TrainNo,
                                            PlaceType = ret.OrderDetailList[0].PlaceType,
                                            PlaceGrade = ret.OrderDetailList[0].PlaceGrade,
                                            PlaceCar = retPass.PlaceCar,
                                            PlaceSeatNo = retPass.PlaceSeatNo,
                                            RefundPrice = ret.OrderDetailList[0].FacePrice,
                                            RefundOrderTime = ret.Order.CreateTime,
                                            RefundOrderId = ret.OrderDetailList[0].OrderId
                                        };

                                        if (pp.RefundTravelInfo != null)
                                        {
                                            pp.IsRefund = true;
                                        }
                                    }
                                }
                            }
                        }



                    }
                    #endregion
                }
                viewModel.OrderDetailList.Add(ss);
            }

            ResponseBaseViewModel <TraModOrderInfoViewModel> v = new ResponseBaseViewModel<TraModOrderInfoViewModel>()
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }

        /// <summary>
        /// 火车票改签列表视图api
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraOrderListQueryViewModel> ModOrderListView()
        {

            List<SortedListViewModel> orderStatuslist = new List<SortedListViewModel>();
            SortedList<int, string> orderSortedList = new SortedList<int, string>();
            orderSortedList.Add((int)OrderTypeEnum.RequestChangeSuccess, OrderTypeEnum.RequestChangeSuccess.ToDescription());
            orderSortedList.Add((int)OrderTypeEnum.RequestChangeMakingTicket, OrderTypeEnum.RequestChangeMakingTicket.ToDescription());
            orderSortedList.Add((int)OrderTypeEnum.RequestChangeConfirm, OrderTypeEnum.RequestChangeConfirm.ToDescription());
            orderSortedList.Add((int)OrderTypeEnum.ApplyRequestChange, OrderTypeEnum.ApplyRequestChange.ToDescription());

            foreach (var l in orderSortedList)
            {
                orderStatuslist.Add(new SortedListViewModel()
                {
                    Key = l.Key,
                    Value = l.Value
                });
            }
            orderStatuslist.Add(new SortedListViewModel() { Key = -1, Value = "处理中" });

            ResponseBaseViewModel<TraOrderListQueryViewModel> v = new ResponseBaseViewModel<TraOrderListQueryViewModel>()
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = new TraOrderListQueryViewModel
                {
                    TraOrderStatusList = orderStatuslist
                }
            };
            return v;
        }
        /// <summary>
        /// 获取改签费率
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<string> GetModFeeRate([FromBody]TraOrderRequestViewModel request)
        {
            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain orderDomain = orderDomainFactory.CreateDomainObj();
            if (!request.ModFacePrice.HasValue || !request.ModStartTime.HasValue || !request.StartTime.HasValue)
            {
                throw new Exception("参数错误");
            }
            string str=orderDomain.GetModFeeRate(request.FacePriceList, request.ModFacePrice.Value,request.ModStartTime.Value, request.StartTime.Value);
            ResponseBaseViewModel<string> v = new ResponseBaseViewModel<string>()
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = str
            };
            return v;
        }

        #endregion

    }
}
