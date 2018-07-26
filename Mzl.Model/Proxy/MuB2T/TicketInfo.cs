using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 票号信息
    /// </summary>
    public class TicketInfo
    {
        /// <summary>
        /// 旅客序号
        /// </summary>
        public int? PassengerSq { get; set; }
        /// <summary>
        /// 旅客姓名
        /// </summary>
        public string PassengerName { get; set; }
        /// <summary>
        /// 客票票号
        /// </summary>
        public string TicketNo { get; set; }
    }
}
