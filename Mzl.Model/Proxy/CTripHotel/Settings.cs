using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel
{
    /// <summary>
    /// 设置返回的酒店字段信息
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// 展示酒店页面数据的语言。接受的值：
        /// “zh-cn”(简历中文)和“en”（英文），默认“zh-cn”
        /// </summary>
        public string PrimaryLangID { get; set; }

        /// <summary>
        /// 否	返回体中包含的扩展节点/信息
        /// </summary>
        public string[] ExtendedNodes { get; set; }

        /// <summary>
        /// 用于酒店和房型增量接口,写死为F
        /// 备注：目前仅放出少数几个字段的明细，请务必置为F。
        /// </summary>
        public string IsShowChangeDetails { get; set; }
    }
}
