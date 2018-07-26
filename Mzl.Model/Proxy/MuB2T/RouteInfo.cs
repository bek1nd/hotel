using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 航程组合列表
    /// </summary>
    public class RouteInfo
    {
        /// <summary>
        /// 航程方向
        /// </summary>
        public string routeDirect { get; set; }
        /// <summary>
        /// 航程信息
        /// </summary>
        public string routeName { get; set; }
        /// <summary>
        /// 旅行日期
        /// </summary>
        public string travelDate { get; set; }
        /// <summary>
        /// 航班信息
        /// </summary>
        public string flightNo { get; set; }
        /// <summary>
        /// 舱位信息
        /// </summary>
        public string cabinName { get; set; }
    }
}
