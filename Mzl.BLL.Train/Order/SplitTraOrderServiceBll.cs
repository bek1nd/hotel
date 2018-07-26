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
    public class SplitTraOrderServiceBll : BaseServiceBll, ISplitTraOrderServiceBll
    {
        private readonly ITraOrderDal _traOrderDal;
        private readonly ITraOrderStatusDal _traOrderStatusDal;
        private readonly ITraOrderDetailDal _traOrderDetailDal;
        private readonly ITraPassengerDal _traPassengerDal;
        private readonly ITraOrderLogDal _traOrderLogDal;


        public SplitTraOrderServiceBll(ITraOrderDal traOrderDal, ITraOrderStatusDal traOrderStatusDal,
    ITraOrderDetailDal traOrderDetailDal, ITraPassengerDal traPassengerDal,
     ITraOrderLogDal traOrderLogDal)
        {
            _traOrderDal = traOrderDal;
            _traOrderDetailDal = traOrderDetailDal;
            _traPassengerDal = traPassengerDal;
            _traOrderStatusDal = traOrderStatusDal;
            _traOrderLogDal = traOrderLogDal;
        }
        public List<int> SplitOrder(int orderId, string oid)
        {
            //获取原始订单
            TraOrderEntity copyTraOrderEntity = _traOrderDal.Find<TraOrderEntity>(orderId);
            if (copyTraOrderEntity == null)
            {
                throw new Exception("复制来源订单异常");
            }
            if (string.IsNullOrEmpty(copyTraOrderEntity.OrderFrom) || copyTraOrderEntity.OrderFrom != "Hand")
            {
                throw new Exception("该订单不是手动导单不能拆单！");
            }
            //获取原行程信息
            List<TraOrderDetailEntity> copyTraOrderDetailEntities =
            _traOrderDetailDal.Query<TraOrderDetailEntity>(n => n.OrderId == orderId, true)
              .ToList();
         
            //原始订单乘车人信息
                List<int> odIdList = copyTraOrderDetailEntities.Select(n => n.OdId).ToList();
            List<TraPassengerEntity> copyTraPassengerEntities =
                _traPassengerDal.Query<TraPassengerEntity>(n => odIdList.Contains(n.OdId), true).ToList();
            List<string> nameList = copyTraPassengerEntities.Select(n => n.Name).Distinct().ToList();
      
            if (nameList.Count <= 1)
            {
                throw new Exception("该订单只有一个乘车人不能拆单！");
            }
            List<int> orderIdList = new List<int>();
            foreach (string name in nameList)
            {
                List<TraPassengerEntity> pList = copyTraPassengerEntities.FindAll(n => n.Name == name);
                List<int> oList = pList.Select(n => n.OdId).ToList();
                List<TraOrderDetailEntity> tList = copyTraOrderDetailEntities.FindAll(n => oList.Contains(n.OdId)).ToList();

                int newOrderId = AddOrder(pList, tList, copyTraOrderEntity, oid);
                orderIdList.Add(newOrderId);

            }
            return orderIdList;
            #region
            ////原始订单信息映射复制新实体
            //TraOrderEntity traOrderEntity = Mapper.Map<TraOrderEntity, TraOrderEntity>(copyTraOrderEntity);
            //List<TraOrderDetailEntity> traOrderDetailEntities =
            //    Mapper.Map<List<TraOrderDetailEntity>, List<TraOrderDetailEntity>>(copyTraOrderDetailEntities);
            //List<TraPassengerEntity> traPassengerEntities =
            //    Mapper.Map<List<TraPassengerEntity>, List<TraPassengerEntity>>(copyTraPassengerEntities);
            //if (copyPidList == null || copyPidList.Count == 0 )
            //{
            //    throw new Exception("未找到乘车人不能拆单");
            //}
            //if (copyPidList.Count == 1)
            //{
            //    throw new Exception("只有一个乘车人不能拆单");
            //}
            ////拆单插入订单
            //foreach (var p in traPassengerEntities)
            //{

            //    //复制新实体 新增订单
            //    traOrderEntity.CreateOid = copyTraOrderModel.CreateOid;
            //    traOrderEntity.CopyType = copyTraOrderModel.CopyType;
            //    traOrderEntity.PayAmount = copyTraOrderModel.PayAmount;
            //    traOrderEntity.TotalMoney = copyTraOrderModel.PayAmount;
            //    traOrderEntity.PrintProcurementTime = null;
            //    traOrderEntity.IsNeedPrintTime = null;
            //    //订单表插入
            //    traOrderEntity = _traOrderDal.Insert(traOrderEntity);
            //    //乘车人插入
            //    _traPassengerDal.Insert(p);
            //}
            ////插入行程
            //foreach (var detail in traOrderDetailEntities)
            //{
            //    detail.OrderId = traOrderEntity.OrderId;
            //    List<TraPassengerEntity> thisTravelPassengerList =
            //        traPassengerEntities.FindAll(n => n.OdId == detail.OdId);
            //    detail.ServiceFee = thisTravelPassengerList.Sum(n => (n.ServiceFee ?? 0)) / thisTravelPassengerList.Count;
            //    detail.FacePrice = thisTravelPassengerList.Sum(n => (n.FacePrice ?? 0)) / thisTravelPassengerList.Count;
            //    detail.TotalPrice = (detail.ServiceFee + detail.FacePrice) * (detail.TicketNum ?? 0);
            //    //行程表插入
            //    TraOrderDetailEntity traOrderDetailEntity = _traOrderDetailDal.Insert(detail);
            //}
            #endregion

        }

        private int AddOrder(List<TraPassengerEntity> pList1, List<TraOrderDetailEntity> tList1, TraOrderEntity order1,string oid)
        {
            List<TraOrderDetailEntity> tList =
                Mapper.Map<List<TraOrderDetailEntity>, List<TraOrderDetailEntity>>(tList1);
            List<TraPassengerEntity> pList =
                Mapper.Map<List<TraPassengerEntity>, List<TraPassengerEntity>>(pList1);
            TraOrderEntity order = Mapper.Map<TraOrderEntity, TraOrderEntity>(order1);

            //重新计算订单金额，创建人重新赋值，创建时间重新赋值。。。。，一些时间置NULL
            order.CreateOid = oid;
            order.PayAmount = pList.Sum(n => (n.ServiceFee ?? 0) + (n.FacePrice ?? 0));
            order.TotalMoney = order.PayAmount??0;
            order.PrintProcurementTime = null;
            order.CreateTime = DateTime.Now;
            order.IsNeedPrintTime = null;

            //插入订单信息
            TraOrderEntity newOrder = _traOrderDal.Insert(order);
            //插入订单状态信息
            TraOrderStatusEntity orderStatusEntity = new TraOrderStatusEntity();
            orderStatusEntity.OrderId = newOrder.OrderId;
            orderStatusEntity.ProccessStatus = 64;//设置处理中
            _traOrderStatusDal.Insert(orderStatusEntity);

            foreach (var detail in tList)
            {
                detail.OrderId = newOrder.OrderId;
                //查询行程表中OdId关联旅客表的旅客信息
                TraPassengerEntity Passengers = pList.Find(n => n.OdId == detail.OdId);

                //修改原订单中的价格赋值在行程表
                detail.ServiceFee = Passengers.ServiceFee ?? 0 ;
                detail.FacePrice = Passengers.FacePrice ?? 0 ;
                detail.TicketNum = 1;
                detail.TotalPrice = (detail.ServiceFee + detail.FacePrice);
                //插入行程信息
                TraOrderDetailEntity traOrderDetailEntity = _traOrderDetailDal.Insert(detail);

                //乘客信息
                Passengers.OdId = traOrderDetailEntity.OdId;
                _traPassengerDal.Insert(Passengers);
            }


            _traOrderLogDal.Insert<TraOrderLogEntity>(new TraOrderLogEntity()
            {
                OrderId = newOrder.OrderId,
                CreateOid = newOrder.CreateOid,
                CreateTime = DateTime.Now,
                LogType = "OI",
                LogContent = "拆分订单，来源订单号：" + order1.OrderId,
            });

            return newOrder.OrderId;
        }
    }
}
