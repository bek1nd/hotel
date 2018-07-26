using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDetailPrice
{
    public class CancelPolicyInfo
    {
        public IList<PenaltyAmount> PenaltyAmount { get; set; }
        /// <summary>
        /// 取消政策的生效时间。
        /// 备注：Start定义了最晚免费取消时间。Start时间之前，客人可免费取消；Start之后，客人需承担相应罚金。
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// 取消政策的失效时间
        /// </summary>
        public DateTime End { get; set; }
    }
}
