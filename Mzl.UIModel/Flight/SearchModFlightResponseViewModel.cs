using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class SearchModFlightResponseViewModel
    {
        /// <summary>
        /// 改签航班信息
        /// </summary>
        [Description("改签航班信息")]
        public List<SearchModFlightViewModel> FlightList { get; set; }
        public List<string> AirlineQuery { get; set; }
        public List<string> ClassQuery { get; set; }
        public List<string> DportNameQuery { get; set; }
        public List<string> AportNameQuery { get; set; }
        public List<string> TackOffTimeQuery { get; set; }
        /// <summary>
        /// 违规原因
        /// </summary>
        public List<string> PolicyReason { get; set; }
    }
}
