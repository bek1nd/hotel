using System.Collections.Generic;

namespace Mzl.DomainModel.Customer.MatchCorpPolicyAndAduit
{
    public class MatchCorpPolicyAndAduitModel
    {
        /// <summary>
        /// 乘客Id
        /// </summary>
        public List<int> PassengerCidList { get; set; }
        /// <summary>
        /// 预定人Id
        /// </summary>
        public int BookingCid { get; set; }
        /// <summary>
        /// 该公司是否允许购买保险 0不允许 1允许
        /// </summary>
        public int IsAllowUserInsurance { get; set; }
    }
}
