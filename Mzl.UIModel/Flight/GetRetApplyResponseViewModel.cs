using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.UIModel.Flight
{
    public class GetRetApplyResponseViewModel
    {
        public string CName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// 服务费（单价）
        /// </summary>
        public decimal ServiceFee { get; set; }
        /// <summary>
        /// 原订单航程信息
        /// </summary>
        public List<GetRetApplyFlightViewModel> FlightList { get; set; }
        /// <summary>
        /// 改签申请乘机人信息
        /// </summary>
        public List<GetRetApplyPassengerViewModel> PassengerList { get; set; }

        /// <summary>
        /// 退票原因
        /// </summary>
        public List<string> RetTypeList
        {
            get
            {
                //SortedList<string, string> sortedList= EnumConvert.QueryEnumStr<RetTypeEnum>();
                List<string> list = new List<string>()
                {
                    RetTypeEnum.VoluntaryRefund.ToDescription(),
                    RetTypeEnum.FlightChange.ToDescription(),
                    RetTypeEnum.Bingtui.ToDescription(),
                    RetTypeEnum.Other.ToDescription()
                };

                return list;
            }
        }
        /// <summary>
        /// 差旅政策Id
        /// </summary>
        [Description("差旅政策Id")]
        public int? CorpPolicyId { get; set; }
        /// <summary>
        /// 差旅审批规则Id
        /// </summary>
        [Description("差旅审批规则Id")]
        public int? CorpAduitId { get; set; }
    }
}
