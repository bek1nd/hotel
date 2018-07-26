using Mzl.DomainModel.Train.Order;
using Mzl.IBLL.Train.Order.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Common.AutoMapperHelper;
using Mzl.EntityModel.Train.Order;
using Mzl.IDAL.Train.Order.DAL;

namespace Mzl.BLL.Train.Order.BLL
{
    public class TraOrderLogBLL: ITraOrderLogBLL<TraOrderLogModel>
    {
        private readonly ITraOrderLogDAL _dal;

        public TraOrderLogBLL(ITraOrderLogDAL dal)
        {
            _dal = dal;
        }

        public int AddLog(TraOrderLogModel t)
        {
            if (t.LogId != 0)
                return -1;
            TraOrderLogEntity tt = Mapper.Map<TraOrderLogModel, TraOrderLogEntity>(t);
            return _dal.Insert(tt);
        }

        public List<TraOrderLogModel> GetLogByOrderId(int orderId)
        {
            List<TraOrderLogEntity> logList = _dal.GetTraOrderLogListExpression(n => n.OrderId == orderId);
            if(logList==null)
                return null;
            return Mapper.Map<List<TraOrderLogEntity>, List<TraOrderLogModel>>(logList);
        }
    }
}
