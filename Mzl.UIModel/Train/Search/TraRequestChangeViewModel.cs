using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Search
{
  public  class TraRequestChangeViewModel
    {
        /// <summary>
        /// 出发站简码[可空]
        /// </summary>  
        [Description("出发站简码[可空]")]
        public string FromStationCode { get; set; }


        
        /// <summary>
        /// 出发站名称
        /// </summary>  
        [Description("出发站名称")]
        public string FromStationName { get; set; }





        /// <summary>
        /// 到达站简码[可空]
        /// </summary>  
        [Description("到达站简码[可空]")]
        public string ToStationCode { get; set; }




        /// <summary>
        /// 到达站名称
        /// </summary>  
        [Description("到达站名称")]
        public string ToStationName { get; set; }



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
        /// 取票单号
        /// </summary>  
        [Description("取票单号")]
        public string OrderNumber { get; set; }


        /// <summary>
        /// 改签新车票的车次
        /// </summary>  
        [Description("改签新车票的车次")]
        public string ChangeCheci { get; set; }





        /// <summary>
        /// 改签新车票出发时间，格式 yyyy-MM-ddHH:mm:ss，如：2014-05-30 17:32:00
        /// </summary>  
        [Description("改签新车票出发时间，格式 yyyy-MM-ddHH: mm:ss，如：2014 - 05 - 30 17:32:00")]
        public string ChangeDatetime { get; set; }



        /// <summary>
        /// 改签新车票的座位席别编码
        /// </summary>  
        [Description("改签新车票的座位席别编码")]
        public string ChangeZwcode { get; set; }




        /// <summary>
        /// 改签新车票的座位席别编码
        /// </summary>  
        [Description("原票的座位席别编码")]
        public string OldZwcode { get; set; }





        /// <summary>
        /// 改签新车票的座位席别编码
        /// </summary>  
        [Description("改签车票信息")]
        public List<TraRequestChangeTicketInfoViewModel> TicketInfo { get; set; }




        /// <summary>
        /// 是否为异步改签Y 或N  只支持异步
        /// </summary>  
        [Description("是否为异步改签Y 或N只支持异步")]
        public string IsAsync { get; set; }



       



        /// <summary>
        /// 改签占座异步回调地址[异步改签时有值]
        /// </summary>  
        [Description("请求特征值[异步改签时有值]")]
        public string ReqToken { get; set; }





        /// <summary>
        /// 是否是变站（如果为true，表示变站。to_station_name必须要有值）
        /// </summary>  
        [Description("是否是变站（如果为true，表示变站。to_station_name必须要有值）")]
        public Boolean IsTs { get; set; }


        /// <summary>
        /// 改签占座异步回调地址[异步改签时有值]
        /// </summary>  
        [Description("12306用户名")]
        public string LoginUserName { get; set; }




        /// <summary>
        /// 改签占座异步回调地址[异步改签时有值]
        /// </summary>  
        [Description("12306密码")]
        public string LoginUserPassword { get; set; }



        
    }
}
