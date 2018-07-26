using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
  public  class TraRequestChangeModel:BaseInputModel
    {
        /// <summary>
        /// 出发站简码[可空]
        /// </summary>  
        [Description("出发站简码[可空]")]
        public string from_station_code { get; set; }


        
        /// <summary>
        /// 出发站名称
        /// </summary>  
        [Description("出发站名称")]
        public string from_station_name { get; set; }





        /// <summary>
        /// 到达站简码[可空]
        /// </summary>  
        [Description("到达站简码[可空]")]
        public string to_station_code { get; set; }




        /// <summary>
        /// 到达站名称
        /// </summary>  
        [Description("到达站名称")]
        public string to_station_name { get; set; }



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
        /// 取票单号
        /// </summary>  
        [Description("取票单号")]
        public string ordernumber { get; set; }


        /// <summary>
        /// 改签新车票的车次
        /// </summary>  
        [Description("改签新车票的车次")]
        public string change_checi { get; set; }





        /// <summary>
        /// 改签新车票出发时间，格式 yyyy-MM-ddHH:mm:ss，如：2014-05-30 17:32:00
        /// </summary>  
        [Description("改签新车票出发时间，格式 yyyy-MM-ddHH: mm:ss，如：2014 - 05 - 30 17:32:00")]
        public string change_datetime { get; set; }



        /// <summary>
        /// 改签新车票的座位席别编码
        /// </summary>  
        [Description("改签新车票的座位席别编码")]
        public string change_zwcode { get; set; }




        /// <summary>
        /// 改签新车票的座位席别编码
        /// </summary>  
        [Description("原票的座位席别编码")]
        public string old_zwcode { get; set; }





        /// <summary>
        /// 改签新车票的座位席别编码//////////////////////////////////////////////////////////////////////////
        /// </summary>  
        [Description("改签车票信息")]
        public List<TraRequestChangeTicketInfoModel> ticketinfo { get; set; }




        /// <summary>
        /// 是否为异步改签Y 或N  只支持异步
        /// </summary>  
        [Description("是否为异步改签Y 或N只支持异步")]
        public string isasync { get; set; }



        /// <summary>
        /// 改签占座异步回调地址[异步改签时有值]
        /// </summary>  
        [Description("改签占座异步回调地址[异步改签时有值]")]
        public string callbackurl { get; set; }






        /// <summary>
        /// 改签占座异步回调地址[异步改签时有值]
        /// </summary>  
        [Description("请求特征值[异步改签时有值]")]
        public string reqtoken { get; set; }





        /// <summary>
        /// 是否是变站（如果为true，表示变站。to_station_name必须要有值）
        /// </summary>  
        [Description("是否是变站（如果为true，表示变站。to_station_name必须要有值）")]
        public Boolean isTs { get; set; }


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


        /// <summary>
        /// 是否需要选座
        /// </summary>  
        [Description("是否需要选座")]
        public bool is_choose_seats { get; set; }

        /// <summary>
        /// 选座 STR（比如：1A1D2B2C2F，就是选 5 个坐席），选座个数要与乘客数量应该一致
        /// </summary>  
        [Description("选座 STR（比如：1A1D2B2C2F，就是选 5个坐席），选座个数要与乘客数量应该一致")]
        public string choose_seats { get; set; }
        /// <summary>
        /// 改签是否接受无座  是否要无座票，true要;false或者不传不要
        /// </summary>
        public bool is_accept_standing { get; set; }
    }
}
