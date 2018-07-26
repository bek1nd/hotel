using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 直达航班信息
    /// </summary>
    public class ZhiFlightInfo
    {
        /// <summary>
        /// 航司代码
        /// </summary>
        public string AirlineCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CarrierNo { get; set; }
        /// <summary>
        /// 出发航站楼
        /// </summary>
        public string DepTerm { get; set; }
        /// <summary>
        /// 到达航站楼
        /// </summary>
        public string ArrTerm { get; set; }
        /// <summary>
        /// 出发机场码
        /// </summary>
        public string OrgCode { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public string OrgDate { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        public string OrgTime { get; set; }
        /// <summary>
        /// 到达机场码
        /// </summary>
        public string DesCode { get; set; }
        /// <summary>
        /// 到达日期
        /// </summary>
        public string DesDate { get; set; }
        /// <summary>
        /// 到达时间
        /// </summary>
        public string DesTime { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
        public string FlightNo { get; set; }
        /// <summary>
        /// 飞行时间
        /// </summary>
        public long? FlightSpanTime { get; set; }
        /// <summary>
        /// 是否
        /// </summary>
        public string IsAsr { get; set; }
        /// <summary>
        /// 是否代码共享航班
        /// </summary>
        public string IsCodeShare { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IsEticket { get; set; }
        /// <summary>
        /// 是否有餐食
        /// </summary>
        public string IsMeal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MealCode { get; set; }
        /// <summary>
        /// 机型
        /// </summary>
        public string PlaneType { get; set; }
        /// <summary>
        /// 经停
        /// </summary>
        public string Stop { get; set; }
        /// <summary>
        /// 航段类型
        /// </summary>
        public string SegTp { get; set; }
        /// <summary>
        /// 舱位信息
        /// </summary>
        public List<CabinInfo> CabinInfoModel { get; set; }
    }
}
