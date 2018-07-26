using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Mzl.DomainModel.Train.Server;
using Mzl.IApplication.Customer;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Customer.CorpAduit;
using Mzl.UIModel.Customer.Customer;
using Newtonsoft.Json;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    /// <summary>
    /// 获取所有的待预定乘客信息
    /// </summary>
    public class SearchPassengersController : ApiController
    {
        private readonly ISearchPassengersApplication _searchPassengersApplication;

        public SearchPassengersController(ISearchPassengersApplication searchPassengersApplication)
        {
            _searchPassengersApplication = searchPassengersApplication;
        }

        /// <summary>
        /// 获取所有的待预定乘客信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<SearchPassengersResponseViewModel>> SearchPassengers(
         [FromBody] SearchPassengersRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.OrderSource = this.GetOrderSource();
            SearchPassengersResponseViewModel viewModel = new SearchPassengersResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _searchPassengersApplication.SearchPassengers(request);
            });

            ResponseBaseViewModel<SearchPassengersResponseViewModel> v = new ResponseBaseViewModel
                <SearchPassengersResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }

    }
}
