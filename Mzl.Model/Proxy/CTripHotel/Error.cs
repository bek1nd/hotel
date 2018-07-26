using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel
{
    public class Error
    {
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public string SeverityCode { get; set; }
        public Object ErrorFields { get; set; }
        public string ErrorClassification { get; set; }
    }
}
