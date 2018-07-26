using Mzl.DomainModel.Train.Server;
using Mzl.UIModel.Search;
using Mzl.UIModel.Train.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Search
{
  public  class TraOrderSubmitViewModel
    {
       


        /// <summary>
        /// 使用方订单号
        /// </summary>  
        [Description("使用方订单号")]
        public string Orderid { get; set; }


        /// <summary>
        /// 车次
        /// </summary>  
        [Description("车次")]
        public string CheCi { get; set; }


        /// <summary>
        /// 出发站简码
        /// </summary>  
        [Description("出发站简码")]
        public string FromStationCode { get; set; }

        /// <summary>
        /// 出发站名称
        /// </summary>  
        [Description("出发站名称")]
        public string FromStationName { get; set; }


        /// <summary>
        /// 到达站简码
        /// </summary>  
        [Description("到达站简码")]
        public string ToStationCode { get; set; }


        /// <summary>
        /// 到达站名称
        /// </summary>  
        [Description("到达站名称")]
        public string ToStationName { get; set; }

        
        /// <summary>
        /// 乘车日期
        /// </summary>  
        [Description("乘车日期")]
        public string TrainDate { get; set; }


        /// <summary>
        /// 乘客信息的 json 字符串。可以是多个乘客信息，最多 5 个，如：[{乘客1 信息},{乘客 2 信息},...]，也可以只 有一个，[{乘客1 信息}]。乘客参数 见附注 1。重要提示：如果购买儿童票，必须使用 随行成人的成人票证件信息（包括姓名、证件号码）。
        /// </summary>  
        [Description("乘客信息的 json 字符串")]
        public List<TraOrderSubmitPassengerViewModel> Passengers { get; set; }

       

        /// <summary>
        /// 12306 用户名
        /// </summary>  
        [Description("12306 用户名")]
        public string LoginUserName { get; set; }


        /// <summary>
        /// 12306 密码
        /// </summary>  
        [Description("12306 密码")]
        public string LoginUserPassword { get; set; }



        /// <summary>
        /// 是否要无座票，true 要;false 或者不传不要
        /// </summary>  
        [Description("是否要无座票，true 要;false 或者不传不要")]
        public bool IsAcceptStanding { get; set; }



        /// <summary>
        /// 是否需要选座
        /// </summary>  
        [Description("是否需要选座")]
        public bool IsChooseSeats { get; set; }

        /// <summary>
        /// 选座 STR（比如：1A1D2B2C2F，就是选 5 个坐席），选座个数要与乘客数量应该一致
        /// </summary>  
        [Description("选座 STR（比如：1A1D2B2C2F，就是选 5个坐席），选座个数要与乘客数量应该一致")]
        public string ChooseSeats { get; set; }



    }
}
