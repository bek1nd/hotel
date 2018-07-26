using Mzl.DomainModel.Train.GrabTicket.KongTieInterface;

namespace Mzl.IBLL.Train.GrabTicket.KongTieInterface
{
    /// <summary>
    /// 响应异步抢票
    /// </summary>
    public interface IResponseAsyncGrabTicketServiceBll
    {
        /// <summary>
        /// 收到抢票异步通知
        /// </summary>
        /// <param name="responseData"></param>
        /// <returns>true 抢票成功，false抢票失败</returns>
        bool ResponseGrabTicketResult(string responseData);
        /// <summary>
        /// 失败结果
        /// </summary>
        GrabTicketFailedDataAsyncResponseModel FailedResult { get; }
        /// <summary>
        /// 成功结果
        /// </summary>
        GrabTicketSuccessedDataAsyncResponseModel SuccessedResult { get; }

    }
}
