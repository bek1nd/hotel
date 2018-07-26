using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.ElongEnum
{    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public enum EnumDrrRuleCode
    {
        None,
        /// <summary>
        /// 提前X天预订，每间晚优惠：金额M或比例N%
        /// </summary>
        [Description("提前X天预订，每间晚优惠：金额M或比例N%")]
        DRRBookAhead,
        /// <summary>
        /// 连住X晚起，每间晚优惠：金额M或比例N%
        /// </summary>
        [Description("连住X晚起，每间晚优惠：金额M或比例N%")]
        DRRStayPerRoomPerNight,
        /// <summary>
        /// 连住X晚起，最后Y晚优惠：金额M或比例N%
        /// </summary>
        [Description("连住X晚起，最后Y晚优惠：金额M或比例N%")]
        DRRStayLastNight,
        /// <summary>
        /// 连住X晚起，第Y晚及以后优惠：金额M或比例N%
        /// </summary>
        [Description("连住X晚起，第Y晚及以后优惠：金额M或比例N%")]
        DRRStayTheNightAndAfter,
        /// <summary>
        /// 每连住X晚起，最后Y晚优惠：金额M或比例N%
        /// </summary>
        [Description("每连住X晚起，最后Y晚优惠：金额M或比例N%")]
        DRRStayPerLastNight,
        /// <summary>
        /// 在店日期包含周X1……X7，订单按周末价或平日价结算
        /// </summary>
        [Description("在店日期包含周X1……X7，订单按周末价或平日价结算")]
        DRRStayWeekDay,
        /// <summary>
        /// 在周X1至X7入住，订单按周末价或平日价结算
        /// </summary>
        [Description("在周X1至X7入住，订单按周末价或平日价结算")]
        DRRCheckInWeekDay,
    }
}
