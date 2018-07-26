using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class QueryFltOrderListResponseViewModel
    {
        /// <summary>
        /// 总数
        /// </summary>
        [Description("总数")]
        public int TotalCount { get; set; }
        /// <summary>
        /// 订单查询状态
        /// </summary>
        [Description("订单查询状态")]
        public List<SortedListViewModel> QueryOrderStatusList { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        [Description("返回数据")]
        public List<FltOrderListDataViewModel> OrderDataList { get; set; }

    }
}
