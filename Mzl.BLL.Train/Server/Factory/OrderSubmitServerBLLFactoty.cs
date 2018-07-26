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
  
        public class OrderSubmitServerBLLFactoty : IOrderSubmitServerBLLFactoty
        {
            public IOrderSubmitServerBLL<TraOrderSubmitResponseModel> CreateBllObj()
            {
                throw new NotImplementedException();
            }


            //public IQueryTrainServerBLL<TraQueryTrainCallBackLogModel> CreateBllObj()
            //{
            //    IQueryTrainServerDALFactory factory = new QueryTrainServerDALFactory();
            //    return new QueryTrainServerBLL(factory);
            //}

            public IOrderSubmitServerBLL<TraOrderSubmitResponseModel> CreateSampleBllObj()
            {
                return new OrderSubmitServerBLL();
            }

        }
    }
