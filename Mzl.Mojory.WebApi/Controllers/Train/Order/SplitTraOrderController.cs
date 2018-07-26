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
using Mzl.UIModel.Flight.SplitOrder;

namespace Mzl.Mojory.WebApi.Controllers.Train.Order
{
    public class SplitTraOrderController : ApiController
    {
        private readonly ISplitTraOrderApplication _SplitTraOrderApplication;
        public SplitTraOrderController(ISplitTraOrderApplication SplitTraOrderApplication)
        {
            _SplitTraOrderApplication = SplitTraOrderApplication;
        }
        /// <summary>
        /// 火车订单拆分
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<SplitTraOrderResponseViewModel>> SplitTraOrder(
            [FromBody] SplitTraOrderRequestViewModel request)
        {
            request.Oid = this.GetOid();
            string message = "";
            SplitTraOrderResponseViewModel viewModel = new SplitTraOrderResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _SplitTraOrderApplication.SplitTraOrder(request,out message);
            });

            ResponseBaseViewModel<SplitTraOrderResponseViewModel> returnval = new ResponseBaseViewModel
                <SplitTraOrderResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken(), Message = message },
                Data = viewModel
            };
            return returnval;
        }
    }
}