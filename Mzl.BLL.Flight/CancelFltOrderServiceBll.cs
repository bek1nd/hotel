using System;
using Mzl.Common.EnumHelper;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight
{
    internal class CancelFltOrderServiceBll: BaseServiceBll, ICancelFltOrderServiceBll
    {
        private readonly IFltOrderDal _fltOrderDal;
        private readonly IFltOrderLogDal _fltOrderLogDal;

        public CancelFltOrderServiceBll(IFltOrderDal fltOrderDal, IFltOrderLogDal fltOrderLogDal)
        {
            _fltOrderDal = fltOrderDal;
            _fltOrderLogDal = fltOrderLogDal;
        }

        public int CancelOnlineCorpOrder(int orderId,int cid, string remark)
        {
            FltOrderEntity orderEntity = _fltOrderDal.Find<FltOrderEntity>(orderId);
            if(orderEntity==null)
                throw new Exception("查无此订单");
            if (cid != orderEntity.Cid)
                throw new Exception("查无此订单");
            if (orderEntity.Orderstatus == "C")
            {
                throw new Exception("此订单已取消");
            }

            if ((orderEntity.ProcessStatus & 8) == 8)
                throw new Exception("此订单已经出票，不能取消");

        
            FltOrderLogEntity log = new FltOrderLogEntity()
            {
                OrderId = orderEntity.OrderId,
                LogTime = DateTime.Now,
                LogType = "修改订单"
            };

            orderEntity.Orderstatus = "C";
            orderEntity.CancelType = "C";
            orderEntity.Remark = (orderEntity.Remark ?? "") + ",客户自行取消";
            orderEntity.Oid = "sys";
            log.Remark = "操作人:" + cid + ",原因：" + remark;

            _fltOrderDal.Update(orderEntity, new string[] {"Orderstatus", "CancelType", "Remark", "Oid"});

            _fltOrderLogDal.Insert(log);

            return 0;
        }
    }
}
