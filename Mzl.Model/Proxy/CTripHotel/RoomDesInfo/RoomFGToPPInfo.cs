using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class RoomFGToPPInfo
    {
        /// <summary>
        /// 该售卖房型，若为现付是否可转为预付。True-可以；False-不可以；
        /// </summary>
        public bool CanFGToPP { get; set; }
    }
}
