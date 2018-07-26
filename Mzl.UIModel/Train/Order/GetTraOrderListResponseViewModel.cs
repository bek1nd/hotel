using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order
{
    public class GetTraOrderListResponseViewModel
    {
        public List<TraOrderListDataViewModel> ListData { get; set; }
        public int TotalCount { get; set; }
    }
}
