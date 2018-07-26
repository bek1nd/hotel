using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class GetUnAvailablePassengerModel
    {
        public int TotalCount { get; set; }
        public List<GetUnAvailablePassengerDataModel> DataList { get; set; }
    }
}
