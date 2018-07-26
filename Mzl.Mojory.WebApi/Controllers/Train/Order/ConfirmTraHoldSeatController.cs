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
using Mzl.UIModel.Train.Order;

namespace Mzl.Mojory.WebApi.Controllers.Train.Order
{
    /// <summary>
    /// 确认火车占位结果
    /// 同意占位：进行送审；有审批：成功后进行出票申请；没审批直接出票申请
    /// 不同意占位：取消第三方接口
    /// </summary>
    public class ConfirmTraHoldSeatController : ApiController
    {
        private readonly IConfirmTraHoldSeatApplication _confirmTraHoldSeatApplication;

        public ConfirmTraHoldSeatController(IConfirmTraHoldSeatApplication confirmTraHoldSeatApplication)
        {
            _confirmTraHoldSeatApplication = confirmTraHoldSeatApplication;
        }
        /// <summary>
        /// 确认火车占位结果
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<ConfirmTraHoldSeatResponseViewModel>> ConfirmTraHoldSeat(
           [FromBody] ConfirmTraHoldSeatRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.OrderSource = this.GetOrderSource();
            request.Oid = this.GetOid();
            ConfirmTraHoldSeatResponseViewModel viewModel = new ConfirmTraHoldSeatResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _confirmTraHoldSeatApplication.ConfirmTraHoldSeat(request);
            });

            ResponseBaseViewModel<ConfirmTraHoldSeatResponseViewModel> v = new ResponseBaseViewModel
                <ConfirmTraHoldSeatResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
