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
    /// 差旅审批规则维护
    /// </summary>
    public class GetCorpAduitConfigController : ApiController
    {
        private readonly IGetCorpAduitConfigApplication _getCorpAduitConfigApplication;

        public GetCorpAduitConfigController(IGetCorpAduitConfigApplication getCorpAduitConfigApplication)
        {
            _getCorpAduitConfigApplication = getCorpAduitConfigApplication;
        }

        /// <summary>
        /// 获取公司对应的审批规则
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<GetCorpAduitConfigListResponseViewModel>> GetCorpAduitConfigList(
            [FromBody] GetCorpAduitConfigListRequestViewModel request)
        {
            request.Cid = this.GetCid();
            GetCorpAduitConfigListResponseViewModel viewModel = new GetCorpAduitConfigListResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _getCorpAduitConfigApplication.GetCorpAduitConfigList(request);
            });

            ResponseBaseViewModel<GetCorpAduitConfigListResponseViewModel> v = new ResponseBaseViewModel
                <GetCorpAduitConfigListResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = viewModel
            };
            return v;
        }
        /// <summary>
        /// 获取id对应的审批规则
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<GetCorpAduitConfigResponseViewModel>> GetCorpAduitConfig(
           [FromBody] GetCorpAduitConfigRequestViewModel request)
        {
            request.Cid = this.GetCid();
            GetCorpAduitConfigResponseViewModel viewModel = new GetCorpAduitConfigResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _getCorpAduitConfigApplication.GetCorpAduitConfigById(request);
            });

            ResponseBaseViewModel<GetCorpAduitConfigResponseViewModel> v = new ResponseBaseViewModel
                <GetCorpAduitConfigResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }

    }
}
