using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.ChangeInfo
{
    public class PagingInfo
    {
        /// <summary>
        /// 同StartTime和Duration时间段内，上次调用该接口时，返回报文中的LastRecordID
        /// </summary>
        public string LastRecordID { get; set; }
    }
}
