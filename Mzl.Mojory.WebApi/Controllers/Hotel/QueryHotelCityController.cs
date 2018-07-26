using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Mzl.IApplication.Hotel;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Customer.Customer;
using Mzl.UIModel.Hotel.Elong.City;

namespace Mzl.Mojory.WebApi.Controllers.Hotel
{
    /// <summary>
    /// 查询酒店城市信息
    /// </summary>
    public class QueryHotelCityController : ApiController
    {
        private readonly IQueryHotelCityApplication _queryHotelCityApplication;

        public QueryHotelCityController(IQueryHotelCityApplication queryHotelCityApplication)
        {
            _queryHotelCityApplication = queryHotelCityApplication;
        }

        /// <summary>
        /// 查询酒店城市信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<QueryHotelCityResponseViewModel>> QueryHotelCity(
            [FromBody] QueryHotelCityRequestViewModel request)
        {
            request.Cid = this.GetCid();
            QueryHotelCityResponseViewModel viewModel = new QueryHotelCityResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _queryHotelCityApplication.QueryHotelCity(request);
            });

            ResponseBaseViewModel<QueryHotelCityResponseViewModel> v = new ResponseBaseViewModel
                <QueryHotelCityResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = viewModel
            };
            return v;
        }
    }
}
