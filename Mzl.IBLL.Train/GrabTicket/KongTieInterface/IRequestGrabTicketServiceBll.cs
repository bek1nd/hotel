using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.GrabTicket;
using Mzl.DomainModel.Train.GrabTicket.KongTieInterface;

namespace Mzl.IBLL.Train.GrabTicket.KongTieInterface
{
    public interface IRequestGrabTicketServiceBll
    {
        /// <summary>
        /// 请求空铁无忧抢票接口
        /// </summary>
        /// <param name="addTraGrabTicketModel"></param>
        /// <returns></returns>
        GrabTicketResponseModel RequestGrabTicketInterface(AddTraGrabTicketModel addTraGrabTicketModel);
    }
}
