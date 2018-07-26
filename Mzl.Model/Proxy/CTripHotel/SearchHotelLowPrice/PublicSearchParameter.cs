using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.SearchHotelLowPrice
{
    public class PublicSearchParameter
    {
        public int City { get; set; }
        public string HotelList { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public bool OnlyPPPrice { get; set; }
        public bool OnlyFGPrice { get; set; }
        public string FilterRoomByPerson { get; set; }
        public string IsJustifyConfirm { get; set; }
        public string Plottype { get; set; }
    }
}
