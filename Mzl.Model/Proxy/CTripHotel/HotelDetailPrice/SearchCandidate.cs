using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDetailPrice
{
    public class SearchCandidate
    {
        public int HotelID { get; set; }
        public DateRange DateRange { get; set; }
        public Occupancy Occupancy { get; set; }
    }
}
