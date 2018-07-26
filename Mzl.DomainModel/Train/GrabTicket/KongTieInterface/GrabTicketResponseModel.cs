using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.GrabTicket.KongTieInterface
{
    /// <summary>
    /// 抢票接口同步响应信息
    /// </summary>
    public class GrabTicketResponseModel
    {
        /// <summary>
        /// 抢票订单号
        /// </summary>
        public string orderid { get; set; }
        /// <summary>
        /// 抢票下单是否成功
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 下单结果代码
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 下单结果信息
        /// </summary>
        public string msg { get; set; }
    }
}
