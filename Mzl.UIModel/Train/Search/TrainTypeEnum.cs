using Mzl.DomainModel.Train.Server;
using Mzl.UIModel.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Search
{
   public static class TrainTypeEnum
    {
        public static TraTravelInfoDetailViewModel QTXB { get { return new TraTravelInfoDetailViewModel("", "其他席别", 1); } }
        public static TraTravelInfoDetailViewModel DW { get { return new TraTravelInfoDetailViewModel("F", "动卧", 2); } }
        public static TraTravelInfoDetailViewModel SWZ { get { return new TraTravelInfoDetailViewModel("9", "商务座", 3); } }
        public static TraTravelInfoDetailViewModel TDZ { get { return new TraTravelInfoDetailViewModel("P", "特等座", 4); } }
        public static TraTravelInfoDetailViewModel YDZ { get { return new TraTravelInfoDetailViewModel("M", "一等座", 5); } }
        public static TraTravelInfoDetailViewModel EDZ { get { return new TraTravelInfoDetailViewModel("O", "二等座", 6); } }
        public static TraTravelInfoDetailViewModel GJRW { get { return new TraTravelInfoDetailViewModel("6", "高级软卧", 7); } }
        public static TraTravelInfoDetailViewModel RW { get { return new TraTravelInfoDetailViewModel("4", "软卧", 8); } }
        public static TraTravelInfoDetailViewModel YW { get { return new TraTravelInfoDetailViewModel("3", "硬卧", 9); } }
        public static TraTravelInfoDetailViewModel RZ { get { return new TraTravelInfoDetailViewModel("2", "软座", 10); } }
        public static TraTravelInfoDetailViewModel YZ { get { return new TraTravelInfoDetailViewModel("1", "硬座", 11); } }
        public static TraTravelInfoDetailViewModel WZ { get { return new TraTravelInfoDetailViewModel("", "无座", 12); } }
        



    }
}
