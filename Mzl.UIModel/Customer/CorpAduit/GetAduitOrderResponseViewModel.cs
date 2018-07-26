using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.CorpAduit
{
    public class GetAduitOrderResponseViewModel : CorpAduitOrderViewModel
    {
        /// <summary>
        /// 关联订单集合
        /// </summary>
        [Description("关联订单集合")]
        public List<CorpAduitOrderDetailViewModel> OrderDetailList { get; set; }

        /// <summary>
        /// 审批环节集合
        /// </summary>
        [Description("审批环节集合")]
        public List<CorpAduitOrderFlowViewModel> FlowList { get; set; }

        /// <summary>
        /// 操作日志集合
        /// </summary>
        [Description("操作日志集合")]
        public List<CorpAduitOrderLogViewModel> LogList { get; set; }

        

    }
}
