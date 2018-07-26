using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.DomainModel.Flight
{
    public class FltModFlightModel
    {
        public int Id { get; set; }

        public int Orderid { get; set; }

        public int? Sequence { get; set; }

        public string FlightNo { get; set; }
        public string AirlineNo => string.IsNullOrEmpty(FlightNo) ? string.Empty : FlightNo.Substring(0, 2);
        public string Class { get; set; }
        public string ClassName { get; set; }
        public string ClassEnName { get; set; }

        public string RecordNo { get; set; }

        public DateTime? TackoffTime { get; set; }
        public string TackOffDate => TackoffTime?.ToString("yyyy-MM-dd") ?? "2001-01-01";
        public string TackOffTimes => TackoffTime?.ToString("HH:mm");
        public string TackOffWeek => TackoffTime.HasValue? WeekHelper.GetWeek(TackoffTime.Value.DayOfWeek):"";
        public DateTime? ArrivalsTime { get; set; }

        public string ArrivalsDate => ArrivalsTime?.ToString("yyyy-MM-dd");
        public string ArrivalsTimes => ArrivalsTime?.ToString("HH:mm");
        /// <summary>
        /// 飞行时长
        /// </summary>
        public string FlightingTime
        {
            get
            {
                if (!TackoffTime.HasValue || !ArrivalsTime.HasValue)
                {
                    return string.Empty;
                }
                var ts = TackoffTime.Value.Subtract(ArrivalsTime.Value).Duration();
                return string.Format("{0}时{1}分", ts.Hours, ts.Minutes);
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

        public decimal? TaxFee { get; set; }

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

        public decimal? GetRate { get; set; }

        public decimal? GetRatePrice { get; set; }

        public decimal? ReturnRatePrice { get; set; }

        public string ChoiceReason { get; set; }

        public DateTime? CreateTime { get; set; }

        public string CreateOid { get; set; }

        public int? UpdateCount { get; set; }

        public int Rmid { get; set; }

        public string PType { get; set; }

        public string Airportson { get; set; }

        public string Meal { get; set; }

        public string Luggage { get; set; }

        public string BigRecordNo { get; set; }
    }
}
