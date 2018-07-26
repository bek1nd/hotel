using System.Collections.Generic;

namespace Mzl.DomainModel.Hotel.Elong.City
{
    public class HotelCountryModel
    {
        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public List<HotelCityModel> CityList { get; set; }
    }
}
