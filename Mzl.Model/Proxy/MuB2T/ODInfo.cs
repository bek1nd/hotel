using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 航班信息
    /// </summary>
    public class ODInfo
    {
        /// <summary>
        /// 航段序号
        /// </summary>
        public int? odSq { get; set; }
        /// <summary>
        /// 出发机场三字码
        /// </summary>
        public string odDepCd { get; set; }
        /// <summary>
        /// 到达机场三字码
        /// </summary>
        public string odArrCd { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public string odDepDt { get; set; }
        /// <summary>
        /// 返程日期
        /// </summary>
        public string odRetDt { get; set; }
        /// <summary>
        /// 价格（成人）
        /// </summary>
        public float? price { get; set; }
        /// <summary>
        /// 价格（儿童）
        /// </summary>
        public float? chdPrice { get; set; }
        /// <summary>
        /// 所选航班信息
        /// </summary>
        public List<TransferFlightInfo> FlightInfo{ get; set; }
    }
}
