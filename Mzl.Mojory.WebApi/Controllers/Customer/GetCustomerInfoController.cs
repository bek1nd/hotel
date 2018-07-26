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
using Mzl.UIModel.Customer.CorpPolicy;
using Mzl.UIModel.Customer.Customer;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    /// <summary>
    /// 获取客户信息
    /// </summary>
    public class GetCustomerInfoController : ApiController
    {
        private readonly IGetCustomerInfoApplication _getCustomerInfoApplication;

        public GetCustomerInfoController(IGetCustomerInfoApplication getCustomerInfoApplication)
        {
            _getCustomerInfoApplication = getCustomerInfoApplication;
        }

        /// <summary>
        /// 获取客户信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<GetCustomerInfoResponseViewModel>> GetCustomerInfo(
         [FromBody] GetCustomerInfoRequestViewModel request)
        {
            if (request == null)
                request = new GetCustomerInfoRequestViewModel();
            request.Cid = this.GetCid();
            GetCustomerInfoResponseViewModel viewModel = new GetCustomerInfoResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _getCustomerInfoApplication.GetCustomerInfoByCid(request);
            });

            ResponseBaseViewModel<GetCustomerInfoResponseViewModel> v = new ResponseBaseViewModel
                <GetCustomerInfoResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
