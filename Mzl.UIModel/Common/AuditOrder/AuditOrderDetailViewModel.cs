using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.UIModel.Common.AuditOrder
{
    public class AuditOrderDetailViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        /// <summary>
        /// 订单号描述
        /// </summary>
        public string OrderIdDes { get; set; }
        public OrderSourceTypeEnum OrderType { get; set; }
        public string OrderTypeDesc => OrderType.ToDescription();
        public decimal OrderAmount { get; set; }
        public List<string> PassengerNameList { get; set; }
        public List<string> TravelList { get; set; }
        public List<string> TackOffTimeList { get; set; }
        /// <summary>
        /// 违反差旅政策信息
        /// </summary>
        public string CorpPolicy { get; set; }
        /// <summary>
        /// 选择违反原因
        /// </summary>
        public string ChoiceReason { get; set; }
    }
}
