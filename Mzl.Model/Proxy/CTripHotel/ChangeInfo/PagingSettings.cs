using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.ChangeInfo
{
    public class PagingSettings
    {
        /// <summary>
        /// 每页最大记录数，默认为10，最大200
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// Start和Duration时间内首次调用，传0。之后，每次传上次调用时返回报文当中的LastRecordID
        /// </summary>
        public string LastRecordID { get; set; }
    }
}
