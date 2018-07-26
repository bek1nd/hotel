using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class AirportModel
    {
        public string AirportCode { get; set; }

        public string AirportName { get; set; }

        public string AirportEnName { get; set; }

        public int? AreaId { get; set; }

        public int? CityId { get; set; }

        public string CityCode { get; set; }

        public string IsInter { get; set; }

        public string AirportLongName { get; set; }
    }

}
