using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.GrabTicket
{
    public class TraGrabTicketListDataPassengerViewModel
    {
        /// <summary>
        /// 乘客姓名
        /// </summary>
        public string PassengerName { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CardNo { get; set; }
        public string CardTypeName { get; set; }
        public string Mobile { get; set; }

        public int ContactId { get; set; }
    }
}
