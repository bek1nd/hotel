using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.Identification
{
    public class IdentificationModel
    {
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string CardType
        {
            get { return Iid.ValueToDescription<CardTypeEnum>(); }
        }

        /// <summary>
        /// 联系人Id
        /// </summary>
        public int ContactId { get; set; }
        /// <summary>
        /// 证件类型Id
        /// </summary>
        public int Iid { get; set; }

        /// <summary>
        /// 是否默认
        /// </summary>
        public int IsDefault { get; set; }
    }
}
