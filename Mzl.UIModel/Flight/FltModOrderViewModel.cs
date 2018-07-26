using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class FltModOrderViewModel
    {
        public int Rmid { get; set; }
        public decimal ModPrice { get; set; }
        public int OrderId { get; set; }
        public string NumberIdentity { get; set; }

        /// <summary>
        /// 改签行程
        /// </summary>
        public List<FltModFlightViewModel> FltModFlightList { get; set; }
        /// <summary>
        /// 改签乘机人
        /// </summary>
        public List<FltModPassengerViewModel> FltModPassengerList { get; set; }
    }
}
