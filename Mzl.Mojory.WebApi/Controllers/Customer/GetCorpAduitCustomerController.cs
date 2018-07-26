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
    /// 获取差旅客户部门信息
    /// </summary>
    public class GetCorpAduitCustomerController : ApiController
    {
        private readonly IGetCorpAduitCustomerApplication _getCorpAduitCustomerApplication;

        public GetCorpAduitCustomerController(IGetCorpAduitCustomerApplication getCorpAduitCustomerApplication)
        {
            _getCorpAduitCustomerApplication = getCorpAduitCustomerApplication;
        }

        /// <summary>
        /// 获取差旅客户的客户信息(包含是否对应政策)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<GetCorpAduitCustomerResponseViewModel>> GetCorpAduitCustomers(
        [FromBody] GetCorpAduitCustomerRequestViewModel request)
        {
            request.Cid = this.GetCid();
            if (request.AduitId == 0)
            {
                throw new Exception("审批规则Id不能为0");
            }
            GetCorpAduitCustomerResponseViewModel viewModel = new GetCorpAduitCustomerResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _getCorpAduitCustomerApplication.GetCorpAduitCustomer(request);
            });

            ResponseBaseViewModel<GetCorpAduitCustomerResponseViewModel> v = new ResponseBaseViewModel
                <GetCorpAduitCustomerResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
