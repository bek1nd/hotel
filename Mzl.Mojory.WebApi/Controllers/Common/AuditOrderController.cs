using Mzl.IApplication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Common.AuditOrder;

namespace Mzl.Mojory.WebApi.Controllers.Common
{
    /// <summary>
    /// 审批
    /// </summary>
    [Obsolete("该审批功能已废弃")]
    public class AuditOrderController : ApiController
    {
        private readonly IAuditOrderApplication _auditOrderApplication;

        public AuditOrderController(IAuditOrderApplication auditOrderApplication)
        {
            _auditOrderApplication = auditOrderApplication;
        }
        /// <summary>
        /// 审批
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<AuditOrderResponseViewModel> Audit([FromBody] AuditOrderRequestViewModel request)
        {
            if (request == null)
                request = new AuditOrderRequestViewModel();
            request.Cid = this.GetCid();
            AuditOrderResponseViewModel responseViewModel = _auditOrderApplication.RunAudit(request);
            ResponseBaseViewModel<AuditOrderResponseViewModel> v = new ResponseBaseViewModel<AuditOrderResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = responseViewModel.Code, MojoryToken = this.GetToken() },
                Data = responseViewModel
            };
            return v;

        }
    }
}
