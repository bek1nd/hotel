using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class AirportViewModel
    {
        /// <summary>
        /// 机场名称
        /// </summary>
        public string AirportName { get; set; }
        /// <summary>
        /// 机场全名
        /// </summary>
        public string AirportLongName { get; set; }
        /// <summary>
        /// 机场英文名称
        /// </summary>
        public string AirportEnName { get; set; }
        /// <summary>
        /// 机场三字码
        /// </summary>
        public string AirportCode { get; set; }
    }
}
