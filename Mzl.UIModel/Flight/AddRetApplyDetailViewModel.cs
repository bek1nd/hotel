using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class AddRetApplyDetailViewModel
    {
        public int Pid { get; set; }
        public int Contactid { get; set; }
        public int Sequence { get; set; }
        public DateTime TackOffTime { get; set; }
        /// <summary>
        /// 抵达时间
        /// </summary>
        public DateTime ArrivalsTime { get; set; }
        public string Dport { get; set; }
        public string Aport { get; set; }
        public string Class { get; set; }
        public string RecordNo { get; set; }
        public string FlightNo { get; set; }
        /// <summary>
        /// 票号
        /// </summary>
        public string TicketNo { get; set; }
    }
}
