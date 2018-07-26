using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.SearchHotelLowPrice
{
    public class CityCount
    {
        /// <summary>
        /// 城市ID
        /// </summary>
        public int City { get; set; }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 该参数的寓意受传参影响，具体如下：
        /// 若PageIndex为空、为0或不存在PageIndex节点，则CityNum代表该城市下所有符合请求条件的、存在最低价房型的酒店数；
        /// 若PageIndex>0，则CityNum代表当前页符合请求条件的、存在最低价房型的酒店数量；
        /// 备注：频繁修改请求体中的HotelCount会造成CityNum不准确，因存在一些缓存策略。
        /// </summary>
        public int CityNum { get; set; }
        /// <summary>
        /// 城市英文名
        /// </summary>
        public string CityEName { get; set; }
    }
}
