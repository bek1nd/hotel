using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class GetUnAvailablePassengerListResponseViewModel
    {
        public int TotalCount { get; set; }
        public List<GetUnAvailablePassengerDataViewModel> DataList { get; set; }
    }
}
