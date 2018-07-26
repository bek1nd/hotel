using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.IApplication.Flight;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Common.AuditOrder;
using Mzl.UIModel.Flight;

namespace Mzl.Mojory.WebApi.Controllers.Flight.Corp
{
    /// <summary>
    /// 取消差旅订单
    /// </summary>
    public class CancelFltCorpOrderController : ApiController
    {
        private readonly ICancelFltOrderApplication _cancelFltOrderApplication;

        public CancelFltCorpOrderController(ICancelFltOrderApplication cancelFltOrderApplication)
        {
            _cancelFltOrderApplication = cancelFltOrderApplication;
        }

        /// <summary>
        /// 取消线上订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<CancelFltOrderResponseViewModel> CancelOnlineOrder([FromBody] CancelFltOrderRequestViewModel request)
        {
            if (request == null)
                request = new CancelFltOrderRequestViewModel();
            request.Cid = this.GetCid();
            CancelFltOrderResponseViewModel responseViewModel = _cancelFltOrderApplication.CancelOnlineCorpOrder(request);
            ResponseBaseViewModel<CancelFltOrderResponseViewModel> v = new ResponseBaseViewModel<CancelFltOrderResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = responseViewModel.Code, MojoryToken = this.GetToken() },
                Data = responseViewModel
            };
            return v;
        }
    }
}
