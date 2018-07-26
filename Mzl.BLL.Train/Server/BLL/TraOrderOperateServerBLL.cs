using Mzl.DomainModel.Train.Server;
using Mzl.EntityModel.Train.Server;
using Mzl.IBLL.Train.Server.BLL;
using Mzl.IDAL.Train.Server.DAL;
using Mzl.IDAL.Train.Server.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Train.Server.BLL
{
  public  class TraOrderOperateServerBLL : ITraOrderOperateServerBLL<TraOrderOperateModel>
    {
        private readonly ITraOrderOperateServerDALFactory factory;


        public TraOrderOperateServerBLL(ITraOrderOperateServerDALFactory factory)
        {
            this.factory = factory;
            _dal = factory.CreateSampleDalObj();
        }

        public TraOrderOperateServerBLL()
        {
        }


        private readonly ITraOrderOperateServerDAL _dal;

      



        public int AddOrder(TraOrderOperateModel t)
        {
            return _dal.Insert(new TraOrderOperateEntity()
            {
                InterfaceId = t.InterfaceId,
                AfterOperateStatus = t.AfterOperateStatus,
                BeforOperateStatus = t.BeforOperateStatus,
                Operate = t.Operate,
                OperateTime = t.OperateTime,
                Reason = t.Reason
            });
        }

        public int UpdateOrder(TraOrderOperateModel t)
        {
            throw new NotImplementedException();
        }

        public TraOrderOperateModel GetOrderByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

      



        public IEnumerable<TraOrderOperateModel> GetOrderListByPage()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TraOrderOperateModel> GetOrderList()
        {
            throw new NotImplementedException();
        }

        public int GetOrderByOrderId(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}
