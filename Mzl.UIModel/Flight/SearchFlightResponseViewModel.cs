using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class SearchFlightResponseViewModel
    {
        public List<SearchFlightViewModel> FlightList { get; set; }
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
