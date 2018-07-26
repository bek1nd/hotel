using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Hotel.CTripHotel.HotelQuery
{
    public class CTripHotelSimpleReqViewModel
    {
        public string CityCode { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public IList<string> PassengerNameList { get; set; }
        public IList<string> CardNoList { get; set; }
        public string CorpId { get; set; }
        public string PolicyId { get; set; }
        public string PageIndex { get; set; }
        public string PageSize { get; set; }
        public string QuickPick { get; set; }
        public string Star { get; set; }
        public string PayType { get; set; }
        public string Facility { get; set; }
        public string Price { get; set; }
        public string Brand { get; set; }
        public string Area { get; set; }
        public string BD { get; set; }
    }
}
