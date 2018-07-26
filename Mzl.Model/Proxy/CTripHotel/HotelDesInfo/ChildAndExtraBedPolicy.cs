using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo
{
    public class ChildAndExtraBedPolicy
    {
        public ExistingBed ExistingBed { get; set; }
        public ExtraBed ExtraBed { get; set; }
        public IList<Description> Descriptions { get; set; }
        /// <summary>
        /// 是否可携带儿童入住
        /// </summary>
        public bool AllowChildrenToStay { get; set; }
        /// <summary>
        /// 儿童是否可使用现有床位
        /// </summary>
        public bool AllowUseExistngBed { get; set; }
        /// <summary>
        /// 是否提供加床
        /// </summary>
        public bool AllowExtrabed { get; set; }
        /// <summary>
        /// 是否提供加婴儿床
        /// </summary>
        public bool AllowExtraCrib { get; set; }
    }
}
