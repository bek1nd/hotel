using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order
{
    public class TraModOrderViewModel
    {
        public int CorderId { get; set; }
        public int? OrderId { get; set; }
        /// <summary>
        /// 常用联系人--姓名
        /// </summary>
        [Description("常用联系人--姓名")]
        public string CName { get; set; }
        /// <summary>
        /// 常用联系人--手机
        /// </summary>
        [Description("常用联系人--手机")]
        public string CPhone { get; set; }
        /// <summary>
        /// 常用联系人--电话
        /// </summary>
        [Description("常用联系人--电话")]
        public string CMobile { get; set; }
        /// <summary>
        /// 常用联系人--传真
        /// </summary>
        [Description("常用联系人--传真")]
        public string CFax { get; set; }
        /// <summary>
        /// 常用联系人--email
        /// </summary>
        [Description("常用联系人--email")]
        public string CEmail { get; set; }
        /// <summary>
        /// 改签单显示单号，如20027216B
        /// </summary>
        [Description("改签单显示单号")]
        public string Coid { get; set; }
        /// <summary>
        /// 改签差价
        /// </summary>
        [Description("改签差价")]
        public decimal? CalcPrice { get; set; }
        /// <summary>
        /// 改签面价
        /// </summary>
        public decimal? ModFacePrice { get; set; }

        public string OrderStatusDesc { get; set; }
        public string TravelRemark { get; set; }
    }
}
