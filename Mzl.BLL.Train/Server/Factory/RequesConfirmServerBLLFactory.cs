using Mzl.BLL.Train.Server.BLL;
using Mzl.DomainModel.Train.Server;
using Mzl.IBLL.Train.Server.BLL;
using Mzl.IBLL.Train.Server.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Train.Server.Factory
{
  public  class RequestConfirmServerBLLFactory : IRequestConfirmServerBLLFactory
    {
        public IRequestConfirmServerBLL<TraRequestConfirmResponseModel> CreateBllObj()
        {
            throw new NotImplementedException();
        }


        //public IQueryTrainServerBLL<TraQueryTrainCallBackLogModel> CreateBllObj()
        //{
        //    IQueryTrainServerDALFactory factory = new QueryTrainServerDALFactory();
        //    return new QueryTrainServerBLL(factory);
        //}
        
        public IRequestConfirmServerBLL<TraRequestConfirmResponseModel> CreateSampleBllObj()
        {
            return new RequestConfirmServerBLL();
        }
    }
}
