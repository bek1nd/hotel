using Mzl.IDAL.Train.Order.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IDAL.Train.Order.DAL;
using Mzl.DAL.Train.Order.DAL;

namespace Mzl.DAL.Train.Order.Factory
{
    public class TraModOrderDALFactory: ITraModOrderDALFactory
    {
        public ITraModOrderDAL CreateSampleDalObj()
        {
            return new TraModOrderDAL();
        }
    }
}
