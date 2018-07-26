using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class FacilityItem
    {
        /// <summary>
        /// 设施ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 设施名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 定义该物理房型内是否有该设施：0-未知；1-全部此类房型都有该设施；2-部分此类房型有该设施
        /// </summary>
        public int Status { get; set; }
    }
}
