using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.Framework.Base;
using Mzl.IDAL.Flight;
using Mzl.DomainModel.Common.Insurance;
using AutoMapper;
using Mzl.IBLL.Flight;

namespace Mzl.BLL.Flight.DomesticRetMod
{
    /// <summary>
    /// 获取改签申请提交页面
    /// </summary>
    internal class GetFltDomesticModApplyViewServiceBll : BaseServiceBll, IGetFltDomesticModApplyViewServiceBll
    {
        private readonly IFltOrderDal _fltOrderDal;
        private readonly IFltFlightDal _fltFlightDal;
        private readonly IFltPassengerDal _fltPassengerDal;
        private readonly IGetClassNameBll _getClassNameBll;
        private readonly IFltTicketNoDal _fltTicketNoDal;

        public GetFltDomesticModApplyViewServiceBll(IFltOrderDal fltOrderDal,
            IFltFlightDal fltFlightDal, IFltPassengerDal fltPassengerDal, IGetClassNameBll getClassNameBll,
            IFltTicketNoDal fltTicketNoDal)
        {
            _fltOrderDal = fltOrderDal;
            _fltFlightDal = fltFlightDal;
            _fltPassengerDal = fltPassengerDal;
            _getClassNameBll = getClassNameBll;
            _fltTicketNoDal = fltTicketNoDal;
        }

        public GetModApplyModel GetModApplyView(GetModApplyQueryModel query)
        {
            //1.判断是否已经出票
            FltOrderEntity fltOrderEntity= _fltOrderDal.Find<FltOrderEntity>(query.OrderId);
            if(fltOrderEntity==null)
                throw new Exception("查无此订单");

            if ((fltOrderEntity.ProcessStatus&8)!=8)
                throw new Exception("该订单未出票，不能提交改签申请");

            if (fltOrderEntity.Cid != query.Cid && query.Customer != null &&
                query.Customer.UserID.ToLower() != "administrator")
                throw new Exception("查无此订单");


            List<FltFlightEntity> flightEntities =
                _fltFlightDal.Query<FltFlightEntity>(n => n.OrderId == query.OrderId).ToList();
            List<FltPassengerEntity> passengerEntities =
                _fltPassengerDal.Query<FltPassengerEntity>(n => n.OrderId == query.OrderId).ToList();
            List<FltTicketNoEntity> fltTicketNoEntities =
                _fltTicketNoDal.Query<FltTicketNoEntity>(n => n.OrderId == query.OrderId).ToList();

            //5.获取机场信息
            List<SearchCityModel> cityModels = query.AportInfo.CountryList.SelectMany(n => n.CityList).ToList();
            List<SearchAirportModel> airportModels = cityModels.SelectMany(n => n.AirportList).ToList();
            List<FltClassNameModel> classNameModels = _getClassNameBll.GetFlightClassName();

            GetModApplyModel result = new GetModApplyModel();
            result.CName = fltOrderEntity.Cname;
            result.Mobile = fltOrderEntity.Mobile;
            result.Email = fltOrderEntity.Email;
            result.Cid = fltOrderEntity.Cid;
            result.CorpAduitId = fltOrderEntity.CorpAduitId;
            result.CorpPolicyId = fltOrderEntity.CorpPolicyId;

            result.PassengerList = Mapper.Map<List<FltPassengerEntity>, List<FltPassengerModel>>(passengerEntities);

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

            List<int> pidList = result.PassengerList.Select(n => n.PId).ToList();
            #region 判断该乘机人是否有未处理的改签申请
            List<string> orderStatusList = new List<string>() { "C", "F" };
            var select = from flight in Context.Set<FltRetModFlightApplyEntity>()
                         join apply in Context.Set<FltRetModApplyEntity>() on flight.Rmid equals apply.Rmid into c
                         from apply in c.DefaultIfEmpty()
                         where !orderStatusList.Contains(apply.OrderStatus) && pidList.Contains(flight.Pid) && apply.OrderType.ToUpper() == "M"
                         select flight;

            List<FltRetModFlightApplyEntity> listMod = select.ToList();//已经改签人
            if (listMod != null && listMod.Count > 0)
            {
                result.PassengerList.ForEach(n =>
                {
                    FltRetModFlightApplyEntity l = listMod.Find(x => x.Pid == n.PId);
                    if (l != null)
                    {
                        n.IsMod = true;
                    }
                });
            }
            #endregion

            #region 判断该乘机人是否有存在退票申请
            List<string> refundStatusList = new List<string>() { "C" };
            var selectRefund = from flight in Context.Set<FltRetModFlightApplyEntity>()
                         join apply in Context.Set<FltRetModApplyEntity>() on flight.Rmid equals apply.Rmid into c
                         from apply in c.DefaultIfEmpty()
                         where !refundStatusList.Contains(apply.OrderStatus) && pidList.Contains(flight.Pid) && apply.OrderType.ToUpper() == "R"
                         select flight;

            List<FltRetModFlightApplyEntity> listRefund = selectRefund.ToList();//已经退票
            if (listRefund != null && listRefund.Count > 0)
            {
                result.PassengerList.ForEach(n =>
                {
                    FltRetModFlightApplyEntity l = listRefund.Find(x => x.Pid == n.PId);
                    if (l != null)
                    {
                        n.IsRet = true;
                    }
                });
            }
            #endregion

            //获取航程允许改签的乘机人Id
            foreach (var fltFlightModel in result.FlightList)
            {
                fltFlightModel.AllowModPidList = new List<int>();

                foreach (var fltPassengerModel in result.PassengerList)
                {
                    //判断当前是否已经退票
                    FltRetModFlightApplyEntity  isRefund = listRefund.Find(n => n.Sequence == fltFlightModel.Sequence&& fltPassengerModel.PId==n.Pid);

                    //判断票号使用情况
                    FltTicketNoEntity fltTicketNoEntity =
                        fltTicketNoEntities.Find(
                            x => x.PassengerName == fltPassengerModel.Name && x.Sequence == fltFlightModel.Sequence);
                    if (fltTicketNoEntity != null && fltTicketNoEntity.TicketNoStatus == "R")//如果当前乘机人对应航段票号已经退票了
                    {
                        isRefund = new FltRetModFlightApplyEntity();
                    }

                    if (isRefund == null)
                    {
                        //再判断是否已经改签
                        FltRetModFlightApplyEntity isMod =
                            listMod.Find(n => n.Sequence == fltFlightModel.Sequence && fltPassengerModel.PId == n.Pid);
                        if (isMod == null)
                        {
                            fltFlightModel.AllowModPidList.Add(fltPassengerModel.PId);
                        }
                    }
                }

                if (fltFlightModel.AllowModPidList.Count > 1)
                {
                    fltFlightModel.AllowModPidList = fltFlightModel.AllowModPidList.Distinct().ToList();
                }
            }

            return result;
        }
    }
}
