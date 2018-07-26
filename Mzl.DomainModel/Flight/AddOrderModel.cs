using Mzl.DomainModel.Customer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class AddOrderModel : FltOrderModel
    {
        /// <summary>
        /// 行程信息
        /// </summary>
        public List<FltFlightModel> FlightList { get; set; }
        /// <summary>
        /// 乘客信息
        /// </summary>
        public List<FltPassengerModel> PassengerList { get; set; }
        /// <summary>
        /// 客户信息
        /// </summary>
        public CustomerModel Customer { get; set; }
        /// <summary>
        /// 乘客对应的客户信息
        /// </summary>
        public List<CorpPassengerCustomerModel> PassengerCustomerList { get; set; }
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
        /// <summary>
        /// 是否对相同行程做验证
        /// </summary>
        public bool IsCheckSameFlight { get; set; }

        /// <summary>
        /// 是否检查未使用票号
        /// </summary>
        public bool IsCheckUnUsedTicketNo { get; set; } 
    }
}
