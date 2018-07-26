using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Enum;

namespace Mzl.DomainModel.Train.Order
{
    public class TraOrderListDataModel : TraOrderModel
    {
        public string CorpId { get; set; }
        public int IsCancle { get; set; }
        public int InterfaceOrderId { get; set; }
        public int ProcessStatus { get; set; }
        public List<string> PassengerNameList { get; set; }
        public List<string> TrainNoList { get; set; }
        public List<string> TravelList { get; set; }
        public List<string> StartTimeList { get; set; }

        /// <summary>
        /// 出行人
        /// </summary>
        public string PassengerNameListDesc
        {
            get
            {
                if(PassengerNameList==null)
                    return string.Empty;
                PassengerNameList = PassengerNameList.Distinct().ToList();
                string pList = PassengerNameList.Aggregate(string.Empty, (current, p) => current + ("," + p));
                if (!string.IsNullOrEmpty(pList))
                    pList = pList.Substring(1);
                return pList;
            }
        }
        /// <summary>
        /// 班次
        /// </summary>
        public string TrainNoListDesc
        {
            get
            {
                if (TrainNoList == null)
                    return string.Empty;
                TrainNoList = TrainNoList.Distinct().ToList();
                string tList = TrainNoList.Aggregate(string.Empty, (current, p) => current + ("," + p));
                if (!string.IsNullOrEmpty(tList))
                    tList = tList.Substring(1);
                return tList;
            }
        }
        /// <summary>
        /// 行程
        /// </summary>
        public string TravelListDesc
        {
            get
            {
                if (TravelList == null)
                    return string.Empty;
                TravelList = TravelList.Distinct().ToList();
                string tList = TravelList.Aggregate(string.Empty, (current, p) => current + ("," + p));
                if (!string.IsNullOrEmpty(tList))
                    tList = tList.Substring(1);
                return tList;
            }
        }
        /// <summary>
        /// 发车时间
        /// </summary>
        public string StartTimeListDesc
        {
            get
            {
                if (StartTimeList == null)
                    return string.Empty;
                StartTimeList = StartTimeList.Distinct().ToList();
                string tList = StartTimeList.Aggregate(string.Empty, (current, p) => current + ("," + p));
                if (!string.IsNullOrEmpty(tList))
                    tList = tList.Substring(1);
                return tList;
            }
        }
        public int InterfaceOrderStatus { get; set; }
        /// <summary>
        /// 线上订单状态
        /// </summary>
        public string OnlineOrderStatus
        {
            get
            {
                if (IsCancle == 1)
                    return "已取消";
                if ((ProcessStatus & 1) == 1)
                    return "出票成功";
                else
                {
                    if (InterfaceOrderStatus!=-1)
                    {
                        return InterfaceOrderStatus.ValueToDescription<OrderTypeEnum>();
                    }
                }
                return "出票中";
            }
        }

        /// <summary>
        /// 是否退票
        /// </summary>
        public bool IsRefunded { get; set; }


        /// <summary>
        /// 是否改签
        /// </summary>
        public bool IsModed { get; set; }
        /// <summary>
        /// 待确认出票的改签订单Id
        /// </summary>
        public List<int> WaitConfirmModId { get; set; }

        /// <summary>
        /// 线上显示订单
        /// </summary>
        public int ShowOnlineOrderId { get; set; }
    }
}
