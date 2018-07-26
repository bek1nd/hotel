using System.Threading.Tasks;
using System.Web.Http;
using Mzl.IApplication.Train;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Train.Order;

namespace Mzl.Mojory.WebApi.Controllers.Train.Order
{
    /// <summary>
    /// 添加订单
    /// </summary>
    public class AddTraOrderController : ApiController
    {
        private readonly IAddTraOrderApplication _addTraOrderApplication;

        public AddTraOrderController(IAddTraOrderApplication addTraOrderApplication)
        {
            _addTraOrderApplication = addTraOrderApplication;
        }

        /// <summary>
        /// 添加火车订单
        /// 分为两个路线
        /// 1.走接口路线
        /// 2.不走接口路线（手动导单路线）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<AddTraOrderResponseViewModel>> AddTraOrder(
            [FromBody] AddTraOrderRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.OrderSource = this.GetOrderSource();
            request.Order.CreateOid = this.GetOid();
            AddTraOrderResponseViewModel viewModel = new AddTraOrderResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _addTraOrderApplication.AddTraOrder(request);
            });

            ResponseBaseViewModel<AddTraOrderResponseViewModel> v = new ResponseBaseViewModel
                <AddTraOrderResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
