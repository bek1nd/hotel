using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class FltModFlightViewModel
    {
        public int Id { get; set; }

        public int Sequence { get; set; }

        public string FlightNo { get; set; }

        public string Class { get; set; }

        public DateTime? TackoffTime { get; set; }

        public DateTime? ArrivalsTime { get; set; }

        public string Dport { get; set; }
        public string DportName { get; set; }
        public string DportCity { get; set; }

        public string Aport { get; set; }
        public string AportName { get; set; }
        public string AportCity { get; set; }

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
        /// 舱等
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 飞行时长
        /// </summary>
        public string FlightingTime { get; set; }
    }
}
