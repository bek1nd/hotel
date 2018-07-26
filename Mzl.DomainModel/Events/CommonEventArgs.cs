using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Events
{
    public class CommonEventArgs<T> : EventArgs
    {
        public T Obj { get; set; }
        public CommonEventArgs(T t)
        {
            this.Obj = t;
        }
    }
}
