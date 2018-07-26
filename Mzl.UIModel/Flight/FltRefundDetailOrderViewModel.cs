using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class FltRefundDetailOrderViewModel
    {
        public int Rid { get; set; }

        public int OrderId { get; set; }

        public int Sequence { get; set; }

        public string PassengerName { get; set; }

        public string AirlineNo { get; set; }

        public string TicketNo { get; set; }

        public string FlightNo { get; set; }

        public string Class { get; set; }


        public DateTime? TackoffTime { get; set; }

        public DateTime? ArrivalsTime { get; set; }

        public string Dport { get; set; }
        public string DportName { get; set; }
        public string DportCity { get; set; }

        public string Aport { get; set; }
        public string AportName { get; set; }
        public string AportCity { get; set; }

    }
}
