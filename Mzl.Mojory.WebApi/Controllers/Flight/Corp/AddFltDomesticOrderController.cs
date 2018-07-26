using Microsoft.Practices.Unity;
using Mzl.Common.Ioc;
using Mzl.IApplication.Flight;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Mzl.Mojory.WebApi.Controllers.Flight.Corp
{
    /// <summary>
    /// 添加机票国内订单
    /// </summary>
    public class AddFltDomesticOrderController : ApiController
    {
        private readonly IAddOrderApplication _addOrderApplication;

        public AddFltDomesticOrderController(IAddOrderApplication addOrderApplication)
        {
            _addOrderApplication = addOrderApplication;
        }

        /// <summary>
        /// 添加机票国内订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<AddOrderResponseViewModel>> AddFltDomesticOrder(
            [FromBody] AddOrderRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.OrderSource = this.GetOrderSource();
            request.CreateOid = this.GetOid();
            AddOrderResponseViewModel viewModel = new AddOrderResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _addOrderApplication.AddDomesticOrderApplicationService(request);
            });

            ResponseBaseViewModel<AddOrderResponseViewModel> v = new ResponseBaseViewModel
                <AddOrderResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = viewModel
            };
            return v;
        }

    }
}