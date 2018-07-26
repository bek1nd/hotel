using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo
{
    public class FacilityItem
    {
        /// <summary>
        /// 设施ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 酒店设施名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 设施可用性:
        /// 可能的值：0-不确定；1-所有房间；2-部分房间
        /// </summary>
        public string Status { get; set; }
    }
}
