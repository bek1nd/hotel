using Mzl.UIModel.Customer.Corporation;
using Mzl.UIModel.Passenger;
using System.Collections.Generic;
using System.ComponentModel;

namespace Mzl.UIModel.Base
{
    /// <summary>
    /// 确认订单基础视图模型
    /// </summary>
    public abstract class ComfireOrderBaseViewModel
    {
        /// <summary>
        /// 是否预定人
        /// </summary>
        [Description("是否预定人")]
        public string IsMaster { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [Description("联系人")]
        public string CName { get; set; }
        /// <summary>
        /// EMail
        /// </summary>
        [Description("EMail")]
        public string EMail { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Description("手机号码")]
        public string Mobile { get; set; }
        /// <summary>
        /// 乘客信息
        /// </summary>
        [Description("乘客信息")]
        public List<PassengerViewModel> PassengerList { get; set; }
        /// <summary>
        /// 成本中心
        /// </summary>
        [Description("成本中心")]
        public List<CostCenterViewModel> CostCenterList { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Description("项目名称")]
        public List<ProjectNameViewModel> ProjectNameList { get; set; }
        /// <summary>
        /// 乘车人类型
        /// </summary>
        [Description("乘车人类型")]
        public List<SortedListViewModel> PassengerTypeList { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        [Description("证件类型")]
        public List<SortedListViewModel> CardTypeList { get; set; }
        /// <summary>
        /// 送票方式
        /// </summary>
        [Description("送票方式")]
        public List<SortedListViewModel> SendTicketTypeList { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        [Description("支付方式")]
        public List<SortedListViewModel> PayTypeList { get; set; }
        /// <summary>
        /// 是否打印五连单
        /// </summary>
        [Description("是否打印五连单")]
        public int IsPrint { get; set; }
        /// <summary>
        /// 送票地址信息集合
        /// </summary>
        [Description("送票地址信息集合")]
        public List<string> AddressList { get; set; }
    }
}
