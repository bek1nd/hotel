using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class GetModApplyFlightViewModel
    {
        /// <summary>
        /// 航段序号
        /// </summary>
        public int Sequence { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
        public string FlightNo { get; set; }
        /// <summary>
        /// 出发机场三字码
        /// </summary>
        public string Dport { get; set; }
        /// <summary>
        /// 出发机场航站楼
        /// </summary>
        public string DportSon { get; set; }
        /// <summary>
        /// 抵达机场三字码
        /// </summary>
        public string Aport { get; set; }
        /// <summary>
        /// 抵达机场航站楼
        /// </summary>
        public string AportSon { get; set; }
        /// <summary>
        /// 出发机场名称
        /// </summary>
        public string DportName { get; set; }
        /// <summary>
        /// 出发城市
        /// </summary>
        public string DportCity { get; set; }
        /// <summary>
        /// 抵达机场名称
        /// </summary>
        public string AportName { get; set; }
        /// <summary>
        /// 抵达城市
        /// </summary>
        public string AportCity { get; set; }
        /// <summary>
        /// PNR编码
        /// </summary>
        public string RecordNo { get; set; }
        
        /// <summary>
        /// 出发日期
        /// </summary>
        public string TackOffDate { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        public string TackOffTimes { get; set; }
        public string TackOffWeek { get; set; }
        public string ArrivalsDate { get; set; }
        public string ArrivalsTimes { get; set; }
        /// <summary>
        /// 舱位
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 舱等
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 飞行时长
        /// </summary>
        public string FlightingTime { get; set; }
        /// <summary>
        /// 该航段允许改签的乘机人Id
        /// </summary>
        [Description("该航段允许改签的乘机人Id")]
        public List<int> AllowModPidList { get; set; }
    }
}
