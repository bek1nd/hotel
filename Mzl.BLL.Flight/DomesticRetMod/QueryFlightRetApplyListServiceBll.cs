﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight.DomesticRetMod
{
    internal class QueryFlightRetApplyListServiceBll: BaseServiceBll, IQueryFlightRetApplyListServiceBll
    {
        private readonly IFltRetModFlightApplyDal _fltRetModFlightApplyDal;
        private readonly IFltPassengerDal _fltPassengerDal;
        private readonly IFltFlightDal _fltFlightDal;

        public QueryFlightRetApplyListServiceBll(IFltRetModFlightApplyDal fltRetModFlightApplyDal,
            IFltPassengerDal fltPassengerDal, IFltFlightDal fltFlightDal)
        {
            _fltRetModFlightApplyDal = fltRetModFlightApplyDal;
            _fltPassengerDal = fltPassengerDal;
            _fltFlightDal = fltFlightDal;
        }

        public QueryFlightRetApplyListModel QueryFlightRetApplyList(QueryFlightRetApplyListDataQueryModel query)
        {
            QueryFlightRetApplyListModel resultModel = new QueryFlightRetApplyListModel();
            resultModel.ApplyDataList = new List<QueryFlightRetApplyListDataModel>();

            //List<string> orderstatusList = new List<string>() { "C" };
            var select = from modApply in Context.Set<FltRetModApplyEntity>().AsNoTracking()
                         join order in Context.Set<FltOrderEntity>().AsNoTracking() on modApply.OrderId equals order.OrderId
                             into o
                         from order in o.DefaultIfEmpty()
                         join customer in Context.Set<CustomerInfoEntity>().AsNoTracking() on modApply.Cid equals customer.Cid
                             into c
                         from customer in c.DefaultIfEmpty()
                         where modApply.OrderType.ToUpper() == "R" && modApply.RefundType == "实退"
                               && (order.IsInter == "N" || order.IsInter == "n") && (modApply.IsHidden ?? 0) == 0
                select new QueryFlightRetApplyListDataModel()
                {
                    Rmid = modApply.Rmid,
                    CreateTime = modApply.CreateTime,
                    OrderId = modApply.OrderId,
                    OrderStatus = modApply.OrderStatus,
                    Cid = modApply.Cid,
                    CorpId = customer.CorpID,
                    Cpid = modApply.Cpid,
                    CpidSecond = modApply.CpidSecond
                };

            #region 查询条件

            if (query.Cid.HasValue)
                select = select.Where(n => n.Cid == query.Cid.Value);

            if (!string.IsNullOrEmpty(query.CorpId))
                select = select.Where(n => n.CorpId == query.CorpId);

            if (query.OrderId.HasValue)
                select = select.Where(n => n.OrderId == query.OrderId.Value);

            if (!string.IsNullOrEmpty(query.OrderStatus))
                select = select.Where(n => n.OrderStatus.ToUpper() == query.OrderStatus.ToUpper());

            if (query.AllowShowDataBeginTime.HasValue)
            {
                select = select.Where(n => n.CreateTime > query.AllowShowDataBeginTime.Value);
            }

            if (query.TackOffBeginTime.HasValue)
            {
                select =
                    select.Where(
                        n =>
                            Context.Set<FltRetModFlightApplyEntity>()
                                .Where(m => m.TackoffTime >= query.TackOffBeginTime.Value)
                                .Select(m => m.Rmid).Contains(n.Rmid));
            }

            if (query.TackOffEndTime.HasValue)
            {
                query.TackOffEndTime = query.TackOffEndTime.Value.AddDays(1);
                select =
                    select.Where(
                        n =>
                            Context.Set<FltRetModFlightApplyEntity>()
                                .Where(m => m.TackoffTime < query.TackOffEndTime.Value)
                                .Select(m => m.Rmid).Contains(n.Rmid));
            }

            if (!string.IsNullOrEmpty(query.PassengerName))
            {
                select = select.Where(
                    n =>
                        Context.Set<FltRetModFlightApplyEntity>()
                            .Where(m => m.FltPassenger.Name.Contains(query.PassengerName))
                            .Select(m => m.Rmid).Contains(n.Rmid)
                    );
            }

            if (query.OrderBeginTime.HasValue)
                select = select.Where(n => n.CreateTime >= query.OrderBeginTime.Value);
            if (query.OrderEndTime.HasValue)
            {
                query.OrderEndTime = query.OrderEndTime.Value.AddDays(1);
                select = select.Where(n => n.CreateTime < query.OrderEndTime.Value);
            }

            #endregion

            resultModel.TotalCount = select.Count();//查询所有结果的数量
            //判断是否是导出操作 如果是导出操作就返回全部订单
            if ((query.IsExport ?? 0) == 0)
            {
                select =
                    select.OrderByDescending(n => n.Rmid).Skip(query.PageSize * (query.PageIndex - 1)).Take(query.PageSize);
            }
            else
            {
                select = select.OrderByDescending(n => n.Rmid);
            }

            resultModel.ApplyDataList = select.ToList();//分页结果 

            List<int> rmidList = new List<int>();
            resultModel.ApplyDataList.ForEach(n => rmidList.Add(n.Rmid));

            List<FltRetModFlightApplyEntity> flightApplyEntities =
                _fltRetModFlightApplyDal.Query<FltRetModFlightApplyEntity>(n => rmidList.Contains(n.Rmid),true).ToList();

            List<SearchCityModel> cityModels = query.AportInfo.CountryList.SelectMany(n => n.CityList).ToList();
            List<SearchAirportModel> airportModels = cityModels.SelectMany(n => n.AirportList).ToList();

            List<FltRetModFlightApplyModel> flightApplyModels =
                Mapper.Map<List<FltRetModFlightApplyEntity>, List<FltRetModFlightApplyModel>>(flightApplyEntities);


            #region 乘机人信息
            List<int> pidList = flightApplyModels.Select(n => n.Pid).ToList();
            List<FltPassengerEntity> passengerEntities = _fltPassengerDal.Query<FltPassengerEntity>(n => pidList.Contains(n.PId), true).ToList();
            List<FltPassengerModel> passengerModels =
                Mapper.Map<List<FltPassengerEntity>, List<FltPassengerModel>>(passengerEntities);
            #endregion

            //flightApplyModels.ForEach(n =>
            //{
            //    //string dport= _fltFlightDal.Query<FltFlightEntity>(x=>x.OrderId==n.Sequence)
               
            //});

            resultModel.ApplyDataList.ForEach(n =>
            {
                n.DetailList = flightApplyModels.FindAll(x => x.Rmid == n.Rmid);

                n.DetailList.ForEach(y =>
                {
                    FltFlightEntity orderFlightEntity =
                        _fltFlightDal.Query<FltFlightEntity>(x => x.OrderId == n.OrderId && x.Sequence == y.Sequence)
                            .FirstOrDefault();
                    if (orderFlightEntity != null)
                    {
                        if (!y.TackoffTime.HasValue)
                        {
                            y.TackoffTime = orderFlightEntity.TackoffTime;
                        }
                        if (string.IsNullOrEmpty(y.FlightNo))
                        {
                            y.FlightNo = orderFlightEntity.FlightNo;
                        }
                    }

                    SearchAirportModel airportModel = airportModels.Find(x => x.AirportCode.ToLower() == orderFlightEntity?.Dport.ToLower());
                    if (airportModel != null)
                    {
                        y.DportName = airportModel.AirportName;
                        SearchCityModel cityModel = cityModels.Find(x => x.CityCode.ToLower() == airportModel.CityCode.ToLower());
                        y.DportCity = cityModel.CityName;
                    }

                    SearchAirportModel airportModel2 = airportModels.Find(x => x.AirportCode.ToLower() == orderFlightEntity?.Aport.ToLower());
                    if (airportModel2 != null)
                    {
                        y.AportName = airportModel2.AirportName;
                        SearchCityModel cityModel2 = cityModels.Find(x => x.CityCode.ToLower() == airportModel2.CityCode.ToLower());
                        y.AportCity = cityModel2.CityName;
                    }
                    y.PassengerModel = passengerModels.Find(x => x.PId == y.Pid);
                });

                List<int> dPidList = new List<int>();
                List<int> sequenceList = new List<int>();

                n.DetailList.ForEach(x =>
                {
                    dPidList.Add(x.Pid);
                    sequenceList.Add(x.Sequence);
                });

                dPidList = dPidList.Distinct().ToList();
                sequenceList = sequenceList.Distinct().ToList();

                n.PassengerList = new List<FltPassengerModel>();
                foreach (var pid in dPidList)
                {
                    n.PassengerList.Add(passengerModels.Find(x => x.PId == pid));
                }

                n.FlightList = new List<FltFlightModel>();
                foreach (var sequence in sequenceList)
                {
                    var dd = n.DetailList.Find(x => x.Sequence == sequence);
                    n.FlightList.Add(new FltFlightModel()
                    {
                        FlightNo = dd.FlightNo,
                        Dport = dd.Dport,
                        Aport = dd.Aport,
                        DportName = dd.DportName,
                        AportName = dd.AportName,
                        AportCity = dd.AportCity,
                        DportCity = dd.DportCity,
                        TackoffTime = dd.TackoffTime ?? Convert.ToDateTime("2000-01-01")
                    });
                }

            });

            return resultModel;
        }
    }
}
