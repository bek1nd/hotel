using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight.DomesticRetMod
{
    /// <summary>
    /// 获取改签申请所有信息
    /// </summary>
    internal class GetFlightRetModApplyBll: BaseBll, IGetFlightRetModApplyBll
    {
        private readonly IFltRetModApplyDal _fltRetModApplyDal;
        private readonly IFltRetModFlightApplyDal _fltRetModFlightApplyDal;
        private readonly IFltRetModApplyLogDal _fltRetModApplyLogDal;
        private readonly IFltPassengerDal _fltPassengerDal;
        private readonly IGetClassNameBll _getClassNameBll;
        private readonly IFltFlightDal _fltFlightDal;
        public SearchCityAportModel AportInfo { private get; set; }
        public List<ChoiceReasonModel> PolicyReasonList { private get; set; }

        public GetFlightRetModApplyBll(IFltRetModFlightApplyDal fltRetModFlightApplyDal,
            IFltRetModApplyDal fltRetModApplyDal, IFltRetModApplyLogDal fltRetModApplyLogDal,
            IFltPassengerDal fltPassengerDal, IGetClassNameBll getClassNameBll, IFltFlightDal fltFlightDal)
        {
            _fltRetModApplyDal = fltRetModApplyDal;
            _fltRetModFlightApplyDal = fltRetModFlightApplyDal;
            _fltRetModApplyLogDal = fltRetModApplyLogDal;
            _fltPassengerDal = fltPassengerDal;
            _getClassNameBll = getClassNameBll;
            _fltFlightDal = fltFlightDal;
        }


        public FltRetModApplyModel GetRetModApply(int rmid)
        {
            FltRetModApplyEntity fltRetModApply = _fltRetModApplyDal.Find<FltRetModApplyEntity>(rmid);
            List<FltRetModFlightApplyEntity> fltRetModFlightApplyEntities =
                _fltRetModFlightApplyDal.Query<FltRetModFlightApplyEntity>(n => n.Rmid == rmid).ToList();
            List<FltRetModApplyLogEntity> fltRetModApplyLogEntities =
                _fltRetModApplyLogDal.Query<FltRetModApplyLogEntity>(n => n.Rmid == rmid).ToList();

         

            FltRetModApplyModel fltRetModApplyModel =
                Mapper.Map<FltRetModApplyEntity, FltRetModApplyModel>(fltRetModApply);
            fltRetModApplyModel.DetailList =
                Mapper.Map<List<FltRetModFlightApplyEntity>, List<FltRetModFlightApplyModel>>(
                    fltRetModFlightApplyEntities);
            fltRetModApplyModel.LogList = Mapper.Map<List<FltRetModApplyLogEntity>, List<FltRetModApplyLogModel>>(
                fltRetModApplyLogEntities);
            List<SearchCityModel> cityModels = AportInfo?.CountryList.SelectMany(n => n.CityList).ToList();
            List<SearchAirportModel> airportModels = cityModels?.SelectMany(n => n.AirportList).ToList();

            #region 乘机人信息
            List<int> pidList = fltRetModApplyModel.DetailList.Select(n => n.Pid).ToList();
            List<FltPassengerEntity> passengerEntities =
                _fltPassengerDal.Query<FltPassengerEntity>(n => pidList.Any(x => x == n.PId)).ToList();
         
            #endregion

            //4.获取仓等信息
            List<FltClassNameModel> classNameModels = _getClassNameBll.GetFlightClassName();

            fltRetModApplyModel.DetailList.ForEach(n =>
            {
                FltFlightEntity orderFlightEntity =
                     _fltFlightDal.Query<FltFlightEntity>(x => x.OrderId == fltRetModApplyModel.OrderId && x.Sequence == n.Sequence)
                         .FirstOrDefault();
                if (orderFlightEntity != null)
                {
                    if (!n.TackoffTime.HasValue)
                    {
                        n.TackoffTime = orderFlightEntity.TackoffTime;
                    }
                    if (string.IsNullOrEmpty(n.FlightNo))
                    {
                        n.FlightNo = orderFlightEntity.FlightNo;
                    }
                }

                string dport = n.Dport.ToLower();
                if (fltRetModApplyModel.OrderType == "R"&& orderFlightEntity!=null)
                {
                    dport = orderFlightEntity.Dport.ToLower();
                }

                SearchAirportModel airportModel = airportModels.Find(x => x.AirportCode.ToLower() == dport);
                if (airportModel != null)
                {
                    n.DportName = airportModel.AirportName;
                    SearchCityModel cityModel = cityModels.Find(x => x.CityCode.ToLower() == airportModel.CityCode.ToLower());
                    n.DportCity = cityModel.CityName;
                }

                string aport = n.Aport.ToLower();
                if (fltRetModApplyModel.OrderType == "R" && orderFlightEntity != null)
                {
                    aport = orderFlightEntity.Aport.ToLower();
                }

                SearchAirportModel airportModel2 = airportModels.Find(x => x.AirportCode.ToLower() == aport);
                if (airportModel2 != null)
                {
                    n.AportName = airportModel2.AirportName;
                    SearchCityModel cityModel2 = cityModels.Find(x => x.CityCode.ToLower() == airportModel2.CityCode.ToLower());
                    n.AportCity = cityModel2.CityName;
                }
                FltPassengerModel passengerModel =
                    Mapper.Map<FltPassengerEntity, FltPassengerModel>(passengerEntities.Find(x => x.PId == n.Pid));

                n.PassengerModel = passengerModel;

                if (fltRetModApplyModel.OrderType == "R")
                    n.PassengerModel.RefundTicketNo = n.TicketNo;

                if (n.ChoiceReasonId.HasValue)
                    n.ChoiceReason = PolicyReasonList?.Find(x => x.Id == n.ChoiceReasonId.Value)?.Reason;

                FltClassNameModel classNameModel =
                   classNameModels.Find(
                       x =>
                           !string.IsNullOrEmpty(x.MClass) && !string.IsNullOrEmpty(n.Class) &&
                           x.MClass.ToLower() == n.Class.ToLower() &&
                           !string.IsNullOrEmpty(x.AirlineCode) && !string.IsNullOrEmpty(n.FlightNo) &&
                           x.AirlineCode.ToLower() == n.FlightNo.Substring(0,2).ToLower());

                if (classNameModel != null)
                {
                    n.ClassName = classNameModel.ClassName;
                }
            });


            return fltRetModApplyModel;
        }

        public List<FltRetModApplyModel> GetRetModApply(List<int> rmid)
        {
            List<FltRetModApplyModel> resultList = new List<FltRetModApplyModel>();
            rmid.ForEach(n =>
            {
                FltRetModApplyModel model= GetRetModApply(n);
                if (model != null)
                    resultList.Add(model);
            });
            return resultList;
        }
    }
}
