using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.Factory
{
    public interface IBaseBLLFactory<out T> where T : class
    {
        T CreateBllObj();
        T CreateSampleBllObj();
    }
}
