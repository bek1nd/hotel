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

namespace Mzl.Mojory.WebApi.Controllers.Hotel
{
    /// <summary>
    /// 复制酒店订单
    /// </summary>
    public class CopyHotelOrderController : ApiController
    {
        private readonly ICopyHotelOrderApplication _copyHotelOrderApplication;

        public CopyHotelOrderController(ICopyHotelOrderApplication copyHotelOrderApplication)
        {
            _copyHotelOrderApplication = copyHotelOrderApplication;
        }

        /// <summary>
        /// 复制酒店订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<CopyHotelOrderResponseViewModel>> CopyHotelOrder(
            [FromBody] CopyHotelOrderRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.OrderSource = this.GetOrderSource();
            request.CreateOid = this.GetOid();
            CopyHotelOrderResponseViewModel viewModel = new CopyHotelOrderResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _copyHotelOrderApplication.CopHotelOrder(request);
            });

            ResponseBaseViewModel<CopyHotelOrderResponseViewModel> v = new ResponseBaseViewModel
                <CopyHotelOrderResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
