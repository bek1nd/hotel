using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.EFContext;
using Mzl.IDAL.Train.Order.DAL;

namespace Mzl.DAL.Train.Order.DAL
{
    public class CheckSameTravelDal: ICheckSameTravelDal
    {
        public List<int> OrderList { get; private set; }
        public bool CheckIsExistSameTravel(List<DateTime> startTimeList, List<DateTime> endTimeList,
            List<string> startNameList, List<string> endNameList, List<string> nameList)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                DateTime beginTime = DateTime.Now.AddYears(-1);
                var select = from order in db.TraOrder.AsNoTracking()
                    join orderStatus in db.TraOrderStatus.AsNoTracking() on order.OrderId equals orderStatus.OrderId
                    join detail in db.TraOrderDetail.AsNoTracking() on order.OrderId equals detail.OrderId
                    join passenger in db.TraPassenger.AsNoTracking() on detail.OdId equals passenger.OdId
                    where orderStatus.IsCancle == 0 && order.OrderType == 1
                          && startTimeList.Any(x => x == detail.StartTime)
                          && endTimeList.Any(x => x == detail.EndTime)
                          && startNameList.Any(x => x == detail.StartName)
                          && endNameList.Any(x => x == detail.EndName)
                          && nameList.Any(x => x == passenger.Name)
                          && order.CreateTime > beginTime
                    select order.OrderId;
                //List<int> orderIdList = select.ToList();

                if (select.Any())
                {
                    OrderList = select.Distinct().ToList();
                    return true;
                }

            }

            return false;
        }
    }
}
