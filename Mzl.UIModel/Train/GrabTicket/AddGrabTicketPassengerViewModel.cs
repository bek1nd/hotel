using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.UIModel.Train.GrabTicket
{
    public class AddGrabTicketPassengerViewModel
    {
        /// <summary>
        /// 乘客姓名
        /// </summary>
        [Required]
        public string PassengerName { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [Required]
        public string CardNo { get; set; }
        /// <summary>
        /// 证件类型id
        /// </summary>
        public CardTypeEnum CardType { get; set; }
        /// <summary>
        /// 票种
        /// </summary>
        public AgeTypeEnum TicketType { get; set; }
        /// <summary>
        /// 联系人Id
        /// </summary>
        public int ContactId { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }
    }
}
