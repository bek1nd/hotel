using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class GetModApplyModel
    {
        public int Cid { get; set; }
        public string CName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// 航程信息
        /// </summary>
        public List<FltFlightModel> FlightList { get; set; }
        /// <summary>
        /// 乘机人信息
        /// </summary>
        public List<FltPassengerModel> PassengerList { get; set; }
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
