using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order
{
    public class TraOrderListDataViewModel : TraOrderListDataBaseViewModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 线上显示订单
        /// </summary>
        public int ShowOnlineOrderId { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 成本中心
        /// </summary>
        public string CostCenter { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName { get; set; }
        /// <summary>
        /// 是否退票
        /// </summary>
        public bool IsRefunded { get; set; }
        /// <summary>
        /// 是否改签
        /// </summary>
        public bool IsModed { get; set; }
        /// <summary>
        /// 待确认出票的改签订单Id
        /// </summary>
        public List<int> WaitConfirmModId { get; set; }
    }
}
