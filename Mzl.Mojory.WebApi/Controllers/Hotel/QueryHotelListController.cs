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
using Mzl.UIModel.Hotel.Elong.HotelInfo;

namespace Mzl.Mojory.WebApi.Controllers.Hotel
{
    /// <summary>
    /// 查询酒店信息列表
    /// </summary>
    public class QueryHotelListController : ApiController
    {
        private readonly IQueryHotelListApplication _queryHotelListApplication;

        public QueryHotelListController(IQueryHotelListApplication queryHotelListApplication)
        {
            _queryHotelListApplication = queryHotelListApplication;
        }
        /// <summary>
        /// 查询酒店信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<QueryHotelInfoResponseViewModel>> QueryHotelList(
          [FromBody] QueryHotelInfoRequestViewModel request)
        {
            request.Cid = this.GetCid();
            QueryHotelInfoResponseViewModel viewModel = new QueryHotelInfoResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _queryHotelListApplication.QueryHotelList(request);
            });

            ResponseBaseViewModel<QueryHotelInfoResponseViewModel> v = new ResponseBaseViewModel
                <QueryHotelInfoResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }

    }
}
