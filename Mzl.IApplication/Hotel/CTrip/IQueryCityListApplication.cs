using Mzl.UIModel.Hotel.CTrip.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.Hotel.CTrip
{
    public interface IQueryCityListApplication
    {
        CountryViewModel QueryCityList();
    }
}
