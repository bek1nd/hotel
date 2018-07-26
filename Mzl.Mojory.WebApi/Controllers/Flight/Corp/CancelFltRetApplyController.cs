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
    /// 取消退票申请
    /// </summary>
    public class CancelFltRetApplyController : ApiController
    {
        private readonly ICancelFltRetApplyApplication _cancelFltRetApplyApplication;

        public CancelFltRetApplyController(ICancelFltRetApplyApplication cancelFltRetApplyApplication)
        {
            _cancelFltRetApplyApplication = cancelFltRetApplyApplication;
        }

        /// <summary>
        /// 待核价确认阶段取消退票申请
        /// </summary>
        [HttpPost]
        public ResponseBaseViewModel<CancelFltRetApplyResponseViewModel> CancelFltRetApplyByWaitAuditStep(
            [FromBody] CancelFltRetApplyRequestViewModel request)
        {
            request.Cid = this.GetCid();
            CancelFltRetApplyResponseViewModel responseViewModel =
                _cancelFltRetApplyApplication.CancelFltRetApplyByWaitAuditStep(request);
            ResponseBaseViewModel<CancelFltRetApplyResponseViewModel> v = new ResponseBaseViewModel
                <CancelFltRetApplyResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = responseViewModel.Code, MojoryToken = this.GetToken() },
                Data = responseViewModel
            };
            return v;
        }
    }
}
