using System.Collections.Generic;
using System.ComponentModel;

namespace Mzl.UIModel.Hotel.Elong.City
{
    public class QueryHotelCityResponseViewModel
    {
        [Description("国家集合")]
        public List<HotelCountryViewModel> CountryList { get; set; }
    }
}
