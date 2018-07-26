using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight;
using Mzl.IDAL.Flight;
using Mzl.EntityModel.Customer.BaseInfo;

namespace Mzl.BLL.Flight
{
    public class GetNotUseTicketNoListServiceBll : BaseServiceBll,IGetNotUseTicketNoListServiceBll
    {
        private readonly IFltFlightDal _fltFlightDal;
        private readonly IFltPassengerDal _fltPassengerDal;

        public GetNotUseTicketNoListServiceBll(IFltFlightDal fltFlightDal, IFltPassengerDal fltPassengerDal)
        {
            _fltFlightDal = fltFlightDal;
            _fltPassengerDal = fltPassengerDal;
        }

        public GetNotUseTicketNoModel GetNotUseNationTicketNoList(GetNotUseTicketNoQueryModel query)
        {
            GetNotUseTicketNoModel resultModel = new GetNotUseTicketNoModel();
            List<string> orderstatusList = new List<string>() { "N", "C","W" };
            List<int> orderIdList = new List<int>();
            DateTime beginTime = DateTime.Now.AddYears(-1);
            var select = from ticketNo in Context.Set<FltTicketNoEntity>().AsNoTracking()
                join order in Context.Set<FltOrderEntity>().AsNoTracking() on ticketNo.OrderId equals order.OrderId into
                    b
                from order in b.DefaultIfEmpty()
                join customer in Context.Set<CustomerInfoEntity>().AsNoTracking() on order.Cid equals customer.Cid into
                    c
                from customer in c.DefaultIfEmpty()
                where (order.ProcessStatus & 8) == 8 && !orderstatusList.Contains(order.Orderstatus) &&
                      !string.IsNullOrEmpty(order.IsInter) && order.IsInter.ToUpper() == "N"
                      && ticketNo.TicketNoStatus == "F" && ticketNo.AuditTime.HasValue && order.OrderDate >= beginTime
                select new GetNotUseTicketNoDataModel()
                {
                    Cid = order.Cid,
                    OrderId = order.OrderId,
                    TicketNo = ticketNo.AirlineNo + "-" + ticketNo.TicketNo,
                    OrderDate = order.OrderDate,
                    CorpId = customer.CorpID,
                    PassengerName = ticketNo.PassengerName,
                    Sequence = ticketNo.Sequence
                };



            #region 分页功能
            if (query.Cid.HasValue)
                select = select.Where(n => n.Cid == query.Cid.Value);
            if (query.OrderId.HasValue)
                select = select.Where(n => n.OrderId == query.OrderId.Value);
            if (!string.IsNullOrEmpty(query.CorpId))
            {
                select = select.Where(n => n.CorpId == query.CorpId);
            }

            if (query.AllowShowDataBeginTime.HasValue)
            {
                select = select.Where(n => n.OrderDate > query.AllowShowDataBeginTime);
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
                select = select.Where(m => m.PassengerName.Contains(query.PassengerName));
            }

            if (query.OrderBeginTime.HasValue)
                select = select.Where(n => n.OrderDate >= query.OrderBeginTime.Value);
            if (query.OrderEndTime.HasValue)
            {
                query.OrderEndTime = query.OrderEndTime.Value.AddDays(1);
                select = select.Where(n => n.OrderDate < query.OrderEndTime.Value);
            }
            resultModel.TotalCount = select.Count();//查询所有结果的数量

            select =
              select.OrderByDescending(n => n.OrderId).Skip(query.PageSize * (query.PageIndex - 1)).Take(query.PageSize);
            List<GetNotUseTicketNoDataModel> orderList = select.ToList();//分页结果  
           

            #endregion

            orderList.ForEach(n => orderIdList.Add(n.OrderId));
            //1.根据订单号 获取航段信息
            List<FltFlightEntity> flightEntities = _fltFlightDal.Query<FltFlightEntity>(n => orderIdList.Contains(n.OrderId),true).ToList();
            //2.根据订单号 获取乘机人信息
            List<FltPassengerEntity> passengerEntities = _fltPassengerDal.Query<FltPassengerEntity>(n => orderIdList.Contains(n.OrderId), true).ToList();

            List<SearchCityModel> cityModels = query.AportInfo.CountryList.SelectMany(n => n.CityList).ToList();
            List<SearchAirportModel> airportModels = cityModels.SelectMany(n => n.AirportList).ToList();
            List< FltPassengerModel> fltPassengerModels =
                   Mapper.Map<List<FltPassengerEntity>, List<FltPassengerModel>>(passengerEntities);
            List< FltFlightModel> flightModels =
                Mapper.Map<List<FltFlightEntity>, List<FltFlightModel>>(flightEntities);
            flightModels.ForEach(n =>
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

            orderList.ForEach(n =>
            {
                n.FlightList = flightModels.FindAll(x => x.OrderId == n.OrderId&x.Sequence==n.Sequence);
                n.PassengerList = fltPassengerModels.FindAll(x => x.OrderId == n.OrderId && x.Name == n.PassengerName);
            });

            resultModel.DataList = orderList;
            return resultModel;
        }
    }
}
