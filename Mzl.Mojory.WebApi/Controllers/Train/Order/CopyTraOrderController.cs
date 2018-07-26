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
using Mzl.UIModel.Train.Order.CopyOrder;

namespace Mzl.Mojory.WebApi.Controllers.Train.Order
{
    /// <summary>
    /// 复制火车订单
    /// </summary>
    public class CopyTraOrderController : ApiController
    {
        private readonly ICopyTraOrderApplication _copyTraOrderApplication;

        public CopyTraOrderController(ICopyTraOrderApplication copyTraOrderApplication)
        {
            _copyTraOrderApplication = copyTraOrderApplication;
        }

        /// <summary>
        /// 复制火车订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<CopyTraOrderResponseViewModel>> CopyTraOrder(
            [FromBody] CopyTraOrderRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.OrderSource = this.GetOrderSource();
            request.CreateOid = this.GetOid();
            CopyTraOrderResponseViewModel viewModel = new CopyTraOrderResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _copyTraOrderApplication.CopyTraOrder(request);
            });

            ResponseBaseViewModel<CopyTraOrderResponseViewModel> v = new ResponseBaseViewModel
                <CopyTraOrderResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
