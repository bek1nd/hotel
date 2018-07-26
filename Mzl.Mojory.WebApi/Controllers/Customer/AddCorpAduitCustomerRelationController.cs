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
using Mzl.UIModel.Customer.CorpAduit;
using Mzl.UIModel.Customer.CorpPolicy;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    /// <summary>
    /// 审批规则和员工进行关联
    /// </summary>
    public class AddCorpAduitCustomerRelationController : ApiController
    {
        private readonly IAddCorpAduitCustomerRelationApplication _addCorpAduitCustomerRelationApplication;

        public AddCorpAduitCustomerRelationController(IAddCorpAduitCustomerRelationApplication addCorpAduitCustomerRelationApplication)
        {
            _addCorpAduitCustomerRelationApplication = addCorpAduitCustomerRelationApplication;
        }

        /// <summary>
        /// 添加审批规则和员工之间的关联
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<AddCorpAduitCustomerRelationResponseViewModel>> AddAduitCustomerRelation(
           [FromBody] AddCorpAduitCustomerRelationRequestViewModel request)
        {
            request.Cid = this.GetCid();
            AddCorpAduitCustomerRelationResponseViewModel viewModel = new AddCorpAduitCustomerRelationResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _addCorpAduitCustomerRelationApplication.AddCorpAduitCustomerRelation(request);
            });

            ResponseBaseViewModel<AddCorpAduitCustomerRelationResponseViewModel> v = new ResponseBaseViewModel
                <AddCorpAduitCustomerRelationResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
