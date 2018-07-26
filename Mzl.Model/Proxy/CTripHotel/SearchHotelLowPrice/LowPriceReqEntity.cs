using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.SearchHotelLowPrice
{
    public class LowPriceReqEntity
    {
        public SearchTypeEntity SearchTypeEntity { get; set; }
        public PublicSearchParameter PublicSearchParameter { get; set; }
        public FacilityEntity FacilityEntity { get; set; }
        public OrderBy OrderBy { get; set; }
    }
}
