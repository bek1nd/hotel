using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class AddFltFlightViewModel
    {
        /// <summary>
        /// 航班号
        /// </summary>
        public string FlightNo { get; set; }
        /// <summary>
        /// 共享航班
        /// </summary>
        public string SharedFlightNo { get; set; }
        /// <summary>
        /// 舱位
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public DateTime TackoffTime { get; set; }
        /// <summary>
        /// 到达日期
        /// </summary>
        public DateTime ArrivalsTime { get; set; }
        /// <summary>
        /// 出发三字码
        /// </summary>
        public string Dport { get; set; }
        /// <summary>
        /// 到达三字码
        /// </summary>
        public string Aport { get; set; }
        /// <summary>
        /// 票面价扣点
        /// </summary>
        public decimal FRate { get; set; }
        /// <summary>
        /// 销售扣点
        /// </summary>
        public decimal Rate { get; set; }
        /// <summary>
        /// 票面价
        /// </summary>
        public decimal FacePrice { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        public decimal SalePrice { get; set; }
        /// <summary>
        /// 机场建设费
        /// </summary>
        public decimal TaxFee { get; set; }
        /// <summary>
        /// 燃油费
        /// </summary>
        public decimal OilFee { get; set; }

        public string IsRet { get; set; } = "F";
        public string IsMod { get; set; } = "F";
        public string IsEnd { get; set; } = "F";
        public string RetDes { get; set; }
        public string ModDes { get; set; }
        public string EndDes { get; set; }
        public string AirType { get; set; }
        public decimal ServiceFee { get; set; }
        public string Meal { get; set; }

        public string PolicyType { get; set; }

        /// <summary>
        /// 航段类型 C 普通价格 X 协议价格 G B2G价格
        /// </summary>
        public string CorpPolicyType { get; set; }

        public int Sequence { get; set; }
        /// <summary>
        /// 违反政策信息
        /// </summary>
        public string CorpPolicy { get; set; }
        /// <summary>
        /// 违反政策原因
        /// </summary>
        public string ChoiceReason { get; set; }
        /// <summary>
        /// 违反政策损失金额
        /// </summary>
        public decimal LostAmount { get; set; }
        /// <summary>
        /// 政策Id
        /// </summary>
        public string PlcId { get; set; }
        /// <summary>
        /// 航站楼
        /// </summary>
        [Required]
        [StringLength(4)]
        public string Airportson { get; set; }
        /// <summary>
        /// 是否存在B2G价格
        /// </summary>
        public bool HasB2GPrice { get; set; }
        /// <summary>
        /// 航段最低销售价
        /// </summary>
        public decimal? MinSalePrice { get; set; }
    }
}
