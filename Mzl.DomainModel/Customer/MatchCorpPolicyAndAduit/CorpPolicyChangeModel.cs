using System.ComponentModel;

namespace Mzl.DomainModel.Customer.MatchCorpPolicyAndAduit
{
    public class CorpPolicyChangeModel
    {
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }

        /// <summary>
        /// 航班前后XX分钟内是否最低价格政策判断
        /// </summary>
        [Description("航班前后XX分钟内是否最低价格政策判断")]
        public string ViolateNPolicyValL { get; set; }

        public string ViolateNPolicyValLDesc
            => (string.IsNullOrEmpty(ViolateNPolicyValL) || ViolateNPolicyValL == "-1") ? "" : string.Format("需购买出发时间前后{0}分钟内最低航班", ViolateNPolicyValL);

        /// <summary>
        ///提前预定判断政策
        /// </summary>
        [Description("提前预定判断政策")]
        public string ViolateNPolicyValT { get; set; }

        public string ViolateNPolicyValTDesc
        {
            get
            {
                if (string.IsNullOrEmpty(ViolateNPolicyValT))
                    return string.Empty;
                if (ViolateNPolicyValT == "-1")
                    return string.Empty;
                return string.Format("需提前{0}天以上购买航班", ViolateNPolicyValT);
            }
        }

        /// <summary>
        /// 折扣限制政策判断
        /// </summary>
        [Description("折扣限制政策判断")]
        public string ViolateNPolicyValR { get; set; }

        public string ViolateNPolicyValRDesc
        {
            get
            {
                if (string.IsNullOrEmpty(ViolateNPolicyValR))
                    return string.Empty;
                if (ViolateNPolicyValR == "-1")
                    return string.Empty;
                return string.Format("需购买折扣低于{0}的航班", ViolateNPolicyValR);
            }
        }

        /// <summary>
        /// 仓等限制政策判断
        /// </summary>
        [Description("仓等限制政策判断")]
        public string ViolateNPolicyValY { get; set; }

        public string ViolateNPolicyValYDesc => string.IsNullOrEmpty(ViolateNPolicyValY)
            ? ""
            : ("需购买" +
               (ViolateNPolicyValY == "Y"
                   ? "经济舱"
                   : ViolateNPolicyValY == "C" ? "公务舱" : "头等舱"));

        /// <summary>
        /// 购买保险限制
        /// </summary>
        [Description("购买保险限制")]
        public string ViolateNPolicyValI { get; set; }

        public string ViolateNPolicyValIDesc
            => string.IsNullOrEmpty(ViolateNPolicyValI) ? "" : (ViolateNPolicyValI == "T" ? "允许购买保险" : "不许购买保险");



        /// <summary>
        /// 火车快车席别最高限制
        /// </summary>
        [Description("火车快车席别最高限制")]
        public string ViolateTPolicyValQ { get; set; }

        public string ViolateTPolicyValQDesc
            => string.IsNullOrEmpty(ViolateTPolicyValQ) ? "" : string.Format("快车席别最高限制为{0}", ViolateTPolicyValQ);

        /// <summary>
        /// 普车/其他最高限制
        /// </summary>
        [Description("普车/其他最高限制")]
        public string ViolateTPolicyValM { get; set; }

        public string ViolateTPolicyValMDesc
            => string.IsNullOrEmpty(ViolateTPolicyValM) ? "" : string.Format("普车/其他最高限制为{0}", ViolateTPolicyValM);

        /// <summary>
        /// 最高卧铺限制
        /// </summary>
        [Description("最高卧铺限制")]
        public string ViolateTPolicyValS { get; set; }

        public string ViolateTPolicyValSDesc
            =>
                string.IsNullOrEmpty(ViolateTPolicyValS)
                    ? ""
                    : string.Format("最高卧铺限制为{0}", (ViolateTPolicyValS == "99" ? "不可乘坐卧铺" : ViolateTPolicyValS));

    }
}
