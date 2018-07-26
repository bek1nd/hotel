using Mzl.Framework.Base;
using Mzl.IBLL.Flight;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.IDAL.Flight;
using AutoMapper;
using Mzl.Common.EnumHelper;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;

namespace Mzl.BLL.Flight
{
    internal class QueryFlightOrderListServiceBll: BaseServiceBll, IQueryFlightOrderListServiceBll
    {
        private readonly IFltOrderDal _fltOrderDal;
        private readonly IFltFlightDal _fltFlightDal;
        private readonly IFltPassengerDal _fltPassengerDal;

        public QueryFlightOrderListServiceBll(IFltOrderDal fltOrderDal, IFltFlightDal fltFlightDal,
            IFltPassengerDal fltPassengerDal) : base()
        {
            _fltOrderDal = fltOrderDal;
            _fltFlightDal = fltFlightDal;
            _fltPassengerDal = fltPassengerDal;
        }

        public QueryFlightOrderListModel QueryFlightOrderList(QueryFlightOrderListDataQueryModel query)
        {
            QueryFlightOrderListModel resultModel = new QueryFlightOrderListModel();
            resultModel.OrderDataList = new List<QueryFlightOrderListDataModel>();

            #region 订单分页
            List<string> orderstatusList = new List<string>() { "N" };
            List<int> orderIdList = new List<int>();

            var select = from order in Context.Set<FltOrderEntity>().AsNoTracking()
                join customer in Context.Set<CustomerInfoEntity>().AsNoTracking() on order.Cid equals customer.Cid into
                    c
                from customer in c.DefaultIfEmpty()

                join aduitOrderDetail in Context.Set<CorpAduitOrderDetailEntity>().AsNoTracking() on order.OrderId
                    equals aduitOrderDetail.OrderId into aod
                from aduitOrderDetail in aod.DefaultIfEmpty()

                join aduitOrder in Context.Set<CorpAduitOrderEntity>().AsNoTracking() on aduitOrderDetail.AduitOrderId
                    equals aduitOrder.AduitOrderId into ao
                from aduitOrder in ao.DefaultIfEmpty()

                where !orderstatusList.Contains(order.Orderstatus) && (order.IsInter == "N" || order.IsInter == "n")
                      && order.IsOnlineShow != 1
                select new QueryFlightOrderListDataModel()
                {
                    OrderId = order.OrderId,
                    Cid = order.Cid,
                    OrderDate = order.OrderDate,
                    OrderStatus = order.Orderstatus,
                    PayAmount = order.Payamount,
                    ProcessStatus = order.ProcessStatus,
                    CorpId = customer.CorpID,
                    AduitOrderId = aduitOrderDetail.AduitOrderId,
                    AduitOrderStatus = aduitOrder.Status,
                    CopyFromOrderId = order.CopyFromOrderId,
                    CopyType = order.CopyType,
                    ShowOnlineOrderId2 =
                        (order.CopyType == "X" && order.CopyFromOrderId.HasValue && (order.ProcessStatus & 8) == 8 &&
                         order.Orderstatus.ToUpper() != "C")
                            ? order.CopyFromOrderId.Value
                            : order.OrderId
                };

            #region 查询条件


            if (query.Cid.HasValue)
                select = select.Where(n => n.Cid == query.Cid.Value);
            if (query.OrderId.HasValue)
                select = select.Where(n => n.ShowOnlineOrderId2 == query.OrderId.Value);

            if (!string.IsNullOrEmpty(query.CorpId))
            {
                select = select.Where(n => n.CorpId == query.CorpId);
            }

            if (query.AllowShowDataBeginTime.HasValue)
            {
                select = select.Where(n => n.OrderDate > query.AllowShowDataBeginTime);
            }

            if (query.OrderStatus.HasValue)
            {
               
                if (query.OrderStatus.Value == (int)FltOrderListOrderStatusEnum.WaitTicket)
                {
                    select = select.Where(n => (n.ProcessStatus & 8) != 8 && n.OrderStatus.ToUpper() == "W");
                }
                if (query.OrderStatus.Value == (int)FltOrderListOrderStatusEnum.Ticketing)
                {
                    select =
                        select.Where(
                            n =>
                                (n.ProcessStatus & 8) != 8 && n.OrderStatus.ToUpper() == "P" &&
                                ((n.AduitOrderStatus.HasValue && n.AduitOrderStatus == 7) ||
                                 !n.AduitOrderStatus.HasValue));
                }
                if (query.OrderStatus.Value == (int)FltOrderListOrderStatusEnum.Ticketed)
                {
                    select = select.Where(n => (n.ProcessStatus & 8) == 8);
                }
                if (query.OrderStatus.Value == (int)FltOrderListOrderStatusEnum.PartRefunded)
                {
                    select = select.Where(n => (n.ProcessStatus & 8) != 8 && n.OrderStatus.ToUpper() == "S");
                }
                if (query.OrderStatus.Value == (int)FltOrderListOrderStatusEnum.AllRefunded)
                {
                    select = select.Where(n => (n.ProcessStatus & 8) != 8 && n.OrderStatus.ToUpper() == "T");
                }
                if (query.OrderStatus.Value == (int)FltOrderListOrderStatusEnum.Cancel)
                {
                    select = select.Where(n => n.OrderStatus.ToUpper() == "C");
                }
                if (query.OrderStatus.Value == (int)FltOrderListOrderStatusEnum.Aduiting)
                {
                    List<string> statusList = new List<string>()
                    {
                        "W",
                        "P"
                    };
                    select =
                        select.Where(
                            n =>
                                statusList.Contains(n.OrderStatus.ToUpper()) && n.AduitOrderStatus.HasValue &&
                                n.AduitOrderStatus != 6 && n.AduitOrderStatus != 7);
                }
            }

            if (query.TackOffBeginTime.HasValue)
            {
                select = select.Where(n => Context.Set<FltFlightEntity>().Where(m => m.TackoffTime >= query.TackOffBeginTime.Value)
                      .Select(m => m.OrderId).Contains(n.OrderId));
            }

            if (query.TackOffEndTime.HasValue)
            {
                query.TackOffEndTime = query.TackOffEndTime.Value.AddDays(1);
                select = select.Where(n => Context.Set<FltFlightEntity>().Where(m => m.TackoffTime < query.TackOffEndTime.Value)
                      .Select(m => m.OrderId).Contains(n.OrderId));
            }

            if (!string.IsNullOrEmpty(query.PassengerName))
            {
                select = select.Where(
                    n => Context.Set<FltPassengerEntity>().Where(m => m.Name.Contains(query.PassengerName))
                        .Select(m => m.OrderId).Contains(n.OrderId)
                    );
            }

            if (query.OrderBeginTime.HasValue)
                select = select.Where(n => n.OrderDate >= query.OrderBeginTime.Value);
            if (query.OrderEndTime.HasValue)
            {
                query.OrderEndTime = query.OrderEndTime.Value.AddDays(1);
                select = select.Where(n => n.OrderDate < query.OrderEndTime.Value);
            }

            #endregion

            resultModel.TotalCount = select.Count();//查询所有结果的数量
            //判断是否是导出excel 如果是导出操作 返回全部订单
            if ((query.IsExport ?? 0) == 0)
            {
                select =
                    select.OrderByDescending(n => n.OrderId).Skip(query.PageSize * (query.PageIndex - 1)).Take(query.PageSize);
            }
            else
            {
                select = select.OrderByDescending(n => n.OrderId);
            }
            List<QueryFlightOrderListDataModel> orderList = select.ToList();//分页结果 
            if (orderList == null || orderList.Count == 0)
                return resultModel;
            #endregion

            orderList.ForEach(n=>orderIdList.Add(n.OrderId));

            //1.根据订单号 获取航段信息
            List< FltFlightEntity > flightEntities= _fltFlightDal.Query<FltFlightEntity>(n => orderIdList.Contains(n.OrderId),true).ToList();
            //2.根据订单号 获取乘机人信息
            List<FltPassengerEntity> passengerEntities = _fltPassengerDal.Query<FltPassengerEntity>(n => orderIdList.Contains(n.OrderId), true).ToList();


            #region 拼凑实体
            List<SearchCityModel> cityModels = query.AportInfo.CountryList.SelectMany(n => n.CityList).ToList();
            List<SearchAirportModel> airportModels = cityModels.SelectMany(n => n.AirportList).ToList();

            for (int i = 0; i < orderList.Count; i ++)
            {
                QueryFlightOrderListDataModel result = orderList[i];
                if(result==null)
                    continue;
                result.PassengerList =
                    Mapper.Map<List<FltPassengerEntity>, List<FltPassengerModel>>(
                        passengerEntities.FindAll(n => n.OrderId == orderList[i].OrderId));
                result.FlightList =
                    Mapper.Map<List<FltFlightEntity>, List<FltFlightModel>>(
                        flightEntities.FindAll(n => n.OrderId == orderList[i].OrderId));
                result.FlightList.ForEach(n =>
                {
                    SearchAirportModel airportModel = airportModels.Find(x => x.AirportCode.ToLower() == n.Dport.ToLower());
                    if (airportModel != null)
                    {
                        n.DportName = airportModel.AirportName;
                        SearchCityModel cityModel = cityModels.Find(x => x.CityCode.ToLower() == airportModel.CityCode.ToLower());
                        n.DportCity = cityModel.CityName;
                    }

                    SearchAirportModel airportModel2 = airportModels.Find(x => x.AirportCode.ToLower() == n.Aport.ToLower());
                    if (airportModel2 != null)
                    {
                        n.AportName = airportModel2.AirportName;
                        SearchCityModel cityModel2 = cityModels.Find(x => x.CityCode.ToLower() == airportModel2.CityCode.ToLower());
                        n.AportCity = cityModel2.CityName;
                    }
                });

                resultModel.OrderDataList.Add(result);
            }

            #endregion

         

            return resultModel;
        }


        
    }
}
