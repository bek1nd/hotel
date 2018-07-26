using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.SearchHotelLowPrice
{
    public class OrderBy
    {
        /// <summary>
        /// 排序规则的名称。
        /// MinPrice-按起价排序；
        /// </summary>
        public string OrderName { get; set; }
        /// <summary>
        /// DESC-倒序；
        /// ASC-顺序；
        /// </summary>
        public string OrderType { get; set; }
    }
}
