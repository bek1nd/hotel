using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.ChangeInfo
{
    public class ChangeInfo
    {
        public IList<ChangeDetail> ChangeDetails { get; set; }
        /// <summary>
        /// 发生变化的实体类型，类别包括酒店/物理房型/售卖房型三类
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 酒店ID
        /// </summary>
        public string HotelID { get; set; }
        /// <summary>
        /// 物理房型ID
        /// </summary>
        public string RoomTypeID { get; set; }
        /// <summary>
        /// 售卖房型ID
        /// </summary>
        public string RoomID { get; set; }
        /// <summary>
        /// 静态信息发生变化的时间
        /// </summary>
        public DateTime ChangeTime { get; set; }
    }
}
