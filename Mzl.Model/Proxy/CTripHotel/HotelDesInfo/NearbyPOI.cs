using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo
{
    public class NearbyPOI
    {
        /// <summary>
        /// 附近地标名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 附近地标类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 酒店与附近地标的距离
        /// </summary>
        public string Distance { get; set; }
    }
}
