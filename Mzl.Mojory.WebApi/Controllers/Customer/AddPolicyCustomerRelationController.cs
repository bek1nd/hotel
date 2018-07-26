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
    /// 差旅政策和员工进行关联
    /// </summary>
    public class AddPolicyCustomerRelationController : ApiController
    {
        private readonly IAddPolicyCustomerRelationApplication _addPolicyCustomerRelationApplication;

        public AddPolicyCustomerRelationController(IAddPolicyCustomerRelationApplication addPolicyCustomerRelationApplication)
        {
            _addPolicyCustomerRelationApplication = addPolicyCustomerRelationApplication;
        }

        /// <summary>
        /// 添加差旅政策和员工之间的关联
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<AddPolicyCustomerRelationResponseViewModel>> AddPolicyCustomerRelation(
           [FromBody] AddPolicyCustomerRelationRequestViewModel request)
        {
            request.Cid = this.GetCid();
            AddPolicyCustomerRelationResponseViewModel viewModel = new AddPolicyCustomerRelationResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _addPolicyCustomerRelationApplication.AddPolicyCustomerRelation(request);
            });

            ResponseBaseViewModel<AddPolicyCustomerRelationResponseViewModel> v = new ResponseBaseViewModel
                <AddPolicyCustomerRelationResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
