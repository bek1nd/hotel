using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 中转所选航班信息
    /// </summary>
    public class TransferFlightInfo
    {        
        /// <summary>
        /// 航班序号
        /// </summary>
        public int? flightIndex { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
        public string flightNo { get; set; }
        /// <summary>
        /// 实际承运人
        /// </summary>
        public string carrier { get; set; }
        /// <summary>
        /// 舱位
        /// </summary>
        public string cabin { get; set; }
        /// <summary>
        /// 出发机场
        /// </summary>
        public string depCd { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        public string depTm { get; set; }
        /// <summary>
        /// 到达机场
        /// </summary>
        public string arrCd { get; set; }
        /// <summary>
        /// 到达时间
        /// </summary>
        public string arrTm { get; set; }
        /// <summary>
        /// 航司号
        /// </summary>
        public string carrierCd
        {
            get { return this.flightNo.Substring(0, 2); }
        }
    }
}
