using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class QueryFlightOrderListModel
    {
        public int TotalCount { get; set; }
        public List<QueryFlightOrderListDataModel> OrderDataList { get; set; }
    }
}
