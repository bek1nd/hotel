using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;

namespace Mzl.DomainModel.Flight
{
    public class FltOrderInfoModel: FltOrderModel
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }

        public List<string> PassengerNameList => PassengerList?.Select(x => x.Name).Distinct().ToList();

        public List<string> TravelList => FlightList?.Select(x => x.DportCity + "-" + x.AportCity).Distinct().ToList();

        public List<string> TackOffTimeList => FlightList?.Select(x => x.TackoffTime.ToString("yyyy-MM-dd HH:mm")).Distinct().ToList();


        /// <summary>
        /// 行程信息
        /// </summary>
        public List<FltFlightModel> FlightList { get; set; }
        /// <summary>
        /// 乘客信息
        /// </summary>
        public List<FltPassengerModel> PassengerList { get; set; }
        /// <summary>
        /// 客户信息
        /// </summary>
        public CustomerModel Customer { get; set; }
    }
}
