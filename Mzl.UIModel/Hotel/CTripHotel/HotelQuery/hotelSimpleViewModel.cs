using Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Hotel.CTripHotel.HotelQuery
{
    public class HotelSimpleViewModel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelNameEN { get; set; }
        public double StarRating { get; set; }
        public int Price { get; set; }
        public GeoInfo GetInfo { get; set; }
        public IList<Facility> Facilities { get; set; }
        public IList<Rating> Ratings { get; set; }
        public IList<Picture> Pictures { get; set; }
        public IList<ImportantNotice> ImportantNotices { get; set; }
        public IList<TransportationInfo> TransportationInfos { get; set; }
    }
}
