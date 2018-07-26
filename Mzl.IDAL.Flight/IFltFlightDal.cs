using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;

namespace Mzl.IDAL.Flight
{
    public interface IFltFlightDal : IBaseDal
    {
        List<T> GetFlightByOrderId<T>(int orderid, int sequencet) where T : class;
    }
}
