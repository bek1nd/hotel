using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.GrabTicket.KongTieInterface
{
    public class GrabTicketPassengerRequestModel
    {
        /// <summary>
        /// 乘客的顺序号
        /// </summary>
        public int passengerid { get; set; }
        /// <summary>
        /// 乘客姓名
        /// </summary>
        public string passengersename { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string passportseno { get; set; }
        /// <summary>
        /// 证件类型id 1:二代身份证，2:一代身份证，C:港澳通行证，G:台湾通 行证，B:护照
        /// </summary>
        public string passporttypeseid { get; set; }
        /// <summary>
        /// 证件类型名称
        /// </summary>
        public string passporttypeidname
        {
            get
            {
                switch (passporttypeseid)
                {
                    case "1":
                        return "二代身份证";
                    case "2":
                        return "一代身份证";
                    case "C":
                        return "港澳通行证";
                    case "G":
                        return "台湾通行证";
                    case "B":
                        return "护照";
                    default:
                        return String.Empty;
                }
            }
        }
        /// <summary>
        /// 票种 Id 票种名称对应关系:1:成人票;2:儿童票; 3:学生票;4:残军票
        /// </summary>
        public string piaotype { get; set; }

        /// <summary>
        /// 票种名称
        /// </summary>
        public string piaotypename
        {
            get
            {
                switch (piaotype)
                {
                    case "1":
                        return "成人票";
                    case "2":
                        return "儿童票";
                    case "3":
                        return "学生票";
                    case "4":
                        return "残军票";
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// 最大票价(做价格校验)选填
        /// </summary>
        public string ticketprice { get; set; }

    }
}
