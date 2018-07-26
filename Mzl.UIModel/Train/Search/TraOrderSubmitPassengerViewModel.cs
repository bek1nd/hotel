using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Mzl.UIModel.Train.Search
{
    public class TraOrderSubmitPassengerViewModel
    {
        /// <summary>
        /// 乘客的顺序号
        /// </summary>  
        [Description("乘客的顺序号")]
        public int passengerid { get; set; }




        /// <summary>
        /// 票号（此票在本订单中的唯一标识）
        /// </summary>  
        [Description("票号（此票在本订单中的唯一标识）")]
        public string ticket_no { get; set; }



        private string _passengersename;
        /// <summary>
        /// 乘客姓名
        /// </summary>  
        [Description("乘客姓名")]
        public string passengersename
        {
            get
            {
                return string.IsNullOrEmpty(_passengersename)
                    ? _passengersename
                    : HttpUtility.UrlDecode(_passengersename);
            }
            set { _passengersename = value; }
        }


        /// <summary>
        /// 乘客证件号码
        /// </summary>  
        [Description("乘客证件号码")]
        public string passportseno { get; set; }


        /// <summary>
        /// 证件类型 ID不名称对应关系: 1:二代身份证，2:一代身份证，C:港澳通行证，G:台湾通 行证，B:护照
        /// </summary>  
        [Description("证件类型 ID不名称对应关系: 1:二代身份证，2:一代身份证，C: 港澳通行证，G: 台湾通 行证，B: 护照")]
        public string passporttypeseid { get; set; }

        private string _passporttypeseidname;

        /// <summary>
        /// 证件类型名称
        /// </summary>  
        [Description("证件类型名称")]
        public string passporttypeseidname
        {
            get
            {
                return string.IsNullOrEmpty(_passporttypeseidname)
                    ? _passporttypeseidname
                    : HttpUtility.UrlDecode(_passporttypeseidname);
            }
            set { _passporttypeseidname = value; }
        }


        /// <summary>
        /// 票种 ID。票种名称对应关系：1:成人票，2:儿童票，3:学生票，4:残军票
        /// </summary>  
        [Description("票种 ID。票种名称对应关系：1:成人票，2:儿童票，3:学生票，4:残军票")]
        public string piaotype { get; set; }

        private string _piaotypename;
        /// <summary>
        /// 票种名称
        /// </summary>  
        [Description("票种名称")]
        public string piaotypename
        {
            get
            {
                return string.IsNullOrEmpty(_piaotypename)
                    ? _piaotypename
                    : HttpUtility.UrlDecode(_piaotypename);
            }
            set { _piaotypename = value; }
        }


        /// <summary>
        /// 座位编码。与座位名称对应关系：F:动卧，9:商务座，P:特等座，M:一等座，O:二等座，6:高级软卧，4:软卧，3:硬卧，2:软座，1:硬座 注意：当最低的一种座位，无票时，购买选择该座位种类， 买下的就是无座(也就说买无座的席别编码就是该车次的 最低席别的编码)，另外，当最低席别的票卖完了的时候 才可以卖无座的票
        /// </summary>  
        [Description("座位编码。与座位名称对应关系：F: 动卧，9:商务座，P: 特等座，M: 一等座，O: 二等座，6:高级软卧，4:软卧，3:硬卧，2:软座，1:硬座 注意：当最低的一种座位，无票时，购买选择该座位种类， 买下的就是无座(也就说买无座的席别编码就是该车次的 最低席别的编码)，另外，当最低席别的票卖完了的时候 才可以卖无座的票")]
        public string zwcode { get; set; }

        private string _zwname;

        /// <summary>
        /// 座位名称
        /// </summary>  
        [Description("座位名称")]
        public string zwname
        {
            get
            {
                return string.IsNullOrEmpty(_zwname)
                    ? _zwname
                    : HttpUtility.UrlDecode(_zwname);
            }
            set { _zwname = value; }
        }

        private string _cxin;
        /// <summary>
        /// 几车厢几座（在订票成功后才会有值，如：‘15 车厢，20 号上铺’）
        /// </summary>  
        [Description("几车厢几座（在订票成功后才会有值，如：‘15 车厢，20 号上铺’）")]
        public string cxin
        {
            get
            {
                return string.IsNullOrEmpty(_cxin)
                    ? _cxin
                    : HttpUtility.UrlDecode(_cxin);
            }
            set { _cxin = value; }
        }


        /// <summary>
        /// 票价
        /// </summary>  
        [Description("票价")]
        public string price { get; set; }



        /// <summary>
        /// 身份核验状态 0：正常 1：待审核 2：未通过（占座结果回调才有）
        /// </summary>  
        [Description("身份核验状态 0：正常 1：待审核 2：未通过（占座结果回调才有）")]
        public int? reason { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>  
        [Description("省份名称")]
        public string province_name { get; set; }

        /// <summary>
        /// 省份编号
        /// </summary>  
        [Description("省份编号")]
        public string province_code { get; set; }

        /// <summary>
        /// 学校代号
        /// </summary>  
        [Description("学校代号")]
        public string school_code { get; set; }


        /// <summary>
        /// 票价
        /// </summary>  
        [Description("学校名称")]
        public string school_name { get; set; }

        /// <summary>
        /// 学号
        /// </summary>  
        [Description("学号")]
        public string student_no { get; set; }

        /// <summary>
        /// 票价
        /// </summary>  
        [Description("学制")]
        public string school_system { get; set; }

        /// <summary>
        /// 入学年份
        /// </summary>  
        [Description("入学年份")]
        public string enter_year { get; set; }

        /// <summary>
        /// 优惠区间起始地名称【选填】
        /// </summary>  
        [Description("优惠区间起始地名称【选填】")]
        public string preference_from_station_name { get; set; }


        /// <summary>
        /// 优惠区间起始地代号
        /// </summary>  
        [Description("优惠区间起始地代号")]
        public string preference_from_station_code { get; set; }

        /// <summary>
        /// 优惠区间到达地名称【选填】
        /// </summary>  
        [Description("优惠区间到达地名称【选填】")]
        public string preference_to_station_name { get; set; }

        /// <summary>
        /// 优惠区间到达地代号
        /// </summary>  
        [Description("优惠区间到达地代号")]
        public string preference_to_station_code { get; set; }

        /// <summary>
        /// 入学年份
        /// </summary>  
        [Description("是否需要保险")]
        public bool isneedinsure { get; set; }

        /// <summary>
        /// 省
        /// </summary>  
        [Description("省")]
        public string province { get; set; }

        /// <summary>
        /// 市
        /// </summary>  
        [Description("市")]
        public string city { get; set; }

        /// <summary>
        /// 区
        /// </summary>  
        [Description("区")]
        public string distric { get; set; }


        /// <summary>
        /// 具体地址
        /// </summary>  
        [Description("具体地址")]
        public string detailedaddress { get; set; }


        /// <summary>
        /// 邮政编码
        /// </summary>  
        [Description("邮政编码")]
        public string zipcode { get; set; }



        /// <summary>
        /// 收件人姓名
        /// </summary>  
        [Description("收件人姓名")]
        public string recipientname { get; set; }


        /// <summary>
        /// 收件人电话
        /// </summary>  
        [Description("收件人电话")]
        public string recipientphone { get; set; }
    }
}
