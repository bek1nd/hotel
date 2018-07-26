using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo
{
    public class ExistingBed
    {
        public IList<LimitInfo> LimitInfo { get; set; }
        public IList<Fee> Fees { get; set; }
        /// <summary>
        /// 最多共用现有床位的儿童数
        /// </summary>
        public int MaxOccupancy { get; set; }
    }
}
