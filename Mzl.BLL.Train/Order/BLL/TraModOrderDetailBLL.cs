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

namespace Mzl.BLL.Train.Order.BLL
{
    public class TraModOrderDetailBLL : ITraModOrderDetailBLL<TraModOrderDetailModel>
    {
        private readonly ITraModOrderDetailDAL _dal;

        public TraModOrderDetailBLL(ITraModOrderDetailDAL dal)
        {
            _dal = dal;
        }

        public List<TraModOrderDetailModel> GetTraModOrderDetailListByCorderid(int corderid)
        {
            List<TraModOrderDetailEntity> traModOrderDetailEntities =
                _dal.GetTraOrderListExpression(n => n.CorderId == corderid);
            if (traModOrderDetailEntities == null)
                return null;
            return Mapper.Map<List<TraModOrderDetailEntity>, List<TraModOrderDetailModel>>(traModOrderDetailEntities);
        }

        public List<TraModOrderDetailModel> GetTraModOrderDetailListByCorderid(List<int> corderid)
        {
            List<TraModOrderDetailEntity> traModOrderDetailEntities =
                _dal.GetTraOrderListExpression(n => n.CorderId.HasValue && corderid.Contains(n.CorderId.Value));
            if (traModOrderDetailEntities == null)
                return null;
            return Mapper.Map<List<TraModOrderDetailEntity>, List<TraModOrderDetailModel>>(traModOrderDetailEntities);
        }

        public int AddTraModOrderDetail(List<TraModOrderDetailModel> detailList)
        {
            List<TraModOrderDetailEntity> modDetailOrderEntity = Mapper.Map<List<TraModOrderDetailModel>, List< TraModOrderDetailEntity >> (detailList);
            foreach (var detail in modDetailOrderEntity)
            {
                _dal.Insert(detail);
            }
            return 0;
        }

        public int UpdateTraModOrderDetail(List<TraModOrderDetailModel> detailList, string[] paramsStr = null)
        {
            List<TraModOrderDetailEntity> traModOrderDetailEntities =
                Mapper.Map<List<TraModOrderDetailModel>, List<TraModOrderDetailEntity>>(detailList);
            foreach (var d in traModOrderDetailEntities)
            {
                _dal.Update(d, paramsStr);
            }
            return 0;
        }
    }
}
