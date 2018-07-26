using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.Tool
{
    public interface IGetB2TFlightNoApplication
    {
        List<string> GetB2TFlightNo(string aport, string dport);
    }
}
