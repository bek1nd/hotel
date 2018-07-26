using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.Corp;

namespace Mzl.DomainModel.Flight
{
    public class AddRetModApplyModel : FltRetModApplyModel
    {
        public CustomerModel Customer { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string RealName
        {
            get
            {
                if (Customer == null)
                    return string.Empty;
                return Customer.RealName;
            }
        }

        public string Oid
        {
            get
            {
                if (!string.IsNullOrEmpty(IsOnlineRefund) && IsOnlineRefund.ToUpper() == "T")
                {
                    if (string.IsNullOrEmpty(RealName))
                        return "sys";
                    return RealName;
                }
                return CreateOid;
            }
        }

    }
}
