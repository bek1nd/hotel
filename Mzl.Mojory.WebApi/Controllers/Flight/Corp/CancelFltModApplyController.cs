using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.IApplication.Flight;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Flight;

namespace Mzl.Mojory.WebApi.Controllers.Flight.Corp
{
    /// <summary>
    /// 取消改签申请
    /// </summary>
    public class CancelFltModApplyController : ApiController
    {
        private readonly ICancelFltModApplyApplication _cancelFltModApplyApplication;

        public CancelFltModApplyController(ICancelFltModApplyApplication cancelFltModApplyApplication)
        {
            _cancelFltModApplyApplication = cancelFltModApplyApplication;
        }

        /// <summary>
        /// 待核价确认阶段取消申请
        /// </summary>
        [HttpPost]
        public ResponseBaseViewModel<CancelFltModApplyResponseViewModel> CancelFltModApplyByWaitAuditStep(
            [FromBody] CancelFltModApplyRequestViewModel request)
        {
            request.Cid = this.GetCid();
            CancelFltModApplyResponseViewModel responseViewModel =
                _cancelFltModApplyApplication.CancelFltModApplyByWaitAuditStep(request);
            ResponseBaseViewModel<CancelFltModApplyResponseViewModel> v = new ResponseBaseViewModel
                <CancelFltModApplyResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = responseViewModel.Code, MojoryToken = this.GetToken()},
                Data = responseViewModel
            };
            return v;
        }

    }
}
