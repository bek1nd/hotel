using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel.CTripHotel.SolrModel
{
    public class Hotel
    {
        [SolrUniqueKey("id")]
        public int IdIndex { get; set; }
        [SolrField("hotelname")]
        public string NameIndex { get; set; }
        [SolrField("value")]
        public string Value { get; set; }
    }
}
