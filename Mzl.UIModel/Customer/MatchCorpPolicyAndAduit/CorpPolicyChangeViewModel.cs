using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.MatchCorpPolicyAndAduit
{
    public class CorpPolicyChangeViewModel
    {
        /// <summary>
        /// 差旅政策Id
        /// </summary>
        [Description("差旅政策Id")]
        public int PolicyId { get; set; }
        /// <summary>
        /// 差旅政策名称
        /// </summary>
        [Description("差旅政策名称")]
        public string PolicyName { get; set; }
        /// <summary>
        /// 航班前后XX分钟内是否最低价格政策判断
        /// </summary>
        [Description("航班前后XX分钟内是否最低价格政策判断")]
        public string ViolateNPolicyValL { get; set; }
        public string ViolateNPolicyValLDesc { get; set; }

        /// <summary>
        ///提前预定判断政策
        /// </summary>
        [Description("提前预定判断政策")]
        public string ViolateNPolicyValT { get; set; }
        public string ViolateNPolicyValTDesc { get; set; }

        /// <summary>
        /// 折扣限制政策判断
        /// </summary>
        [Description("折扣限制政策判断")]
        public string ViolateNPolicyValR { get; set; }
        public string ViolateNPolicyValRDesc { get; set; }

        /// <summary>
        /// 仓等限制政策判断
        /// </summary>
        [Description("仓等限制政策判断")]
        public string ViolateNPolicyValY { get; set; }

        public string ViolateNPolicyValYDesc { get; set; }

        /// <summary>
        /// 购买保险限制
        /// </summary>
        [Description("购买保险限制")]
        public string ViolateNPolicyValI { get; set; }

        public string ViolateNPolicyValIDesc { get; set; }


        /// <summary>
        /// 火车快车席别最高限制
        /// </summary>
        [Description("火车快车席别最高限制")]
        public string ViolateTPolicyValQ { get; set; }

        public string ViolateTPolicyValQDesc { get; set; }

        /// <summary>
        /// 普车/其他最高限制
        /// </summary>
        [Description("普车/其他最高限制")]
        public string ViolateTPolicyValM { get; set; }

        public string ViolateTPolicyValMDesc { get; set; }

        /// <summary>
        /// 最高卧铺限制
        /// </summary>
        [Description("最高卧铺限制")]
        public string ViolateTPolicyValS { get; set; }

        public string ViolateTPolicyValSDesc { get; set; }
    }
}
