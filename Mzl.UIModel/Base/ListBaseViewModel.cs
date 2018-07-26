using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Base
{
    public class ListBaseViewModel<T> where T : class
    {
        /// <summary>
        /// 列表数据
        /// </summary>
        public T ListData { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }
    }
}
