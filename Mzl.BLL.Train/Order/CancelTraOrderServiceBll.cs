using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Base;
using Mzl.DomainModel.Train.Order;
using Mzl.EntityModel.Train.Order;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.Order;
using Mzl.IDAL.Train;

namespace Mzl.BLL.Train.Order
{
    public class CancelTraOrderServiceBll: BaseServiceBll, ICancelTraOrderServiceBll
    {
        private readonly ITraOrderLogDal _traOrderLogDal;
        private readonly ITraOrderStatusDal _traOrderStatusDal;

        public CancelTraOrderServiceBll(ITraOrderLogDal traOrderLogDal, ITraOrderStatusDal traOrderStatusDal)
        {
            _traOrderLogDal = traOrderLogDal;
            _traOrderStatusDal = traOrderStatusDal;
        }

        public UpdateResultBaseModel<int> CancelTraOrder(CancelTraOrderModel cancelTraOrderModel)
        {
            TraOrderStatusEntity traOrderStatusEntity =
                _traOrderStatusDal.Query<TraOrderStatusEntity>(n => n.OrderId == cancelTraOrderModel.OrderId).FirstOrDefault();
            if(traOrderStatusEntity==null)
                throw new Exception("当前订单状态异常");

            if (traOrderStatusEntity.IsCancle==1)
                throw new Exception("当前订单已经取消");
            if((traOrderStatusEntity.ProccessStatus & 1)==1)
                throw new Exception("当前订单已经付款，不能取消");

            traOrderStatusEntity.IsCancle = 1;
            _traOrderStatusDal.Update(traOrderStatusEntity, new[] {"IsCancle"});

            _traOrderLogDal.Insert(new TraOrderLogEntity()
            {
                OrderId = traOrderStatusEntity.OrderId,
                CreateOid = "sys",
                CreateTime = DateTime.Now,
                LogContent = cancelTraOrderModel.CancelReason,
                LogType = "修改"
            });

            return new UpdateResultBaseModel<int>() {Id = cancelTraOrderModel.OrderId, IsSuccessed = true};
        }
    }
}
