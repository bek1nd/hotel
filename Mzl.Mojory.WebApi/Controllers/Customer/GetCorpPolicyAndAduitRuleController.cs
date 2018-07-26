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
using Mzl.UIModel.Customer.MatchCorpPolicyAndAduit;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    /// <summary>
    /// 获取待预定乘客的差旅政策和审批规则
    /// </summary>
    public class GetCorpPolicyAndAduitRuleController : ApiController
    {
        private readonly IMatchCorpPolicyAndAduitApplication _matchCorpPolicyAndAduitApplication;

        public GetCorpPolicyAndAduitRuleController(IMatchCorpPolicyAndAduitApplication matchCorpPolicyAndAduitApplication)
        {
            _matchCorpPolicyAndAduitApplication = matchCorpPolicyAndAduitApplication;
        }

        /// <summary>
        /// 获取待预定乘客的差旅政策和审批规则
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<MatchCorpPolicyAndAduitResponseViewModel>> GetCorpPolicyAndAduitRule(
            [FromBody] MatchCorpPolicyAndAduitRequestViewModel request)
        {
            if (request == null)
                request = new MatchCorpPolicyAndAduitRequestViewModel();
            request.Cid = this.GetCid();
            MatchCorpPolicyAndAduitResponseViewModel viewModel = new MatchCorpPolicyAndAduitResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _matchCorpPolicyAndAduitApplication.Match(request);
            });

            ResponseBaseViewModel<MatchCorpPolicyAndAduitResponseViewModel> v = new ResponseBaseViewModel
                <MatchCorpPolicyAndAduitResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = viewModel
            };
            return v;
        }

    }
}
