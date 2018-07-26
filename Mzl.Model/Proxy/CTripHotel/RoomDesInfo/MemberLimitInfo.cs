using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class MemberLimitInfo
    {
        /// <summary>
        /// 基于会员身份的促销：
        /// 是否EDM专享
        /// </summary>
        public bool EDM { get; set; }
        /// <summary>
        /// 基于会员身份的促销：
        /// 是否普通会员专享
        /// </summary>
        public bool General { get; set; }
        /// <summary>
        /// 基于会员身份的促销：
        /// 是否黄金会员专享
        /// </summary>
        public bool Gold { get; set; }
        /// <summary>
        /// 基于会员身份的促销：
        /// 是否铂金会员专享
        /// </summary>
        public bool Platinum { get; set; }
        /// <summary>
        /// 基于会员身份的促销：
        /// 是否钻石会员专享
        /// </summary>
        public bool Diamond { get; set; }
        /// <summary>
        /// 基于会员身份的促销：
        ///是否微信会员专享
        /// </summary>
        public bool WeChat { get; set; }
    }
}
