using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Train.Order
{
    public class ConfirmTraHoldSeatRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号")]
        public int OrderId { get; set; }
        /// <summary>
        /// 是否同意占位结果
        /// </summary>
        [Description("是否同意占位结果")]
        public bool IsAgree { get; set; }
    }
}
