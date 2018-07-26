using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class RoomBedInfo
    {
        public IList<BedInfo> BedInfo { get; set; }
        /// <summary>
        /// 床型分类ID
        /// 备注：当床型分类ID为多床（ID=363）时，若BedInfo数组中多个床型之间的关系为“且”；当床型分类ID非多床（ID!=363）时，若BedInfo数组中多个床型之间的关系为“或”。
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 床型分类名称
        /// </summary>
        public string Name { get; set; }
    }
}
