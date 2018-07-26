using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;

namespace Mzl.IApplication.Train.GrabTicket
{
    public interface IGetGrabTicketNoticeApplication: IBaseApplication
    {
        void GetGrabTicketNotice(string responseData);
    }
}
