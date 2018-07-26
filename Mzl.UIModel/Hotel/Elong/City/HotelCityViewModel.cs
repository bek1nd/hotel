using System.Collections.Generic;
using System.ComponentModel;

namespace Mzl.UIModel.Hotel.Elong.City
{
    /// <summary>
    /// 城市信息
    /// </summary>
    public class HotelCityViewModel
    {
        /// <summary>
        /// 省份编号
        /// </summary>
        [Description("省份编号")]
        public string ProvinceId { get; set; }
        /// <summary>
        /// 省份名称
        /// </summary>
        [Description("省份名称")]
        public string ProvinceName { get; set; }
        /// <summary>
        /// 城市编码
        /// </summary>
        [Description("城市编码")]
        public string CityCode { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        [Description("城市名称")]
        public string CityName { get; set; }
        /// <summary>
        /// 行政区信息列表
        /// </summary>
        [Description("行政区信息列表")]
        public List<HotelDistrictViewModel> DistrictList { get; set; }
        /// <summary>
        /// 商业区信息列表
        /// </summary>
        [Description("商业区信息列表")]
        public List<HolelCommericalLocationViewModel> CommericalLocationList { get; set; }
        /// <summary>
        /// 标志物信息列表
        /// </summary>
        [Description("标志物信息列表")]
        public List<HotelLandmarkLocationViewModel> LandmarkLocationList { get; set; }
    }
}
