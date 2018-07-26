using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.UIModel.Base
{
    /// <summary>
    /// 订单送票方式
    /// </summary>
    public class SendTicketViewModel
    {
        /// <summary>
        /// 送票方式
        /// </summary>
        public SendTicketTypeEnum SendTicketType { get; set; }
        /// <summary>
        /// 送票地址
        /// </summary>
        public string SendTicketAddress { get; set; }
        /// <summary>
        /// 送(取)票时间
        /// </summary>
        public DateTime? SendTicketTime { get; set; }
        /// <summary>
        /// 最晚送(取)票时间
        /// </summary>
        public DateTime? SendTicketLastTime { get; set; }
        /// <summary>
        /// 送票说明
        /// </summary>
        public string SendTicketRemark { get; set; }
    }
}
