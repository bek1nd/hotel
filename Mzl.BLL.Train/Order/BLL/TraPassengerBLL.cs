using Mzl.DomainModel.Train.Order;
using Mzl.IBLL.Train.Order.BLL;
using Mzl.IDAL.Train.Order.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.EntityModel.Train.Order;
using Mzl.Common.AutoMapperHelper;
using Mzl.DomainModel.Enum;

namespace Mzl.BLL.Train.Order.BLL
{
    public class TraPassengerBLL : ITraPassengerBLL<TraPassengerModel>
    {
        private readonly ITraPassengerDAL _dal;
        private readonly ITraOrderDetailDAL _orderDetailDal;

        public TraPassengerBLL(ITraPassengerDAL dal)
        {
            _dal = dal;
        }
        public TraPassengerBLL(ITraPassengerDAL dal, ITraOrderDetailDAL orderDetailDal)
        {
            _dal = dal;
            _orderDetailDal = orderDetailDal;
        }

        public int AddPassengerList(IEnumerable<TraPassengerModel> tList)
        {
            foreach (var t in tList)
            {
                var p= Mapper.Map<TraPassengerModel, TraPassengerEntity>(t);
                p.AgeType = t.AgeType.ToString();
                _dal.Insert(p);
            }
            return 0;
        }

        public List<TraPassengerModel> GetPassengerListByOrderId(int orderid)
        {
            List<TraOrderDetailEntity> traOrderDetailEntities =
                _orderDetailDal.GetTraOrderDetailListExpression(n => n.OrderId == orderid);
            if (traOrderDetailEntities == null)
                return null;
            List<int> odIdList=new List<int>();
            traOrderDetailEntities.ForEach(n=> odIdList.Add(n.OdId));
            List<TraPassengerEntity> traPassengerEntities =
                _dal.GetTraPassengerListExpression(n => odIdList.Contains(n.OdId));
            if (traPassengerEntities == null)
                return null;
            return ConvertEntityToModel(traPassengerEntities);
        }

        public List<TraPassengerModel> GetPassengerListByOdId(List<int> odIdsList)
        {
            List<TraPassengerEntity> passengerEntities =
                _dal.GetTraPassengerListExpression(n => odIdsList.Contains(n.OdId));
            if (passengerEntities == null)
                return null;
            return ConvertEntityToModel(passengerEntities);
        }

        public List<TraPassengerModel> GetPassengerListByPid(List<int> pidList)
        {
            List<TraPassengerEntity> passengerEntities =
               _dal.GetTraPassengerListExpression(n => pidList.Contains(n.Pid));
            if (passengerEntities == null)
                return null;
            return ConvertEntityToModel(passengerEntities);
        }

        public int UpdatePassengerList(List<TraPassengerModel> tList, string[] paramStrings = null)
        {
            List<TraPassengerEntity> passengerEntities = ConvertModelToEntity(tList);
            passengerEntities.ForEach(n => _dal.Update(n, paramStrings));
            return 0;
        }

        #region 私有方法

        private List<TraPassengerModel> ConvertEntityToModel(List<TraPassengerEntity> passengerEntities)
        {
            return Mapper.Map<List<TraPassengerEntity>, List<TraPassengerModel>>(passengerEntities);
        }

        private List<TraPassengerEntity> ConvertModelToEntity(List<TraPassengerModel> passengerModels)
        {
            return Mapper.Map<List<TraPassengerModel>, List<TraPassengerEntity>>(passengerModels);
        } 
        #endregion
    }
}
