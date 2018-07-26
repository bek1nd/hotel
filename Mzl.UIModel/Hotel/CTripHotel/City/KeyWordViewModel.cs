using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Hotel.CTripHotel.City
{
    public class KeyWordViewModel
    {
        public List<KeyValuePair<string, string>> Areas { get; set; }
        public List<KeyValuePair<string, string>> BusinessDistricts { get; set; }
        public List<KeyValuePair<string, string>> Brands { get; set; }
    }
}
