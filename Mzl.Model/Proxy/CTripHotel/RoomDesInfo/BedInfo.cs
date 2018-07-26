using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class BedInfo
    {
        /// <summary>
        /// 床型ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 床型名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 床型数量
        /// </summary>
        public int NumberOfBeds { get; set; }
        /// <summary>
        /// 床型宽度
        /// </summary>
        public double BedWidth { get; set; }
    }
}
