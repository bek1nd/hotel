using Mzl.Common.EnumHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper.CorpAduit;

namespace Mzl.DomainModel.Flight
{
    public class QueryFlightOrderListDataModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal PayAmount { get; set; }
        public string OrderStatus { get; set; }
        public int ProcessStatus { get; set; }
        /// <summary>
        ///  审批单状态
        /// </summary>
        public int? AduitOrderStatus { get; set; }
        /// <summary>
        /// 线上订单状态
        /// </summary>
        public string OnlineOrderStatus
        {
            get
            {
                if (OrderStatus.ToUpper() == "C")
                    return FltOrderListOrderStatusEnum.Cancel.ToDescription();

                if (AduitOrderStatus.HasValue)
                {
                    if (AduitOrderStatus.Value != (int)CorpAduitOrderStatusEnum.F &&
                        AduitOrderStatus.Value != (int)CorpAduitOrderStatusEnum.J)
                    {
                        return FltOrderListOrderStatusEnum.Aduiting.ToDescription();
                    }
                }
                if ((ProcessStatus & 8) == 8)
                    return FltOrderListOrderStatusEnum.Ticketed.ToDescription();
                if ((ProcessStatus & 8) != 8 && OrderStatus.ToUpper() == "W")
                    return FltOrderListOrderStatusEnum.WaitTicket.ToDescription();
                if ((ProcessStatus & 8) != 8 && OrderStatus.ToUpper() == "P")
                    return FltOrderListOrderStatusEnum.Ticketing.ToDescription();

                return string.Empty;
            }
        }

        public int Cid { get; set; }
        public string CorpId { get; set; }

        public List<FltFlightModel> FlightList { get; set; }
        public List<FltPassengerModel> PassengerList { get; set; }
        /// <summary>
        /// 审核状态描述
        /// </summary>
        public string AuditStatus { get; set; }
        /// <summary>
        /// 线上订单展现状态（v1.7.6之后线上订单状态）
        /// </summary>
        public string OnlineShowOrderStatus
        {
            get
            {
                if (OrderStatus.ToUpper() == "C")
                    return FltOrderListOrderStatusEnum.Cancel.ToDescription();

                if (AduitOrderStatus.HasValue)
                {
                    if (AduitOrderStatus.Value != (int) CorpAduitOrderStatusEnum.F &&
                        AduitOrderStatus.Value != (int) CorpAduitOrderStatusEnum.J)
                    {
                        return FltOrderListOrderStatusEnum.Aduiting.ToDescription();
                    }
                }
                if ((ProcessStatus & 8) == 8)
                    return FltOrderListOrderStatusEnum.Ticketed.ToDescription();
                if ((ProcessStatus & 8) != 8 && OrderStatus.ToUpper() == "W")
                    return FltOrderListOrderStatusEnum.WaitTicket.ToDescription();
                if ((ProcessStatus & 8) != 8 && OrderStatus.ToUpper() == "P")
                    return FltOrderListOrderStatusEnum.Ticketing.ToDescription();

                return string.Empty;
            }
        }

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
        /// <summary>
        /// 是否显示取消按钮
        /// </summary>
        [Description("是否显示取消按钮")]
        public bool IsShowCancelButton { get; set; }

        public string CopyType { get; set; }
        public int? CopyFromOrderId { get; set; }
        /// <summary>
        /// 线上展示订单号
        /// </summary>
        public int ShowOnlineOrderId
        {
            get
            {
                if (CopyType == "X" && CopyFromOrderId.HasValue && (this.ProcessStatus & 8) == 8 &&
                    this.OrderStatus.ToUpper() != "C")
                    return CopyFromOrderId.Value;
                return OrderId;
            }
        }

        public int ShowOnlineOrderId2 { get; set; }
    }
}
