using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.ChangeInfo
{
    public class SearchCandidate
    {
        /// <summary>
        /// 定义静态信息发生变化的起始时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 从起始时间开始，查询多少时间内的静态信息增量。取值范围0到600，600表示10分钟。取值为0时，等价于600
        /// </summary>
        public int Duration { get; set; }
    }
}
