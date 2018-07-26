using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo
{
    public class Rating
    {
        /// <summary>
        /// 评分类型
        /// 可能的值：CtripStarRate（携程推荐评分），CtripCommRate（携程用户总体评分）
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 酒店评分
        /// </summary>
        public double Value { get; set; }
    }
}
