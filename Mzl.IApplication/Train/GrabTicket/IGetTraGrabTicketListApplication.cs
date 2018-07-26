using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Train.GrabTicket;

namespace Mzl.IApplication.Train.GrabTicket
{
    public interface IGetTraGrabTicketListApplication : IBaseApplication
    {
        TraGrabTicketListResponseViewModel GetTraGrabTicketList(TraGrabTicketListRequestViewModel request);
    }
}
