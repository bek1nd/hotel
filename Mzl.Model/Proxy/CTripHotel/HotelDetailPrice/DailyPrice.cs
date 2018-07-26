using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDetailPrice
{
    public class DailyPrice
    {
        public MealInfo MealInfo { get; set; }
        public IList<Price> Prices { get; set; }
        public List<Cashback> Cashbacks { get; set; }
        /// <summary>
        /// 每日价的生效日期
        /// </summary>
        public DateTime EffectiveDate { get; set; }
        /// <summary>
        /// 担保政策代码。
        /// 备注：参考CodeList，查看担保政策枚举值。
        /// </summary>
        public string GuaranteeCode { get; set;}
    }
}
