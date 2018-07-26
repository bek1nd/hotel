using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo
{
    public class Picture
    {
        /// <summary>
        /// 图片类型（例如外景）
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 图片标题
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// 图片网址链接
        /// </summary>
        public string URL { get; set; }
    }
}
