using Mzl.DomainModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Order
{
    public class TraOrderListQueryModel 
    {
        public DateTime? OrderBeginTime { get; set; }
        public DateTime? OrderEndTime { get; set; }
        public DateTime? TravelBeginTime { get; set; }
        public DateTime? TravelEndTime { get; set; }
        public int? OrderId { get; set; }
        /// <summary>
        /// 退票订单号
        /// </summary>
        public string RefundOrderId { get; set; }
        public string PassengerName { get; set; }
        public string CostCenter { get; set; }
        public int? ProjectId { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int? OrderStatus { get; set; }
        /// <summary>
        /// 订单状态 0为正单 2为退票
        /// </summary>
        public int OrderType { get; set; }
        /// <summary>
        /// 当前显示多少条
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 第几页
        /// </summary>
        public int PageIndex { get; set; }
        public int? Cid { get; set; }
        public string UserId { get; set; }
        public string CorpId { get; set; }
        /// <summary>
        /// 该请求是否来自App
        /// </summary>
        public bool IsFromApp { get; set; }
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
