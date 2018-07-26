using Mzl.IBLL.Train.Order.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Order;
using Mzl.EntityModel.Train.Order;
using Mzl.IDAL.Train.Order.DAL;

namespace Mzl.BLL.Train.Order.BLL
{
    public class CheckSameTravelBll : ICheckSameTravelBll
    {
        private readonly ICheckSameTravelDal _checkSameTravelDal;
        public string Result { get;private set; }

        public CheckSameTravelBll(ICheckSameTravelDal checkSameTravelDal)
        {
            _checkSameTravelDal = checkSameTravelDal;
        }

        public bool CheckIsExistSameTravel(TraAddOrderModel traAddOrder)
        {
            List<DateTime> startTimeList = traAddOrder.OrderDetailList.Select(n => n.StartTime).ToList();
            List<DateTime> endTimeList = traAddOrder.OrderDetailList.Select(n => n.EndTime).ToList();

            List<string> startNameList = traAddOrder.OrderDetailList.Select(n => n.StartName).ToList();
            List<string> endNameList = traAddOrder.OrderDetailList.Select(n => n.EndName).ToList();

            List<string> nameList =
                traAddOrder.OrderDetailList.SelectMany(n => n.PassengerList).Select(n => n.Name).ToList();

            bool flag= _checkSameTravelDal.CheckIsExistSameTravel(startTimeList, endTimeList, startNameList, endNameList, nameList);
            List<int> list = _checkSameTravelDal.OrderList;
            if (list!=null&& list.Count>0)
            {
                Result = string.Concat(list.Select(n => "," + n)).Substring(1);
            }
            return flag;
        }
    }
}
