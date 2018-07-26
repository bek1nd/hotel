using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.SendAppMessage
{
    public class GetAppMessageResultModel
    {
        /// <summary>
        /// 消息集合
        /// </summary>
        public List<SendAppMessageModel> AppMessageList { get; set; }
        public int TotalCount { get; set; }
    }
}
