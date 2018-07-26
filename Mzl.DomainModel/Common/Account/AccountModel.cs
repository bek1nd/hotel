using System.ComponentModel;

namespace Mzl.DomainModel.Common.Account
{
    public class AccountModel
    {
        /// <summary>
        /// 帐号Id
        /// </summary>
        [Description("帐号Id")]
        public int Aid { get; set; }
        /// <summary>
        /// 帐号名称
        /// </summary>
        [Description("帐号名称")]
        public string AccountName { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        [Description("余额")]
        public decimal? Amount { get; set; }
        /// <summary>
        /// 是否付款账户（T是 F否） 
        /// </summary>
        [Description("是否付款账户")]
        public string IsPay { get; set; }
        /// <summary>
        /// 是否收款账户（T是 F否） 
        /// </summary>
        [Description("是否收款账户")]
        public string Iscollection { get; set; }
        /// <summary>
        /// 是否显示（T是 F否） 
        /// </summary>
        [Description("是否显示")]
        public string IsShow { get; set; }
    }
}
