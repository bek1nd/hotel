using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel.CTripHotel.SolrModel
{
    public class KeyWordHotel
    {

        [SolrUniqueKey("id")]
        public int HotelId { get; set; }
        [SolrField("hotelname")]
        public string HotelName { get; set; }
        [SolrField("cityname")]
        public string CityName { get; set; }
        [SolrField("citycode")]
        public string CityCode { get; set; }
        [SolrField("areaname")]
        public string AreaName { get; set; }
        [SolrField("areacode")]
        public string AreaCode { get; set; }
        [SolrField("businessdistrict")]
        public string BusinessDistrict { get; set; }
        [SolrField("hotelbrandname")]
        public string HotelBrandName { get; set; }
        [SolrField("hotelbrandcode")]
        public string HotelBrandCode { get; set; }
    }
}
