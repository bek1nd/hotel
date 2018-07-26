using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 价格列表
    /// </summary>
    public class OdFareInfo
    {
        /// <summary>
        /// 价格等级
        ///分三个价格:
        ///1.最高价
        ///2.最低价
        ///3.中间价
        /// </summary>
        public string fareRank { get; set; }
        /// <summary>
        /// 舱位名称,每个舱位间用“/”隔开，对应各自航段，如“F/C/Y/C”    
        /// </summary>
        public string cabinName { get; set; }
        /// <summary>
        /// 旅客类型    
        /// </summary>
        public string passengerType { get; set; }
        /// <summary>
        /// 价格  
        /// </summary>
        public string price { get; set; }
        /// <summary>
        /// 原价，促销前的价格   
        /// </summary>
        public string pubPrice { get; set; }
        /// <summary>
        /// 促销价格   
        /// </summary>
        public string rulePrice { get; set; }
        /// <summary>
        /// 促销价标识  
        /// </summary>
        public string ruleFlag { get; set; }
        /// <summary>
        /// kams折扣价    
        /// </summary>
        public string kamsPrice { get; set; }
        /// <summary>
        /// Kams折扣价标识   
        /// </summary>
        public string kamsFlag { get; set; }
        /// <summary>
        /// 运价基础代码   
        /// </summary>
        public string fareBasis { get; set; }
        /// <summary>
        /// 旅行代码    
        /// </summary>
        public string tourCode { get; set; }
        /// <summary>
        /// 签注项    
        /// </summary>
        public string ei { get; set; }
        /// <summary>
        /// 备注项   
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// 行李重  
        /// </summary>
        public string baggageWeight { get; set; }
        /// <summary>
        /// 客票有效期   
        /// </summary>
        public string maxStay { get; set; }
        /// <summary>
        /// 最短停留    
        /// </summary>
        public string minStay { get; set; }
        /// <summary>
        /// 退票费    
        /// </summary>
        public decimal? refundedAm { get; set; }
        /// <summary>
        /// 退票费是否为百分比    
        /// </summary>
        public string refundedAmPer { get; set; }
        /// <summary>
        /// 是否可退票    
        /// </summary>
        public string refundedFg { get; set; }
        /// <summary>
        /// 改期费    
        /// </summary>
        public decimal? rescheduledAm { get; set; }
        /// <summary>
        /// 改期费是否为百分比    
        /// </summary>
        public string rescheduledAmPer { get; set; }
        /// <summary>
        /// 是否可改期    
        /// </summary>
        public string rescheduledFg { get; set; }
        /// <summary>
        /// 改签费    
        /// </summary>
        public decimal? changeAirlineAm { get; set; }
        /// <summary>
        /// 改签费是否为百分比    
        /// </summary>
        public string changeAirlineAmPer { get; set; }
        /// <summary>
        /// 是否可改签    
        /// </summary>
        public string changeAirlineFg { get; set; }
        /// <summary>
        /// 规则编号    
        /// </summary>
        public int? ruleId { get; set; }
        /// <summary>
        /// WSD奖励政策ID    
        /// </summary>
        public string giftId { get; set; }
        /// <summary>
        /// 使用集体客户规则标记    
        /// </summary>
        public string policyFg { get; set; }
        /// <summary>
        /// 佣金    
        /// </summary>
        public string commission { get; set; }
        /// <summary>
        /// 产品代码    
        /// </summary>
        public string productCode { get; set; }

        /// <summary>
        /// 是否为黑屏运价    
        /// </summary>
        public string isPublish { get; set; }

        /// <summary>
        /// 差价字段    
        /// </summary>
        public string priceDiff { get; set; }

        /// <summary>
        /// 税费    
        /// </summary>
        public double? priceTaxes { get; set; }

        /// <summary>
        /// 动态运价区分标识    
        /// </summary>
        public string fareInfoTp { get; set; }
        #region 2017-09-06新增字段
        /// <summary>
        /// 
        /// </summary>
        public string changeAirlineAmPerUsed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? changeAirlineAmUsed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string changeAirlineFgUsed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string chd_price_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<OriginalFares> originalFares { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string refundedAmPerUsed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? refundedAmUsed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string refundedFgUsed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? reschedulePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rescheduledAmPerUsed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? rescheduledAmUsed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string rescheduledFgUsed { get; set; }
        #endregion
    }
}
