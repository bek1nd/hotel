using Mzl.DomainModel.Hotel.CTrip.City;
using Mzl.Framework.Base;
using Mzl.UIModel.Hotel.CTrip.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.CTripHotel
{
    public interface IQueryCityCNApplication : IBaseApplication
    {
        CountryViewModel Query();
    }
}
