using System.Collections.Generic;
using System.ComponentModel;
using Mzl.Common.EnumHelper;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.MatchCorpPolicyAndAduit
{
    public class MatchCorpPolicyAndAduitRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 乘客Id
        /// </summary>
        [Description("乘客Id")]
        public List<int> PassengerCidList { get; set; }
        /// <summary>
        /// 订单类型 默认机票
        /// </summary>
        [Description("订单类型 默认机票")]
        public OrderSourceTypeEnum OrderType { get; set; } = OrderSourceTypeEnum.Flt;
    }
}
