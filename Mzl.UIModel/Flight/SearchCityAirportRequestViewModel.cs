using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class SearchCityAirportRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 国内/国际
        /// </summary>
        public string IsInter { get; set; }
    }
}
