using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
  public  class TraTicketRefundResponseModel:BaseOutputModel
    {


        /// <summary>
        /// 请求特征
        /// <summary>
        [Description("请求特征")]
        public string orderid { get; set; }
        /// <summary>
        /// 请求特征
        /// <summary>
        [Description("请求特征")]
        public string ordernumber  { get; set; }
        /// <summary>
        /// 请求特征
        /// <summary>
        [Description("请求特征")]
        public string tooltip { get; set; }
        /// <summary>
        /// 请求特征
        /// <summary>
        [Description("请求特征")]
        public string reqtoken { get; set; }









    }
}
