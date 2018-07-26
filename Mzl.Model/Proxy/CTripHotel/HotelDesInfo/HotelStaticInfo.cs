using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo
{
    public class HotelStaticInfo
    {
        public GeoInfo GeoInfo { get; set; }
        public IList<NearbyPOI> NearbyPOIs { get; set; }
        public IList<TransportationInfo> TransportationInfos { get; set; }
        public Brand Brand { get; set; }
        public Group Group { get; set; }
        public IList<Rating> Ratings { get; set; }
        public IList<Policy> Policies { get; set; }
        public NormalizedPolicies NormalizedPolicies { get; set; }
        public IList<AcceptedCreditCard> AcceptedCreditCards { get; set; }
        public IList<ImportantNotice> ImportantNotices { get; set; }
        public IList<Facility> Facilities { get; set; }
        public IList<Picture> Pictures { get; set; }
        public IList<Description> Descriptions { get; set; }
        public IList<Theme> Themes { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public ArrivalTimeLimitInfo ArrivalTimeLimitInfo { get; set; }
        public DepartureTimeLimitInfo DepartureTimeLimitInfo { get; set; }
        public IList<HotelTag> HotelTags { get; set; }
        //public ExternalFacilities ExternalFacilities { get; set; }
        //public BossInfos BossInfos { get; set; }
        //public SellerShowInfos SellerShowInfos { get; set; }
        //public VideoItems VideoItems { get; set; }
        /// <summary>
        /// 酒店ID,确定酒店的唯一代码
        /// </summary>
        public int HotelId { get; set; }
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName { get; set; }
        /// <summary>
        /// 酒店英文名称
        /// </summary>
        public string HotelNameEN { get; set; }
        /// <summary>
        /// 酒店星级
        /// </summary>
        public double StarRating { get; set; }
        /// <summary>
        /// 标明星级是否有政府机构评定
        /// </summary>
        public bool IsOfficialRating { get; set; }
        /// <summary>
        /// 酒店开始运营的日期
        /// </summary>
        public string OpenYear { get; set; }
        /// <summary>
        /// 酒店最近装修的日期
        /// </summary>
        public string RenovationYear { get; set; }
        /// <summary>
        /// 酒店的客房数量
        /// </summary>
        public int RoomQuantity { get; set; }
        /// <summary>
        /// 是否是在线加盟酒店
        /// </summary>
        public bool IsOnlineSignUp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int MaintainerCode { get; set; }
        /// <summary>
        /// 定义酒店是否可定：T-是；F-否
        /// </summary>
        public string Bookable { get; set; }
    }
}
