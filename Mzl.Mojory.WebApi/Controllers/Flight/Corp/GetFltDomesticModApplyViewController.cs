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
    /// 获取国内机票改签申请页面
    /// </summary>
    public class GetFltDomesticModApplyViewController : ApiController
    {
        private readonly IGetFltDomesticModApplyViewApplication _getFltDomesticModApplyViewApplication;

        public GetFltDomesticModApplyViewController(IGetFltDomesticModApplyViewApplication getFltDomesticModApplyViewApplication)
        {
            _getFltDomesticModApplyViewApplication = getFltDomesticModApplyViewApplication;
        }

        /// <summary>
        /// 获取改签申请页面
        /// </summary>
        [HttpPost]
        public ResponseBaseViewModel<GetModApplyResponseViewModel> GetModApply([FromBody] GetModApplyRequestViewModel request)
        {
            request.Cid = this.GetCid();
            GetModApplyResponseViewModel responseViewModel = _getFltDomesticModApplyViewApplication.GetFltDomesticModApply(request);
            ResponseBaseViewModel<GetModApplyResponseViewModel> v = new ResponseBaseViewModel<GetModApplyResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = responseViewModel
            };
            return v;
        }

     
    }
}
