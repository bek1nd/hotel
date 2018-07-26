using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo
{
    public class ImportantNotice
    {
        /// <summary>
        /// 重要提示内容
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 重要提示分类:City,Hotel,PPRooms,FGRooms
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 政策生效的日期
        /// </summary>
        public string Start { get; set; }
        /// <summary>
        /// 政策到期的日期
        /// </summary>
        public string End { get; set; }
    }
}
