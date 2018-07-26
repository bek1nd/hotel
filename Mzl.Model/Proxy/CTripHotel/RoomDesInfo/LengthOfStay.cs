using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class LengthOfStay
    {
        /// <summary>
        /// 连续入住时长促销：
        /// Max-最大连住时长；
        /// Min-最小连住时长；
        /// </summary>
        public string MinMaxType { get; set; }
        /// <summary>
        /// 连续入住的时长数值
        /// </summary>
        public int Time { get; set; }
        /// <summary>
        /// 时长数值的单位：
        /// Year-年；
        /// Month-月；
        /// Week-周；
        /// Day-天(默认)；
        /// Hour-小时；
        /// Minute-分钟；
        /// Second-秒数；
        /// </summary>
        public string TimeUnit { get; set; }
        /// <summary>
        /// 实际入住时长为预设入住时长的倍数时，是否也可享受该促销优惠：True-是；False-否 (默认)。
        /// </summary>
        public bool MustBeMultiple { get; set; }
    }
}
