using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class QueryFlightRetApplyListModel
    {
        public int TotalCount { get; set; }
        public List<QueryFlightRetApplyListDataModel> ApplyDataList { get; set; }
    }
}
