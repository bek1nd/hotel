using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper.ElongEnum;

namespace Mzl.EntityModel.Hotel.Elong
{
    public class BaseRequestEntity<T>
    {
        public double Version { get; set; }
        public EnumLocal Local { get; set; }
        public T Request { get; set; }

    }
}
