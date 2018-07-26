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
using System.Threading.Tasks;
using System.Web.Http;

namespace Mzl.Mojory.WebApi.Controllers.Flight.Corp
{
    /// <summary>
    /// 查询航班
    /// </summary>
    public class SearchFlightController : ApiController
    {
        private readonly ISearchFlightApplication _searchFlightApplication;

        public SearchFlightController(ISearchFlightApplication searchFlightApplication)
        {
            _searchFlightApplication = searchFlightApplication;
        }

        /// <summary>
        /// 查询航班
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<SearchFlightResponseViewModel>> SearchFlight(
            [FromBody] SearchFlightRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.OrderSource = this.GetOrderSource();
            SearchFlightResponseViewModel viewModel = new SearchFlightResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _searchFlightApplication.Search(request);
            });

            ResponseBaseViewModel<SearchFlightResponseViewModel> v = new ResponseBaseViewModel
                <SearchFlightResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = viewModel
            };
            return v;
        }
    }
}
