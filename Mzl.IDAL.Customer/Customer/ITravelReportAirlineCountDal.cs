using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.TravelReport;
namespace Mzl.IDAL.Customer.Customer
{
    public interface ITravelReportAirlineCountDal : IBaseDal
    {
        List<T> GetTravelReportData<T>(string yearval,string corpId) where T : class;
        List<T> GetTravelReportFltRefund<T>(TravelReportRequestDoModel Remodel) where T : class;
        List<T> GetTravelReportFltMod<T>(TravelReportRequestDoModel Remodel) where T : class;
        List<T> GetTravelReport_ReserveDay<T>(TravelReportRequestDoModel Remodel) where T : class;
        List<T> GetTravelReport_YearPriceCount<T>(TravelReportRequestDoModel Remodel) where T : class;
        List<T> GetTravelReport_ConsumeCount<T>(TravelReportRequestDoModel Remodel) where T : class;
        List<T> GetTravelReport_PassengerTop<T>(TravelReportRequestDoModel Remodel) where T : class;
        List<T> GetTravelReport_DportCity<T>(TravelReportRequestDoModel Remodel) where T : class;
        List<T> GetTravelReport_AllSalePrice<T>(TravelReportRequestDoModel Remodel) where T : class;
        List<T> GetTravelReport_SalePrice<T>(TravelReportRequestDoModel Remodel) where T : class;
        List<T> GetTravelReport_CostCenter<T>(TravelReportRequestDoModel Remodel) where T : class;
        List<T> GetTravelReport_AirlineCount<T>(TravelReportRequestDoModel Remodel) where T : class;
        List<T> GetTravelReport_AirConsumeCount<T>(TravelReportRequestDoModel Remodel) where T : class;
        List<T> GetTravelReport_AirConsumeCountTable<T>(TravelReportRequestDoModel Remodel) where T : class;
        

    }
}
