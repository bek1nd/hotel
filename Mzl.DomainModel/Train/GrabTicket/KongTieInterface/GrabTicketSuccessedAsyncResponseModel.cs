using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.GrabTicket.KongTieInterface
{
    /// <summary>
    /// 抢票下单成功异步响应
    /// </summary>
    public class GrabTicketSuccessedAsyncResponseModel : GrabTicketAbstractAsyncResponseModel
    {
        public GrabTicketSuccessedDataAsyncResponseModel data { get; set; }

    }
}
