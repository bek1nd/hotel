using Mzl.Common.AutoMapperHelper;
using Mzl.DAL.Train.Server.DAL;
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
    public class TraInterFaceOrderServerBLL : ITraInterFaceOrderServerBLL<TraInterFaceOrderModel>
    {
        private readonly ITraInterFaceOrderServerDALFactory factory;


        public TraInterFaceOrderServerBLL(ITraInterFaceOrderServerDALFactory factory)
        {
            this.factory = factory;
            _dal = factory.CreateSampleDalObj();
        }

        public TraInterFaceOrderServerBLL()
        {

        }



        private readonly ITraInterFaceOrderServerDAL _dal;







        public int AddOrder(TraInterFaceOrderModel t)
        {
            return _dal.Insert(new TraInterFaceOrderEntity()
            {
                OrderId = t.OrderId,
                Transactionid = t.Transactionid,
                CreateTime = t.CreateTime,
                Status = t.Status,
                OrderType = t.OrderType
            });//,               

            //
        }

        public int UpdateOrder(TraInterFaceOrderModel t, string[] properties = null)
        {
            TraInterFaceOrderEntity traInterFaceOrderEntity =
                AutoMapperHelper.DoMap<TraInterFaceOrderModel, TraInterFaceOrderEntity>(t);
            return _dal.Update(traInterFaceOrderEntity, properties);
        }

        public int GetOrderByOrderIdCount(string orderId)
        {
            return _dal.GetInterFaceOrderListByExpression(a => a.OrderId == orderId).Count();
        }

        public List<TraInterFaceOrderModel> GetTraInterFaceOrderByTransactionid(string transactionid)
        {
            List<TraInterFaceOrderEntity> traInterFaceOrderEntities =
                _dal.GetInterFaceOrderListByExpression(a => a.Transactionid == transactionid);
            if (traInterFaceOrderEntities == null)
                return null;
            return
                (List<TraInterFaceOrderModel>)
                    AutoMapperHelper.DoMapList<TraInterFaceOrderEntity, TraInterFaceOrderModel>(
                        traInterFaceOrderEntities);
        }


        public TraInterFaceOrderModel GetOrderByTransactionid(string transactionid)
        {
            var exc = _dal.GetInterFaceOrderListByExpression(a => a.Transactionid == transactionid).FirstOrDefault();
            if (exc == null)
                return null;
            return AutoMapperHelper.DoMap<TraInterFaceOrderEntity, TraInterFaceOrderModel>(exc);
        }

        public TraInterFaceOrderModel GetOrderByOrderId(string orderId)
        {
            var exc = _dal.GetInterFaceOrderListByExpression(a => a.OrderId == orderId).FirstOrDefault();
            if (exc == null)
                return null;
            return AutoMapperHelper.DoMap<TraInterFaceOrderEntity, TraInterFaceOrderModel>(exc);
        }

        public IEnumerable<TraInterFaceOrderModel> GetOrderListByPage()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TraInterFaceOrderModel> GetOrderList()
        {
            throw new NotImplementedException();
        }

        public List<TraInterFaceOrderModel> GetOrderByOrderIdList(List<string> orderIdList)
        {
            List<TraInterFaceOrderEntity> traInterFaceOrderEntities =
                _dal.GetInterFaceOrderListByExpression(a => orderIdList.Contains(a.OrderId));
            if (traInterFaceOrderEntities == null)
                return null;
            return
                (List<TraInterFaceOrderModel>)
                    AutoMapperHelper.DoMapList<TraInterFaceOrderEntity, TraInterFaceOrderModel>(
                        traInterFaceOrderEntities);
        }

        public List<TraInterFaceOrderModel> GetOrderListByStatus(List<int> statusList, DateTime queryTime)
        {
            DateTime enDateTime = Convert.ToDateTime(queryTime.ToString("yyyy-MM-dd")).AddDays(-1);
            List<TraInterFaceOrderEntity> traInterFaceOrderEntities =
                _dal.GetInterFaceOrderListByExpression(
                    a =>
                        statusList.Contains(a.Status) && a.CreateTime < queryTime &&
                        a.CreateTime > enDateTime);
            if (traInterFaceOrderEntities == null)
                return null;
            return
                (List<TraInterFaceOrderModel>)
                    AutoMapperHelper.DoMapList<TraInterFaceOrderEntity, TraInterFaceOrderModel>(
                        traInterFaceOrderEntities);
        }


    }
}
