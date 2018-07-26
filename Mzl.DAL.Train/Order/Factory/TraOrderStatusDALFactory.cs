using Mzl.IDAL.Train.Order.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DAL.Train.Order.DAL;
using Mzl.IDAL.Train.Order.DAL;

namespace Mzl.DAL.Train.Order.Factory
{
    public class TraOrderStatusDALFactory : ITraOrderStatusDALFactory
    {
        public ITraOrderStatusDAL CreateSampleDalObj()
        {
            return new TraOrderStatusDAL();
        }
    }
}
