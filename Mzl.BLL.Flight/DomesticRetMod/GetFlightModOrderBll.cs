using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight.DomesticRetMod
{
    /// <summary>
    /// 获取改签订单所有信息（行程，乘机人，票号，日志）
    /// </summary>
    internal class GetFlightModOrderBll: BaseBll,IGetFlightModOrderBll
    {
        private readonly IFltModOrderDal _fltModOrderDal;
        private readonly IFltModFlightDal _fltModFlightDal;
        private readonly IFltModPassengerDal _fltModPassengerDal;
        private readonly IFltPassengerDal _fltPassengerDal;
        private readonly IFltModTicketNoDal _fltModTicketNoDal;
        private readonly IFltModOrderLogDal _fltModOrderLogDal;
        public SearchCityAportModel AportInfo { private get; set; }

        public GetFlightModOrderBll(IFltModOrderDal fltModOrderDal, IFltModFlightDal fltModFlightDal,
            IFltModPassengerDal fltModPassengerDal, IFltModTicketNoDal fltModTicketNoDal,
            IFltModOrderLogDal fltModOrderLogDal, IFltPassengerDal fltPassengerDal) : base()
        {
            _fltModOrderDal = fltModOrderDal;
            _fltModFlightDal = fltModFlightDal;
            _fltModPassengerDal = fltModPassengerDal;
            _fltModTicketNoDal = fltModTicketNoDal;
            _fltModOrderLogDal = fltModOrderLogDal;
            _fltPassengerDal = fltPassengerDal;
        }

       

        public FltModOrderModel GetModOrderByRmid(int rmid)
        {
            FltModOrderEntity fltModOrder =
                _fltModOrderDal.Query<FltModOrderEntity>(n => n.RootRmid == rmid).FirstOrDefault();
            if(fltModOrder==null)
                return null;
            return Convert(fltModOrder);
        }

        public FltModOrderModel GetModOrderByModOrderId(string modOrderId)
        {
            FltModOrderEntity fltModOrder =
               _fltModOrderDal.Query<FltModOrderEntity>(n => (n.OrderId + n.NumberIdentity) == modOrderId).FirstOrDefault();
            if (fltModOrder == null)
                return null;
            return Convert(fltModOrder);
        }

        public List<FltModOrderModel> GetModOrderByOrderId(int orderId)
        {
            List<FltModOrderEntity> fltModOrderEntities =
                _fltModOrderDal.Query<FltModOrderEntity>(n => n.OrderId == orderId).ToList();

            if(fltModOrderEntities==null|| fltModOrderEntities.Count==0)
                return null;

            List<FltModOrderModel> fltModOrderModels = new List<FltModOrderModel>();

            fltModOrderEntities.ForEach(n =>
            {
                fltModOrderModels.Add(Convert(n));
            });

            return fltModOrderModels;
        }


        #region 私有方法
        private FltModOrderModel Convert(FltModOrderEntity fltModOrder)
        {

            //改签行程
            List<FltModFlightEntity> fltModFlightEntities =
                _fltModFlightDal.Query<FltModFlightEntity>(n => n.Rmid == fltModOrder.Rmid).ToList();
            //改签乘机人
            List<FltModPassengerEntity> fltModPassengerEntities =
                _fltModPassengerDal.Query<FltModPassengerEntity>(n => n.Rmid == fltModOrder.Rmid).ToList();
            //原订单乘机人
            List<int> pidList = fltModPassengerEntities.Select(n => n.Pid).ToList();
            List<FltPassengerEntity> fltPassengerEntities =
                _fltPassengerDal.Query<FltPassengerEntity>(n => pidList.Any(x => x == n.PId)).ToList();
            //改签票号
            List<FltModTicketNoEntity> fltModTicketNoEntities =
                _fltModTicketNoDal.Query<FltModTicketNoEntity>(n => n.Rmid == fltModOrder.Rmid).ToList();
            //改签日志
            List<FltModOrderLogEntity> fltModOrderLogEntities =
                _fltModOrderLogDal.Query<FltModOrderLogEntity>(n => n.Rmid == fltModOrder.Rmid).ToList();

            List<SearchCityModel> cityModels = AportInfo.CountryList.SelectMany(n => n.CityList).ToList();
            List<SearchAirportModel> airportModels = cityModels.SelectMany(n => n.AirportList).ToList();


            List<FltPassengerModel> fltPassengerModels = Mapper.Map<List<FltPassengerEntity>, List<FltPassengerModel>>(fltPassengerEntities);

            FltModOrderModel fltModOrderModel = new FltModOrderModel();
            fltModOrderModel = Mapper.Map<FltModOrderEntity, FltModOrderModel>(fltModOrder);
            fltModOrderModel.FltModFlightList =
                Mapper.Map<List<FltModFlightEntity>, List<FltModFlightModel>>(fltModFlightEntities);

            fltModOrderModel.FltModFlightList.ForEach(n =>
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

            fltModOrderModel.FltModPassengerList =
                Mapper.Map<List<FltModPassengerEntity>, List<FltModPassengerModel>>(fltModPassengerEntities);
            fltModOrderModel.FltModPassengerList.ForEach(n =>
            {
                n.Passenger = fltPassengerModels.Find(x => x.PId == n.Pid);
            });

            fltModOrderModel.FltModTicketNoList =
                 Mapper.Map<List<FltModTicketNoEntity>, List<FltModTicketNoModel>>(fltModTicketNoEntities);
            fltModOrderModel.FltModOrderLogList =
                 Mapper.Map<List<FltModOrderLogEntity>, List<FltModOrderLogModel>>(fltModOrderLogEntities);


            return fltModOrderModel;
        } 
        #endregion
    }
}
