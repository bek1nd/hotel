using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class GetModApplyResponseViewModel
    {
        public string CName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// 航程信息
        /// </summary>
        public List<GetModApplyFlightViewModel> FlightList { get; set; }
        /// <summary>
        /// 乘机人信息
        /// </summary>
        public List<GetModApplyPassengerViewModel> PassengerList  { get; set; }
        /// <summary>
        /// 差旅政策Id
        /// </summary>
        [Description("差旅政策Id")]
        public int? CorpPolicyId { get; set; }
        /// <summary>
        /// 差旅审批规则Id
        /// </summary>
        [Description("差旅审批规则Id")]
        public int? CorpAduitId { get; set; }
    }
}
