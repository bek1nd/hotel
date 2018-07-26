using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Search
{
 public   class TraTicketRefundViewModel
    {
        /// <summary>
        /// 使用方订单号
        /// <summary>
        [Description("使用方订单号")]
        public string Orderid { get; set; }

        /// <summary>
        /// 交易单号
        /// <summary>
        [Description("对方交易单号")]
        public string TransactionId { get; set; }


        /// <summary>
        /// 取票单号
        /// <summary>
        [Description("取票单号")]
        public string OrderNumber { get; set; }

        
        /// <summary>
        /// 请求特征
        /// <summary>
        [Description("请求特征")]
        public string ReqToken { get; set; }



        /// <summary>
        /// 车票信息    
        /// <summary>
        [Description("车票信息")]
        public List<RefundTicketDetailViewModel> Tickets { get; set; }


        /// <summary>
        /// 12306用户名
        /// <summary>
        [Description("12306用户名")]
        public string LoginUserName { get; set; }



        /// <summary>
        /// 12306密码
        /// <summary>
        [Description("12306密码")]
        public string LoginUserPassword { get; set; }















    }
}
