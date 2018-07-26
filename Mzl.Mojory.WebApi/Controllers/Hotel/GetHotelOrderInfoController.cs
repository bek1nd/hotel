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
using Mzl.UIModel.Hotel.CopyOrder;
using Mzl.UIModel.Hotel.GetOrderInfo;

namespace Mzl.Mojory.WebApi.Controllers.Hotel
{
    /// <summary>
    /// 获取酒店订单信息
    /// </summary>
    public class GetHotelOrderInfoController : ApiController
    {
        private readonly IGetHotelOrderInfoApplication _getHotelOrderInfoApplication;

        public GetHotelOrderInfoController(IGetHotelOrderInfoApplication getHotelOrderInfoApplication)
        {
            _getHotelOrderInfoApplication = getHotelOrderInfoApplication;
        }

        /// <summary>
        /// 获取酒店订单信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<GetHotelOrderInfoResponseViewModel>> GetHotelOrderInfo(
            [FromBody] GetHotelOrderInfoRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.OrderSource = this.GetOrderSource();
            GetHotelOrderInfoResponseViewModel viewModel = new GetHotelOrderInfoResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _getHotelOrderInfoApplication.GetHotelOrderInfoByOrderId(request);
            });

            ResponseBaseViewModel<GetHotelOrderInfoResponseViewModel> v = new ResponseBaseViewModel
                <GetHotelOrderInfoResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
