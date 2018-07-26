using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class CountryModel
    {
        public int Pcid { get; set; }

        public int ContinentId { get; set; }

        public string CName { get; set; }

        public string CEName { get; set; }

        public string CountryCode { get; set; }

        public string CountryShortCode { get; set; }

        public string Capital { get; set; }

        public string CountryFullName { get; set; }
    }
}
