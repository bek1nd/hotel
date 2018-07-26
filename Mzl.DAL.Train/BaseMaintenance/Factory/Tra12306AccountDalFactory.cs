using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DAL.Train.BaseMaintenance.DAL;
using Mzl.IDAL.Train.BaseMaintenance.DAL;
using Mzl.IDAL.Train.BaseMaintenance.Factory;

namespace Mzl.DAL.Train.BaseMaintenance.Factory
{
    public class Tra12306AccountDalFactory : ITra12306AccountDalFactory
    {
        public Mzl.IDAL.Train.BaseMaintenance.DAL.ITra12306AccountDal CreateSampleDalObj()
        {
            return new Mzl.DAL.Train.BaseMaintenance.DAL.Tra12306AccountDal();
        }
    }
}
