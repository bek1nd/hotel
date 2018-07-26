using Mzl.Framework.Base;
using Mzl.IApplication.Flight;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Flight;
using Mzl.IBLL.Common.BaseInfo;
using Mzl.DomainModel.Flight;
using AutoMapper;

namespace Mzl.Application.Flight
{
    /// <summary>
    /// 查询机场应用层
    /// </summary>
    internal class SearchAirportApplication : BaseApplicationService, ISearchAirportApplication
    {
        private readonly IGetCityForFlightServiceBll _getCityForFlightServiceBll;

        public SearchAirportApplication(IGetCityForFlightServiceBll getCityForFlightServiceBll)
            : base()
        {
            this._getCityForFlightServiceBll = getCityForFlightServiceBll;
        }

        public SearchCityAirportResponseViewModel SearchAirport(SearchCityAirportRequestViewModel request)
        {
            List<string> requestList = new List<string>();
            requestList.Add("N");
            if (request.IsInter == "I")
                requestList.Add("I");
            SearchCityAportModel cityAportModel = _getCityForFlightServiceBll.SearchAirport(requestList);
         
            SearchCityAirportResponseViewModel v =
                Mapper.Map<SearchCityAportModel, SearchCityAirportResponseViewModel>(cityAportModel);

            return v;
        }
    }
}
