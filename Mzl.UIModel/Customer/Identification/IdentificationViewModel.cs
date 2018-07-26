using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.Identification
{
    public class IdentificationViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string CardType { get; set; }
        /// <summary>
        /// 证件Id
        /// </summary>
        public int Iid { get; set; }

        /// <summary>
        /// 是否默认
        /// </summary>
        public int IsDefault { get; set; }
    }
}
