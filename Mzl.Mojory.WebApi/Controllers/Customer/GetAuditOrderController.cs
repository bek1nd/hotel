using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Mzl.IApplication.Customer;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Customer.CorpAduit;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    /// <summary>
    /// 获取审批单信息
    /// </summary>
    public class GetAuditOrderController : ApiController
    {
        private readonly IGetAduitOrderApplication _getAduitOrderApplication;

        public GetAuditOrderController(IGetAduitOrderApplication getAduitOrderApplication)
        {
            _getAduitOrderApplication = getAduitOrderApplication;
        }

        /// <summary>
        /// 根据审批单号获取审批信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<GetAduitOrderResponseViewModel>> GetAuditOrderById(
         [FromBody] GetAduitOrderRequestViewModel request)
        {
            request.Cid = this.GetCid();
            if (string.IsNullOrEmpty(request.OrderSource))
            {
                request.OrderSource = this.GetOrderSource();
            }
            GetAduitOrderResponseViewModel viewModel = new GetAduitOrderResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _getAduitOrderApplication.GetAuditOrder(request);
            });

            ResponseBaseViewModel<GetAduitOrderResponseViewModel> v = new ResponseBaseViewModel
                <GetAduitOrderResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
