using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
  public  class TraRequestCancelModel:BaseInputModel
    {


        /// <summary>
        ///使用方订单号
        /// </summary>  
        [Description("使用方订单号")]
        public string orderid { get; set; }


        /// <summary>
        ///交易单号
        /// </summary>  
        [Description("交易单号")]
        public string transactionid { get; set; }




        /// <summary>
        /// 请求特征值[与请求改签reqtoken对应]
        /// </summary>  
        [Description("请求特征值[与请求改签reqtoken对应]")]
        public string reqtoken { get; set; }



    }
}
