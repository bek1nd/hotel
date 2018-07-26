using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 中转航班查询接口
    /// </summary>
    public class FlightSearchRequest
    {
        /// <summary>
        /// 出发机场三字码
        /// </summary>
        public string depCd { get; set; }
        /// <summary>
        /// 到达机场三字码
        /// </summary>
        public string arrCd { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public string depDt { get; set; }
        /// <summary>
        /// 返程日期
        /// </summary>
        public string retDt { get; set; }
        /// <summary>
        /// 人数
        /// </summary>
        public int? passNum { get; set; }
        /// <summary>
        /// 舱等
        /// </summary>
        public string cabin { get; set; }
        /// <summary>
        /// B2T登录名
        /// </summary>
        public string account { get; set; }
        /// <summary>
        /// 航班类型
        /// </summary>
        public string flightTp { get; set; }
        /// <summary>
        /// 行程类型
        /// </summary>
        public string routeTp { get; set; }
    }
}
