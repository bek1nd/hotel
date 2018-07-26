using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo
{
    public class Description
    {
        /// <summary>
        /// 类别（SpecialTIps：特别提示）
        /// 当作为HotelStaticInfo的属性时表示:酒店描述类型代码：1-简短描述；2-长篇描述
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 正文
        /// </summary>
        public string Text { get; set; }
    }
}
