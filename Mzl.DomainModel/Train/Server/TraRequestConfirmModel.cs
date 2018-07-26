using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
 public   class TraRequestConfirmModel:BaseInputModel
    {

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
        /// 是否为异步改签Y 或N
        /// </summary>  
        [Description("是否为异步改签Y 或N")]
        public string isasync { get; set; }


        /// <summary>
        /// 请求特征值[异步改签时有值]
        /// </summary>  
        [Description("请求特征值[异步改签时有值]")]
        public string reqtoken { get; set; }


        /// <summary>
        /// 确认改签异步回调地址[异步改签时有值]
        /// </summary>  
        [Description("确认改签异步回调地址[异步改签时有值]")]
        public string callbackurl { get; set; }


        
    }
}
