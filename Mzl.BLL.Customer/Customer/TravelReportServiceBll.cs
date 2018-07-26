using Mzl.Common;
using Mzl.Common.CacheHelper;
using Mzl.Common.EnumHelper;
using Mzl.Common.Exceptions;
using Mzl.Common.RegexHelper;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using Mzl.EntityModel.Customer.TravelReport;
using Mzl.DomainModel.Customer.TravelReport;
using Mzl.IDAL.Customer.Corporation;
using AutoMapper;
using Mzl.EntityModel.Customer.Corporation.Corp;
namespace Mzl.BLL.Customer.Customer
{

    public class TravelReportServiceBll: BaseServiceBll,ITravelReportServiceBll
    {
        private readonly ITravelReportAirlineCountDal _travelReportAirlineCountDal;
        private readonly ICorporationDal _corporationDal;

        public TravelReportServiceBll(ITravelReportAirlineCountDal travelReportAirlineCountDal, ICorporationDal corporationDal)
        {
            _travelReportAirlineCountDal = travelReportAirlineCountDal;
            _corporationDal = corporationDal;
        }
        //退票数量
        public List<TravelReportFltRefundFltModModel> GetTravelReportFltRefund(TravelReportRequestDoModel Remodel)
        {
            List<TravelReportFltRefundFltModModel> list = _travelReportAirlineCountDal.GetTravelReportFltRefund<TravelReportFltRefundFltModModel>(Remodel);
            return list;
        }
        //改签数量
        public List<TravelReportFltRefundFltModModel> GetTravelReportFltMod(TravelReportRequestDoModel Remodel)
        {
            List<TravelReportFltRefundFltModModel> list = _travelReportAirlineCountDal.GetTravelReportFltMod<TravelReportFltRefundFltModModel>(Remodel);
            return list;
        }
        //汇总页面返回机票条数
        public List<TravelReportCountDataModel> GetTravelReportCountData(string corpId, string TheYear)
        {
            List<TravelReportCountDataModel> list = _travelReportAirlineCountDal.GetTravelReportData<TravelReportCountDataModel>(TheYear,corpId);
            return list;
        }
        //预定提前天数占比 
        public List<TravelReportReserveDayModel> GetTravelReportReserveDay(TravelReportRequestDoModel Remodel)
        {
            List<TravelReportReserveDayModel> list = _travelReportAirlineCountDal.GetTravelReport_ReserveDay<TravelReportReserveDayModel>(Remodel);
            return list;
        }
        //月度消费额
        public List<TravelReportYearPriceCountModel> GetTravelReportYearPriceCount(TravelReportRequestDoModel Remodel)
        {

            List<TravelReportYearPriceCountModel> list = _travelReportAirlineCountDal.GetTravelReport_YearPriceCount<TravelReportYearPriceCountModel>(Remodel);
            return list;
        }
        //汇总页面
        public List<TravelReportConsumeCountModel> GetTravelReportConsumeCount(TravelReportRequestDoModel Remodel)
        {
            List<TravelReportConsumeCountModel> list = _travelReportAirlineCountDal.GetTravelReport_ConsumeCount<TravelReportConsumeCountModel>(Remodel);
            return list;
        }
        //前10位人员出差人次汇总表
        public List<TravelReportPassengerTopModel> GetTravelReportPassengerTop(TravelReportRequestDoModel Remodel)
        {
            List<TravelReportPassengerTopModel> list = _travelReportAirlineCountDal.GetTravelReport_PassengerTop<TravelReportPassengerTopModel>(Remodel);
            return list;
        }
        //前10条出差航段汇总表
        public List<TravelReportDportCityModel> GetTravelReportDportCity(TravelReportRequestDoModel Remodel)
        {
            List<TravelReportDportCityModel> list = _travelReportAirlineCountDal.GetTravelReport_DportCity<TravelReportDportCityModel>(Remodel);
            return list;
        }
        //全航司折扣舱位
        public List<TravelReportAllSalePriceModel> GetTravelReportAllSalePrice(TravelReportRequestDoModel Remodel)
        {
            List<TravelReportAllSalePriceModel> list = _travelReportAirlineCountDal.GetTravelReport_AllSalePrice<TravelReportAllSalePriceModel>(Remodel);
            return list;
        }
        //东上航折扣舱位占比分析
        public List<TravelReportSalePriceModel> GetTravelReportSalePrice(TravelReportRequestDoModel Remodel)
        {
            List<TravelReportSalePriceModel> list = _travelReportAirlineCountDal.GetTravelReport_SalePrice<TravelReportSalePriceModel>(Remodel);
            return list;
        }
        //成本中心汇总表 
        public List<TravelReportCostCenterModel> GetTravelReportCostCenter(TravelReportRequestDoModel Remodel)
        {
            List<TravelReportCostCenterModel> list = _travelReportAirlineCountDal.GetTravelReport_CostCenter<TravelReportCostCenterModel>(Remodel);
            return list;
        }
        //航空公司占比分析
        public List<TravelReportAirlineCountModel> GetTravelReportAirlineCount(TravelReportRequestDoModel Remodel)
        {
            List<TravelReportAirlineCountModel> list = _travelReportAirlineCountDal.GetTravelReport_AirlineCount<TravelReportAirlineCountModel>(Remodel);
            return list;
        }
        //年享受航司协议节省金额
        public List<TravelReportConsumeCountModel> GetTravelReportAirConsumeCount(TravelReportRequestDoModel Remodel)
        {
            List<TravelReportConsumeCountModel> list = _travelReportAirlineCountDal.GetTravelReport_AirConsumeCount<TravelReportConsumeCountModel>(Remodel);
            return list;
        }

        //年享受航司协议节省金额table
        public List<TravelReportAirConsumeCountTableModel> GetTravelReportAirConsumeCountTable(TravelReportRequestDoModel Remodel)
        {
            List<TravelReportAirConsumeCountTableModel> list = _travelReportAirlineCountDal.GetTravelReport_AirConsumeCountTable<TravelReportAirConsumeCountTableModel>(Remodel);
            return list;
        }
        class ComparerItem : IComparable
        {
            public int manNum { get; set; }
            public decimal SalePriceSum { get; set; }
            public string DiffDay { get; set; }

            public int CompareTo(object obj)
            {
                var tem = (ComparerItem)obj;

                if (this.DiffDay == tem.DiffDay)
                {
                    return 0;
                }
                else if (this.DiffDay != tem.DiffDay)
                {
                    return 1;
                }
                return -1;
            }
        }
    }
}
