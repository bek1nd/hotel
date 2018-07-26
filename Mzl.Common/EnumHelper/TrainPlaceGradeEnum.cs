using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper
{
    /// <summary>
    /// 火车座位等级,枚举值不要任何修改，否则会影响差旅政策
    /// </summary>
    public enum TrainPlaceGradeEnum
    {
        /// <summary>
        /// 无座
        /// </summary>
        [Description("无座")]
        No = 1,
        /// <summary>
        /// 二等座
        /// </summary>
        [Description("二等座")]
        Second = 2,
        /// <summary>
        /// 一等座
        /// </summary>
        [Description("一等座")]
        First = 3,
        /// <summary>
        /// 特等座
        /// </summary>
        [Description("特等座")]
        Special = 4,
        /// <summary>
        /// 商务座
        /// </summary>
        [Description("商务座")]
        Business = 5,
        /// <summary>
        /// 硬座
        /// </summary>
        [Description("硬座")]
        Hard = 6,
        /// <summary>
        /// 软座
        /// </summary>
        [Description("软座")]
        Soft = 7,


        /// <summary>
        /// 硬卧
        /// </summary>
        [Description("硬卧")]
        HardSleep = 8,
        /// <summary>
        /// 动卧
        /// </summary>
        [Description("动卧")]
        DongSleep = 9,
        /// <summary>
        /// 软卧
        /// </summary>
        [Description("软卧")]
        SoftSleep = 10,
        /// <summary>
        /// 高级软卧
        /// </summary>
        [Description("高级软卧")]
        SeniorSoftSleep = 11,
        
    }
}
