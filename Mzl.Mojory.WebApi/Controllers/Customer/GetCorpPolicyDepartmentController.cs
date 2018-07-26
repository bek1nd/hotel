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
    /// 获取差旅政策对应的部门信息
    /// </summary>
    public class GetCorpPolicyDepartmentController : ApiController
    {
        private readonly IGetCorpPolicyDepartmentApplication _getCorpPolicyDepartmentApplication;

        public GetCorpPolicyDepartmentController(IGetCorpPolicyDepartmentApplication getCorpPolicyDepartmentApplication)
        {
            _getCorpPolicyDepartmentApplication = getCorpPolicyDepartmentApplication;
        }

        /// <summary>
        /// 获取差旅政策对应的部门信息(包含是否对应政策)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<GetCorpDepartmentResponseViewModel>> GetCorpPolicyDepartments(
         [FromBody] GetCorpDepartmentRequestViewModel request)
        {
            request.Cid = this.GetCid();
            GetCorpDepartmentResponseViewModel viewModel = new GetCorpDepartmentResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _getCorpPolicyDepartmentApplication.GetCorpPolicyDepartmentByCorpId(request);
            });

            ResponseBaseViewModel<GetCorpDepartmentResponseViewModel> v = new ResponseBaseViewModel
                <GetCorpDepartmentResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }


    }
}
