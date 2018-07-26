using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Train.GrabTicket;
using Mzl.EntityModel.Train;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.GrabTicket;
using Mzl.IDAL.Train;

namespace Mzl.BLL.Train.GrabTicket
{
    internal class UpdateTraGrabTicketStatusServiceBll : BaseServiceBll, IUpdateTraGrabTicketStatusServiceBll
    {
        private readonly ITraGrabTicketDal _traGrabTicketDal;

        public UpdateTraGrabTicketStatusServiceBll(ITraGrabTicketDal traGrabTicketDal)
        {
            _traGrabTicketDal = traGrabTicketDal;
        }

        public bool UpdateTraGrabTicketStatusByAfterSubmit(UpdateTraGrabTicketStatusModel updateTraGrabTicketStatusModel)
        {
            TraGrabTicketEntity traGrabTicketEntity=_traGrabTicketDal.Find<TraGrabTicketEntity>(updateTraGrabTicketStatusModel.GrabId);
            traGrabTicketEntity.GrabStatus = updateTraGrabTicketStatusModel.GrabStatus.ToString();
            traGrabTicketEntity.SubmitFailedReason = updateTraGrabTicketStatusModel.SubmitFailedReason;
            _traGrabTicketDal.Update(traGrabTicketEntity, new string[] {"GrabStatus", "SubmitFailedReason"});
            return true;
        }

        
    }
}
