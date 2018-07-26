using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.CorpAduit
{
    /// <summary>
    /// 审批处理类型
    /// </summary>
    public enum AduitDealResultEnum
    {
        /// <summary>
        /// 送审
        /// </summary>
        [Description("送审")]
        W = 0,
        /// <summary>
        /// 审批通过
        /// </summary>
        [Description("审批通过")]
        F = 1,
        /// <summary>
        /// 审批不通过
        /// </summary>
        [Description("审批不通过")]
        C = 2,
        /// <summary>
        /// 创建审批单
        /// </summary>
        [Description("创建审批单")]
        S = 3,

    }
}
