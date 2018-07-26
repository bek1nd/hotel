using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
    public class TraModPrintTicketCallBackLogModel
    {





        /// <summary>
        /// 标记
        /// </summary>
        public string sign { get; set; }



        /// <summary>
        /// 用户id
        /// </summary>
        public string partnerid { get; set; }

        /// <summary>
        /// 标识
        /// </summary>
        public string reqtoken { get; set; }

        /// <summary>
        /// oldticketchangeserial
        /// </summary>
        public string oldticketchangeserial { get; set; }



        /// <summary>
        /// 请求时间
        /// </summary>
        public string reqtime { get; set; }



        /// <summary>
        /// 请求时间
        /// </summary>
        public string ticketpricediffchangeserial { get; set; }


        /// <summary>
        /// 新票信息
        /// </summary>
        public List<TicketNo> newticketcxins { get; set; }



        /// <summary>
        /// 方法名
        /// </summary>
        public string method { get; set; }


        /// <summary>
        /// 订单号
        /// </summary>
        public string orderid { get; set; }




        /// <summary>
        /// newticketchangeserial
        /// </summary>
        public string newticketchangeserial { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string code { get; set; }




        /// <summary>
        /// 编码
        /// </summary>
        public string msg { get; set; }


        /// <summary>
        /// 是否成功
        /// </summary>
        public bool success { get; set; }


    }



    public class TicketNo
    {
        /// <summary>
        /// 新票号
        /// </summary>
        public string new_ticket_no { get; set; }



        /// <summary>
        /// 旧票号
        /// </summary>
        public string old_ticket_no { get; set; }

        /// <summary>
        ///车厢号
        /// </summary>
        public string cxin{ get; set; }


    }




























}

