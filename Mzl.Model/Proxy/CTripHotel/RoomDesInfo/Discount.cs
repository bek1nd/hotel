using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class Discount
    {
        /// <summary>
        /// 住几送几促销：
        /// 实际需要连住的房夜数
        /// </summary>
        public int NigthsRequired { get; set; }
        /// <summary>
        /// 免费赠送的房夜数
        /// 备注：包含在实际连住的房夜数当中
        /// </summary>
        public int NightsDiscounted { get; set; }
        /// <summary>
        /// 收费/免费房夜数的数据格式。示例如下：住二送一，该值为"001"，住四送二，该值为0011）
        /// </summary>
        public string DiscountPattern { get; set; }
    }
}
