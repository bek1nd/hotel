using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelList
{
    public class HotelIdListResEntity
    {
        public ResponseStatusEntity ResponseStatus { get; set; }
        public string HotelIDs { get; set; }
        public int Total { get; set; }
    }
}
