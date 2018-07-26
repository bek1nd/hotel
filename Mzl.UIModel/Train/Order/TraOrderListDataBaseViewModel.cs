using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order
{
    public class TraOrderListDataBaseViewModel
    {
        /// <summary>
        /// 出行人
        /// </summary>
        public string PassengerNameListDesc { get; set; }
        /// <summary>
        /// 班次
        /// </summary>
        public string TrainNoListDesc { get; set; }
        /// <summary>
        /// 行程
        /// </summary>
        public string TravelListDesc { get; set; }
        /// <summary>
        /// 发车时间
        /// </summary>
        public string StartTimeListDesc { get; set; }
        public string OrderStatus { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        ///  审批单状态
        /// </summary>
        public int? AduitOrderStatus { get; set; }

        public string AuditStatus { get; set; }
    }
}
