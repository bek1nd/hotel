using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel
{
    public class HotelIdListResponseEntity
    {
        /// <summary>
        /// 请求状态
        /// </summary>
        public ResponseStatusEntity ResponseStatus { get; set; }

        /// <summary>
        /// 酒店ID拼接字符串,以逗号分隔
        /// </summary>
        public string HotelIDs { get; set; }

        /// <summary>
        /// 酒店ID总数
        /// </summary>
        public int Total { get; set; }
    }
}
