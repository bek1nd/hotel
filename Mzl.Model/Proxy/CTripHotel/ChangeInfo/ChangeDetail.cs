using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.ChangeInfo
{
    public class ChangeDetail
    {
        /// <summary>
        /// 取值发生变化的字段的名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 取值发生变化的字段的新值
        /// </summary>
        public string NewValue { get; set; }
    }
}
