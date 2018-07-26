using Mzl.DomainModel.Train.Order;
using Mzl.IBLL.Train.Order.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.EntityModel.Train.Order;
using Mzl.IDAL.Train.Order.DAL;
using Mzl.Common.AutoMapperHelper;

namespace Mzl.BLL.Train.Order.BLL
{
    public class TraOrderStatusBLL : ITraOrderStatusBLL<TraOrderStatusModel>
    {
        private readonly ITraOrderStatusDAL _dal;

        public TraOrderStatusBLL(ITraOrderStatusDAL dal)
        {
            _dal = dal;
        }

        public int AddOrderStatus(TraOrderStatusModel t)
        {
            return _dal.Insert(Mapper.Map<TraOrderStatusModel, TraOrderStatusEntity>(t));
        }

        public TraOrderStatusModel GetOrderStatusByOrderId(int orderid)
        {
            TraOrderStatusEntity orderStatusEntity = _dal.GetTraOrderStatusByExpression(n => n.OrderId == orderid);
            return Mapper.Map<TraOrderStatusEntity, TraOrderStatusModel>(orderStatusEntity);
        }

        public List<TraOrderStatusModel> GetOrderStatusByOrderIds(List<int> orderidList)
        {
            List<TraOrderStatusEntity> orderStatusList =
                _dal.GetTraOrderStatusListByExpression(n => orderidList.Contains(n.OrderId));
            return Mapper.Map<List<TraOrderStatusEntity>, List<TraOrderStatusModel>>(orderStatusList);
        }

        public int UpdateOrderStatus(TraOrderStatusModel t, string[] paramsStrings = null)
        {
            _dal.Update(Mapper.Map<TraOrderStatusModel, TraOrderStatusEntity>(t), paramsStrings);
            return 0;
        }
    }
}
