using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.GrabTicket.KongTieInterface
{
    /// <summary>
    /// 抢票下单失败异步响应
    /// </summary>
    public class GrabTicketFailedAsyncResponseModel : GrabTicketAbstractAsyncResponseModel
    {
        public GrabTicketFailedDataAsyncResponseModel data { get; set; }

    }
}
