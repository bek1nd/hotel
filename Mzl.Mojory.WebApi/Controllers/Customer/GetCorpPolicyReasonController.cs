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
using Mzl.UIModel.Customer.Corporation;
using Mzl.UIModel.Customer.CorpPolicy;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    /// <summary>
    /// 获取差旅政策对应的原因信息
    /// </summary>
    public class GetCorpPolicyReasonController : ApiController
    {
        private readonly IGetCorpPolicyReasonApplication _getCorpPolicyReasonApplication;

        public GetCorpPolicyReasonController(IGetCorpPolicyReasonApplication getCorpPolicyReasonApplication)
        {
            _getCorpPolicyReasonApplication = getCorpPolicyReasonApplication;
        }

        /// <summary>
        /// 获取差旅政策对应的原因信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<GetCorpPolicyReasonResponseViewModel>> GetCorpPolicyReason(
        [FromBody] GetCorpPolicyReasonRequestViewModel request)
        {
            if (request == null)
                request = new GetCorpPolicyReasonRequestViewModel();
            request.Cid = this.GetCid();
            GetCorpPolicyReasonResponseViewModel viewModel = new GetCorpPolicyReasonResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _getCorpPolicyReasonApplication.GetCorpPolicyReasonByCorpId(request);
            });

            ResponseBaseViewModel<GetCorpPolicyReasonResponseViewModel> v = new ResponseBaseViewModel
                <GetCorpPolicyReasonResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
