using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo
{
    public class Facility
    {
        /// <summary>
        /// 
        /// </summary>
        public IList<FacilityItem> FacilityItem { get; set; }
        /// <summary>
        /// 特定设施的分类
        /// </summary>
        public string CategoryName { get; set; }
    }
}
