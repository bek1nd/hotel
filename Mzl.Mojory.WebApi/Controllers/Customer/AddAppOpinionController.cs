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
using Mzl.UIModel.Customer.Customer;
using Mzl.Common.EmailHelper;
using Mzl.Common.ConfigHelper;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    /// <summary>
    /// 添加app意见
    /// </summary>
    public class AddAppOpinionController : ApiController
    {
        private readonly IAddAppOpinionApplication _addAppOpinionApplication;

        public AddAppOpinionController(IAddAppOpinionApplication addAppOpinionApplication)
        {
            _addAppOpinionApplication = addAppOpinionApplication;
        }
        /// <summary>
        /// 添加差旅网站app意见
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<AppOpinionResponseViewModel>> AddMojoryAppOpinion(
            [FromBody] AppOpinionRequestViewModel request)
        {
            request.Cid = this.GetCid();
            bool flag = false;
            await new TaskFactory().StartNew(() =>
            {
                flag = _addAppOpinionApplication.AddMojoryOpinion(request);
            });
            ResponseBaseViewModel<AppOpinionResponseViewModel> v = new ResponseBaseViewModel
                <AppOpinionResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = new AppOpinionResponseViewModel() { IsSuccessed = flag }
            };
            
            return v;
        }
    }
}
