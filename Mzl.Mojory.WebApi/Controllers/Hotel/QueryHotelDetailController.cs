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
    /// 查询酒店详情信息
    /// </summary>
    public class QueryHotelDetailController : ApiController
    {
        private readonly IQueryHotelDetailApplication _queryHotelDetailApplication;

        public QueryHotelDetailController(IQueryHotelDetailApplication queryHotelDetailApplication)
        {
            _queryHotelDetailApplication = queryHotelDetailApplication;
        }

        /// <summary>
        /// 查询酒店详情信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<QueryHotelDetailResponseViewModel>> QueryHotelDetail(
          [FromBody] QueryHotelDetailRequestViewModel request)
        {
            request.Cid = this.GetCid();
            QueryHotelDetailResponseViewModel viewModel = new QueryHotelDetailResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _queryHotelDetailApplication.QueryHotelDetail(request);
            });

            ResponseBaseViewModel<QueryHotelDetailResponseViewModel> v = new ResponseBaseViewModel
                <QueryHotelDetailResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
