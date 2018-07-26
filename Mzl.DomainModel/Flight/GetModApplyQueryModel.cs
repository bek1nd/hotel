using Mzl.DomainModel.Customer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class GetModApplyQueryModel
    {
        public int? Cid { get; set; }
        public int OrderId { get; set; }
        public SearchCityAportModel AportInfo { get; set; }
        public CustomerModel Customer { get; set; }
        public List<int> CidList { get; set; }
    }
}
