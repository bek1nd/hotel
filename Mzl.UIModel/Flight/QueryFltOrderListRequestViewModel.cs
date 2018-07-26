using Mzl.Common.EnumHelper;
using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    /// <summary>
    /// 查询机票订单列表
    /// </summary>
    public class QueryFltOrderListRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号")]
        public int? OrderId { get; set; }
        /// <summary>
        /// 起飞开始日期
        /// </summary>
        [Description("起飞开始日期")]
        public DateTime? TackOffBeginTime { get; set; }
        /// <summary>
        /// 起飞结束日期
        /// </summary>
        [Description("起飞结束日期")]
        public DateTime? TackOffEndTime { get; set; }
        /// <summary>
        /// 乘机人名称
        /// </summary>
        [Description("乘机人名称")]
        public string PassengerName { get; set; }
        /// <summary>
        /// 订单开始日期
        /// </summary>
        [Description("订单开始日期")]
        public DateTime? OrderBeginTime { get; set; }
        /// <summary>
        /// 订单结束日期
        /// </summary>
        [Description("订单结束日期")]
        public DateTime? OrderEndTime { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        [Description("订单状态")]
        public FltOrderListOrderStatusEnum? OrderStatus { get; set; }
        /// <summary>
        /// 当前显示多少条
        /// </summary>
        [Description("当前显示多少条")]
        public int PageSize { get; set; }
        /// <summary>
        /// 第几页
        /// </summary>
        [Description("第几页")]
        public int PageIndex { get; set; }
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
