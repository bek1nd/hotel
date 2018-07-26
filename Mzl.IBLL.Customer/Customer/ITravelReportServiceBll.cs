using Mzl.DomainModel.Customer.TravelReport;
using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.Customer
{
    public interface ITravelReportServiceBll : IBaseServiceBll
    {
        List<TravelReportAirlineCountModel> GetTravelReportAirlineCount(TravelReportRequestDoModel Remodel);
        List<TravelReportConsumeCountModel> GetTravelReportAirConsumeCount(TravelReportRequestDoModel Remodel);
        List<TravelReportPassengerTopModel> GetTravelReportPassengerTop(TravelReportRequestDoModel Remodel);
        List<TravelReportDportCityModel> GetTravelReportDportCity(TravelReportRequestDoModel Remodel);
        List<TravelReportSalePriceModel> GetTravelReportSalePrice(TravelReportRequestDoModel Remodel);
        List<TravelReportAllSalePriceModel> GetTravelReportAllSalePrice(TravelReportRequestDoModel Remodel);
        List<TravelReportReserveDayModel> GetTravelReportReserveDay(TravelReportRequestDoModel Remodel);
        List<TravelReportCostCenterModel> GetTravelReportCostCenter(TravelReportRequestDoModel Remodel);
        List<TravelReportConsumeCountModel> GetTravelReportConsumeCount(TravelReportRequestDoModel Remodel);
        List<TravelReportYearPriceCountModel> GetTravelReportYearPriceCount(TravelReportRequestDoModel Remodelr);
        List<TravelReportCountDataModel> GetTravelReportCountData(string corpId, string TheYear);
        List<TravelReportFltRefundFltModModel> GetTravelReportFltRefund(TravelReportRequestDoModel Remodelr);
        List<TravelReportFltRefundFltModModel> GetTravelReportFltMod(TravelReportRequestDoModel Remodelr);
        List<TravelReportAirConsumeCountTableModel> GetTravelReportAirConsumeCountTable(TravelReportRequestDoModel Remodelr);
    }
}
