using Mzl.Framework.Base;
using Mzl.UIModel.Customer.TravelReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.Customer
{
    public interface ITravelReportApplication : IBaseApplication
    {
        TravelReportAirlineCountResponseViewModel GetTravelReport_AirlineCount(TravelReportRequestUIModel request);
        TravelReportCostCenterResponseViewModel GetTravelReport_CostCenter(TravelReportRequestUIModel request);
        TravelReportReserveDayResponseViewModel GetTravelReport_ReserveDay(TravelReportRequestUIModel request);
        TravelReportSalePriceResponseViewModel GetTravelReport_SalePrice(TravelReportRequestUIModel request);
        TravelReportAllSalePriceResponseViewModel GetTravelReport_AllSalePrice(TravelReportRequestUIModel request);
        TravelReportDportCityResponseViewModel GetTravelReport_DportCity(TravelReportRequestUIModel request);
        TravelReportPassengerTopResponseViewModel GetTravelReport_PassengerTop(TravelReportRequestUIModel request);
        TravelReportConsumeCountResponseViewModel GetTravelReport_ConsumeCount(TravelReportRequestUIModel request);
        TravelReportAirConsumeCountTableResponseViewModel GetTravelReport_AirConsumeCountTable(TravelReportRequestUIModel request);
        TravelReportYearPriceCountResponseViewModel GetTravelReport_YearPriceCount(TravelReportRequestUIModel request);
        TravelReportCountDataResponseViewModel GetTravelReport_CountData(TravelReportCountDataRequestViewModel request);
        TravelReportFltRefundFltModResponseViewModel GetTravelReport_FltRefund(TravelReportRequestUIModel request);
        TravelReportFltRefundFltModResponseViewModel GetTravelReport_FltMod(TravelReportRequestUIModel request);

    }
}
