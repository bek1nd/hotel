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
    /// 差旅政策和项目进行关联
    /// </summary>
    public class AddPolicyProjectRelationController : ApiController
    {
        private readonly IAddPolicyProjectRelationApplication _addPolicyProjectRelationApplication;

        public AddPolicyProjectRelationController(IAddPolicyProjectRelationApplication addPolicyProjectRelationApplication)
        {
            _addPolicyProjectRelationApplication = addPolicyProjectRelationApplication;
        }

        /// <summary>
        /// 差旅政策和项目进行关联
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<AddPolicyProjectRelationResponseViewModel>> AddPolicyProjectRelation(
           [FromBody] AddPolicyProjectRelationRequestViewModel request)
        {
            request.Cid = this.GetCid();
            AddPolicyProjectRelationResponseViewModel viewModel = new AddPolicyProjectRelationResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _addPolicyProjectRelationApplication.AddPolicyProjectRelation(request);
            });

            ResponseBaseViewModel<AddPolicyProjectRelationResponseViewModel> v = new ResponseBaseViewModel
                <AddPolicyProjectRelationResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
