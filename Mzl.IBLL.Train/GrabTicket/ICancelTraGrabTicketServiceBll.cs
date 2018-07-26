using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.GrabTicket;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Train.GrabTicket
{
    public interface ICancelTraGrabTicketServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 取消抢票
        /// </summary>
        /// <param name="cancelTraGrabTicketModel"></param>
        /// <returns></returns>
        CancelTraGrabTicketResultModel CancelTraGrabTicket(CancelTraGrabTicketModel cancelTraGrabTicketModel);
    }
}
