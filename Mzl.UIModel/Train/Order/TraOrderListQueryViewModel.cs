using Mzl.UIModel.Base;
using Mzl.UIModel.Customer.Corporation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order
{
    public class TraOrderListQueryViewModel
    {
        public List<CostCenterViewModel> CostCenterList { get; set; }
        public List<ProjectNameViewModel> ProjectNameList { get; set; }
        public List<SortedListViewModel> TraOrderStatusList { get; set; }
    }
}
