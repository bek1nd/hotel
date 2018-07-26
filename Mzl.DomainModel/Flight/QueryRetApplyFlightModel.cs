using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class QueryRetApplyFlightModel
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
        /// 抵达机场名称
        /// </summary>
        public string AportName { get; set; }
        /// <summary>
        /// PNR编码
        /// </summary>
        public string RecordNo { get; set; }
        /// <summary>
        /// 核价的价格
        /// </summary>
        public decimal AuditPrice { get; set; }
        /// <summary>
        /// 违规信息
        /// </summary>
        public string PolicyDesc { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public string TackOffDate { get; set; }

        public string ArrivalsDate { get; set; }

        /// <summary>
        /// 舱位
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 舱等
        /// </summary>
        public string ClassName { get; set; }
        
    }
}
