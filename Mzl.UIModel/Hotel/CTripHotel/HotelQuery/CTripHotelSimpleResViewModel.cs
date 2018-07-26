using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Hotel.CTripHotel.HotelQuery
{
    public class CTripHotelSimpleResViewModel
    {
        public IList<HotelSimpleViewModel> Hotels { get; set; }
        public int Count { get; set; }
    }
}
