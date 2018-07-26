using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class GetUnAvailablePassengerViewModel
    {
        public string Name { get; set; }
        public string CardNo { get; set; }
        public string CardTypeDesc { get; set; }
        public string IsAvailable { get; set; }
    }
}
