using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class FltModTicketNoModel
    {
        public int Rmid { get; set; }

        public int Sequence { get; set; }

        public string PassengerName { get; set; }

        public string AirlineNo { get; set; }

        public string TicketNo { get; set; }

        public decimal? DeductionRate { get; set; }

        public decimal? Discountprice { get; set; }

        public decimal TaxFee { get; set; }

        public decimal? OilFee { get; set; }

        public decimal TotalPrice { get; set; }

        public int Faid { get; set; }

        public int? Aid { get; set; }

        public decimal ServiceFee { get; set; }

        public decimal SalePrice { get; set; }

        public decimal? SingleTrip { get; set; }

        public string PrintSingleTrip { get; set; }

        public string TicketNoStatus { get; set; }

        public string AuditOid { get; set; }

        public DateTime? AuditTime { get; set; }

        public string IsMod { get; set; }

        public int CheckCount { get; set; }

        public string TicketNoStatusStr { get; set; }

        public string TicketNoStatusSeq { get; set; }

        public string TicketNoStatusDes { get; set; }

        public string TicketCompany { get; set; }
    }
}
