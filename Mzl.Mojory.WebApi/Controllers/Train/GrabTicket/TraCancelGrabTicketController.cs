using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.IApplication.Train.GrabTicket;
using Mzl.UIModel.Base;
using Mzl.UIModel.Train.GrabTicket;
using Mzl.Mojory.WebApi.Config;

namespace Mzl.Mojory.WebApi.Controllers.Train.GrabTicket
{
    /// <summary>
    ///火车抢票取消
    /// </summary>
    public class TraCancelGrabTicketController : ApiController
    {
        private readonly ICancelGrabTicketApplication _cancelGrabTicketApplication;

        public TraCancelGrabTicketController(ICancelGrabTicketApplication cancelGrabTicketApplication)
        {
            _cancelGrabTicketApplication = cancelGrabTicketApplication;
        }

        /// <summary>
        /// 取消抢票
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<CancelTraGrabTicketResponseViewModel> CancelGrabTicket([FromBody] CancelTraGrabTicketRequestViewModel request)
        {
            request.Oid = this.GetOid();
            CancelTraGrabTicketResponseViewModel responseViewModel = _cancelGrabTicketApplication.CancelGrabTicket(request);
            ResponseBaseViewModel<CancelTraGrabTicketResponseViewModel> v = new ResponseBaseViewModel
               <CancelTraGrabTicketResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = responseViewModel
            };
            return v;
        }

    }
}
