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
    /// 审批规则维护
    /// </summary>
    public class MaintainCorpAduitConfigController : ApiController
    {
        private readonly IMaintainCorpAduitConfigApplication _maintainCorpAduitConfigApplication;

        public MaintainCorpAduitConfigController(IMaintainCorpAduitConfigApplication maintainCorpAduitConfigApplicatio)
        {
            _maintainCorpAduitConfigApplication = maintainCorpAduitConfigApplicatio;
        }

        /// <summary>
        /// 添加审批规则
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<AddCorpAduitConfigResponseViewModel>> Add(
           [FromBody] AddCorpAduitConfigRequestViewModel request)
        {
            request.Cid = this.GetCid();
            AddCorpAduitConfigResponseViewModel viewModel = new AddCorpAduitConfigResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _maintainCorpAduitConfigApplication.Add(request);
            });

            ResponseBaseViewModel<AddCorpAduitConfigResponseViewModel> v = new ResponseBaseViewModel
                <AddCorpAduitConfigResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }

        /// <summary>
        /// 修改审批规则
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<UpdateCorpAduitConfigResponseViewModel>> Update(
           [FromBody] UpdateCorpAduitConfigRequestViewModel request)
        {
            request.Cid = this.GetCid();
            UpdateCorpAduitConfigResponseViewModel viewModel = new UpdateCorpAduitConfigResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _maintainCorpAduitConfigApplication.Update(request);
            });

            ResponseBaseViewModel<UpdateCorpAduitConfigResponseViewModel> v = new ResponseBaseViewModel
                <UpdateCorpAduitConfigResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
