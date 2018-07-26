using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.IApplication.Train.GrabTicket;
using Mzl.IBLL.Train.GrabTicket;
using Mzl.UIModel.Train.GrabTicket;
using AutoMapper;
using Mzl.DomainModel.Train.GrabTicket;

namespace Mzl.Application.Train.GrabTicket
{
    internal class GetTraGrabTicketListApplication : BaseApplicationService, IGetTraGrabTicketListApplication
    {
        private readonly IGetTraGrabTicketListServiceBll _getTraGrabTicketListServiceBll;

        public GetTraGrabTicketListApplication(IGetTraGrabTicketListServiceBll getTraGrabTicketListServiceBll)
        {
            _getTraGrabTicketListServiceBll = getTraGrabTicketListServiceBll;
        }

        public TraGrabTicketListResponseViewModel GetTraGrabTicketList(TraGrabTicketListRequestViewModel request)
        {
            TraGrabTicketListQueryModel query =
              Mapper.Map<TraGrabTicketListRequestViewModel, TraGrabTicketListQueryModel>(request);

            TraGrabTicketListModel traGrabTicketListModel = _getTraGrabTicketListServiceBll.GetTraGrabTicketList(query);

            return Mapper.Map<TraGrabTicketListModel, TraGrabTicketListResponseViewModel>(traGrabTicketListModel);
        }
    }
}
