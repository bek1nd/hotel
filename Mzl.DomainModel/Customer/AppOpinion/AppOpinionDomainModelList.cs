using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.AppOpinion
{
    public class AppOpinionDomainModelList
    {
        public int TotalCount { get; set; }
        public List<AppOpinionDomainModel> AppOpinionList { get; set; }
    }
}
