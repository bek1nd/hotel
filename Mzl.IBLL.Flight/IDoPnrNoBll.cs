using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Flight
{
    /// <summary>
    /// PNR定位功能
    /// </summary>
    public interface IDoPnrNoBll
    {
        string DoPnrNo(int orderid, string oid);
    }
}
