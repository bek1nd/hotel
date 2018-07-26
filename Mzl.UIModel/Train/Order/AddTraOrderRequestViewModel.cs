using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Train.Order
{
    public class AddTraOrderRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 创建订单的方式 0走接口订单 1走手动订单 
        /// </summary>
        [Description("创建订单的方式 0走接口订单 1走手动订单，线上提交不需要传")]
        public int AddOrderType { get; set; }
        /// <summary>
        /// 订单主体
        /// </summary>
        [Description("订单主体")]
        public TraOrderViewModel Order { get; set; }
        /// <summary>
        /// 行程信息
        /// </summary>
        [Description("行程信息")]
        public List<TraOrderDetailViewModel> OrderDetailList { get; set; }

        /// <summary>
        /// 选座信息1A,1B,1C,2A,2B
        /// </summary>
        [Description("选座信息")]
        public List<ChooseSeatViewModel> ChooseSeatList { get; set; }

        /// <summary>
        /// 是否接受无座,默认接受无座
        /// </summary>
        public bool IsAcceptStanding { get; set; } = true;
    }
}
