using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.GrabTicket;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Train.GrabTicket
{
    public interface IGetTraGrabTicketListServiceBll : IBaseServiceBll
    {
        TraGrabTicketListModel GetTraGrabTicketList(TraGrabTicketListQueryModel query);
    }
}
