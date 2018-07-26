using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.GrabTicket.KongTieInterface;

namespace Mzl.IBLL.Train.GrabTicket.KongTieInterface
{
    /// <summary>
    ///取消抢票
    /// </summary>
    public interface IRequestGrabTicketCancelBll
    {
        /// <summary>
        /// 请求第三方取消抢票接口
        /// </summary>
        /// <param name="cancelRequestModel"></param>
        /// <returns></returns>
        GrabTicketCancelResponseModel CancelGrabTicket(GrabTicketCancelRequestModel cancelRequestModel);
    }
}
