using System.Collections.Generic;
using System.ComponentModel;

namespace Mzl.UIModel.Hotel.Elong.HotelInfo
{
    public class QueryHotelInfoResponseViewModel
    {
        [Description("酒店结果集")]
        public List<HotelInfoResultViewModel> Hotels { get; set; }
    }
}
