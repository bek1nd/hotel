using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.CorpAduit;
using Mzl.DomainModel.Base;

namespace Mzl.DomainModel.Customer.CorpAduit
{
    public class SubmitCorpAduitOrderModel
    {
        /// <summary>
        /// 订单信息集合
        /// </summary>
        [Description("订单信息集合")]
        public List<SubmitCorpAduitOrderDetailModel> OrderInfoList { get; set; }
        /// <summary>
        /// 审批规则Id
        /// </summary>
        [Description("审批规则Id")]
        public int? AduitConfigId { get; set; }
        /// <summary>
        /// 差旅政策Id
        /// </summary>
        [Description("差旅政策Id")]
        public int? PolicyId { get; set; }
        /// <summary>
        /// 是否违反差旅政策
        /// </summary>
        [Description("是否违反差旅政策")]
        public bool? IsViolatePolicy { get; set; }
        /// <summary>
        /// 送审人
        /// </summary>
        public int SubmitCid { get; set; }
        /// <summary>
        /// 送审人 tc端
        /// </summary>
        public string SubmitOid { get; set; }
        /// <summary>
        /// 操作来源 PC,OA,IOS,Android
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 审批订单类型
        /// </summary>
        public OrderSourceTypeEnum OrderType { get; set; }
    }
}
