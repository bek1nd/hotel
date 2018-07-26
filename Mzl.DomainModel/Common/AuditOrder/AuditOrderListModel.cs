using System.Collections.Generic;
using Mzl.DomainModel.Flight;

namespace Mzl.DomainModel.Common.AuditOrder
{
    public class AuditOrderListModel
    {
        public List<AuditOrderListDataModel> DataList { get; set; }
        public int TotalCount { get; set; }
    }
}
