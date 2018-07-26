using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.UIModel.Flight;
using Mzl.IApplication.Flight;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Common.AuditOrder;

namespace Mzl.Mojory.WebApi.Controllers.Flight.Corp
{
    /// <summary>
    /// 改签申请核价确认
    /// </summary>
    public class ConfirmModApplyAuditPriceController : ApiController
    {
        private readonly IConfirmModAuditPriceApplication _confirmModAuditPriceApplication;

        public ConfirmModApplyAuditPriceController(IConfirmModAuditPriceApplication confirmModAuditPriceApplication)
        {
            _confirmModAuditPriceApplication = confirmModAuditPriceApplication;
        }
        [HttpPost]
        public ResponseBaseViewModel<ConfirmModAuditPriceResponseViewModel> ConfirmModAuditPrice([FromBody]ConfirmRetModAuditPriceRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.Oid = this.GetOid();
            request.OrderSource = this.GetOrderSource();
            bool flag=_confirmModAuditPriceApplication.ConfirmModAuditPrice(request);
            ResponseBaseViewModel<ConfirmModAuditPriceResponseViewModel> v = new ResponseBaseViewModel
                <ConfirmModAuditPriceResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = new ConfirmModAuditPriceResponseViewModel() {IsAuditPriceSuccess = flag}
            };
            return v;
        }
    }
}
