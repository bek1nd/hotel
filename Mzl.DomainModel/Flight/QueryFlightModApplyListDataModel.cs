using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.CorpAduit;
using Mzl.DomainModel.Customer.Base;

namespace Mzl.DomainModel.Flight
{
    public class QueryFlightModApplyListDataModel
    {
        /// <summary>
        /// 申请Id
        /// </summary>
        public int Rmid { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 申请对应的原订单号
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 审批单状态
        /// </summary>
        public int? AduitOrderStatus { get; set; }
        /// <summary>
        /// 审批单状态描述
        /// </summary>
        public string AuditStatus { get; set; }
        /// <summary>
        /// 改签申请状态
        /// </summary>
        public string OrderStatus { get; set; }

        public int Cid { get; set; }

        public string CorpId { get; set; }

        /// <summary>
        /// 改签状态
        /// </summary>
        public string OrderStatusDesc
        {
            get
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
                return  OrderStatus.NameToDescription<FltModApplyStatusEnum>();
            }
        }

        /// <summary>
        /// 申请明细信息
        /// </summary>
        public List<FltRetModFlightApplyModel> DetailList { get; set; }

        public List<FltFlightModel> FlightList { get; set; }
        public List<FltPassengerModel> PassengerList { get; set; }
        /// <summary>
        /// 一级审核人Id
        /// </summary>
        public int? Cpid { get; set; }
        /// <summary>
        /// 二级审核人Id
        /// </summary>
        public int? CpidSecond { get; set; }
        /// <summary>
        /// 一级审核人
        /// </summary>
        public CustomerModel FirstAuditCustomer { get; set; }
        /// <summary>
        /// 二级审核人
        /// </summary>
        public CustomerModel SecondAuditCustomer { get; set; }
    }
}
