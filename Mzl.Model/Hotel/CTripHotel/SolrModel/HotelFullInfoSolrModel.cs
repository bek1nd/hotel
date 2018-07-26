using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel.CTripHotel.SolrModel
{
    public class HotelFullInfoSolrModel
    {
        [SolrUniqueKey("id")]
        public string HotelId { get; set; }
        [SolrField("hotelname")]
        public string HotelName { get; set; }
        [SolrField("hotelenglishname")]
        public string HotelNameEN { get; set; }
        [SolrField("hotelcitycode")]
        public string HotelCityCode { get; set; }
        [SolrField("hotelcityname")]
        public string HotelCiteName { get; set; }
        [SolrField("hotelpostalcode")]
        public string HotelPostalCode { get; set; }
        [SolrField("hoteladdress")]
        public string HotelAddress { get; set; }
        [SolrField("hotelvalue")]
        public string HotelValue { get; set; }
    }
}
