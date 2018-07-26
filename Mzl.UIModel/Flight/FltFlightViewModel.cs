using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class FltFlightViewModel : FltFlightListViewModel
    {
        public string TackOffDate => base.TackOffTime.ToString("yyyy年MM月dd日");
        /// <summary>
        /// 到达时间
        /// </summary>
        public DateTime ArrivalsTime { get; set; }

        /// <summary>
        /// 时长
        /// </summary>
        public string LongTime => $"{(ArrivalsTime - base.TackOffTime).Hours}小时{(ArrivalsTime - base.TackOffTime).Minutes}分";
        /// <summary>
        /// 机型
        /// </summary>
        public string AirType { get; set; }
        /// <summary>
        /// 舱等
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 舱位
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 是否有餐食
        /// </summary>
        public bool IsMeal { get; set; }
        /// <summary>
        /// 销售价
        /// </summary>
        public decimal SalePrice { get; set; }

        public decimal TaxFee { get; set; }
        public decimal OilFee { get; set; }
        public decimal ServiceFee { get; set; }
        /// <summary>
        /// 违反差旅政策
        /// </summary>
        public string CorpPolicy { get; set; }
        /// <summary>
        /// 违反原因
        /// </summary>
        public string ChoiceReason { get; set; }
        /// <summary>
        /// 退票条件
        /// </summary>
        public string Rule { get; set; }
        /// <summary>
        /// 更改条件
        /// </summary>
        public string RetDes { get; set; }
        /// <summary>
        /// 改签规则
        /// </summary>
        public string ModDes { get; set; }
        /// <summary>
        /// 签转条件
        /// </summary>
        public string EndDes { get; set; }
        public string DportSon { get; set; }
        public string AportSon { get; set; }
        public string Dport { get; set; }
        public string Aport { get; set; }
        public decimal Rate { get; set; }
        public int Sequence { get; set; }
    }
}
