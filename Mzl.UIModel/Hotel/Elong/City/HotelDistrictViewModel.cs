using System.ComponentModel;

namespace Mzl.UIModel.Hotel.Elong.City
{
    /// <summary>
    /// 行政区
    /// </summary>
    public class HotelDistrictViewModel
    {
        [Description("Id")]
        public string Id { get; set; }
        [Description("名称")]
        public string Name { get; set; }
    }
}
