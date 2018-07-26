using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.CorpAduit
{
    public class CorpAduitConfigListViewModel
    {
        public int ConfigId { get; set; }
        /// <summary>
        /// 审批规则类型名称
        /// </summary>
        [Description("审批规则类型名称")]
        public string AduitName { get; set; }
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

    }
}
