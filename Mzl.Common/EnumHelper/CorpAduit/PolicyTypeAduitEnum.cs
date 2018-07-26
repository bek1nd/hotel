using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.CorpAduit
{
    /// <summary>
    /// 差旅政策审批使用范围
    /// </summary>
    public enum PolicyTypeAduitEnum
    {
        /// <summary>
        /// 符合差旅政策
        /// </summary>
        [Description("符合差旅政策")]
        A = 2,
        /// <summary>
        /// 违背差旅政策
        /// </summary>
        [Description("违背差旅政策")]
        V = 4,
    }
}
