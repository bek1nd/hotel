using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Common.TravelManage;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.EntityModel.Train.Order;
using Mzl.Framework.Base;
using Mzl.IBLL.Common.TravelManage;

namespace Mzl.BLL.Common.TravelManage
{
    internal class GetTravelServiceBll : BaseServiceBll, IGetTravelServiceBll
    {
        public TravelModel GetTravelList(TravelQueryModel query)
        {
            TravelModel result = new TravelModel();
            result.DataList = new List<TravelDataModel>();

            TravelModel fltTravelModel = GetFlight(query);
            TravelModel traTravelModel = GetTrain(query);

            if (fltTravelModel != null && fltTravelModel.DataList != null && fltTravelModel.DataList.Count > 0)
                result.DataList.AddRange(fltTravelModel.DataList);

            if (traTravelModel != null && traTravelModel.DataList != null && traTravelModel.DataList.Count > 0)
                result.DataList.AddRange(traTravelModel.DataList);

            result.DataList = result.DataList.OrderBy(n => n.DTime).ToList();

            return result;
        }

        private TravelModel GetFlight(TravelQueryModel query)
        {
            if (!query.ContactId.HasValue)
                throw new Exception("请传入ContactId参数");

            TravelModel travel = new TravelModel();
            travel.DataList = new List<TravelDataModel>();

            List<string> orderstatusList = new List<string>() {"N", "C", "W"};

            List<SearchCityModel> cityModels = query.AportInfo.CountryList.SelectMany(n => n.CityList).ToList();
            List<SearchAirportModel> airportModels = cityModels.SelectMany(n => n.AirportList).ToList();

            int contactId = query.ContactId.Value;
            DateTime nowTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

            List<string> indexList = new List<string>();
            List<int> orderIdList = new List<int>();
            List<TravelDataModel> travelDataModels = new List<TravelDataModel>();

            #region 机票正单行程

            List<FltFlightEntity> flightList = (from flight in base.Context.Set<FltFlightEntity>().AsNoTracking()
                join passenger in Context.Set<FltPassengerEntity>().AsNoTracking() on flight.OrderId equals
                    passenger.OrderId
                join order in Context.Set<FltOrderEntity>().AsNoTracking() on flight.OrderId equals order.OrderId
                where
                    flight.TackoffTime >= nowTime && !orderstatusList.Contains(order.Orderstatus) &&
                    (order.ProcessStatus & 8) == 8
                    && passenger.Contactid == contactId
                select flight).Distinct().ToList();


            List<FltFlightModel> flightModels = Mapper.Map<List<FltFlightEntity>, List<FltFlightModel>>(flightList);
            flightModels.ForEach(n =>
            {
                SearchAirportModel airportModel = airportModels.Find(x => x.AirportCode == n.Dport);
                if (airportModel != null)
                {
                    n.DportName = airportModel.AirportName;
                    SearchCityModel cityModel = cityModels.Find(x => x.CityCode == airportModel.CityCode);
                    n.DportCity = cityModel.CityName;
                }

                SearchAirportModel airportModel2 = airportModels.Find(x => x.AirportCode == n.Aport);
                if (airportModel2 != null)
                {
                    n.AportName = airportModel2.AirportName;
                    SearchCityModel cityModel2 = cityModels.Find(x => x.CityCode == airportModel2.CityCode);
                    n.AportCity = cityModel2.CityName;
                }

                orderIdList.Add(n.OrderId);
            });

            List<TravelDataModel> flightTravelDataModels = (from n in flightModels
                select new TravelDataModel()
                {
                    Type = OrderSourceTypeEnum.Flt.ToString(),
                    AName = n.AportName,
                    DName = n.DportName,
                    ATime = n.ArrivalsTime,
                    DTime = n.TackoffTime,
                    Id = n.OrderId,
                    Sequence = n.Sequence,
                    TravelNo = n.FlightNo
                }).ToList();

            travelDataModels.AddRange(flightTravelDataModels);

            #endregion

            #region 机票改签行程

            List<FltModFlightEntity> modFlightList = (from modFlight in Context.Set<FltModFlightEntity>().AsNoTracking()
                join modOrder in Context.Set<FltModOrderEntity>().AsNoTracking() on modFlight.Rmid equals modOrder.Rmid
                join modPassenger in Context.Set<FltModPassengerEntity>().AsNoTracking() on modFlight.Rmid equals
                    modPassenger.Rmid
                join passenger in Context.Set<FltPassengerEntity>().AsNoTracking() on modPassenger.Pid equals
                    passenger.PId
                where
                    modFlight.TackoffTime.HasValue && modFlight.TackoffTime.Value > nowTime &&
                    (modOrder.ProcessStatus & 8) == 8
                    && passenger.Contactid == contactId
                select modFlight).Distinct().ToList();

            List<FltModFlightModel> modFlightModels =
                Mapper.Map<List<FltModFlightEntity>, List<FltModFlightModel>>(modFlightList);
            modFlightModels.ForEach(n =>
            {
                SearchAirportModel airportModel = airportModels.Find(x => x.AirportCode == n.Dport);
                if (airportModel != null)
                {
                    n.DportName = airportModel.AirportName;
                    SearchCityModel cityModel = cityModels.Find(x => x.CityCode == airportModel.CityCode);
                    n.DportCity = cityModel.CityName;
                }

                SearchAirportModel airportModel2 = airportModels.Find(x => x.AirportCode == n.Aport);
                if (airportModel2 != null)
                {
                    n.AportName = airportModel2.AirportName;
                    SearchCityModel cityModel2 = cityModels.Find(x => x.CityCode == airportModel2.CityCode);
                    n.AportCity = cityModel2.CityName;
                }
            });

            List<TravelDataModel> modFlightTravelDataModels = (from n in modFlightModels
                select new TravelDataModel()
                {
                    Type = OrderSourceTypeEnum.FltMod.ToString(),
                    AName = n.AportName,
                    DName = n.DportName,
                    ATime = n.ArrivalsTime.Value,
                    DTime = n.TackoffTime.Value,
                    Id = n.Orderid,
                    Sequence = n.Sequence.Value,
                    TravelNo = n.FlightNo
                }).ToList();

            travelDataModels.AddRange(modFlightTravelDataModels);

            #endregion

            #region 过滤正单和改签单


            //同一个订单，同一个行程Id,改签替换正单行程
            travelDataModels.ForEach(n =>
            {
                indexList.Add(n.Id + "|" + n.Sequence);

            });
            indexList = indexList.Distinct().ToList();


            foreach (string index in indexList)
            {
                int orderid = Convert.ToInt32(index.Split('|')[0]);
                int sequence = Convert.ToInt32(index.Split('|')[1]);

                List<TravelDataModel> fightTempList =
                    travelDataModels.FindAll(
                        n => n.Id == orderid && n.Sequence == sequence && n.Type == OrderSourceTypeEnum.Flt.ToString());

                List<TravelDataModel> modFightTempList =
                    travelDataModels.FindAll(
                        n =>
                            n.Id == orderid && n.Sequence == sequence && n.Type == OrderSourceTypeEnum.FltMod.ToString());

                if (fightTempList != null && fightTempList.Count > 0 &&
                    (modFightTempList == null || modFightTempList.Count == 0))
                    travel.DataList.AddRange(fightTempList);
                else if (modFightTempList != null && modFightTempList.Count > 0)
                    travel.DataList.AddRange(modFightTempList);
            }

            #endregion

            #region 过滤退票订单

            List<int> refundId = new List<int>();
            if (travel.DataList != null && travel.DataList.Count > 0)
            {
                List<FltRefundOrderDetailEntity> fltRefundOrderDetailEntities =
                    base.Context.Set<FltRefundOrderDetailEntity>().Where(n => orderIdList.Contains(n.OrderId)).ToList();
                if (fltRefundOrderDetailEntities.Count > 0)
                {

                    for (int i = 0; i < travel.DataList.Count; i++)
                    {
                        FltRefundOrderDetailEntity fltRefundOrderEntity =
                            fltRefundOrderDetailEntities.Find(
                                n => n.OrderId == travel.DataList[i].Id && n.Sequence == travel.DataList[i].Sequence);
                        if (fltRefundOrderEntity != null)
                        {
                            refundId.Add(fltRefundOrderEntity.OrderId);
                        }
                    }
                }

            }

            #endregion

            if (refundId.Count > 0)
            {
                travel.DataList.RemoveAll(n => refundId.Contains(n.Id));
            }

            return travel;
        }

        private TravelModel GetTrain(TravelQueryModel query)
        {
            if (!query.ContactId.HasValue)
                throw new Exception("请传入ContactId参数");

            TravelModel travel = new TravelModel();
            travel.DataList = new List<TravelDataModel>();

            int contactId = query.ContactId.Value;
            DateTime nowTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

            List<int> indexList = new List<int>();
            List<TravelDataModel> travelDataModels = new List<TravelDataModel>();

            #region 火车正单行程

            List<TravelDataModel> trainTravelDataModels = (from detail in Context.Set<TraOrderDetailEntity>()
                join order in Context.Set<TraOrderEntity>() on detail.OrderId equals order.OrderId
                join status in Context.Set<TraOrderStatusEntity>() on detail.OrderId equals status.OrderId
                join passenger in Context.Set<TraPassengerEntity>() on detail.OdId equals passenger.OdId
                where passenger.ContactId.HasValue && passenger.ContactId == contactId
                      && status.IsCancle == 0 && status.IsBuy == 1 && detail.StartTime > nowTime
                      && !string.IsNullOrEmpty(detail.StartName)
                      && !string.IsNullOrEmpty(detail.EndName)
                      && detail.EndTime.HasValue
                select new TravelDataModel()
                {
                    Type = OrderSourceTypeEnum.Tra.ToString(),
                    AName = detail.EndName,
                    DName = detail.StartName,
                    ATime = detail.EndTime.Value,
                    DTime = detail.StartTime,
                    Id = detail.OrderId,
                    Sequence = 1,
                    TravelNo = detail.TrainNo
                }).Distinct().ToList();
            travelDataModels.AddRange(trainTravelDataModels);

            #endregion

            #region 火车改签行程

            List<TravelDataModel> trainModTravelDataModels = (from modDetail in Context.Set<TraModOrderDetailEntity>()
                join modOrder in Context.Set<TraModOrderEntity>() on modDetail.CorderId equals modOrder.CorderId
                join passenger in Context.Set<TraPassengerEntity>() on modDetail.Pid equals passenger.Pid.ToString()
                where passenger.ContactId.HasValue && passenger.ContactId == contactId
                      && modDetail.SendTime.HasValue && modDetail.SendTime.Value > nowTime
                      && !string.IsNullOrEmpty(modOrder.ProcessStatus) && modOrder.ProcessStatus.Contains("H")
                      && !string.IsNullOrEmpty(modDetail.AddrName)
                      && !string.IsNullOrEmpty(modDetail.EndName)
                      && modDetail.EndTime.HasValue
                      && modDetail.SendTime.HasValue
                select new TravelDataModel()
                {
                    Type = OrderSourceTypeEnum.TraMod.ToString(),
                    AName = modDetail.EndName,
                    DName = modDetail.AddrName,
                    ATime = modDetail.EndTime.Value,
                    DTime = modDetail.SendTime.Value,
                    Id = modOrder.OrderId.Value,
                    Sequence = 1,
                    TravelNo = modDetail.TrainNo
                }).Distinct().ToList();

            travelDataModels.AddRange(trainModTravelDataModels);

            #endregion

            #region 过滤正单和改签单

            travelDataModels.ForEach(n =>
            {
                indexList.Add(n.Id);
            });

            foreach (int index in indexList)
            {
                List<TravelDataModel> traList =
                    travelDataModels.FindAll(
                        n => n.Id == index && n.Type == OrderSourceTypeEnum.Tra.ToString());

                List<TravelDataModel> modList =
                    travelDataModels.FindAll(
                        n =>
                            n.Id == index && n.Type == OrderSourceTypeEnum.TraMod.ToString());

                if (traList != null && traList.Count > 0 &&
                    (modList == null || modList.Count == 0))
                    travel.DataList.AddRange(traList);
                else if (modList != null && modList.Count > 0)
                    travel.DataList.AddRange(modList);
            }

            #endregion

            #region 过滤退票订单

            List<int> refundId = new List<int>();
            if (travel.DataList != null && travel.DataList.Count > 0)
            {
                List<TraOrderEntity> traOrderEntities =
                    base.Context.Set<TraOrderEntity>().Where(n => indexList.Contains(n.OrderRoot ?? 0)
                                                                  &&
                                                                  ((!n.IsModRefund.HasValue) || n.IsModRefund == false) &&
                                                                  n.OrderType == 2)
                        .ToList();
                if (traOrderEntities.Count > 0)
                {
                    for (int i = 0; i < travel.DataList.Count; i++)
                    {
                        TraOrderEntity traOrderEntity =
                            traOrderEntities.Find(n => n.OrderRoot == travel.DataList[i].Id);
                        if (traOrderEntity != null)
                        {
                            refundId.Add(traOrderEntity.OrderRoot ?? 0); //有退票的订单号
                        }
                    }
                }

            }

            #endregion

            if (refundId.Count > 0)
            {
                travel.DataList.RemoveAll(n => refundId.Contains(n.Id));
            }

            return travel;
        }
    }
}
