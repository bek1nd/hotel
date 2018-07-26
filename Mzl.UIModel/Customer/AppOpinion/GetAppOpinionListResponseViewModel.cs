using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.AppOpinion
{
    public class GetAppOpinionListResponseViewModel
    {
        public int TotalCount { get; set; }
        public List<AppOpinionViewModel> AppOpinionList{ get; set; }
    }
}
