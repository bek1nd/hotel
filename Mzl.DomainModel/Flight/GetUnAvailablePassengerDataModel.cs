using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class GetUnAvailablePassengerDataModel
    {
        public int OrderId { get; set; }
        public List<FltPassengerModel> PassengerNameList { get; set; }
        public DateTime TackOffTime { get; set; }
        public string CreateOid { get; set; }
        public string CreateOName { get; set; }
        public string CustomerName { get; set; }
        public int Cid { get; set; }
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// 距离起飞日期的天数
        /// </summary>
        public int Day
        {
            get
            {
                return
                    (int)
                        (Convert.ToDateTime(TackOffTime.ToString("yyyy-MM-dd")) -
                         Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))).TotalDays;
            }
        }

        
    }
}
