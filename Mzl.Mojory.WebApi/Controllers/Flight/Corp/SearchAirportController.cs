using Microsoft.Practices.Unity;
using Mzl.Common.Ioc;
using Mzl.IApplication.Flight;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mzl.Mojory.WebApi.Controllers.Flight.Corp
{
    /// <summary>
    /// 查询机场信息
    /// </summary>
    public class SearchAirportController : ApiController
    {
        private readonly ISearchAirportApplication _searchAirportApplication;

        public SearchAirportController(ISearchAirportApplication searchAirportApplication)
        {
            _searchAirportApplication = searchAirportApplication;
        }

        /// <summary>
        /// 查询机场信息
        /// </summary>
        /// <returns></returns>
        public ResponseBaseViewModel<SearchCityAirportResponseViewModel> SearchAirport(SearchCityAirportRequestViewModel request)
        {
            request.Cid = this.GetCid();
            SearchCityAirportResponseViewModel responseViewModel = _searchAirportApplication.SearchAirport(request);
            ResponseBaseViewModel<SearchCityAirportResponseViewModel> v =
              new ResponseBaseViewModel<SearchCityAirportResponseViewModel>
              {
                  Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                  Data = responseViewModel
              };

            return v;
        }
    }
}
