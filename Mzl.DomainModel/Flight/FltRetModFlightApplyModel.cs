using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpDepartment;

namespace Mzl.DomainModel.Flight
{
    public class FltRetModFlightApplyModel
    {
        public int Rmid { get; set; }

        public int Pid { get; set; }
        /// <summary>
        /// 乘机人
        /// </summary>
        public FltPassengerModel PassengerModel { get; set; }
        /// <summary>
        /// 乘机人Id对应的联系人id
        /// </summary>
        public int? ContactId { get; set; }
        /// <summary>
        /// 乘机人对应的客户信息
        /// </summary>
        public CustomerModel PassengerCustomer { get; set; }
        /// <summary>
        /// 乘机人对应的部门信息
        /// </summary>
        public CorpDepartmentModel PassengerDepartment { get; set; }

        public int Sequence { get; set; }

        public string FlightNo { get; set; }

        public DateTime? TackoffTime { get; set; }

        public string OrderStatus { get; set; }

        public string Oid { get; set; }

        public string DisposeResult { get; set; }

        public DateTime? DisposeTime { get; set; }
        /// <summary>
        /// 原订单票号
        /// </summary>
        public string TicketNo { get; set; }
        /// <summary>
        /// 改签订单票号
        /// </summary>
        public string ModTicketNo { get; set; }

        public int? RefundId { get; set; }

        public string Dport { get; set; }
        public string DportName { get; set; }
        public string DportCity { get; set; }

        public string Aport { get; set; }
        public string AportName { get; set; }
        public string AportCity { get; set; }

        public DateTime? ArrivalsTime { get; set; }

        public string Class { get; set; }
        public string ClassName { get; set; }

        public decimal? SalePrice { get; set; }

        public decimal? FacePrice { get; set; }

        public decimal? AuditPrice { get; set; }

        public string PolicyDesc { get; set; }

        public string PolicyId { get; set; }

        public int? ChoiceReasonId { get; set; }
        public string ChoiceReason { get; set; }

        public string RecordNo { get; set; }
    }
}
