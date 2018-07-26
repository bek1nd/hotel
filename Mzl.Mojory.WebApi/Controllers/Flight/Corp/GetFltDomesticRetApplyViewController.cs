using Mzl.IApplication.Flight;
using Mzl.UIModel.Base;
using Mzl.UIModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.Mojory.WebApi.Config;

namespace Mzl.Mojory.WebApi.Controllers.Flight.Corp
{
    /// <summary>
    /// 获取国内机票退票申请页面
    /// </summary>
    public class GetFltDomesticRetApplyViewController : ApiController
    {
        private readonly IGetFltDomesticRetApplyViewApplication _getFltDomesticRetApplyViewApplication;

        public GetFltDomesticRetApplyViewController(IGetFltDomesticRetApplyViewApplication getFltDomesticRetApplyViewApplication)
        {
            _getFltDomesticRetApplyViewApplication = getFltDomesticRetApplyViewApplication;
        }

        /// <summary>
        /// 获取退票申请页面
        /// </summary>
        [HttpPost]
        public ResponseBaseViewModel<GetRetApplyResponseViewModel> GetRetApply([FromBody] GetRetApplyRequestViewModel request)
        {
            request.Cid = this.GetCid();
            GetRetApplyResponseViewModel responseViewModel = _getFltDomesticRetApplyViewApplication.GetRetApplyView(request);
            ResponseBaseViewModel<GetRetApplyResponseViewModel> v = new ResponseBaseViewModel<GetRetApplyResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = responseViewModel
            };
            return v;
        }
    }
}
