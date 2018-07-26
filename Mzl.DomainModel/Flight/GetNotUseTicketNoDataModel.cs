using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class GetNotUseTicketNoDataModel
    {
        public int Cid { get; set; }
        public int OrderId { get; set; }
        public string TicketNo { get; set; }
        public List<FltFlightModel> FlightList { get; set; }
        public string PassengerName { get; set; }
        public int Sequence { get; set; }
        public List<FltPassengerModel> PassengerList { get; set; }
        public List<string> PassengerNameList => PassengerList.Select(n => n.Name).ToList();
        public string CorpId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
