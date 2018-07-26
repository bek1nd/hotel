using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class Picture
    {
        /// <summary>
        /// 物理房型图片分类
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 物理房型图片标题
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// 物理房型图片URL
        /// </summary>
        public string URL { get; set; }
    }
}
