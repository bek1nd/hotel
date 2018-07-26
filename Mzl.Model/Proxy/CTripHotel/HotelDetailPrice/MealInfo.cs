using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDetailPrice
{
    public class MealInfo
    {
        /// <summary>
        /// 早餐数量
        /// </summary>
        public int NumberOfBreakfast { get; set; }
        /// <summary>
        /// 午餐数量
        /// </summary>
        public int NumberOfLunch { get; set; }
        /// <summary>
        /// 晚餐数量
        /// </summary>
        public int NumberOfDinner { get; set; }
    }
}
