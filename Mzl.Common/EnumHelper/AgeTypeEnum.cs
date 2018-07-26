using System.ComponentModel;

namespace Mzl.Common.EnumHelper
{
    /// <summary>
    /// 乘车人/乘机人类型
    /// </summary>
    public enum AgeTypeEnum
    {
        /// <summary>
        /// 成人
        /// </summary>
        [Description("成人")]
        C = 1,
        /// <summary>
        /// 儿童
        /// </summary>
        [Description("儿童")]
        E = 2,
        /// <summary>
        /// 婴儿
        /// </summary>
        [Description("婴儿")]
        Y = 3,
    }
}
