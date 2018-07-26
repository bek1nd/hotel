using Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel
{
    public class HotelDesInfoResEntity
    {
        public ResponseStatusEntity ResponseStatus { get; set; }
        public HotelStaticInfo HotelStaticInfo { get; set; }
    }
}
