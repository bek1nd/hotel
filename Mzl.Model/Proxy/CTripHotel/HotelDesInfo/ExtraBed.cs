using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo
{
    public class ExtraBed
    {
        public RangeLimit RangeLimit { get; set; }
        public IList<LimitInfo> LimitInfo { get; set; }
        public IList<Fee> Fees { get; set; }

        /// <summary>
        /// 最多允许的加床数量
        /// </summary>
        public int MaxQuantity { get; set; }
        /// <summary>
        /// 加床类型
        ///1：加床；2：加婴儿床；3：加床/加婴儿床
        /// </summary>
        public string ExtraBedType { get; set; }
        /// <summary>
        /// 最大加婴儿床数量
        /// </summary>
        public int MaxCribQuantity { get; set; }
    }
}
