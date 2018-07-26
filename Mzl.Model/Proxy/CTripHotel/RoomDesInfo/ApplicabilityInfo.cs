using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class ApplicabilityInfo
    {
        /// <summary>
        /// 八位二进制数字，每一位分别表示房型的适用人群条件。详情如下：
        /// 第一位为1，表示无限制；
        /// 第二位为1，表示有其他文本限制条件，详见OtherDescription节点的描述内容；
        /// 第三位为1，表示该房型适用持大陆身份证的中国人；
        /// 第四位为1，表示该房型适用香港及澳门居民；
        /// 第五位为1，表示该房型适用台湾居民；
        /// 第六位为1，表示该房型适用持中国护照的侨胞；
        /// 第七位为1，表示该房型适用驰中国签证或居留许可证的外籍人士；
        /// 第八位为1，表示该房型适用于持非中国护照的外籍人士；
        /// 备注：可能多位数为1；
        /// </summary>
        public string Applicability { get; set; }
        /// <summary>
        /// 上述Applicability节点的第二位为1时，其他限制条件见此处的文本描述
        /// </summary>
        public string OtherDescription { get; set; }
    }
}
