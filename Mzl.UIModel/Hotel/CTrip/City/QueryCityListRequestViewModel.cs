using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Hotel.CTrip.City
{
    public class QueryCityListRequestViewModel : RequestBaseViewModel
    {
        public string CityName { get; set; }
        public string ProvinceName { get; set; }
        public string CountryName { get; set; }
    }
}
