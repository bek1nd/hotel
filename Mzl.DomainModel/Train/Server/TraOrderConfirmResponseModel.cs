using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
  public  class TraOrderConfirmResponseModel:BaseOutputModel
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
        public string ordernumber { get; set; }

      public string changeserial { get; set; }


    }
}
