using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.GrabTicket.KongTieInterface
{
    public class GrabTicketSuccessedPassengerAsyncResponseModel
    {
        /// <summary>
        /// 乘客的顺序号
        /// </summary>
        public string passengerid { get; set; }
        /// <summary>
        /// 乘客姓名
        /// </summary>
        public string passengersename { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string passportseno { get; set; }
        /// <summary>
        /// 证件类型id1:二代身份证，2:一代身份证，C:港澳通行证，G:台湾通 行证，B:护照
        /// </summary>
        public string passporttypeseid { get; set; }
        /// <summary>
        /// 证件类型名称
        /// </summary>
        public string passporttypeseidname { get; set; }
        /// <summary>
        /// 票种 Id 票种名称对应关系：1:成人票，2:儿童票，3:学生票，4:残军票
        /// </summary>
        public string piaotype { get; set; }
        /// <summary>
        /// 票种名称
        /// </summary>
        public string piaotypename { get; set; }
        /// <summary>
        /// 身份核验状态0：正常 1：待审核 2：未通过（占座结果回调才有）
        /// </summary>
        public int reason { get; set; }
        /// <summary>
        /// 座位名称
        /// </summary>
        public string zwname { get; set; }
        /// <summary>
        /// 票价
        /// </summary>
        public string price { get; set; }
        /// <summary>
        /// 票号（此票在本订单中的唯一标识）
        /// </summary>
        public string ticket_no { get; set; }
        /// <summary>
        /// 座位编码
        /// </summary>
        public string zwcode { get; set; }
        /// <summary>
        /// 几车厢几座（在订票成功后才会有值，如：‘15车厢，20号上铺’）
        /// </summary>
        public string cxin { get; set; }
    }
}
