using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IDAL.Train.Order.DAL
{
    public interface ICheckSameTravelDal
    {
        bool CheckIsExistSameTravel(List<DateTime> startTimeList, List<DateTime> endTimeList, List<string> startNameList,
            List<string> endNameList, List<string> nameList);

        List<int> OrderList { get; }
    }
}
