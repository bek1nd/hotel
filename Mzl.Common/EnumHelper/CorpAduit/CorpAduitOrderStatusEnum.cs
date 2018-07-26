using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.CorpAduit
{
    /// <summary>
    /// 审批单状态
    /// </summary>
    public enum CorpAduitOrderStatusEnum
    {
        /// <summary>
        /// 已提交待送审
        /// </summary>
        [Description("已提交待送审")]
        N = 0,
        /// <summary>
        /// 已送审待审批
        /// </summary>
        [Description("已送审待审批")]
        W = 1,
        /// <summary>
        /// 已送审待汇审
        /// </summary>
        [Description("已送审待汇审")]
        W1 = 2,
        /// <summary>
        /// 已审批待下级审批
        /// </summary>
        [Description("已审批待下级审批")]
        P = 3,
        /// <summary>
        /// 已审批待下级汇审
        /// </summary>
        [Description("已审批待下级汇审")]
        P1 = 4,
        /// <summary>
        /// 会审中
        /// </summary>
        [Description("会审中")]
        P2 = 5,
        /// <summary>
        /// 已拒绝
        /// </summary>
        [Description("已拒绝")]
        J = 6,
        /// <summary>
        /// 已完成
        /// </summary>
        [Description("已完成")]
        F = 7,
    }
}
