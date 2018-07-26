using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.CorpAduit;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpAduit;

namespace Mzl.DomainModel.Flight
{
    public class FltRetModApplyModel
    {
        public int Rmid { get; set; }

        public string OrderType { get; set; }

        public int OrderId { get; set; }

        public int Cid { get; set; }

        public DateTime CreateTime { get; set; }=DateTime.Now;

        public string ContactName { get; set; }

        public string ContactTel { get; set; }

        public string OrderStatus { get; set; } = "W";

        public string OrderStatusDesc
        {
            get
            {
                if (OrderType == "R")
                {
                    if (OrderStatus == FltRetApplyStatusEnum.C.ToString())
                    {
                        return OrderStatus.NameToDescription<FltRetApplyStatusEnum>();
                    }
                    if (AduitOrderStatus.HasValue)
                    {
                        if (AduitOrderStatus.Value != (int)CorpAduitOrderStatusEnum.F &&
                            AduitOrderStatus.Value != (int)CorpAduitOrderStatusEnum.J)
                        {
                            return FltOrderListOrderStatusEnum.Aduiting.ToDescription();
                        }
                    }
                    return OrderStatus.NameToDescription<FltRetApplyStatusEnum>();
                }
                else
                {
                    if (OrderStatus == FltModApplyStatusEnum.C.ToString())
                    {
                        return OrderStatus.NameToDescription<FltModApplyStatusEnum>();
                    }
                    if (AduitOrderStatus.HasValue)
                    {
                        if (AduitOrderStatus.Value != (int)CorpAduitOrderStatusEnum.F &&
                            AduitOrderStatus.Value != (int)CorpAduitOrderStatusEnum.J)
                        {
                            return FltOrderListOrderStatusEnum.Aduiting.ToDescription();
                        }
                    }
                    return OrderStatus.NameToDescription<FltModApplyStatusEnum>();
                }
            }
        }

        public string Remark { get; set; }

        public string CorpId { get; set; }

        public string EditOid { get; set; }

        public DateTime? EditTime { get; set; }
        private string _createOid = string.Empty;

        public string CreateOid
        {
            get
            {
                if (!string.IsNullOrEmpty(IsOnlineRefund) && IsOnlineRefund.ToUpper() == "T")
                    return "sys";
                return _createOid; 
            }
            set { _createOid = value; }
        }
        

        public string IsOnlineRefund { get; set; } = "F";

        public int? OrderRmid { get; set; }

        public string UploadUrl { get; set; }

        public string IsKeepPnr { get; set; }

        public string KeepPnrRemark { get; set; }

        public string AuditRemark { get; set; }

        public DateTime? AuditTime { get; set; }

        public string AuditOid { get; set; }

        public int? AgainNewOrderId { get; set; }

        public string OrderFrom { get; set; }

        public string OrderNumber { get; set; }

        public int? BackOrderId { get; set; }

        public decimal? OtherSystemBudget { get; set; }

        public int? ProcessStatus { get; set; }

        public int? NewRmid { get; set; }

        public int? CorpLinkId { get; set; }

        public string RefundType { get; set; }

        public decimal? ServiceFee { get; set; }

        public string LostUpLoadUrl { get; set; }

        public string LostReason { get; set; }

        public DateTime? RecoverDate { get; set; }

        public string RecoverType { get; set; }
        /// <summary>
        /// 申请明细
        /// </summary>
        public List<FltRetModFlightApplyModel> DetailList { get; set; }
        /// <summary>
        /// 申请日志
        /// </summary>
        public List<FltRetModApplyLogModel> LogList { get; set; }

        /// <summary>
        /// 改签申请行程信息
        /// </summary>
        public List<FltFlightModel> FlightList
        {
            get
            {
                List<int> sequenceList = this.DetailList.Select(n => n.Sequence).Distinct().ToList();
                List<FltRetModFlightApplyModel> d = new List<FltRetModFlightApplyModel>();
                foreach (int sequence in sequenceList)
                {
                    FltRetModFlightApplyModel dd = this.DetailList.Find(n => n.Sequence== sequence);
                    d.Add(dd);
                }
                return (from detail in d
                    select new FltFlightModel()
                    {
                        FlightNo = detail.FlightNo,
                        Dport = detail.Dport,
                        Aport = detail.Aport,
                        DportName = detail.DportName,
                        AportName = detail.AportName,
                        AportCity = detail.AportCity,
                        DportCity = detail.DportCity,
                        TackoffTime = detail.TackoffTime ?? Convert.ToDateTime("2000-01-01"),
                        ArrivalsTime = detail.ArrivalsTime ?? Convert.ToDateTime("2000-01-01"),
                        Class = detail.Class,
                        ClassName = detail.ClassName,
                        Sequence = detail.Sequence
                    }).Distinct().ToList();
            }
        }
        /// <summary>
        /// 改签乘机人信息
        /// </summary>
        public List<FltPassengerModel> PassengerList
        {
            get
            {
                List<int> pidList = this.DetailList.Select(n => n.Pid).Distinct().ToList();
                List<FltPassengerModel> pp = new List<FltPassengerModel>();

                var d = this.DetailList.FindAll(n => n.PassengerModel != null).Select(n => n.PassengerModel).Distinct().ToList();
                foreach (var pid in pidList)
                {
                    var dd=d.Find(n =>n.PId== pid);
                    pp.Add(dd);
                }

                return pp;
            }
        }


        /// <summary>
        /// 待确认信息
        /// </summary>
        public List<GetModRetApplyAuditModel> WaitConfirmList
        {
            get
            {
                List<GetModRetApplyAuditModel> list = (from detail in DetailList
                    select new GetModRetApplyAuditModel()
                    {
                        Pid = detail.Pid,
                        Name = detail.PassengerModel?.Name,
                        DportName = detail.DportName,
                        AportName = detail.AportName,
                        AportCity = detail.AportCity,
                        DportCity = detail.DportCity,
                        AuditPrice = detail.AuditPrice,
                        PolicyDesc = detail.PolicyDesc,
                        ChoiceReason = detail.ChoiceReason,
                        ChoiceReasonId = detail.ChoiceReasonId, Sequence = detail.Sequence
                    }).Distinct().ToList();
                return list;
            }

        }

        /// <summary>
        /// 申请所属客户信息
        /// </summary>
        public CustomerModel ApplyCustomer { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public string ApplyName
        {
            get
            {
                if (this.IsOnlineRefund == "T")
                    return ApplyCustomer.RealName;
                else
                    return CreateOid;
            }
        }

        /// <summary>
        /// 乘客对应的客户信息
        /// </summary>
        public List<CorpPassengerCustomerModel> PassengerCustomerList { get; set; }
        public string OrderSource { get; set; }
        /// <summary>
        /// 差旅政策Id
        /// </summary>
        public int? CorpPolicyId { get; set; }
        /// <summary>
        /// 差旅审批规则Id
        /// </summary>
        public int? CorpAduitId { get; set; }

        public string ChoiceReason
        {
            get
            {
                if (DetailList == null || DetailList.Count == 0)
                    return string.Empty;
                List<string> reasonList = new List<string>();
                foreach (var fltRetModFlightApplyModel in DetailList)
                {
                    if (!string.IsNullOrEmpty(fltRetModFlightApplyModel.ChoiceReason))
                        reasonList.Add(fltRetModFlightApplyModel.ChoiceReason);
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
                if (DetailList == null || DetailList.Count == 0)
                    return string.Empty;
                List<string> reasonList = new List<string>();
                foreach (var fltRetModFlightApplyModel in DetailList)
                {
                    if (!string.IsNullOrEmpty(fltRetModFlightApplyModel.PolicyDesc))
                        reasonList.Add(fltRetModFlightApplyModel.PolicyDesc);
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

        public decimal TotalAuditPrice
        {
            get
            {
                if (DetailList == null || DetailList.Count == 0)
                    return 0;
                decimal price = 0;
                foreach (var fltRetModFlightApplyModel in DetailList)
                {
                    if (fltRetModFlightApplyModel.AuditPrice.HasValue)
                        price += fltRetModFlightApplyModel.AuditPrice.Value;
                }
                return price;
            }
        }
        public List<string> PassengerNameList
        {
            get
            {
                if (DetailList == null || DetailList.Count == 0)
                    return null;
                List<string> reasonList = new List<string>();
                foreach (var fltRetModFlightApplyModel in DetailList)
                {
                    if (fltRetModFlightApplyModel.PassengerModel!=null)
                        reasonList.Add(fltRetModFlightApplyModel.PassengerModel.Name);
                }
                reasonList = reasonList.Distinct().ToList();
                return reasonList;
            }
        }
        public List<string> TackOffTimeList
        {
            get
            {
                if (DetailList == null || DetailList.Count == 0)
                    return null;
                List<string> reasonList = new List<string>();
                foreach (var fltRetModFlightApplyModel in DetailList)
                {
                    if (fltRetModFlightApplyModel.TackoffTime.HasValue)
                        reasonList.Add(fltRetModFlightApplyModel.TackoffTime.Value.ToString("yyyy-MM-dd"));
                }
                reasonList = reasonList.Distinct().ToList();
                return reasonList;
            }
        }
        public List<string> TravelList
        {
            get
            {
                if (DetailList == null || DetailList.Count == 0)
                    return null;
                List<string> reasonList = new List<string>();
                foreach (var fltRetModFlightApplyModel in DetailList)
                {
                    if (!string.IsNullOrEmpty(fltRetModFlightApplyModel.DportName) &&
                        !string.IsNullOrEmpty(fltRetModFlightApplyModel.AportName))
                        reasonList.Add(fltRetModFlightApplyModel.DportName + "-" + fltRetModFlightApplyModel.AportName);
                }
                reasonList = reasonList.Distinct().ToList();
                return reasonList;
            }
        }

        /// <summary>
        /// 审批单状态
        /// </summary>
        public int? AduitOrderStatus { get; set; }
        /// <summary>
        /// 审批单状态描述
        /// </summary>
        public string AuditStatus { get; set; }
        /// <summary>
        /// 审批单Id
        /// </summary>
        [Description("审批单Id")]
        public int? AduitOrderId { get; set; }
        /// <summary>
        /// 是否当前登录用户审批该订单
        /// </summary>
        [Description("是否当前登录用户审批该订单")]
        public bool IsCurrentCustomerAduitOrder { get; set; }
    }
}
