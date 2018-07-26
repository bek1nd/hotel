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
    /// 添加审批规则与部门关系
    /// </summary>
    public class AddCorpAduitDepartmentRelationController : ApiController
    {
        private readonly IAddCorpAduitDepartmentRelationApplication _addCorpAduitDepartmentRelationApplication;

        public AddCorpAduitDepartmentRelationController(IAddCorpAduitDepartmentRelationApplication addCorpAduitDepartmentRelationApplication)
        {
            _addCorpAduitDepartmentRelationApplication = addCorpAduitDepartmentRelationApplication;
        }

        /// <summary>
        /// 添加审批规则与部门关系
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<AddCorpAduitDepartmentRelationResponseViewModel>> AddCorpAduitDepartmentRelation(
         [FromBody] AddCorpAduitDepartmentRelationRequestViewModel request)
        {
            request.Cid = this.GetCid();
            AddCorpAduitDepartmentRelationResponseViewModel viewModel = new AddCorpAduitDepartmentRelationResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _addCorpAduitDepartmentRelationApplication.AddCorpAduitDepartmentRelation(request);
            });

            ResponseBaseViewModel<AddCorpAduitDepartmentRelationResponseViewModel> v = new ResponseBaseViewModel
                <AddCorpAduitDepartmentRelationResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
