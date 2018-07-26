using System.Web.Http;
using Mzl.IApplication.Train;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Train.Order;

namespace Mzl.Mojory.WebApi.Controllers.Train.Order
{
    /// <summary>
    /// 展示火车下单页面信息
    /// </summary>
    public class ConfirmTraOrderViewController : ApiController
    {
        private readonly IConfirmTraOrderViewApplication _confirmTraOrderViewApplication;

        public ConfirmTraOrderViewController(IConfirmTraOrderViewApplication confirmTraOrderViewApplication)
        {
            _confirmTraOrderViewApplication = confirmTraOrderViewApplication;
        }
        /// <summary>
        /// 获取火车下单页面预设信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ResponseBaseViewModel<ConfirmTraOrderResponseViewModel> ConfirmOrderView([FromBody] ConfirmTraOrderRequestViewModel request)
        {
            if (request == null)
                request = new ConfirmTraOrderRequestViewModel();
            request.Cid = this.GetCid();
            request.Oid = this.GetOid();
            request.OrderSource = this.GetOrderSource();
            ConfirmTraOrderResponseViewModel responseViewModel =
                _confirmTraOrderViewApplication.GetTraComfireOrderView(request);

            ResponseBaseViewModel<ConfirmTraOrderResponseViewModel> v =
                new ResponseBaseViewModel<ConfirmTraOrderResponseViewModel>
                {
                    Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                    Data = responseViewModel
                };

            return v;
        }
    }
}
