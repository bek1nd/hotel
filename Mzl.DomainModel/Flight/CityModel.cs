using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class CityModel
    {
        public int CityId { get; set; }

        public int Pid { get; set; }

        public string CityName { get; set; }

        public string CityEnName { get; set; }

        public string CityCode { get; set; }

        public int? AreaId { get; set; }
        /// <summary>
        /// 国家Id
        /// </summary>
        public int? Pcid { get; set; }

        public string PinYin { get; set; }

        public string PinYinShort { get; set; }

        public string IsInter { get; set; }
    }
}
