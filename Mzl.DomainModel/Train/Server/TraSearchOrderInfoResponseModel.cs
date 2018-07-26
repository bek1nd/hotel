using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
 public   class TraSearchOrderInfoResponseModel:BaseOutputModel
    {


        /// <summary>
        /// 交易单号
        /// </summary>  
        [Description("交易单号")]
        public string transactionid { get; set; }

        /// <summary>
        /// 使用方订单号
        /// </summary>  
        [Description("使用方订单号")]
        public string orderid { get; set; }


        /// <summary>
        /// 车次
        /// </summary>  
        [Description("车次")]
        public string checi { get; set; }

        /// <summary>
        /// 取票单号
        /// </summary>  
        [Description("取票单号")]
        public string ordernumber { get; set; }

        /// <summary>
        /// 发站
        /// </summary>  
        [Description("发站")]
        public string fromstation { get; set; }

        /// <summary>
        /// 到站
        /// </summary>  
        [Description("到站")]
        public string tostation { get; set; }


        /// <summary>
        /// 开车时间
        /// </summary>  
        [Description("开车时间")]
        public string traintime { get; set; }
        

        /// <summary>
        /// 订单状态
        /// </summary>  
        [Description("订单状态")]
        public string orderstatusname { get; set; }

        /// <summary>
        /// 资金变动情况
        /// </summary>  
        [Description("资金变动情况")]
        public List<object> cashchange { get; set; }

        /// <summary>
        /// 车票状态
        /// </summary>  
        [Description("车票状态")]
        public List<TicketStatusModel> ticketstatus { get; set; }
    }
}
