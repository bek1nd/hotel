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
    /// 差旅政策和部门进行关联
    /// </summary>
    public class AddPolicyDepartmentRelationController : ApiController
    {
        private readonly IAddPolicyDepartmentRelationApplication _addPolicyDepartmentRelationApplication;

        public AddPolicyDepartmentRelationController(IAddPolicyDepartmentRelationApplication addPolicyDepartmentRelationApplication)
        {
            _addPolicyDepartmentRelationApplication = addPolicyDepartmentRelationApplication;
        }

        /// <summary>
        /// 添加差旅政策和部门之间的关联
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<AddPolicyDepartmentRelationResponseViewModel>> AddPolicyDepartmentRelation(
           [FromBody] AddPolicyDepartmentRelationRequestViewModel request)
        {
            request.Cid = this.GetCid();
            AddPolicyDepartmentRelationResponseViewModel viewModel = new AddPolicyDepartmentRelationResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _addPolicyDepartmentRelationApplication.AddPolicyDepartmentRelation(request);
            });

            ResponseBaseViewModel<AddPolicyDepartmentRelationResponseViewModel> v = new ResponseBaseViewModel
                <AddPolicyDepartmentRelationResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
