using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Train.Order.CopyOrder;
using Mzl.EntityModel.Train.Order;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.Order;
using Mzl.IDAL.Train;

namespace Mzl.BLL.Train.Order
{
    internal class CopyTraOrderServiceBll : BaseServiceBll, ICopyTraOrderServiceBll
    {
        private readonly ITraOrderDal _traOrderDal;
        private readonly ITraOrderStatusDal _traOrderStatusDal;
        private readonly ITraOrderDetailDal _traOrderDetailDal;
        private readonly ITraPassengerDal _traPassengerDal;
        private readonly ITraOrderLogDal _traOrderLogDal;

        public CopyTraOrderServiceBll(ITraOrderDal traOrderDal, ITraOrderStatusDal traOrderStatusDal,
            ITraOrderDetailDal traOrderDetailDal, ITraPassengerDal traPassengerDal,
             ITraOrderLogDal traOrderLogDal)
        {
            _traOrderDal = traOrderDal;
            _traOrderDetailDal = traOrderDetailDal;
            _traPassengerDal = traPassengerDal;
            _traOrderStatusDal = traOrderStatusDal;
            _traOrderLogDal = traOrderLogDal;
        }

        public int CopyOrder(CopyTraOrderModel copyTraOrderModel)
        {
            //原始订单
            TraOrderEntity copyTraOrderEntity = _traOrderDal.Find<TraOrderEntity>(copyTraOrderModel.CopyFromOrderId);
            if (copyTraOrderEntity == null)
            {
                throw new Exception("复制来源订单异常");
            }


            if (copyTraOrderModel.CopyType == "X")
            {
                TraOrderEntity copyTraRefundOrderEntity =
                    _traOrderDal.Query<TraOrderEntity>(
                        n => n.OrderRoot == copyTraOrderEntity.OrderId && n.OrderType == 2 && n.RefundType == 1, true).FirstOrDefault();
                if (copyTraRefundOrderEntity == null)
                    throw new Exception("不是虚退订单，不能虚退复制");
            }

            //原始订单行程信息
            List<TraOrderDetailEntity> copyTraOrderDetailEntities =
                _traOrderDetailDal.Query<TraOrderDetailEntity>(n => n.OrderId == copyTraOrderModel.CopyFromOrderId, true)
                    .ToList();
            //原始订单乘车人信息
            List<int> copyPidList = copyTraOrderModel.PassengerList.Select(n => n.Pid).ToList();
            List<TraPassengerEntity> copyTraPassengerEntities =
                _traPassengerDal.Query<TraPassengerEntity>(n => copyPidList.Contains(n.Pid)).ToList();


            //原始订单信息映射复制新实体
            TraOrderEntity traOrderEntity= Mapper.Map<TraOrderEntity, TraOrderEntity>(copyTraOrderEntity);
            List<TraOrderDetailEntity> traOrderDetailEntities =
                Mapper.Map<List<TraOrderDetailEntity>, List<TraOrderDetailEntity>>(copyTraOrderDetailEntities);
            List<TraPassengerEntity> traPassengerEntities =
                Mapper.Map<List<TraPassengerEntity>, List<TraPassengerEntity>>(copyTraPassengerEntities);

            //复制新实体 新增订单
            traOrderEntity.CreateOid = copyTraOrderModel.CreateOid;
            traOrderEntity.CopyType = copyTraOrderModel.CopyType;
            traOrderEntity.PayAmount = copyTraOrderModel.PayAmount;
            traOrderEntity.TotalMoney = copyTraOrderModel.PayAmount;
            traOrderEntity.PrintProcurementTime = null;
            traOrderEntity.IsNeedPrintTime = null;
            if (traOrderEntity.CopyType!="X")//不是虚退复制
            {
                traOrderEntity.CreateTime = DateTime.Now;
                traOrderEntity.CopyFromOrderId = copyTraOrderModel.CopyFromOrderId;
            }
            else
            {
                if (string.IsNullOrEmpty(copyTraOrderEntity.CopyType))
                {
                    traOrderEntity.CopyFromOrderId = copyTraOrderModel.CopyFromOrderId;
                }
                else
                {
                    //如果当前原始订单是虚退复制的，那么它的虚退复制订单的马甲订单号继承原始订单的马甲订单号
                    if (copyTraOrderEntity.CopyType == "X" && copyTraOrderEntity.CopyFromOrderId.HasValue)
                    {
                        traOrderEntity.CopyFromOrderId = copyTraOrderEntity.CopyFromOrderId;
                    }
                    else
                    {
                        traOrderEntity.CopyFromOrderId = copyTraOrderModel.CopyFromOrderId;
                    }
                }
            }
           
            traOrderEntity = _traOrderDal.Insert(traOrderEntity);

            TraOrderStatusEntity orderStatusEntity = new TraOrderStatusEntity();
            orderStatusEntity.OrderId = traOrderEntity.OrderId;
            orderStatusEntity.ProccessStatus = 64;//设置处理中
            _traOrderStatusDal.Insert(orderStatusEntity);


            foreach (var detail in traOrderDetailEntities)
            {
                detail.OrderId= traOrderEntity.OrderId;
                List<TraPassengerEntity> thisTravelPassengerList =
                    traPassengerEntities.FindAll(n => n.OdId == detail.OdId);

                detail.ServiceFee = thisTravelPassengerList.Sum(n => (n.ServiceFee ?? 0))/thisTravelPassengerList.Count;
                detail.FacePrice = thisTravelPassengerList.Sum(n => (n.FacePrice ?? 0)) / thisTravelPassengerList.Count;

                detail.TotalPrice = (detail.ServiceFee + detail.FacePrice)*(detail.TicketNum ?? 0);
                TraOrderDetailEntity traOrderDetailEntity = _traOrderDetailDal.Insert(detail);

                foreach (var p in traPassengerEntities)
                {
                    p.OdId = traOrderDetailEntity.OdId;
                    _traPassengerDal.Insert(p);
                }
            }

            _traOrderLogDal.Insert<TraOrderLogEntity>(new TraOrderLogEntity()
            {
                OrderId = traOrderEntity.OrderId,
                CreateOid = traOrderEntity.CreateOid,
                CreateTime = DateTime.Now,
                LogType = "OI",
                LogContent = "复制订单，来源订单号：" + copyTraOrderModel.CopyFromOrderId+",马甲订单号："+ traOrderEntity.CopyFromOrderId
            });

            //将原始订单设置为线上隐藏
            if (copyTraOrderModel.CopyType == "X")
            {
                copyTraOrderEntity.IsOnlineShow = 1;
                _traOrderDal.Update(copyTraOrderEntity, new string[] {"IsOnlineShow"});
            }

            return traOrderEntity.OrderId;
        }
    }
}
