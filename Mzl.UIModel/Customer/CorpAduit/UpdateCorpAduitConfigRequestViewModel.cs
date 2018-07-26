using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.CorpAduit
{
    public class UpdateCorpAduitConfigRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Description("主键")]
        public int ConfigId { get; set; }
        /// <summary>
        /// 审批规则类型名称
        /// </summary>
        [Description("审批规则类型名称")]
        [Required]
        public string AduitName { get; set; }
        /// <summary>
        /// 是否需要审批
        /// </summary>
        [Description("是否需要审批")]
        public int IsNeedAduit { get; set; }
        /// <summary>
        /// 汇审类别：0 必须都审批 1只需审批一个
        /// </summary>
        [Description("汇审类别：0 必须都审批 1只需审批一个")]
        public int TogetherAduitType { get; set; }
        /// <summary>
        /// 审批级别集合
        /// </summary>
        [Description("审批级别集合")]
        public List<CorpAduitConfigDetailViewModel> DetailList { get; set; }
    }
}
