using Mzl.EntityModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Train.Order
{
    public class TraOrderListQueryEntity : BaseOrderListQueryEntity
    {
        public DateTime? OrderBeginTime { get; set; }
        public DateTime? OrderEndTime { get; set; }
        public DateTime? TravelBeginTime { get; set; }
        public DateTime? TravelEndTime { get; set; }
        public int? OrderId { get; set; }
        public string PassengerName { get; set; }
        public string CostCenter { get; set; }
        public int? ProjectId { get; set; }
        public int? OrderStatus { get; set; }
        public int OrderType { get; set; }
        public string RefundOrderId { get; set; }
        public DateTime? AllowShowDataBeginTime { get; set; }
        /// <summary>
        /// 是否显示全部订单 用于公司订单的显示
        /// </summary>
        public int? IsShowAllOrder { get; set; }

        /// <summary>
        /// 是否是导出操作
        /// </summary>
        public int? IsExport { get; set; }
    }
}
