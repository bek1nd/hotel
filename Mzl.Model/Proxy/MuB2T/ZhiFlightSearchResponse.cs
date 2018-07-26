using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 直达航班查询接口输出
    /// </summary>
    public class ZhiFlightSearchResponse
    {
        /// <summary>
        /// 返回结果代码
        /// </summary>
        public string MsgType { get; set; }
        /// <summary>
        /// 返回结果描述
        /// </summary>
        public string MsgDesc { get; set; }
        /// <summary>
        /// 出发机场三字码
        /// </summary>
        public string DepCd { get; set; }
        /// <summary>
        /// 到达机场三字码
        /// </summary>
        public string ArrCd { get; set; }
        /// <summary>
        /// 航班信息
        /// </summary>
        public List<ZhiFlightInfo> ZhiFlightInfo { get; set; }
    }
}
