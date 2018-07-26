using System;
using System.ComponentModel;

namespace Mzl.UIModel.Hotel.Elong.HotelInfo
{
    public class HotelHAvailPolicyViewModel
    {
        /// <summary>
        /// 提示编号
        /// RatePlan.HAvailPolicyIds与此关联
        /// </summary>
        [Description("提示编号")]
        public string Id { get; set; }
        /// <summary>
        /// 提示内容
        /// </summary>
        [Description("提示内容")]
        public string AvailPolicyText { get; set; }
        /// <summary>
        /// 有效开始时间
        /// </summary>
        [Description("有效开始时间")]
        public DateTime AvailPolicyStart { get; set; }
        /// <summary>
        /// 有效结束时间
        /// </summary>
        [Description("有效结束时间")]
        public DateTime AvailPolicyEnd { get; set; }
    }
}
