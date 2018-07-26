using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
   public class TraPrintTicketCallBackLogModel
    {
        /// <summary>
        /// 请求时间
        /// </summary>  
        [Description("请求时间")]
        public string reqtime { get; set; }


        /// <summary>
        /// 请求时间
        /// </summary>  
        [Description("数字签名")]
        public string sign { get; set; }


        /// <summary>
        /// 使用方订单号
        /// </summary>  
        [Description("使用方订单号")]
        public string orderid { get; set; }

        /// <summary>
        /// 交易单号
        /// </summary>  
        [Description("交易单号")]
        public string transactionid { get; set; }

        /// <summary>
        /// 是否出票成功的标识
        /// </summary>  
        [Description("是否出票成功的标识")]
        public bool isSuccess { get; set; }



    }
}
