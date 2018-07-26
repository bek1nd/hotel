using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.Base
{
    public class UpdateCustomerInfoModel
    {
        public int Cid { get; set; }
        public string RealName { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
