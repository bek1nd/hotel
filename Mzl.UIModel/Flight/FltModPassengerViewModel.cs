using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class FltModPassengerViewModel
    {
        public string Name { get; set; }
        public string CardNo { get; set; }
        public string CardTypeDesc { get; set; }
        public List<string> TicketNoList { get; set; }
    }
}
