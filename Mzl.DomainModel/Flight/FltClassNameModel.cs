using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class FltClassNameModel
    {
        public int Id { get; set; }

        public string AirlineCode { get; set; }

        public string MClass { get; set; }

        public string Class { get; set; }

        public string ClassName { get; set; }

        public string Rate { get; set; }

        public string Remark { get; set; }

        public int BaggageWeight { get; set; }

        public string ClassEnName { get; set; }
    }
}
