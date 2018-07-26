using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.SearchHotelLowPrice
{
    public class SearchTypeEntity
    {
        public string SearchType { get; set; }
        public int HotelCount { get; set; }
        public int PageIndex { get; set; }
    }
}
