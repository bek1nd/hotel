using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Train.GrabTicket
{
    public class CancelTraGrabTicketRequestViewModel : RequestBaseViewModel
    {
        public int GrabId { get; set; }
    }
}
