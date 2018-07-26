using Mzl.DAL.Train.Server.DAL;
using Mzl.IDAL.Train.Server.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.Factory;
using Mzl.IDAL.Train.Server.DAL;

namespace Mzl.DAL.Train.Server.Factory
{
  public  class TraInterFaceOrderServerDALFactory: ITraInterFaceOrderServerDALFactory
    {
        public ITraInterFaceOrderServerDAL CreateSampleDalObj()
        {
            return new TraInterFaceOrderServerDAL();
        }

      
    }
}
