using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class TimeLimitInfo
    {
        public IList<DateRestriction> DateRestrictions { get; set; }
        public IList<AvailableDayOfWeek> AvailableDayOfWeek { get; set; }
    }
}
