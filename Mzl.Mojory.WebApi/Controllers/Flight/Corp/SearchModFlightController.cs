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
    /// 查询改签航班
    /// </summary>
    public class SearchModFlightController : ApiController
    {
        private readonly ISearchModFlightApplication _searchFlightApplication;

        public SearchModFlightController(ISearchModFlightApplication searchFlightApplication)
        {
            _searchFlightApplication = searchFlightApplication;
        }

        /// <summary>
        /// 查询改签航班
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<SearchModFlightResponseViewModel> SearchFlight([FromBody] SearchModFlightRequestViewModel request)
        {
            request.Cid = this.GetCid();
            SearchModFlightResponseViewModel responseViewModel = _searchFlightApplication.Search(request);

            ResponseBaseViewModel<SearchModFlightResponseViewModel> v =
                new ResponseBaseViewModel<SearchModFlightResponseViewModel>
                {
                    Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                    Data = responseViewModel
                };

            return v;
        }
    }
}
