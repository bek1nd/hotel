using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class QueryRetApplyPassengerModel
    {
        /// <summary>
        /// 乘机人Id
        /// </summary>
        public int Pid { get; set; }
        /// <summary>
        /// 乘机人名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 证件号
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string CardTypeDesc { get; set; }
        /// <summary>
        /// 退票票号
        /// </summary>
        public string RefundTicketNo { get; set; }
        /// <summary>
        /// 退票行程
        /// </summary>
        public List<QueryRetApplyFlightModel> RefundFlightList { get; set; }
    }
}
