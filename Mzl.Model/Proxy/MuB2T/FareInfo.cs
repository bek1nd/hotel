using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 价格列表
    /// </summary>
    //[Serializable]
    public class FareInfo
    {
        /// <summary>
        /// 旅客类型
        /// </summary>
        //[XmlElement]
        public string PAX_TP { get; set; }
        /// <summary>
        /// 不使用B2G大客户政策的价格
        /// </summary>
        //[XmlElement]
        public string NO_POLICY_PRICE { get; set; }
        /// <summary>
        /// 实际使用折后价格
        /// </summary>
        //[XmlElement]
        public string PRICE { get; set; }
        /// <summary>
        /// 机场建设税，当前版本返回 null
        /// </summary>
        //[XmlElement]
        public string AIRP_TAX { get; set; }
        /// <summary>
        /// 燃油税当前版本返回 null
        /// </summary>
        //[XmlElement]
        public string FUEL_TAX { get; set; }
        /// <summary>
        /// FARE_BASIS
        /// </summary>
        //[XmlElement]
        public string FARE_BASIS { get; set; }
        /// <summary>
        /// TOUR_CODE
        /// </summary>
        //[XmlElement]
        public string TOUR_CODE { get; set; }
        /// <summary>
        /// EI
        /// </summary>
        //[XmlElement]
        public string EI { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        //[XmlElement]
        public string COMMENT { get; set; }
        /// <summary>
        /// 是否使用规则 如无规则，返回0。如果使用了规则，则EI,COMMENT,退改签政策需要参考RuleFile对象信息。
        /// </summary>
        //[XmlElement]
        public int? RULE_ID { get; set; }
        /// <summary>
        /// 每段运价的权重，当一个输入符合多个计算规则时，使用权重最重的规则计算。RT/MT，将组合后的每段运价的权重相加，并且以最重的那条运价为准
        /// </summary>
        //[XmlElement]
        public int? WEIGHTING { get; set; }
        /// <summary>
        /// 退票是否减FdPrice的标记位 0：表示否 1：表示是
        /// </summary>
        //[XmlElement]
        public string ReduceFdPriceFlag { get; set; }
        /// <summary>
        /// 退票金额
        /// </summary>
        //[XmlElement]
        public float? refundedAm { get; set; }
        /// <summary>
        /// 退票金额表示是否是用百分比 0：表示否 1：表示是
        /// </summary>
        //[XmlElement]
        public string refundedAmPer { get; set; }
        /// <summary>
        /// 是否可退票  0：表示否 1：表示是
        /// </summary>
        //[XmlElement]
        public string refundedFlag { get; set; }
        /// <summary>
        /// 改期金额
        /// </summary>
        //[XmlElement]
        public float? rescheduledAm { get; set; }
        /// <summary>
        /// 改期金额表示是否是用百分比 0：表示否 1：表示是
        /// </summary>
        //[XmlElement]
        public string rescheduledAmPer { get; set; }
        /// <summary>
        /// 是否可改期  0：表示否 1：表示是
        /// </summary>
        //[XmlElement]
        public string rescheduledFlag { get; set; }
        /// <summary>
        /// 改签金额
        /// </summary>
        //[XmlElement]
        public float? changeAirLineAm { get; set; }
        /// <summary>
        /// 改签金额表示是否是用百分比 0：表示否 1：表示是
        /// </summary>
        //[XmlElement]
        public string changeAirLineAmPer { get; set; }
        /// <summary>
        /// 是否可改签  0：表示否 1：表示是
        /// </summary>
        //[XmlElement]
        public string changeAirLineFlag { get; set; }
        /// <summary>
        /// 客票有效期(最长停留时间)
        /// </summary>
        //[XmlElement]
        public string validityPeriod { get; set; }
        /// <summary>
        /// 最短停留时间
        /// </summary>
        //[XmlElement]
        public string minStay { get; set; }
        /// <summary>
        /// 行李重量
        /// </summary>
        //[XmlElement]
        public string baggageWeight { get; set; }
        /// <summary>
        /// Y舱的金额
        /// </summary>
        //[XmlElement]
        public string yPrice { get; set; }
        /// <summary>
        /// 舱等与Y舱的比值
        /// </summary>
        //[XmlElement]
        public float? ClassWithY { get; set; }
        /// <summary>
        /// 舱等与Y舱的比值的标记位 0：表示固定价格 1：表示是百分比 2：表示直减
        /// </summary>
        //[XmlElement]
        public string classWithYFlag { get; set; }
        /// <summary>
        /// 规则的比值
        /// </summary>
        //[XmlElement]
        public float? RuleAm { get; set; }
        /// <summary>
        /// 规则的直减值
        /// </summary>
        //[XmlElement]
        public float? RuleDisAm { get; set; }
        /// <summary>
        /// 规则的比值的标记位 0：表示固定价格 1：表示是百分比 2：表示直减
        /// </summary>
        //[XmlElement]
        public string ruleAmFlag { get; set; }
        /// <summary>
        /// 大客户的比值
        /// </summary>
        //[XmlElement]
        public float? KamsAm { get; set; }
        /// <summary>
        /// 大客户的比值表示是否是用百分比 0：表示固定价格 1：表示是百分比 2：表示直减
        /// </summary>
        //[XmlElement]
        public string kamsAmFlag { get; set; }
        /// <summary>
        /// 退改签对象
        /// </summary>
        //[XmlElement]
        public  List<CabinEiVO> cabinEiList { get; set; }
        /// <summary>
        /// 基础价格
        /// </summary>

        public string baseClassFullPrice { get; set; }
        public string owFdPrice { get; set; }
        public string FD_PRICE { get; set; }
        public string OUT_POLICY_PRICE { get; set; }
        public string commission { get; set; }
        public string agentFeeCper { get; set; }
        public string agentFeeZper { get; set; }
        public string agentFeeCam { get; set; }
        public string agentFeeZam { get; set; }
        public string giftId { get; set; }
        public string TG_PRICE { get; set; }
        public string TG_RULEID { get; set; }
        public string TG_OWNCREDIT { get; set; }
        public string TG_USECREDIT { get; set; }
        public string policy { get; set; }
        public string fareInfoTp { get; set; }
        public string promoCode { get; set; }
        public string buyADTFlag { get; set; }
        public string POINTS_NUMBER { get; set; }
        public string member_level { get; set; }

        #region 
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfa { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_bcfp { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfb { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfowfd { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfc { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfd { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfe { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccff { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfg { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfh { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfi { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfj { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfk { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfl { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfm { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfn { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfo { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfp { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfq { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfr { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfs { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccft { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfu { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfv { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfw { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlArrayItem]
        //public List<CabinEiVO> sg_fccfei { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfx { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfy { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfz { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfa1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfb1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfc1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfd1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfe1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccff1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfg1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfh1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfi1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfj1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfk1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfl1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfm1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfn1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfo1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfp1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfq1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfr1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfs1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccft1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfu1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfv1 { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string buyADTFlag { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string points_number { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string member_level { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string b2t_commission { get; set; }
        #endregion
    }
}
