using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel
{
    public class BaseResponseEntity<T>
    {
        public string Code { get; set; }
        public T Result { get; set; }
        public T Data { get; set; }
    }
}
