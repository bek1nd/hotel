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
    /// 退票申请核价确认
    /// </summary>
    public class ConfirmRetApplyAuditPriceController : ApiController
    {
        private readonly IConfirmRetAuditPriceApplication _comConfirmRetAuditPriceApplication;

        public ConfirmRetApplyAuditPriceController(IConfirmRetAuditPriceApplication comConfirmRetAuditPriceApplication)
        {
            _comConfirmRetAuditPriceApplication = comConfirmRetAuditPriceApplication;
        }
        /// <summary>
        /// 退票申请核价确认
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<ConfirmModAuditPriceResponseViewModel> ConfirmRetAuditPrice([FromBody]ConfirmRetModAuditPriceRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.Oid = this.GetOid();
            request.OrderSource = this.GetOrderSource();
            bool flag = _comConfirmRetAuditPriceApplication.ConfirmRetAuditPrice(request);
            ResponseBaseViewModel<ConfirmModAuditPriceResponseViewModel> v = new ResponseBaseViewModel
                <ConfirmModAuditPriceResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = new ConfirmModAuditPriceResponseViewModel() { IsAuditPriceSuccess = flag }
            };
            return v;
        }
    }
}
