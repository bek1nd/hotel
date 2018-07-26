using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
 public   class TraRequestConfirmResponseModel:BaseOutputModel
    {

        /// <summary>
        /// 请求特征值
        /// </summary>  
        [Description("请求特征值")]
        public string reqtoken { get; set; }

        /// <summary>
        /// 使用方订单号
        /// </summary>  
        [Description("使用方订单号")]
        public string orderid { get; set; }



        /// <summary>
        /// 出发站名称
        /// </summary>  
        [Description("交易单号")]
        public string transactionid { get; set; }


    }
}
