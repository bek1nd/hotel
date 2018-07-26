using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.Common
{
    public interface IDoTestApplication<T> where T : class
    {
        T Get();
    }
}
