using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 直达航班查询接口
    /// </summary>
    public class ZhiFlightSearchRequest
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
        /// 出发机场三字码
        /// </summary>
        public string DepCd { get; set; }
        /// <summary>
        /// 到达机场三字码
        /// </summary>
        public string ArrCd { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public string DepDt { get; set; }
    }
}
