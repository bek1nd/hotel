using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class SearchModFlightViewModel : SearchFlightViewModel
    {
        /// <summary>
        /// 是否原航司
        /// </summary>
        [Description("是否原航司")]
        public bool IsOriginalAirlineNo { get; set; }
    }
}
