using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class SearchCountryModel : CountryModel
    {
        public List<SearchCityModel> CityList { get; set; }
    }
}
