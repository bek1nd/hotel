using System.Collections.Generic;

namespace Mzl.DomainModel.Hotel.Elong.City
{
    public class HotelCityModel
    {
        /// <summary>
        /// 省份编号
        /// </summary>
        public string ProvinceId { get; set; }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// 城市编码
        /// </summary>
        public string CityCode { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 行政区信息列表
        /// </summary>
        public List<HotelDistrictModel> DistrictList { get; set; }
        /// <summary>
        /// 商业区信息列表
        /// </summary>
        public List<HolelCommericalLocationModel> CommericalLocationList { get; set; }
        /// <summary>
        /// 标志物信息列表
        /// </summary>
        public List<HotelLandmarkLocationModel> LandmarkLocationList { get; set; }
    }
}
