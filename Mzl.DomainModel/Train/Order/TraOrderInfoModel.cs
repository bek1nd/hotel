using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CostCenter;
using Mzl.DomainModel.Customer.ProjectName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Order
{
    /// <summary>
    /// 火车订单信息模型
    /// </summary>
    public class TraOrderInfoModel
    {
        public TraOrderModel Order { get; set; }
        public TraOrderStatusModel OrderStatus { get; set; }
        public List<TraOrderDetailModel> OrderDetailList { get; set; }
        /// <summary>
        /// 客户信息
        /// </summary>
        public CustomerInfoModel CustomerInfo { get; set; }
        /// <summary>
        /// 是否违反差旅政策
        /// </summary>
        public bool IsViolatePolicy
        {
            get
            {
                if (OrderDetailList == null || OrderDetailList.Count == 0)
                    return false;
                return (OrderDetailList.Find(n => !string.IsNullOrEmpty(n.CorpPolicy)) != null
                    ? true
                    : false);
            }
        }

        public string ChoiceReason
        {
            get
            {
                if (OrderDetailList == null || OrderDetailList.Count == 0)
                    return string.Empty;
                List<string> reasonList = new List<string>();
                foreach (var detail in OrderDetailList)
                {
                    if (!string.IsNullOrEmpty(detail.ChoiceReason))
                        reasonList.Add(detail.ChoiceReason);
                }
                reasonList = reasonList.Distinct().ToList();

                string reasonStr = string.Empty;
                foreach (var s in reasonList)
                {
                    reasonStr += ";" + s;
                }

                if (!string.IsNullOrEmpty(reasonStr))
                    reasonStr = reasonStr.Substring(1);

                return reasonStr;
            }
        }
        public string CorpPolicy
        {
            get
            {
                if (OrderDetailList == null || OrderDetailList.Count == 0)
                    return string.Empty;
                List<string> reasonList = new List<string>();
                foreach (var detail in OrderDetailList)
                {
                    if (!string.IsNullOrEmpty(detail.CorpPolicy))
                        reasonList.Add(detail.CorpPolicy);
                }
                reasonList = reasonList.Distinct().ToList();

                string reasonStr = string.Empty;
                foreach (var s in reasonList)
                {
                    reasonStr += ";" + s;
                }

                if (!string.IsNullOrEmpty(reasonStr))
                    reasonStr = reasonStr.Substring(1);

                return reasonStr;
            }
        }
        public List<string> PassengerNameList
        {
            get
            {
                if (OrderDetailList == null || OrderDetailList.Count == 0)
                    return null;
                List<string> reasonList = new List<string>();
                foreach (var detail in OrderDetailList)
                {
                    if (detail.PassengerList != null)
                    {
                        foreach (var traPassengerModel in detail.PassengerList)
                        {
                            reasonList.Add(traPassengerModel.Name);
                        }
                    }
                }
                reasonList = reasonList.Distinct().ToList();
                return reasonList;
            }
        }
        public List<string> TackOffTimeList
        {
            get
            {
                if (OrderDetailList == null || OrderDetailList.Count == 0)
                    return null;
                List<string> reasonList = new List<string>();
                foreach (var detail in OrderDetailList)
                {
                    reasonList.Add(detail.StartTime.ToString("yyyy-MM-dd"));
                }
                reasonList = reasonList.Distinct().ToList();
                return reasonList;
            }
        }
        public List<string> TravelList
        {
            get
            {
                if (OrderDetailList == null || OrderDetailList.Count == 0)
                    return null;
                List<string> reasonList = new List<string>();
                foreach (var detail in OrderDetailList)
                {
                    if (!string.IsNullOrEmpty(detail.StartName) &&
                        !string.IsNullOrEmpty(detail.EndName))
                        reasonList.Add(detail.StartName + "-" + detail.EndName);
                }
                reasonList = reasonList.Distinct().ToList();
                return reasonList;
            }
        }

        /// <summary>
        /// 线上显示订单
        /// </summary>
        public int ShowOnlineOrderId { get; set; }
    }
}
