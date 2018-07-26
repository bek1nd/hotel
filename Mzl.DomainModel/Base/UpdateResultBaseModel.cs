using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Base
{
    public class UpdateResultBaseModel<T>
    {
        public bool IsSuccessed { get; set; }
        public T Id { get; set; }
    }
}
