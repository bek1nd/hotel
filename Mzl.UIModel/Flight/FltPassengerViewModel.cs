using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class FltPassengerViewModel : FltPassengerListViewModel
    {
        public string CardNo { get; set; }
        public string CardTypeDesc { get; set; }
        /// <summary>
        /// 是否改签
        /// </summary>
        public bool IsMod { get; set; }
        /// <summary>
        /// 是否退票
        /// </summary>
        public bool IsRet { get; set; }
      

        /// <summary>
        /// 保险数量
        /// </summary>
        public int InsuranceTotalCount { get; set; }

        /// <summary>
        /// 保险名称
        /// </summary>
        public string InsuranceShowName { get; set; }

        /// <summary>
        /// 保险金额（单价）
        /// </summary>
        public decimal InsuranceShowPrice { get; set; }

        public int ContactId { get; set; }
        public string Mobile { get; set; }
    }
}
