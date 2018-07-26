using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.GrabTicket.KongTieInterface
{
    public class GrabTicketFailedDataAsyncResponseModel
    {
        /// <summary>
        /// 下单失败信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 采购商订单号
        /// </summary>
        public string orderid { get; set; }
        /// <summary>
        /// 下单是否成功
        /// </summary>
        public bool success { get; set; }
        public int AgentId { get; set; }
    }
}
