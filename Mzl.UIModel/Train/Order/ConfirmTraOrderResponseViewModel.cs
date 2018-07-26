using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Train.BaseMaintenance;

namespace Mzl.UIModel.Train.Order
{
    /// <summary>
    /// 火车确认订单视图模型
    /// </summary>
    public class ConfirmTraOrderResponseViewModel : ComfireOrderBaseViewModel
    {
        /// <summary>
        /// 服务费
        /// </summary>
        public decimal ServiceFee { get; set; }

        public decimal TrainGrabTicketServiceFee { get; set; } = 5;

        /// <summary>
        /// 12306帐号信息
        /// </summary>
        public List<SortedListViewModel> AccountList { get; set; }
    }
}
