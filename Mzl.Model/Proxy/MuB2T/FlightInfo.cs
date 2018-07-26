using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 航班组合详情
    /// </summary>
    public class FlightInfo
    {
        #region 中转查询参数
        /// <summary>
        /// 航班序号
        /// </summary>
        public int? segSq { get; set; }
        /// <summary>
        /// 实际承运人
        /// </summary>
        public string carrierCd { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
        public string flightNo { get; set; }
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
        /// 出发航站楼
        /// </summary>
        public string depTerm { get; set; }
        /// <summary>
        /// 到达机场
        /// </summary>
        public string arrCd { get; set; }
        /// <summary>
        /// 到达时间
        /// </summary>
        public string arrTm { get; set; }
        /// <summary>
        /// 到达航站楼
        /// </summary>
        public string arrTerm { get; set; }
        /// <summary>
        /// 机型
        /// </summary>
        public string planeTp { get; set; }
        /// <summary>
        /// FB
        /// </summary>
        public string fareBasis { get; set; }
        /// <summary>
        /// 行李额
        /// </summary>
        public string baggageWeight { get; set; }
        /// <summary>
        /// 是否经停
        /// </summary>
        public string stopFlag { get; set; }
        /// <summary>
        /// 经停机场
        /// </summary>
        public string stopEng { get; set; }
        /// <summary>
        /// 经停时长
        /// </summary>
        public string stopTime { get; set; }
        /// <summary>
        /// 成人单段价格
        /// </summary>
        public string segPriceAdt { get; set; }
        /// <summary>
        /// 儿童单段价格
        /// </summary>
        public string segPriceChd { get; set; }
        /// <summary>
        /// 成人退改签规则
        /// </summary>
        public List<SegRpu> segRpuAdtList;
        /// <summary>
        /// 儿童退改签规则
        /// </summary>
        public List<SegRpu> segRpuChdList;
        #endregion

        #region  中转预定参数
        /// <summary>
        /// 航班序号
        /// </summary>
        public int? flightIndex { get; set; }       
        /// <summary>
        /// 实际承运人
        /// </summary>
        public string carrier { get; set; }                                  
        #endregion
    }
}
