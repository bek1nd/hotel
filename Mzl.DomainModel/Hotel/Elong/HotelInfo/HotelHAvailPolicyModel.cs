using System;

namespace Mzl.DomainModel.Hotel.Elong.HotelInfo
{
    public class HotelHAvailPolicyModel
    {
        /// <summary>
        /// 提示编号
        /// RatePlan.HAvailPolicyIds与此关联
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 提示内容
        /// </summary>
        public string AvailPolicyText { get; set; }
        /// <summary>
        /// 有效开始时间
        /// </summary>
        public DateTime AvailPolicyStart { get; set; }
        /// <summary>
        /// 有效结束时间
        /// </summary>
        public DateTime AvailPolicyEnd { get; set; }
    }
}
