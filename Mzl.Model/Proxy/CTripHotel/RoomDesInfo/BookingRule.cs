using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class BookingRule
    {
        public IList<BookingOffset> BookingOffsets { get; set; }
        public TotalOccupancy TotalOccupancy { get; set; }
        public IList<LengthOfStay> LengthOfStay { get; set; }
        public MemberLimitInfo MemberLimitInfo { get; set; }
        public Discount Discount { get; set; }
        public IList<TimeLimitInfo> TimeLimitInfo { get; set; }
    }
}
