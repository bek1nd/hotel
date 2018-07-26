using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 航班刷新接口输入
    /// </summary>
    public class FlightRefreshRequest
    {
        /// <summary>
        /// B2T用户名
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>
        public string AgentName { get; set; }
        /// <summary>
        /// 航段信息
        /// </summary>
        public List<SegmentInfo> SegmentInfo { get; set; }
    }
}
