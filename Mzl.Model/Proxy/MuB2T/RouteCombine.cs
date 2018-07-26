using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 输出列表
    /// </summary>
    public class RouteCombine
    {
        /// <summary>
        /// 航班号
        /// </summary>
        public string flightNo { get; set; }
        /// <summary>
        /// 价格列表
        /// </summary>
        public List<OdFareInfo> odFareInfoList { get; set; }
    }
}
