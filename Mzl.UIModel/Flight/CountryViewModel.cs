using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class CountryViewModel
    {
        /// <summary>
        /// 国家名称
        /// </summary>
        public string CName { get; set; }
        /// <summary>
        /// 国家代码
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// 城市信息
        /// </summary>
        public List<CityViewModel> CityList { get; set; }
    }
}
