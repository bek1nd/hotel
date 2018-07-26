using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.CorpPolicy
{
    public class ChoiceReasonModel
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public string PolicyType { get; set; }
    }
}
