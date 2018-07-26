using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel.CTripHotel.SolrModel
{
    public class HotelSimpleInfoSolrModel
    {
        [SolrUniqueKey("id")]
        public int HotelId { get; set; }
        [SolrField("hotelname")]
        public string HotelName { get; set; }
        [SolrField("hotelnameen")]
        public string HotelNameEN { get; set; }
        [SolrField("hotelstarrating")]
        public double StarRating { get; set; }
        [SolrField("hotelprice")]
        public int Price { get; set; }
        [SolrField("hotelcitycode")]
        public string CityCode { get; set; }
        [SolrField("hotelcityname")]
        public string CityName { get; set; }
        [SolrField("hotelareacode")]
        public string AreaCode { get; set; }
        [SolrField("hotelareaname")]
        public string AreaName { get; set; }
        [SolrField("hotelpostalcode")]
        public string PostalCode { get; set; }
        [SolrField("hoteladdress")]
        public string Address { get; set; }
        [SolrField("hoteladjacentintersection")]
        public string AdjacentIntersection { get; set; }
        [SolrField("hotelgeoinfo")]
        public string GetInfo { get; set; }
        [SolrField("hotelratings")]
        public string Ratings { get; set; }
        [SolrField("hotelpictures")]
        public string Pictures { get; set; }
        [SolrField("hotelimportantnotices")]
        public string ImportantNotices{get;set;}
        [SolrField("hoteltransportationinfos")]
        public string TransportationInfos { get; set; }
      
    }
}
