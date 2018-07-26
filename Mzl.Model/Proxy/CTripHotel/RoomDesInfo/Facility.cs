using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class Facility
    {
        public IList<FacilityItem> FacilityItem { get; set; }
        /// <summary>
        /// 设施所属分类
        /// </summary>
        public string CategoryName { get; set; }
    }
}
