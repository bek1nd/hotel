using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.BLL.Train.Order.BLL;
using Mzl.DAL.Train.Order.DAL;
using Mzl.IBLL.Train.Order.BLL;

namespace Mzl.BLL.Train.Order.Factory
{
    public class CheckSameTravelBllFactory
    {
        public static ICheckSameTravelBll GetObj()
        {
            return new CheckSameTravelBll(new CheckSameTravelDal());
        }
    }
}
