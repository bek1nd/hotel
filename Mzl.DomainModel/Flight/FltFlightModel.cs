using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.DomainModel.Flight
{
    public class FltFlightModel
    {
        public int OrderId { get; set; }

        public int Sequence { get; set; }

        public string FlightNo { get; set; }
        public string AirlineNo => string.IsNullOrEmpty(FlightNo) ? string.Empty : FlightNo.Substring(0, 2);

        public string Class { get; set; }
        public string ClassName { get; set; }
        public string ClassEnName { get; set; }

        public string RecordNo { get; set; }

        public DateTime TackoffTime { get; set; }
        public string TackOffDate => TackoffTime.ToString("yyyy-MM-dd");
        public string TackOffTimes=> TackoffTime.ToString("HH:mm");
        public string TackOffWeek => WeekHelper.GetWeek(TackoffTime.DayOfWeek);

        public DateTime ArrivalsTime { get; set; }
        public string ArrivalsDate => ArrivalsTime.ToString("yyyy-MM-dd");
        public string ArrivalsTimes => ArrivalsTime.ToString("HH:mm");

        /// <summary>
        /// 飞行时长
        /// </summary>
        public string FlightingTime
        {
            get
            {
                var ts=TackoffTime.Subtract(ArrivalsTime).Duration();
                return string.Format("{0}时{1}分", ts.Hours,ts.Minutes);
            }
        }

        public string Dport { get; set; }
        public string DportName { get; set; }
        public string DportCity { get; set; }

        public string Aport { get; set; }
        public string AportName { get; set; }
        public string AportCity { get; set; }

        public decimal? Rate { get; set; }

        public decimal? FacePrice { get; set; }

        public decimal? SalePrice { get; set; }

        public decimal TaxFee { get; set; }

        public decimal? OilFee { get; set; }

        public string Remark { get; set; }

        public string IsRet { get; set; }

        public string IsMod { get; set; }

        public string IsEnd { get; set; }

        public string RetDes { get; set; }

        public string ModDes { get; set; }

        public string EndDes { get; set; }

        public int? Delayday { get; set; }

        public string IsInter { get; set; }

        public string Shortlimit { get; set; }

        public string Longlimit { get; set; }

        public string AirType { get; set; }

        public decimal GetRate { get; set; }

        public decimal GetRatePrice { get; set; }

        public decimal ReturnRatePrice { get; set; }

        public string ChoiceReason { get; set; }

        public decimal FRate { get; set; }

        public decimal? LeaveRateA { get; set; }

        public decimal? ChangeAmountA { get; set; }

        public decimal? ProfitA { get; set; }

        public decimal? LeaveRateB { get; set; }

        public decimal? ChangeAmountB { get; set; }

        public decimal? ProfitB { get; set; }

        public decimal? LeaveRateC { get; set; }

        public decimal? ChangeAmountC { get; set; }

        public decimal? ProfitC { get; set; }

        public string PlcId { get; set; }

        public decimal? StandardPrice { get; set; }

        public decimal? StandardRate { get; set; }

        public string Airportson { get; set; }

        public string PolicyLostTime { get; set; }

        public string PolicyLostWeekTime { get; set; }

        public decimal? ServiceFee { get; set; }

        public string Meal { get; set; }

        public string Luggage { get; set; }

        public decimal? DetailBasePrice { get; set; }

        public string FlightTime { get; set; }

        public int? InnerTid { get; set; }

        public decimal? InnerRate { get; set; }

        public decimal? InnerSaleRate { get; set; }

        public decimal? BaseFacePrice { get; set; }

        public string OldRecordNo { get; set; }

        public int? BaseFacePriceUpdateCount { get; set; }

        public string PolicyType { get; set; }

        public string PolicyMemo { get; set; }

        public string AgreementNumber { get; set; }

        public string TicketType { get; set; }

        public decimal? PolicyRate { get; set; }

        public decimal? PolicyFloorRate { get; set; }

        public decimal? PolicyReturnMoney { get; set; }

        public decimal? PolicyReward { get; set; }

        public decimal? PolicyServiceFee { get; set; }

        public string SharedFlightNo { get; set; }

        public string BigRecordNo { get; set; }

        public string CorpPolicy { get; set; }
        public decimal LostAmount { get; set; }
        /// <summary>
        /// 退改签政策规则
        /// </summary>
        public string Rule => string.Format("{0},{1},{2}", this.ModDes , this.RetDes , this.EndDes);
        /// <summary>
        /// 是否存在对应的B2G价格
        /// </summary>
        public bool HasB2GPrice { get; set; }

        /// <summary>
        /// 出发机场航站楼
        /// </summary>
        public string DportSon
        {
            get
            {
                if (string.IsNullOrEmpty(Airportson))
                    return "--";
                if (Airportson.Length < 2)
                    return "--";
                return Airportson.Substring(0,2);
            }
        }

        /// <summary>
        /// 抵达机场航站楼
        /// </summary>
        public string AportSon
        {
            get
            {
                if (string.IsNullOrEmpty(Airportson))
                    return "--";
                if (Airportson.Length < 4)
                    return "--";
                return Airportson.Substring(2);
            }
        }

        public string CorpPolicyType { get; set; }
        /// <summary>
        /// 该航段允许改签的乘机人Id
        /// </summary>
        public List<int> AllowModPidList { get; set; }
        /// <summary>
        /// 航段最低销售价
        /// </summary>
        public decimal? MinSalePrice { get; set; }
    }
}
