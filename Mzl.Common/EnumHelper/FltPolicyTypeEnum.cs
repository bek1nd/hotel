using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper
{
    /// <summary>
    /// 政策类型
    /// </summary>
    public enum FltPolicyTypeEnum
    {
        /// <summary>
        /// 普通政策
        /// </summary>
        [Description("普通政策")]
        Ordinary = 0,
        /// <summary>
        /// 特殊政策
        /// </summary>
        [Description("特殊政策")]
        Protocol = 1,
        /// <summary>
        /// 冲量政策
        /// </summary>
        [Description("冲量政策")]
        Impulse = 2,
        /// <summary>
        /// 外采政策
        /// </summary>
        [Description("外采政策")]
        WaiCai = 3,
        /// <summary>
        /// 默认政策
        /// </summary>
        [Description("默认政策")]
        Default = -1,
        /// <summary>
        /// B2G政策
        /// </summary>
        [Description("B2G政策")]
        G = 4,
        /// <summary>
        /// 协议政策
        /// </summary>
        [Description("协议政策")]
        X = 5,
    }
}
