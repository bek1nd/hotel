using Mzl.IBLL.Train.Server.BLL;

namespace Mzl.IBLL.Train.Server.BLL
{
    public interface ITicketRefundServerBLL<out T> : IBaseServerBLL where T : class
    {

        string CallBackUrl { get; }


        T DoTicketRefund();
     }
}