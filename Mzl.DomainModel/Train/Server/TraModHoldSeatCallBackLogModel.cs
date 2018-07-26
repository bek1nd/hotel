using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
    public class TraModHoldSeatCallBackLogModel
    {


        /// <summary>
        /// 请求token
        /// </summary>
        public string reqtoken { get; set; }

        /// <summary>
        /// 价格差值
        /// </summary>
        public string pricedifference { get; set; }





        /// <summary>
        /// 新票信息
        /// </summary>
        public List<NewTickets> newtickets { get; set; }


        /// <summary>
        /// 新票类
        /// </summary>
        public string priceinfotype { get; set; }


        /// <summary>
        /// 到达站名称
        /// </summary>
        public string to_station_name { get; set; }



        /// <summary>
        /// 用户名称
        /// </summary>
        public string partnerid { get; set; }







        /// <summary>
        /// 提示信息
        /// </summary>
        public string help_info { get; set; }


        /// <summary>
        /// 订单号
        /// </summary>
        public string transactionid { get; set; }




        /// <summary>
        /// 改签票款差价提示
        /// </summary>
        public string priceinfo { get; set; }



        /// <summary>
        /// 差额
        /// </summary>
        public string diffrate { get; set; }

        /// <summary>
        /// 请求时间
        /// </summary>
        public string reqtime { get; set; }


        /// <summary>
        /// 出发站名称
        /// </summary>
        public string from_station_name { get; set; }

        /// <summary>
        /// 车次
        /// </summary>
        public string checi { get; set; }




        /// <summary>
        /// 总票差额
        /// </summary>
        public string totalpricediff { get; set; }



        /// <summary>
        /// 出发车站编码
        /// </summary>
        public string from_station_code { get; set; }

        /// <summary>
        /// 费用
        /// </summary>
        public string fee { get; set; }



        /// <summary>
        /// 到达时间
        /// </summary>
        public string arrive_time { get; set; }

        /// <summary>
        /// 到达车站编码
        /// </summary>
        public string to_station_code { get; set; }

        /// <summary>
        /// 查询日期
        /// </summary>
        public string train_date { get; set; }


        /// <summary>
        /// refund_online
        /// </summary>
        public string refund_online { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string start_time { get; set; }


        /// <summary>
        /// 方法
        /// </summary>
        public string method { get; set; }

        /// <summary>
        /// 使用账户
        /// </summary>
        public string orderid { get; set; }


        /// <summary>
        /// 是否成功
        /// </summary>
        public bool success { get; set; }

        public string msg { get; set; }
    }



    public class NewTickets
    {

        /// <summary>
        /// 座位名称
        /// </summary>
        public string zwname { get; set; }

        /// <summary>
        /// 新票号
        /// </summary>
        public string new_ticket_no { get; set; }



        /// <summary>
        /// 价格
        /// </summary>
        public string price { get; set; }

        /// <summary>
        /// 票类型
        /// </summary>
        public string piaotype { get; set; }


        /// <summary>
        /// 座位类型
        /// </summary>
        public string zwcode { get; set; }


        /// <summary>
        /// 乘客身份号
        /// </summary>
        public string passportseno { get; set; }

        /// <summary>
        /// 旧车票号
        /// </summary>
        public string old_ticket_no { get; set; }



        /// <summary>
        /// 标志信息
        /// </summary>
        public string flagmsg { get; set; }

        /// <summary>
        /// 标志编码
        /// </summary>
        public string flagid { get; set; }

        /// <summary>
        /// 车座具体信息
        /// </summary>
        public string cxin { get; set; }
            
      

    } 



















}
