using Mzl.DomainModel.Train.Order;
using Mzl.IBLL.Train.Order.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.IDAL.Train.Order.DAL;
using Mzl.EntityModel.Train.Order;
using Mzl.Common.AutoMapperHelper;
using Mzl.EntityModel.Train.Server;
using Mzl.IDAL.Train.Server.DAL;

namespace Mzl.BLL.Train.Order.BLL
{
    public class TraModOrderBLL : ITraModOrderBLL<TraModOrderModel>, ITraOrderListBLL<TraModOrderListDataModel>
    {
        private readonly ITraModOrderDAL _dal;

        public TraModOrderBLL(ITraModOrderDAL dal)
        {
            _dal = dal;
        }

        public int AddModOrder(TraModOrderModel t)
        {
            TraModOrderEntity modOrderEntity = Mapper.Map<TraModOrderModel, TraModOrderEntity>(t);
            if (modOrderEntity == null)
                throw new Exception("添加火车改签订单失败！");
            return _dal.Insert(modOrderEntity);
        }

        public TraModOrderModel GetModOrderBycorderid(int corderid)
        {
            TraModOrderEntity modOrderEntity = _dal.Query(corderid);
            if (modOrderEntity == null)
                return null;
            return Mapper.Map<TraModOrderEntity, TraModOrderModel>(modOrderEntity);
        }

        public List<TraModOrderModel> GetModOrderByOrderId(int orderid)
        {
            List<TraModOrderEntity> modOrderEntitys = _dal.GetTraOrderListExpression(
                n => n.OrderId == orderid && !string.IsNullOrEmpty(n.OrderStatus));
            if (modOrderEntitys == null)
                return null;
            return Mapper.Map < List<TraModOrderEntity>, List<TraModOrderModel>>(modOrderEntitys);
        }

        public List<TraModOrderModel> GetModOrderByOrderId(List<int> orderidList)
        {
            List<TraModOrderEntity> modOrderEntitys = _dal.GetTraOrderListExpression(
                n => n.OrderId.HasValue && orderidList.Contains(n.OrderId.Value) && !string.IsNullOrEmpty(n.OrderStatus));
            if (modOrderEntitys == null)
                return null;
            List<TraModOrderModel> traModOrderModels= Mapper.Map<List<TraModOrderEntity>, List< TraModOrderModel >> (modOrderEntitys);
            return traModOrderModels;
        }

        public int UpdateModOrder(TraModOrderModel t,string[] paramsStr=null)
        {
            TraModOrderEntity modOrderEntity = Mapper.Map<TraModOrderModel, TraModOrderEntity>(t);
            if (modOrderEntity == null)
                throw new Exception("修改火车改签订单失败！");
            return _dal.Update(modOrderEntity, paramsStr);
        }

        public List<TraModOrderListDataModel> GetOrderListByPage(TraOrderListQueryModel queryModel, ref int totalCount)
        {
            throw new NotImplementedException();
        }

        public List<TraModOrderListDataModel> GetTraModOrderByPageList(TraModOrderListQueryModel queryModel, ref int totalCount)
        {
            TraModOrderListQueryEntity query = Mapper.Map<TraModOrderListQueryModel, TraModOrderListQueryEntity>(queryModel);
            List<TraModOrderListDataEntity> list = _dal.GetTraModOrderByPageList(query, ref totalCount);
            if (list == null)
                return null;
            return Mapper.Map<List<TraModOrderListDataEntity>, List<TraModOrderListDataModel>>(list);
        }

        public TraModOrderModel GetTraModOrderByOrderIdAndTicketNo(int orderId, List<string> ticketNoList)
        {
            TraModOrderEntity  traModOrderEntity= _dal.GetTraModOrderByOrderIdAndTicketNo(orderId, ticketNoList);
            if (traModOrderEntity == null)
                return null;
            return Mapper.Map<TraModOrderEntity, TraModOrderModel>(traModOrderEntity);
        }

        public List<TraModOrderModel> GetTraModOrderListByOrderIdAndTicketNo(int orderId, List<string> ticketNoList)
        {
            List< TraModOrderEntity> traModOrderEntities = _dal.GetTraModOrderListByOrderIdAndTicketNo(orderId, ticketNoList);
            if (traModOrderEntities == null)
                return null;
            return Mapper.Map<List<TraModOrderEntity>, List<TraModOrderModel>>(traModOrderEntities);
        }
    }
}
