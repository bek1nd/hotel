using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.IDAL.Flight;
using Mzl.EntityModel.Flight;
using Mzl.IBLL.Flight;

namespace Mzl.BLL.Flight.DomesticRetMod
{
    /// <summary>
    /// 获取提交退票申请页面信息
    /// </summary>
    internal class GetFltDomesticRetApplyViewServiceBll : BaseServiceBll, IGetFltDomesticRetApplyViewServiceBll
    {
        private readonly IFltTicketNoDal _fltTicketNoDal;
        private readonly IFltOrderDal _fltOrderDal;
        private readonly IFltFlightDal _fltFlightDal;
        private readonly IFltPassengerDal _fltPassengerDal;
        private readonly IGetClassNameBll _getClassNameBll;

        public GetFltDomesticRetApplyViewServiceBll(IFltTicketNoDal fltTicketNoDal,
            IFltOrderDal fltOrderDal,
            IFltFlightDal fltFlightDal, IFltPassengerDal fltPassengerDal, IGetClassNameBll getClassNameBll) : base()
        {
            _fltTicketNoDal = fltTicketNoDal;
            _fltOrderDal = fltOrderDal;
            _fltFlightDal = fltFlightDal;
            _fltPassengerDal = fltPassengerDal;
            _getClassNameBll = getClassNameBll;
        }

        public GetRetApplyModel GetRetApply(GetRetApplyQueryModel query)
        {
            FltOrderEntity fltOrderEntity = _fltOrderDal.Find<FltOrderEntity>(query.OrderId);
            if (fltOrderEntity == null)
                throw new Exception("查无此订单");
            if ((fltOrderEntity.ProcessStatus & 8) != 8)
                throw new Exception("该订单未出票，不能提交改签申请");
            if (fltOrderEntity.Cid != query.Cid && query.Customer != null &&
                query.Customer.UserID.ToLower() != "administrator")
                throw new Exception("查无此订单");


            GetRetApplyModel result = new GetRetApplyModel();

            List<FltFlightEntity> flightEntities =
                _fltFlightDal.Query<FltFlightEntity>(n => n.OrderId == query.OrderId).ToList();
            List<FltPassengerEntity> passengerEntities =
                _fltPassengerDal.Query<FltPassengerEntity>(n => n.OrderId == query.OrderId).ToList();
            List<FltTicketNoEntity> fltTicketNoEntities =
                _fltTicketNoDal.Query<FltTicketNoEntity>(n => n.OrderId == query.OrderId).ToList();
            List<SearchCityModel> cityModels = query.AportInfo.CountryList.SelectMany(n => n.CityList).ToList();
            List<SearchAirportModel> airportModels = cityModels.SelectMany(n => n.AirportList).ToList();
            List<FltClassNameModel> classNameModels = _getClassNameBll.GetFlightClassName();
            /*
             * 判断是否来回程开在一个票号上
             * 如果乘机人的票数=行程数量，则代表分开开；不等于则开在同一票上
             * **/
            int nameTicketCount = fltTicketNoEntities.FindAll(n => n.PassengerName == passengerEntities[0].Name).Count;
            int flightCount = flightEntities.Count;
            bool isSame = (nameTicketCount != flightCount); //是否开在同一票号上
            result.FlightList = new List<FltFlightModel>();

            result.CName = fltOrderEntity.Cname;
            result.Mobile = fltOrderEntity.Mobile;
            result.Email = fltOrderEntity.Email;
            result.Cid = fltOrderEntity.Cid;
            result.CorpAduitId = fltOrderEntity.CorpAduitId;
            result.CorpPolicyId = fltOrderEntity.CorpPolicyId;

            result.FlightList = Mapper.Map<List<FltFlightEntity>, List<FltFlightModel>>(flightEntities);
            result.FlightList.ForEach(n =>
            {
                SearchAirportModel airportModel = airportModels.Find(x => x.AirportCode.ToLower() == n.Dport.ToLower());
                if (airportModel != null)
                {
                    n.DportName = airportModel.AirportLongName;
                    SearchCityModel cityModel = cityModels.Find(x => x.CityCode.ToLower() == airportModel.CityCode.ToLower());
                    n.DportCity = cityModel.CityName;
                }

                SearchAirportModel airportModel2 = airportModels.Find(x => x.AirportCode.ToLower() == n.Aport.ToLower());
                if (airportModel2 != null)
                {
                    n.AportName = airportModel2.AirportLongName;
                    SearchCityModel cityModel2 = cityModels.Find(x => x.CityCode.ToLower() == airportModel2.CityCode.ToLower());
                    n.AportCity = cityModel2.CityName;
                }

                FltClassNameModel classNameModel =
                    classNameModels.Find(
                        x =>
                            !string.IsNullOrEmpty(x.MClass) && !string.IsNullOrEmpty(n.Class) &&
                            x.MClass.ToLower() == n.Class.ToLower() &&
                            !string.IsNullOrEmpty(x.AirlineCode) && !string.IsNullOrEmpty(n.AirlineNo) &&
                            x.AirlineCode.ToLower() == n.AirlineNo.ToLower());

                if (classNameModel != null)
                {
                    n.ClassName = classNameModel.ClassName;
                    n.ClassEnName = classNameModel.ClassEnName;
                }
            });

            List<FltPassengerModel> fltPassengerModels =
                Mapper.Map<List<FltPassengerEntity>, List<FltPassengerModel>>(passengerEntities);
            result.PassengerList = new List<FltPassengerModel>();


            foreach (var ticketNo in fltTicketNoEntities)
            {
                FltPassengerModel fltPassengerModel2 = fltPassengerModels.Find(n => n.Name == ticketNo.PassengerName);

                FltPassengerModel fltPassengerModel = Mapper.Map<FltPassengerModel, FltPassengerModel>(fltPassengerModel2);
                fltPassengerModel.RetApplyTicketNo = ticketNo.AirlineNo+"-"+ticketNo.TicketNo;

                if (isSame)
                {
                    #region 开同一票号的行程

                    List<string> dportList = result.FlightList.Select(n => n.Dport).ToList();
                    List<string> aportList = result.FlightList.Select(n => n.Aport).ToList();
                    List<string> lineList = new List<string>();
                    List<string> lineList2 = new List<string>();

                    for (int i = 0; i < dportList.Count; i++)
                    {
                        string dport = dportList[i];
                        string aport = aportList[i];
                        SearchAirportModel airportModel = airportModels.Find(x => x.AirportCode.ToLower() == dport.ToLower());
                        SearchCityModel cityModel = cityModels.Find(n => n.CityCode.ToLower() == airportModel.CityCode.ToLower());
                        SearchAirportModel airportModel2 = airportModels.Find(x => x.AirportCode.ToLower() == aport.ToLower());
                        SearchCityModel cityModel2 = cityModels.Find(n => n.CityCode.ToLower() == airportModel2.CityCode.ToLower());
                        lineList.Add(cityModel.CityName + "-" + cityModel2.CityName);

                        lineList2.Add(dport + "-" + aport);
                    }

                    fltPassengerModel.RetApplyFlightLine = Convert(lineList);
                    fltPassengerModel.RetApplyDAportList = lineList2;
                    fltPassengerModel.RetApplySequence = 1;
                    fltPassengerModel.RetApplyFlightNo =
                        result.FlightList.Select(n => n.FlightNo).ToList().FirstOrDefault();

                    #endregion
                }
                else
                {
                    #region 没有开在同一票号

                    var flight = result.FlightList.Find(n => n.Sequence == ticketNo.Sequence);
                    SearchAirportModel airportModel = airportModels.Find(x => x.AirportCode.ToLower() == flight.Dport.ToLower());
                    SearchAirportModel airportModel2 = airportModels.Find(x => x.AirportCode.ToLower() == flight.Aport.ToLower());
                    if (airportModel != null && airportModel2 != null)
                    {
                        SearchCityModel cityModel = cityModels.Find(n => n.CityCode.ToLower() == airportModel.CityCode.ToLower());
                        SearchCityModel cityModel2 = cityModels.Find(n => n.CityCode.ToLower() == airportModel2.CityCode.ToLower());
                        fltPassengerModel.RetApplyFlightLine = cityModel.CityName + "-" + cityModel2.CityName;
                    }

                    fltPassengerModel.RetApplyDAportList = new List<string>() {flight.Dport + "-" + flight.Aport};
                    fltPassengerModel.RetApplySequence = flight.Sequence;
                    fltPassengerModel.RetApplyFlightNo = flight.FlightNo;

                    #endregion
                }
                
                result.PassengerList.Add(fltPassengerModel);
            }

            List<int> pidList = result.PassengerList.Select(n => n.PId).ToList();
            List<string> orderStatusList = new List<string>() {"C"};
            var select = from flight in Context.Set<FltRetModFlightApplyEntity>()
                join apply in Context.Set<FltRetModApplyEntity>() on flight.Rmid equals apply.Rmid into c
                from apply in c.DefaultIfEmpty()
                where
                    !orderStatusList.Contains(apply.OrderStatus) && pidList.Contains(flight.Pid) &&
                    apply.OrderType.ToUpper() == "R"
                select flight;
            List<FltRetModFlightApplyEntity> list = select.ToList();
            if (list != null && list.Count > 0)
            {
                result.PassengerList.ForEach(n =>
                {
                    FltRetModFlightApplyEntity l = list.Find(x => x.Pid == n.PId && x.Sequence == n.RetApplySequence);
                    if (l != null)
                    {
                        n.IsRet = true;
                    }
                });
            }
            else
            {
                result.PassengerList.ForEach(n =>
                {
                    FltTicketNoEntity fltTicketNoEntity =
                        fltTicketNoEntities.Find(x => x.PassengerName == n.Name && x.Sequence == n.RetApplySequence);
                    if (fltTicketNoEntity != null && fltTicketNoEntity.TicketNoStatus == "R")
                    {
                        n.IsRet = true;
                    }
                });
            }

            return result;
        }

        #region 私有方法

        private string Convert(List<string> lineList)
        {
            string resultLine = string.Empty;
            for (int i = 0; i < lineList.Count; i++)
            {
                List<string> line = lineList[i].Split('-').ToList();
                if (!string.IsNullOrEmpty(resultLine))
                    resultLine += "-";
                resultLine += line[0];

                if (i == (lineList.Count - 1))
                {
                    resultLine += "-" + line[1];
                }

            }
            return resultLine;
        }

        #endregion
    }
}
