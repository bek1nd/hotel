using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 国内查询规则
    /// </summary>
    public class RuleFile
    {
        /// <summary>
        /// FARE_BASIS(如果当中含有*号，则用该票靠舱的FARE_BASIS去代替)
        /// </summary>
        public string fareBasis { get; set; }
        /// <summary>
        /// TOUR_CODE(同FareBasis的做法)
        /// </summary>
        public string tc { get; set; }
        /// <summary>
        /// EI
        /// </summary>
        public string ri { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// 规则id
        /// </summary>
        public int? ruleId { get; set; }
        /// <summary>
        /// 这个规则的退改签政策是否靠舱。1：表示是 0：表示否
        /// </summary>
        public string IsDefaul { get; set; }
        /// <summary>
        /// 退票金额
        /// </summary>
        public float? RefundedAm { get; set; }
        /// <summary>
        /// 退票金额表示是否是用百分比 0：表示否 1：表示是
        /// </summary>
        public string RefundedAmPer { get; set; }
        /// <summary>
        /// 是否可退票  0：表示否 1：表示是
        /// </summary>
        public string RefundedFlag { get; set; }
        /// <summary>
        /// 改期金额
        /// </summary>
        public float? RescheduledAm { get; set; }
        /// <summary>
        /// 改期金额表示是否是用百分比 0：表示否 1：表示是
        /// </summary>
        public string RescheduledAmPer { get; set; }
        /// <summary>
        /// 是否可改期  0：表示否 1：表示是
        /// </summary>
        public string RescheduledFlag { get; set; }
        /// <summary>
        /// 改签金额
        /// </summary>
        public float? ChangeAirLineAm { get; set; }
        /// <summary>
        /// 改签金额表示是否是用百分比 0：表示否 1：表示是
        /// </summary>
        public string ChangeAirLineAmPer { get; set; }
        /// <summary>
        /// 是否可改签  0：表示否 1：表示是
        /// </summary>
        public string ChangeAirLineFlag { get; set; }
        /// <summary>
        /// 退改签对象，参见CabinEiVO类说明
        /// </summary>
        public CabinEiVO eiList { get; set; }
    }
}
