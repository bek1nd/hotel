using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.CorpAduit
{
    public class CorpAduitConfigViewModel
    {
        /// <summary>
        /// 审批规则id
        /// </summary>
        [Description("审批规则id")]
        public int ConfigId { get; set; }
        /// <summary>
        /// 审批规则类型名称
        /// </summary>
        [Description("审批规则类型名称")]
        public string AduitName { get; set; }
        /// <summary>
        /// 是否需要审批
        /// </summary>
        [Description("是否需要审批")]
        public int IsNeedAduit { get; set; }
        /// <summary>
        /// 是否需要审批描述
        /// </summary>
        [Description("是否需要审批描述")]
        public string IsNeedAduitDes { get; set; }
        /// <summary>
        /// 审批人集合
        /// </summary>
        [Description("审批人集合")]
        public string AduitOName { get; set; }
        /// <summary>
        /// 差旅政策审批使用范围 2符合差旅政策 4违背差旅政策
        /// </summary>
        [Description("差旅政策审批使用范围 2符合差旅政策 4违背差旅政策")]
        public int? PolicyTypeAduit { get; set; }
        /// <summary>
        /// 汇审类别：0 必须都审批 1只需审批一个
        /// </summary>
        [Description("汇审类别：0 必须都审批 1只需审批一个")]
        public int TogetherAduitType { get; set; }
        /// <summary>
        /// 审批级别信息集合
        /// </summary>
        [Description("审批级别信息集合")]
        public List<CorpAduitConfigDetailViewModel> DetailList { get; set; }
    }
}
