using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.ElongEnum
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public enum EnumProductProperty
    {

        /// <summary>
        /// 全部
        /// </summary>
        All,

        /// <summary>
        /// 今日特价
        /// </summary>
        LastMinuteSale,

        /// <summary>
        /// 限时抢购
        /// </summary>
        LimitedTimeSale,

        /// <summary>
        /// 免担保
        /// </summary>
        WithoutGuarantee,

        /// <summary>
        /// 早订省
        /// </summary>
        AdvanceBooking,

        /// <summary>
        /// 连住省
        /// </summary>
        LongStayBooking,

        /// <summary>
        /// 折扣
        /// 
        /// yeano：不知道能否使用
        /// </summary>
        DiscountSale,

        /// <summary>
        /// 钟点房
        /// </summary>
        HourlyRoom,
    }
}
