using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.CorpAduit
{
    public class CorpAduitConfigDetailModel
    {
        [Description("主键")]
        public int Id { get; set; }
        /// <summary>
        /// 审批规则Id
        /// </summary>
        [Description("审批规则Id")]
        public int ConfigId { get; set; }
        /// <summary>
        /// 审批级别
        /// </summary>
        [Description("审批级别")]
        public int AduitLevel { get; set; }
        /// <summary>
        /// 审批人Cid
        /// </summary>
        [Description("审批人Cid")]
        public int AduitCid { get; set; }
        /// <summary>
        /// 审批人名称
        /// </summary>
        public string AduitName { get; set; }
        /// <summary>
        /// 是否具有审批权限
        /// </summary>
        public bool IsCheckPerson { get; set; }
        /// <summary>
        ///差旅政策审批使用范围 2符合差旅政策 4违背差旅政策
        /// </summary>
        [Description("差旅政策审批使用范围 2符合差旅政策 4违背差旅政策")]
        public int? PolicyTypeAduit { get; set; }
        /// <summary>
        ///审批流程对应的订单类别
        /// </summary>
        [Description("审批流程对应的订单类别")]
        public int OrderType { get; set; }
    }
}
