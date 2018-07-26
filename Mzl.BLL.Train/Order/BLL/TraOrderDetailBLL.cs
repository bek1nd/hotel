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
using Mzl.EntityModel.Train.BaseMaintenance;
using Mzl.IDAL.Train.BaseMaintenance.DAL;

namespace Mzl.BLL.Train.Order.BLL
{
    public class TraOrderDetailBLL : ITraOrderDetailBLL<TraOrderDetailModel>
    {
        private readonly ITraOrderDetailDAL _dal;
        private readonly ITraAddressDAL _traAddressDal;

        public TraOrderDetailBLL(ITraOrderDetailDAL dal)
        {
            _dal = dal;
        }
        public TraOrderDetailBLL(ITraOrderDetailDAL dal, ITraAddressDAL traAddressDal)
        {
            _dal = dal;
            _traAddressDal = traAddressDal;
        }

        public int AddOrderDetail(TraOrderDetailModel t)
        {
            if (!string.IsNullOrEmpty(t.StartName))
            {
                t.StartNameId = GetAddressId(t.StartName, t.StartNameCode);
            }
            if (!string.IsNullOrEmpty(t.EndName))
            {
                t.EndNameId = GetAddressId(t.EndName, t.EndNameCode);
            }
            return _dal.Insert(Mapper.Map<TraOrderDetailModel, TraOrderDetailEntity>(t));
        }

        public List<TraOrderDetailModel> GetOrderDetailListByOrderId(List<int> orderids)
        {
            List<TraOrderDetailEntity> detailEntities =
                _dal.GetTraOrderDetailListExpression(n => orderids.Contains(n.OrderId));
            return ConvertEntityToModel(detailEntities);
        }

        public List<TraOrderDetailModel> GetOrderDetailListByOrderId(int orderid)
        {
            List<TraOrderDetailEntity> detailEntities =
             _dal.GetTraOrderDetailListExpression(n => orderid==n.OrderId);
            return ConvertEntityToModel(detailEntities);
        }

        public int UpdateOrderDetail(List<TraOrderDetailModel> t, string[] paramsStrings = null)
        {
            List<TraOrderDetailEntity> traOrderDetailEntities = ConvertModelToEntity(t);
            foreach (var traOrderDetail in traOrderDetailEntities)
            {
                _dal.Update(traOrderDetail, paramsStrings);
            }
            return 0;
        }
        #region 私有方法

        private List<TraOrderDetailModel> ConvertEntityToModel(List<TraOrderDetailEntity> detailEntities)
        {
            return Mapper.Map<List<TraOrderDetailEntity>, List<TraOrderDetailModel>>(detailEntities);
            
        }

        private List<TraOrderDetailEntity> ConvertModelToEntity(List<TraOrderDetailModel> detailModels)
        {
            return Mapper.Map<List<TraOrderDetailModel>, List<TraOrderDetailEntity>>(detailModels);
        }

        private int GetAddressId(string addressName,string addressCode)
        {
            int id = 0;
            var addressEntity = _traAddressDal.GeTraAddressByExpression(n => n.Addr_Name == addressName);
            if (addressEntity != null)
            {
                id = addressEntity.Aid;
            }
            else
            {
                id = _traAddressDal.Insert(new TraAddressEntity()
                {
                    Addr_Name = addressName,
                    Addr_Type = 0,
                    Addr_S = addressCode
                });
            }

            return id;
        }

        #endregion
    }
}
