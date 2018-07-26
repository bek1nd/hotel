using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Flight
{
    public class QueryFltModApplyListResponseViewModel
    {
        public int TotalCount { get; set; }
        /// <summary>
        /// 查询状态
        /// </summary>
        public List<SortedListViewModel> QueryOrderStatusList { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public List<FltModApplyListDataViewModel> ApplyDataList { get; set; }
    }
}
