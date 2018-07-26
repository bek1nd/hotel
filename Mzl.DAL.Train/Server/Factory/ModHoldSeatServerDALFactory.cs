﻿using Mzl.DAL.Train.Server.DAL;
using Mzl.IDAL.Train.Server.DAL;
using Mzl.IDAL.Train.Server.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DAL.Train.Server.Factory
{
   public class ModHoldSeatServerDALFactory: IModHoldSeatServerDALFactory
    {

        public IModHoldSeatServerDAL CreateSampleDalObj()
        {
            return new ModHoldSeatServerDAL();
        }
    }
}