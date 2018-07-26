using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class ChildLimit
    {
        /// <summary>
        /// 儿童入住人数上限
        /// </summary>
        public int MaxOccupancy { get; set; }
        /// <summary>
        /// 儿童年龄下限
        /// </summary>
        public int MinAge { get; set; }
        /// <summary>
        /// 儿童年龄上限
        /// </summary>
        public int MaxAge { get; set; }
    }
}
