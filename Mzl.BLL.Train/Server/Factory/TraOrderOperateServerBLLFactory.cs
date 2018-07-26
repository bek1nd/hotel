using Mzl.BLL.Train.Server.BLL;
using Mzl.DAL.Train.Server.Factory;
using Mzl.DomainModel.Train.Server;
using Mzl.IBLL.Train.Server.BLL;
using Mzl.IBLL.Train.Server.Factory;
using Mzl.IDAL.Train.Server.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Train.Server.Factory
{
   public class TraOrderOperateServerBLLFactory : ITraOrderOperateServerBLLFactory
    {
        public ITraOrderOperateServerBLL<TraOrderOperateModel> CreateBllObj()
        {
            ITraOrderOperateServerDALFactory factory = new TraOrderOperateServerDALFactory();
            return new TraOrderOperateServerBLL(factory);
        }

        public ITraOrderOperateServerBLL<TraOrderOperateModel> CreateSampleBllObj()
        {
            return new TraOrderOperateServerBLL();
        }



    }
}
