using Mzl.EntityModel.Train.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Train.Server
{

    [Table("Tra_RefundTicketCallBackLog")]
    public  class TraRefundTicketCallBackLogEntity : TraCallBackLogBasicEntity
    {
        /// <summary>
        /// 退票/改签退款回调通知类型
        /// </summary>
        [Description("退票/改签退款回调通知类型【0：表示线下退票退款； 1：表示线上退票退款；2：线下改签退款；3：线上改签退款；】3 尚未启用")]
        public string ReturnType { get; set; }

        /// <summary>
        /// 使用方订单号
        /// </summary>
        [Description("使用方订单号")]
        public string ApiorderID { get; set; }

        /// <summary>
        /// 火车票取票单号
        /// </summary>
        [Description("火车票取票单号")]
        public string TrainOrderID { get; set; }


        /// <summary>
        /// 退票回调特征值
        /// </summary>
        [Description("（唯一）退票回调特征值(1.当回调内容是客人在线申请退票的退款，该值为在调用退票请求 API 时，由使用方传入；2.当回调内容是客人在线下车站退票的退款，该值由我方分配。)当为线下退票时，此值为空")]
        public string ReqToken { get; set; }




        /// <summary>
        /// 车票退票信息
        /// </summary>
        [Description("车票退票信息(json 字符串数组形式，每张车票包含乘车人信息和退票相关信息)")]
        public  string ReturnTickets { get; set; }




        /// <summary>
        /// 退票信息特征值
        /// </summary>
        [Description("退票信息特征值 注：当为线下退票或线下改签时，此值为空")]
        public string Token { get; set; }

        /// <summary>
        /// 退票退款状态
        /// </summary>
        [Description("退票退款状态【 true:表示成功 false:表示退票失败 】")]
        public string ReturnState { get; set; }


        /// <summary>
        /// 退款金额
        /// </summary>
        [Description("退款金额（成功需有值） 当为线上退票时，此值为退款总额")]
        public string ReturnMoney { get; set; }


        /// <summary>
        /// 退票后消息描述
        /// </summary>
        [Description("退票后消息描述（当 returnstate=false 时，需显示退票失败原因等）")]
        public string ReturnMsg { get; set; }


        /// <summary>
        /// 请求时间戳
        /// </summary>
        [Description("请求时间戳，形如：1398148112")]
        public string TimeStamp { get; set; }



        /// <summary>
        /// 线下退票或线下改签数字签名
        /// </summary>
        [Description("线下退票或线下改签数字签名= md5(partnerid + returntype + timestamp + apiorderid + trainorderid + returnmoney + returnstate + md5(key))线上退票或线上改签数字签名= md5(partnerid + returntype + timestamp + apiorderid + trainorderid + token + returnmoney + returnstate + md5(key))其中 partnerid 为使用方登录我方开放平台的账户，key 是我方分配给使用方使用的 key。md5 算法得到的字符串全部为小写")]
        public string Sign { get; set; }



    }
}
