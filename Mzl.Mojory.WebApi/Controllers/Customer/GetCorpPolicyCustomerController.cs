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

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    /// <summary>
    /// 获取差旅客户部门信息
    /// </summary>
    public class GetCorpPolicyCustomerController : ApiController
    {
        private readonly IGetCorpPolicyCustomerApplication _getCorpPolicyCustomerApplication;

        public GetCorpPolicyCustomerController(IGetCorpPolicyCustomerApplication getCorpPolicyCustomerApplication)
        {
            _getCorpPolicyCustomerApplication = getCorpPolicyCustomerApplication;
        }

        /// <summary>
        /// 获取差旅客户的客户信息(包含是否对应政策)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<GetCorpPolicyCustomerResponseViewModel>> GetCorpPolicyCustomers(
        [FromBody] GetCorpPolicyCustomerRequestViewModel request)
        {
            request.Cid = this.GetCid();
            if (request.PolicyId == 0)
            {
                throw new Exception("政策Id不能为0");
            }
            GetCorpPolicyCustomerResponseViewModel viewModel = new GetCorpPolicyCustomerResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _getCorpPolicyCustomerApplication.GetCorpPolicyCustomer(request);
            });

            ResponseBaseViewModel<GetCorpPolicyCustomerResponseViewModel> v = new ResponseBaseViewModel
                <GetCorpPolicyCustomerResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
