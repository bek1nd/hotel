using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo
{
    public class Fee
    {
        public IList<RangeLimit> RangeLimit { get; set; }
        public IList<Amount> Amount { get; set; }
        public Percent Percent { get; set; }
        public MealInfo MealInfo { get; set; }
        /// <summary>
        /// 人数
        /// </summary>
        public int Occupancy { get; set; }
        /// <summary>
        /// 类型
        ///（Child：儿童；Adult：成人）
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 床类型
        ///1：加床；2：加婴儿床；3：加床/加婴儿床
        /// </summary>
        public string BedType { get; set; }
        /// <summary>
        /// 收费单位
        /// </summary>
        public string ChargeUnit { get; set; }
        /// <summary>
        /// 收费频率
        /// </summary>
        public string ChargeFrequency { get; set; }
        /// <summary>
        /// 是否免费
        /// </summary>
        public bool IsFree { get; set; }
        
    }
}
