using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class SearchFlightDetailViewModel
    {
        public string Sequence { get; set; }
        public string Class { get; set; }
        public string ClassDesc { get; set; }
        public string ClassDesc_EN { get; set; }
        public string FatherClass { get; set; }
        public string FacePrice { get; set; }
        public string SalePrice { get; set; }
        public string BaseFacePrice { get; set; }
        /// <summary>
        ///  Y C F 标准舱位
        /// </summary>
        public string BaseFacePriceType { get; set; }
        /// <summary>
        /// 剩余座位
        /// </summary>
        public string SeatNumber { get; set; }

        public string RuleDesc { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public string Rate { get; set; }
        /// <summary>
        /// 票面折扣，当有三方协议价存在
        /// </summary>
        public string FRate { get; set; }

        public string TaxFee { get; set; }
        public string OilFee { get; set; }

        public string ModDes { get; set; }
        public string EndDes { get; set; }
        public string RetDes { get; set; }

        public string isMod { get; set; }
        public string isEnd { get; set; }
        public string isRet { get; set; }
        /// <summary>
        /// 价格类型 X：三方价格 ,G:B2G价格 ,C:普通价格
        /// </summary>
        public string PriceType { get; set; }
        /// <summary>
        /// 价格说明
        /// </summary>
        public string PriceTypeDes { get; set; }
        /// <summary>
        /// 明加服务费
        /// </summary>
        public string ServiceFee { get; set; }
        /// <summary>
        /// 暗加服务费
        /// </summary>
        public string NightServicefee { get; set; }
        /// <summary>
        /// 服务费类型 2暗加 4明加 6二者都有
        /// </summary>
        public int ServiceFeeType { get; set; }
        /// <summary>
        /// 是否违规，只有企业公司才生效
        /// </summary>
        public string IsViolate { get; set; }
        /// <summary>
        /// 违反了 国内机票低价航班为出发时间前后XX分钟内最低航班
        /// </summary>
        public string ViolateNPolicyValL { get; set; }
        public string ViolateNPolicyValLDesc { get; set; }
        /// <summary>
        /// 违反了 国内机票提前预定 提前XXX天以上预定航班
        /// </summary>
        public string ViolateNPolicyValT { get; set; }
        public string ViolateNPolicyValTDesc { get; set; }
        /// <summary>
        /// 违反了 国内机票XXX折扣限制
        /// </summary>
        public string ViolateNPolicyValR { get; set; }
        public string ViolateNPolicyValRDesc { get; set; }
        /// <summary>
        /// 违反了 国内机票仓等限制
        /// </summary>
        public string ViolateNPolicyValY { get; set; }
        public string ViolateNPolicyValYDesc { get; set; }
        /// <summary>
        /// b2g政策的ruleID
        /// </summary>
        public string B2GRuleId { get; set; }
        /// <summary>
        /// b2g政策的fareBasis
        /// </summary>
        public string B2GFareBasis { get; set; }
        /// <summary>
        /// 是否包含B2G价格
        /// </summary>
        public bool HasB2GPrice { get; set; }
        /// <summary>
        /// 最低价格
        /// </summary>
        public decimal? MinSalePrice { get; set; }
    }
}
