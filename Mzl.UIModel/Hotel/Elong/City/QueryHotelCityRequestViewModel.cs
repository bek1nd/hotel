using System.ComponentModel;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Hotel.Elong.City
{
    /// <summary>
    /// 查询酒店城市
    /// </summary>
    public class QueryHotelCityRequestViewModel: RequestBaseViewModel
    {
        /// <summary>
        /// 酒店城市查询类型 0艺龙国内 1艺龙国际
        /// </summary>
        [Description("酒店城市查询类型 0艺龙国内 1艺龙国际")]
        public int QueryCityType { get; set; }
    }
}
