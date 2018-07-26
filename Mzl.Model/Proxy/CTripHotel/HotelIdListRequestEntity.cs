using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel
{
    /// <summary>
    /// GetHotelldList Parameter
    /// </summary>
   public class HotelIdListRequestEntity
   {
        /// <summary>
        /// 城市 ID
        /// </summary>
        public int City { get; set; }

        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 单页大小
        /// </summary>
        public int PageSize { get; set; }
   }
}
