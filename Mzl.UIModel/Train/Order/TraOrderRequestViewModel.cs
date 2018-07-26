using Mzl.Common.EnumHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order
{
    /// <summary>
    /// 请求api实体
    /// </summary>
    public class TraOrderRequestViewModel
    {
        /// <summary>
        /// 预定部门Id
        /// </summary>
        public int? DepartId { get; set; }
        /// <summary>
        /// 订单Id
        /// </summary>
        public int? OrderId { get; set; }
        /// <summary>
        /// 火车改签订单Id
        /// </summary>
        public int? CorderId { get; set; }
        /// <summary>
        /// 该请求是否来自App
        /// </summary>
        public bool IsFromApp { get; set; }
        /// <summary>
        /// 原订单面价
        /// </summary>
        public List<decimal> FacePriceList { get; set; }
        /// <summary>
        /// 改签面价
        /// </summary>
        public decimal? ModFacePrice { get; set; }
        /// <summary>
        /// 改签订单出发日期
        /// </summary>
        public DateTime? ModStartTime { get; set; }
        /// <summary>
        /// 改签前的出发日期
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 请求类型
        /// </summary>
        public string RequestType { get; set; } = OrderSourceTypeEnum.Tra.ToString();
        /// <summary>
        /// 搜索条件
        /// </summary>
        public string SearchArgs { get; set; }
        /// <summary>
        /// 12306订单格式字符串
        /// </summary>
        public string AnalysisArgs { get; set; }
        /// <summary>
        /// 是否抢票
        /// </summary>
        public bool IsGrabTicket { get; set; }
    }
}
