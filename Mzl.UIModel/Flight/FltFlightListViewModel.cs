using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class FltFlightListViewModel
    {
        /// <summary>
        /// 出发机场
        /// </summary>
        [Description("出发机场")]
        public string DportName { get; set; }
        /// <summary>
        /// 出发城市
        /// </summary>
        [Description("出发城市")]
        public string DportCity { get; set; }
        /// <summary>
        /// 到达机场
        /// </summary>
        [Description("到达机场")]
        public string AportName { get; set; }
        /// <summary>
        /// 到达城市
        /// </summary>
        [Description("到达城市")]
        public string AportCity { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
        [Description("航班号")]
        public string FlightNo { get; set; }
        /// <summary>
        /// 起飞日期
        /// </summary>
        [Description("起飞日期")]
        public DateTime TackOffTime { get; set; }
    }
}
