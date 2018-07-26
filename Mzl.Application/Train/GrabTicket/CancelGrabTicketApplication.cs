using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.GrabTicket;
using Mzl.Framework.Base;
using Mzl.IApplication.Train.GrabTicket;
using Mzl.IBLL.Train.GrabTicket;
using Mzl.UIModel.Train.GrabTicket;

namespace Mzl.Application.Train.GrabTicket
{
    public class CancelGrabTicketApplication : BaseApplicationService, ICancelGrabTicketApplication
    {
        private readonly ICancelTraGrabTicketServiceBll _cancelTraGrabTicketServiceBll;

        public CancelGrabTicketApplication(ICancelTraGrabTicketServiceBll cancelTraGrabTicketServiceBll)
        {
            _cancelTraGrabTicketServiceBll = cancelTraGrabTicketServiceBll;
        }

        public CancelTraGrabTicketResponseViewModel CancelGrabTicket(CancelTraGrabTicketRequestViewModel request)
        {
            CancelTraGrabTicketResultModel cancelTraGrabTicketResultModel =
                _cancelTraGrabTicketServiceBll.CancelTraGrabTicket(new CancelTraGrabTicketModel()
                {
                    GrabId = request.GrabId
                });


            return new CancelTraGrabTicketResponseViewModel()
            {
                IsSuccess = cancelTraGrabTicketResultModel.IsSuccess,
                Message = cancelTraGrabTicketResultModel.Message
            };
        }
    }
}
