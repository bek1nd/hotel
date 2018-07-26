using Mzl.DomainModel.Train.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Enum
{
   public static class TrainTypeEnum
    {
        public static TraTravelInfoDetailModel QTXB { get { return new TraTravelInfoDetailModel("", "其他席别", 1); } }
        public static TraTravelInfoDetailModel DW { get { return new TraTravelInfoDetailModel("F", "动卧", 2); } }
        public static TraTravelInfoDetailModel SWZ { get { return new TraTravelInfoDetailModel("9", "商务座", 3); } }
        public static TraTravelInfoDetailModel TDZ { get { return new TraTravelInfoDetailModel("P", "特等座", 4); } }
        public static TraTravelInfoDetailModel YDZ { get { return new TraTravelInfoDetailModel("M", "一等座", 5); } }
        public static TraTravelInfoDetailModel EDZ { get { return new TraTravelInfoDetailModel("O", "二等座", 6); } }
        public static TraTravelInfoDetailModel GJRW { get { return new TraTravelInfoDetailModel("6", "高级软卧", 7); } }
        public static TraTravelInfoDetailModel  RW { get { return new TraTravelInfoDetailModel("4", "软卧", 8); } }
        public static TraTravelInfoDetailModel YW { get { return new TraTravelInfoDetailModel("3", "硬卧", 9); } }
        public static TraTravelInfoDetailModel RZ { get { return new TraTravelInfoDetailModel("2", "软座", 10); } }
        public static TraTravelInfoDetailModel YZ { get { return new TraTravelInfoDetailModel("1", "硬座", 11); } }
        public static TraTravelInfoDetailModel WZ { get { return new TraTravelInfoDetailModel("", "无座", 12); } }


       public static string GetTypeCodeByName(string name)
       {
           switch (name)
           {
                case "动卧":return "F";
                case "商务座": return "9";
                case "特等座": return "P";
                case "一等座": return "M";
                case "二等座": return "O";
                case "高级软卧": return "6";
                case "软卧": return "4";
                case "硬卧": return "3";
                case "软座": return "2";
                case "硬座": return "1";
                case "无座": return "1";
                default:
                   return "";
           }
          
       }

       public static List<TraTravelInfoDetailModel> GetTypeList()
       {
           return new List<TraTravelInfoDetailModel>()
           {
               QTXB,
               DW,
               SWZ,
               TDZ,
               YDZ,
               EDZ,
               GJRW,
               RW,
               YW,
               RZ,
               YZ,
               WZ
           };
       }

    }
}
