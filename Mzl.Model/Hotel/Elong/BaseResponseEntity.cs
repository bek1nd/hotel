using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mzl.EntityModel.Hotel.Elong
{
    [XmlRoot("ApiResult")]
    public class BaseResponseEntity<T>
    {
        public string Code { get; set; }
        public T Result { get; set; }
        public T Data { get; set; }
    }
}
