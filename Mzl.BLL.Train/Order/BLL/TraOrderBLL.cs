
using AutoMapper;
using Mzl.Common.AutoMapperHelper;
using Mzl.DAL.Train.Order.DAL;
using Mzl.DomainModel.Train.Order;
using Mzl.EntityModel.Train.Order;
using Mzl.IBLL.Train.Order.BLL;
using Mzl.IDAL.Train.BaseMaintenance.DAL;
using Mzl.IDAL.Train.Order.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Train.Order.BLL
{
    public class TraOrderBLL : ITraOrderBLL<TraOrderModel>, ITraOrderListBLL<TraOrderListDataModel>
    {
        private readonly ITraOrderDAL _dal;
        private readonly ITraOrderListDAL _orderListDal;

        public TraOrderBLL(ITraOrderDAL dal)
        {
            _dal = dal;
        }
        public TraOrderBLL(ITraOrderListDAL dal)
        {
            _orderListDal = dal;
        }
    

        public int AddOrder(TraOrderModel t)
        {
            return _dal.Insert(ConvertModelToEntity(t));
        }

        public TraOrderModel GetOrderByOrderId(int orderId)
        {
            TraOrderEntity order = _dal.Query(orderId);
            if (order == null)
                return null;
            return Mapper.Map<TraOrderEntity, TraOrderModel>(order);
        }

        public List<TraOrderModel> GetRetOrderByRootOrderId(int rootOrderid, bool isNeedCancle = false)
        {
            List< TraOrderEntity> orderList = _dal.GetTraOrderListExpression(n => n.OrderRoot == rootOrderid, isNeedCancle);
            if (orderList == null)
                return null;
            return Mapper.Map<List<TraOrderEntity>, List<TraOrderModel>>(orderList);
        }

        public List<TraOrderModel> GetRetOrderByRootOrderId(List<int> rootOrderidList)
        {
            List<TraOrderEntity> orderList =
                _dal.GetTraOrderListExpression(
                    n => n.OrderRoot.HasValue && rootOrderidList.Contains(n.OrderRoot.Value));
            if (orderList == null)
                return null;
            return Mapper.Map<List<TraOrderEntity>, List<TraOrderModel>>(orderList);
        }


        public List<TraOrderModel> GetOrderList()
        {
            throw new NotImplementedException();
        }

        public List<TraOrderListDataModel> GetOrderListByPage(TraOrderListQueryModel queryModel,ref int totalCount)
        {
            TraOrderListQueryEntity query = Mapper.Map<TraOrderListQueryModel, TraOrderListQueryEntity>(queryModel);
            //List<TraOrderListDataEntity> list = _orderListDal.GetTraOrderByPageList(query, ref totalCount);
            List<TraOrderListDataEntity> list = _orderListDal.GetTraOrderByPageListNew(query, ref totalCount);
            if (list == null)
                return null;
            return Mapper.Map<List<TraOrderListDataEntity>, List<TraOrderListDataModel>>(list);
        }

        public int UpdateOrder(TraOrderModel t,string[] paramStrings=null)
        {
            TraOrderEntity traOrderEntity = ConvertModelToEntity(t);
            return _dal.Update(traOrderEntity, paramStrings);
        }

        private TraOrderEntity ConvertModelToEntity(TraOrderModel t)
        {
            return Mapper.Map<TraOrderModel, TraOrderEntity>(t);
        }

        public List<TraOrderListDataModel> GetTraModOrderByPageList(TraModOrderListQueryModel query, ref int totalCount)
        {
            throw new NotImplementedException();
        }

        public TraOrderModel GetTraRetOrderByOrderRootAndTicketNo(int orderRoot, List<string> ticketNoList, int orderType = 2)
        {
            TraOrderEntity traOrderEntity = _dal.GetTraRetOrderByOrderRootAndTicketNo(orderRoot, ticketNoList, orderType);
            if (traOrderEntity == null)
                return null;
            return Mapper.Map<TraOrderEntity, TraOrderModel>(traOrderEntity);
        }

        public List<TraOrderModel> GetTraRetOrderListByOrderRootAndTicketNo(int orderRoot, List<string> ticketNoList,
            int orderType = 2)
        {
            List< TraOrderEntity> traOrderEntities = _dal.GetTraRetOrderListByOrderRootAndTicketNo(orderRoot, ticketNoList, orderType);
            if (traOrderEntities == null)
                return null;
            return Mapper.Map<List<TraOrderEntity>, List<TraOrderModel>>(traOrderEntities);
        }
    }
}
