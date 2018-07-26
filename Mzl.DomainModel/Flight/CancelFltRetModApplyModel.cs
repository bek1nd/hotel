using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;

namespace Mzl.DomainModel.Flight
{
    public class CancelFltRetModApplyModel
    {
        public int Rmid { get; set; }
        public int? Cid { get; set; }
        public string UserId { get; set; }
        public string CorpId { get; set; }
        public SearchCityAportModel AportInfo { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
