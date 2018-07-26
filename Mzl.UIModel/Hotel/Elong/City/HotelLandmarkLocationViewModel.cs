using System.ComponentModel;

namespace Mzl.UIModel.Hotel.Elong.City
{
    /// <summary>
    /// 标志物信息
    /// </summary>
    public class HotelLandmarkLocationViewModel
    {
        [Description("Id")]
        public string Id { get; set; }
        [Description("名称")]
        public string Name { get; set; }
    }
}
