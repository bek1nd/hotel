using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Search
{
 public   class TraRequestConfirmViewModel
    {

        /// <summary>
        /// 使用方订单号
        /// </summary>  
        [Description("使用方订单号")]
        public string OrderId { get; set; }


        /// <summary>
        /// 交易单号
        /// </summary>  
        [Description("交易单号")]
        public string TransactionId { get; set; }


        /// <summary>
        /// 是否为异步改签Y 或N
        /// </summary>  
        [Description("是否为异步改签Y 或N")]
        public string IsAsync { get; set; }


        /// <summary>
        /// 请求特征值[异步改签时有值]
        /// </summary>  
        [Description("请求特征值[异步改签时有值]")]
        public string ReqToken { get; set; }






    }
}
