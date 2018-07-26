using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class SearchFlightViewModel
    {
        public string RPH { get; set; }

        /// <summary>
        /// 航司代码
        /// </summary>
        public string AirlineNo { get; set; }
        /// <summary>
        /// 航班号
        /// </summary>
        public string FlightNo { get; set; }
        /// <summary>
        /// 航司名称
        /// </summary>
        public string AirlineDesc { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public string TackOffDate { get; set; }
        public string TackOffTime { get; set; }
        /// <summary>
        /// 出发日期偏差
        /// </summary>
        public string TackOffDateAdd { get; set; }
        /// <summary>
        /// 到达日期
        /// </summary>
        public string ArrivalsDate { get; set; }
        public string ArrivalsTime { get; set; }
        /// <summary>
        /// 到达日期偏差
        /// </summary>
        public string ArrivalsDateAdd { get; set; }

        public string Meal { get; set; }
        public string MealID { get; set; }
        /// <summary>
        /// 起飞机场三字码
        /// </summary>
        public string DportCode { get; set; }
        /// <summary>
        /// 到达机场三字码
        /// </summary>
        public string AportCode { get; set; }
        public string DportName { get; set; }
        public string DportCityCode { get; set; }
        public string AportCityCode { get; set; }
        public string DportName_EN { get; set; }
        public string AportName { get; set; }
        public string AportName_EN { get; set; }
        /// <summary>
        /// 出发城市名称
        /// </summary>
        public string DportCityName { get; set; }
        /// <summary>
        /// 到达城市名称
        /// </summary>
        public string AportCityName { get; set; }

        public string OilFee { get; set; }
        public string TaxFee { get; set; }
        /// <summary>
        /// 出发航站楼
        /// </summary>
        public string StarAirPortson { get; set; }

        /// <summary>
        /// 到达航站楼
        /// </summary>
        public string EndAirPortson { get; set; }
        /// <summary>
        /// 经停
        /// </summary>
        public string PassBy { get; set; }
        public int PassByInt { get; set; }
        /// <summary>
        /// 机型
        /// </summary>
        public string AirType { get; set; }
        public string YPrice { get; set; }
        public string CPrice { get; set; }
        public string FPrice { get; set; }
        /// <summary>
        /// 共享航班对应的实际航班号
        /// </summary>
        public string SharedFlightNo { get; set; }
        /// <summary>
        /// 是否是共享航班
        /// </summary>
        public bool IsShared { get; set; }
        /// <summary>
        /// 共享航班对应的实际航班号是否有协议价(2018.5.21 add by QianYuzhe)
        /// </summary>
        public bool IsSharedFlightNoHasXieYiPrice { get; set; }
        /// <summary>
        /// 价格详情
        /// </summary>
        public List<SearchFlightDetailViewModel> DetailList { get; set; }
    }
}
