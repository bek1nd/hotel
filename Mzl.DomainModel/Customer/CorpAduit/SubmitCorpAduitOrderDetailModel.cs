using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.DomainModel.Customer.CorpAduit
{
    public class SubmitCorpAduitOrderDetailModel
    {
        public int OrderId { get; set; }
        public OrderSourceTypeEnum OrderType { get; set; }
    }
}
