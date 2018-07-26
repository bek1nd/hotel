using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Order
{
    public class TraOrderResultListModel
    {
        public List<TraOrderListDataModel> ListData { get; set; }
        public int TotalCount { get; set; }
    }
}
