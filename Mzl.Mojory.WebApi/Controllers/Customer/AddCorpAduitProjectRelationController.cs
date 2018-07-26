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

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    /// <summary>
    /// 添加审批规则与项目成本中心关系
    /// </summary>
    public class AddCorpAduitProjectRelationController : ApiController
    {
        private readonly IAddCorpAduitProjectRelationApplication _addCorpAduitProjectRelationApplication;

        public AddCorpAduitProjectRelationController(IAddCorpAduitProjectRelationApplication addCorpAduitProjectRelationApplication)
        {
            _addCorpAduitProjectRelationApplication = addCorpAduitProjectRelationApplication;
        }

        /// <summary>
        /// 添加审批规则与项目成本中心关系
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<AddCorpAduitProjectRelationResponseViewModel>> AddCorpAduitProjectRelation(
         [FromBody] AddCorpAduitProjectRelationRequestViewModel request)
        {
            request.Cid = this.GetCid();
            AddCorpAduitProjectRelationResponseViewModel viewModel = new AddCorpAduitProjectRelationResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _addCorpAduitProjectRelationApplication.AddCorpAduitProjectRelation(request);
            });

            ResponseBaseViewModel<AddCorpAduitProjectRelationResponseViewModel> v = new ResponseBaseViewModel
                <AddCorpAduitProjectRelationResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
