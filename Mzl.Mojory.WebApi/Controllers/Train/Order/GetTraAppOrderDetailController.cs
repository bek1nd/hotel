using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Mzl.IApplication.Train;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Train.Order.OrderDetail;

namespace Mzl.Mojory.WebApi.Controllers.Train.Order
{
    /// <summary>
    /// 获取订单详情页面
    /// </summary>
    public class GetTraAppOrderDetailController : ApiController
    {
        private readonly IGetTraOrderDetailApplication _getTraOrderDetailApplication;

        public GetTraAppOrderDetailController(IGetTraOrderDetailApplication getTraOrderDetailApplication)
        {
            _getTraOrderDetailApplication = getTraOrderDetailApplication;
        }

        /// <summary>
        /// 获取订单详情页面
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<GetTraOrderDetailResponseViewModel>> GetTraOrderDetailInfo(
          [FromBody] GetTraOrderDetailRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.OrderSource = this.GetOrderSource();
            GetTraOrderDetailResponseViewModel viewModel = new GetTraOrderDetailResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _getTraOrderDetailApplication.GetTraOrderDetailFromAppByOrderId(request);
            });

            ResponseBaseViewModel<GetTraOrderDetailResponseViewModel> v = new ResponseBaseViewModel
                <GetTraOrderDetailResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
