using System.Threading.Tasks;
using System.Web.Http;
using Mzl.IApplication.Flight;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Flight.CopyOrder;
using Mzl.UIModel.Flight.SplitOrder;

namespace Mzl.Mojory.WebApi.Controllers.Flight.OA
{
    /// <summary>
    /// 拆分机票订单
    /// </summary>
    public class SplitFltOrderController : ApiController
    {
        private readonly ISplitFltOrderApplication _splitFltOrderApplication;

        public SplitFltOrderController(ISplitFltOrderApplication splitFltOrderApplication)
        {
            _splitFltOrderApplication = splitFltOrderApplication;
        }

        /// <summary>
        /// 拆分机票订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<SplitFltOrderResponseViewModel>> SplitFltOrder(
            [FromBody] SplitFltOrderRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.OrderSource = this.GetOrderSource();
            request.Oid = this.GetOid();
            SplitFltOrderResponseViewModel viewModel = new SplitFltOrderResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _splitFltOrderApplication.SplitFltOrder(request);
            });

            ResponseBaseViewModel<SplitFltOrderResponseViewModel> v = new ResponseBaseViewModel
                <SplitFltOrderResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
