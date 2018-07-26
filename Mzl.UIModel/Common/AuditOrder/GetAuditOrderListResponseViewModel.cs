using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Common.AuditOrder
{
    public class GetAuditOrderListResponseViewModel
    {
        public List<GetAuditOrderDataListViewModel> DataList { get; set; }
        public int TotalCount { get; set; }
    }
}
