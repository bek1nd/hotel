using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.Train
{
    /// <summary>
    /// 火车抢票状态
    /// </summary>
    public enum TrainGrabStatusEnum
    {
        /// <summary>
        /// 提交抢票
        /// </summary>
        [Description("提交抢票")]
        W,
        /// <summary>
        /// 抢票中
        /// </summary>
        [Description("抢票中")]
        P,
        /// <summary>
        /// 抢票成功
        /// </summary>
        [Description("抢票成功")]
        S,
        /// <summary>
        /// 抢票失败
        /// </summary>
        [Description("抢票失败")]
        F,
        /// <summary>
        /// 抢票取消
        /// </summary>
        [Description("抢票取消")]
        C,
        /// <summary>
        /// 提交抢票失败
        /// </summary>
        [Description("提交抢票失败")]
        D
    }
}
