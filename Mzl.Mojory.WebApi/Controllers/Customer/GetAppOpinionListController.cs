using Mzl.DomainModel.Customer.AppOpinion;
using Mzl.IApplication.Customer;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Customer.AppOpinion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    /// <summary>
    /// 获取app意见列表
    /// </summary>
    public class GetAppOpinionListController : ApiController
    {
        private readonly IGetAppOpinionListApplication _GetAppOpinionListApplication;
        public GetAppOpinionListController(IGetAppOpinionListApplication getAppOpinionListApplication)
        {
            _GetAppOpinionListApplication = getAppOpinionListApplication;
        }
        [HttpPost]
        public async Task<ResponseBaseViewModel<GetAppOpinionListResponseViewModel>> GetAppOpinionList([FromBody]GetAppOpinionListRequestViewModel query)
        {
            GetAppOpinionListResponseViewModel viewModel = new GetAppOpinionListResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _GetAppOpinionListApplication.GetAppinionList(query);
            }
            );
            ResponseBaseViewModel<GetAppOpinionListResponseViewModel> v = new ResponseBaseViewModel<GetAppOpinionListResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
