using System.ComponentModel;

namespace Mzl.UIModel.Hotel.Elong.City
{
    /// <summary>
    /// 城市商业区信息
    /// </summary>
    public class HolelCommericalLocationViewModel
    {
        [Description("Id")]
        public string Id { get; set; }
        [Description("名称")]
        public string Name { get; set; }
    }
}
