using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDetailPrice
{
    public class Fee
    {
        public List<Amount> Amount { get; set; }
        /// <summary>
        /// 费项名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 该费项是否包含在单间房多间夜的税后总价中
        /// </summary>
        public string Type { get; set; }
    }
}
