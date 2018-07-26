using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.CorpAduit;

namespace Mzl.DomainModel.Customer.CorpAduit
{
    public class SubmitAduitModel
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
        public int AduitConfigId { get; set; }
        /// <summary>
        /// 差旅政策Id
        /// </summary>
        [Description("差旅政策Id")]
        public int? PolicyId { get; set; }
        /// <summary>
        /// 差旅政策审批范围
        /// </summary>
        [Description("差旅政策审批范围")]
        public PolicyTypeAduitEnum? PolicyTypeAduit { get; set; }
        /// <summary>
        /// 送审人
        /// </summary>
        public int SubmitCid { get; set; }
        /// <summary>
        /// 送审人（TC）
        /// </summary>
        public string SubmitOid { get; set; }

        public string DealSource { get; set; }
        /// <summary>
        /// 是否违反差旅政策
        /// </summary>
        [Description("是否违反差旅政策")]
        public bool IsViolatePolicy { get; set; }
        /// <summary>
        /// 审批订单类型
        /// </summary>
        public OrderSourceTypeEnum OrderType { get; set; }
    }
}
