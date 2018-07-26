using Mzl.Common.EnumHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class FltPassengerModel
    {
        public int PId { get; set; }

        public int OrderId { get; set; }
        public string Name { get; set; }

        public int CardType { get; set; }

        public string CardTypeDesc => CardType.ValueToDescription<CardTypeEnum>();

        public string CardNo { get; set; }

        public DateTime? Birthday { get; set; }

        public int? Insurance { get; set; }

        public int? InsuranceCount { get; set; }

        public int? FreeInsuranceCount { get; set; }

        public string AgeType { get; set; }

        public string Mobile { get; set; }

        public string Gender { get; set; }

        public string Nationality { get; set; }

        public DateTime? CardValidity { get; set; }

        public string Remark { get; set; }

        public string IsAvailable { get; set; }

        public int? InsCompanyId { get; set; }

        public decimal? InsLowPrice { get; set; }

        public int? InsFaId { get; set; }

        public int? InsAid { get; set; }

        public decimal? ProfitIns { get; set; }

        public int? Contactid { get; set; }
        /// <summary>
        /// 保险名称
        /// </summary>
        public string InsuranceName { get; set; }

        /// <summary>
        /// 票号信息
        /// </summary>
        public List<string> TicketNoList { get; set; }
        /// <summary>
        /// 改签票号信息
        /// </summary>
        public List<string> ModTicketNoList { get; set; }
        /// <summary>
        /// 退票票号
        /// </summary>
        public string RefundTicketNo { get; set; }
        /// <summary>
        /// 保险数量
        /// </summary>
        public int InsuranceTotalCount => (InsuranceCount ?? 0) + (FreeInsuranceCount??0);
        /// <summary>
        /// 保险展示名称
        /// </summary>
        public string InsuranceShowName
        {
            get
            {
                if (InsuranceTotalCount == 0)
                    return string.Empty;
                return InsuranceName;
            }
        }
        /// <summary>
        /// 保险展示单价
        /// </summary>
        public decimal InsuranceShowPrice
        {
            get
            {
                if (InsuranceTotalCount == 0)
                    return 0;
                if (FreeInsuranceCount > 0)
                    return 0;
                return (decimal) (Insurance ?? 0);
            }
        }
        /// <summary>
        /// 退票申请行程
        /// </summary>
        public string RetApplyFlightLine { get; set; }
        /// <summary>
        /// 退票申请行程三字码
        /// </summary>
        public List<string> RetApplyDAportList { get; set; }
        /// <summary>
        /// 退票申请对应的票号信息
        /// </summary>
        public string RetApplyTicketNo { get; set; }
      
        /// <summary>
        /// 退票申请对应的行程
        /// </summary>
        public int RetApplySequence { get; set; }
        /// <summary>
        /// 退票申请航班
        /// </summary>
        public string RetApplyFlightNo { get; set; }

        /// <summary>
        /// 是否改签
        /// </summary>
        public bool IsMod { get; set; }
        /// <summary>
        /// 是否退票
        /// </summary>
        public bool IsRet { get; set; }
      
    }
}
