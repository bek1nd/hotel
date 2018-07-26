using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 航段信息
    /// </summary>
    public class SegmentInfo
    {
        /// <summary>
        /// 航段序号
        /// </summary>
        public int? SegSq { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
        public string FlightNo { get; set; }
        /// <summary>
        /// 舱位
        /// </summary>
        public string Cabin { get; set; }
        /// <summary>
        /// 承运人
        /// </summary>
        public string Carrier { get; set; }
        /// <summary>
        /// 出发机场三字码
        /// </summary>
        public string DepCd { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public string DepDt { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        public string DepTm { get; set; }
        /// <summary>
        /// 到达机场三字码
        /// </summary>
        public string ArrCd { get; set; }
        /// <summary>
        /// 到达日期
        /// </summary>
        public string ArrDt { get; set; }
        /// <summary>
        /// 到达时间
        /// </summary>
        public string ArrTm { get; set; }
        /// <summary>
        /// 成人价格
        /// </summary>
        public string ADTPrice { get; set; }
        /// <summary>
        /// 儿童价格
        /// </summary>
        public string CHDPrice { get; set; }
    }
}
