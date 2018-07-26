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
    public enum EnumSortType
    {

        /// <summary>
        /// 艺龙默认排序
        /// </summary>
        [Description("艺龙默认排序")]
        Default,

        /// <summary>
        /// 推荐星级降序
        /// </summary>
        [Description("推荐星级降序")]
        StarRankDesc,

        /// <summary>
        /// 价格升序
        /// </summary>
        [Description("价格升序")]
        RateAsc,

        /// <summary>
        /// 距离升序
        /// </summary>
        [Description("距离升序")]
        DistanceAsc,

        /// <summary>
        /// 价格降序
        /// </summary>
        [Description("价格降序")]
        RateDesc,
    }
}
