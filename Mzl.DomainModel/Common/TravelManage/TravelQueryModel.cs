using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Base;
using Mzl.DomainModel.Flight;

namespace Mzl.DomainModel.Common.TravelManage
{
    public class TravelQueryModel : BaseOrderListQueryModel
    {
        public SearchCityAportModel AportInfo { get; set; }
        public int? ContactId { get; set; }
    }
}
