using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.AppMessage
{
    public class GetAppMessageResponseViewModel
    {
        /// <summary>
        /// 消息集合
        /// </summary>
        [Description("消息集合")]
        public List<AppMessageViewModel> AppMessageList { get; set; }
        public int TotalCount { get; set; }
    }
}
