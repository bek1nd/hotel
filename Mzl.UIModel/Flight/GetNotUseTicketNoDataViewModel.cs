using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class GetNotUseTicketNoDataViewModel
    {
        public int Cid { get; set; }
        public int OrderId { get; set; }
        public string TicketNo { get; set; }
        public List<string> PassengerNameList { get; set; }
        public DateTime OrderDate { get; set; }
        public List<FltFlightListViewModel> FlightList { get; set; }
    }
}
