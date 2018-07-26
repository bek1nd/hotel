using System.Collections.Generic;
using System.ComponentModel;

namespace Mzl.UIModel.Hotel.Elong.City
{
    public class HotelCountryViewModel
    {
        /// <summary>
        /// 国家
        /// </summary>
        [Description("国家")]
        public string Country { get; set; }
        /// <summary>
        /// 城市集合
        /// </summary>
        [Description("城市集合")]
        public List<HotelCityViewModel> CityList { get; set; }
    }
}
