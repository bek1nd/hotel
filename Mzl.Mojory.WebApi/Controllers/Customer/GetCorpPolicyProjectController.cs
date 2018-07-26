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
    /// 获取差旅政策对应的项目成本中心信息
    /// </summary>
    public class GetCorpPolicyProjectController : ApiController
    {
        private readonly IGetCorpPolicyProjectApplication _getCorpPolicyProjectApplication;

        public GetCorpPolicyProjectController(IGetCorpPolicyProjectApplication getCorpPolicyProjectApplication)
        {
            _getCorpPolicyProjectApplication = getCorpPolicyProjectApplication;
        }

        /// <summary>
        /// 获取差旅政策对应的项目成本中心信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<GetCorpPolicyProjectResponseViewModel>> GetCorpPolicyProjects(
         [FromBody] GetCorpPolicyProjectRequestViewModel request)
        {
            request.Cid = this.GetCid();
            GetCorpPolicyProjectResponseViewModel viewModel = new GetCorpPolicyProjectResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _getCorpPolicyProjectApplication.GetCorpPolicyProjectByCorpId(request);
            });

            ResponseBaseViewModel<GetCorpPolicyProjectResponseViewModel> v = new ResponseBaseViewModel
                <GetCorpPolicyProjectResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
