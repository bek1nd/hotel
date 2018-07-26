using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.GrabTicket.KongTieInterface
{
    public abstract class GrabTicketAbstractAsyncResponseModel
    {
        public string reqtime { get; set; }
        public string sign { get; set; }
        /// <summary>
        /// 采购商订单号
        /// </summary>
        public string orderid { get; set; }
        /// <summary>
        /// “N”或者”Y”
        /// </summary>
        public string isSuccess { get; set; }

        public string transactionid { get; set; }
    }
}
