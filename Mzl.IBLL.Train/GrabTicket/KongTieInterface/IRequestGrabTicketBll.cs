using Mzl.DomainModel.Train.GrabTicket.KongTieInterface;

namespace Mzl.IBLL.Train.GrabTicket.KongTieInterface
{
    /// <summary>
    ///火车抢票接口
    /// </summary>
    public interface IRequestGrabTicketBll
    {
        /// <summary>
        /// 请求抢票接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GrabTicketResponseModel RunGrabTicketInterface(GrabTicketRequestModel request);

    }
}
