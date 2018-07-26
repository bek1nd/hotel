using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    /// <summary>
    /// 机票创建订单视图模型
    /// </summary>
    public class ComfireFlightOrderResponseViewModel : ComfireOrderBaseViewModel
    {
        public List<FltInsuranceViewModel> InsuranceList { get; set; }
    }
}
