using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class CityViewModel
    {
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 城市英文名称
        /// </summary>
        public string CityEnName { get; set; }
        /// <summary>
        /// 城市三字码
        /// </summary>
        public string CityCode { get; set; }
        /// <summary>
        /// 城市拼音
        /// </summary>
        public string PinYin { get; set; }
        /// <summary>
        /// 城市首字母
        /// </summary>
        public string CityHead
        {
            get { return string.IsNullOrEmpty(PinYin) ? "" : this.PinYin.Substring(0, 1); }
        }
        /// <summary>
        /// 国内N，国际I
        /// </summary>
        public string IsInter { get; set; }
        /// <summary>
        /// 机场信息
        /// </summary>
        public List<AirportViewModel> AirportList { get; set; }

    }
}
