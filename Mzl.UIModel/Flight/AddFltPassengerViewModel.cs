using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class AddFltPassengerViewModel
    {
        /// <summary>
        /// 乘机人名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public int CardType { get; set; }
        /// <summary>
        /// 证件号
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 保险价格
        /// </summary>
        public int Insurance { get; set; }
        /// <summary>
        /// 保险数量
        /// </summary>
        public int InsuranceCount { get; set; }
        /// <summary>
        /// 免费保险数量
        /// </summary>
        public int FreeInsuranceCount { get; set; }
        /// <summary>
        /// 乘客类型
        /// </summary>
        public string AgeType { get; set; }
        /// <summary>
        /// 乘客联系号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 联系人Id
        /// </summary>
        public int? Contactid { get; set; }
        /// <summary>
        /// 保险Id
        /// </summary>
        public int? InsCompanyId { get; set; }
    }
}
