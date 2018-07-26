using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Search
{
 public   class TraSearchOrderInfoResponseViewModel
    {
        /// <summary>
        /// 交易单号
        /// </summary>  
        [Description("交易单号")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 使用方订单号
        /// </summary>  
        [Description("使用方订单号")]
        public string OrderId { get; set; }


        /// <summary>
        /// 车次
        /// </summary>  
        [Description("车次")]
        public string CheCi { get; set; }

        /// <summary>
        /// 取票单号
        /// </summary>  
        [Description("取票单号")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// 发站
        /// </summary>  
        [Description("发站")]
        public string FromStation { get; set; }

        /// <summary>
        /// 到站
        /// </summary>  
        [Description("到站")]
        public string ToStation { get; set; }


        /// <summary>
        /// 开车时间
        /// </summary>  
        [Description("开车时间")]
        public string TrainTime { get; set; }




        /// <summary>
        /// 订单状态
        /// </summary>  
        [Description("订单状态")]
        public string OrderStatusName { get; set; }

        /// <summary>
        /// 资金变动情况
        /// </summary>  
        [Description("资金变动情况")]
        public List<object> CashChange { get; set; }

        /// <summary>
        /// 车票状态
        /// </summary>  
        [Description("车票状态")]
        public List<TicketStatusViewModel> TicketStatus { get; set; }


        

    }
}
