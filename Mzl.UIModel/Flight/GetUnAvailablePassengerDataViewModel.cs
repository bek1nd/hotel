using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class GetUnAvailablePassengerDataViewModel
    {
        public int OrderId { get; set; }
        public List<GetUnAvailablePassengerViewModel> PassengerNameList { get; set; }
        public DateTime TackOffTime { get; set; }
        public string TackOffTimeDesc => TackOffTime.ToString("yyyy-MM-dd");
        /// <summary>
        /// 距离起飞日期的天数
        /// </summary>
        public int Day { get; set; }

        public string DayDesc
        {
            get
            {
                if (Day > 0)
                {
                    return "距离起飞还差"+ Day+"天";
                }
                else if (Day==0)
                {
                    return "今天起飞";
                }
                else
                {
                    return "已经起飞" + Day*-1 + "天";
                }
            }
        }

        public string CreateOName { get; set; }
        public string CustomerName { get; set; }
        public int Cid { get; set; }
    }
}
