using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Hotel.CTrip.City
{
    public class HotelCountryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public List<HotelProvinceViewModel> Provinces { get; set; }
    }
}
