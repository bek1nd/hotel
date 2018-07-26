using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.Base
{
    public class UpdateCustomerPwdModel
    {
        /// <summary>
        /// 客户Id
        /// </summary>
        public int Cid { get; set; }
        /// <summary>
        /// 原始密码
        /// </summary>
        public string OriginalPwd { get; set; }
        /// <summary>
        /// 修改后密码
        /// </summary>
        public string AfterUpdatePwd { get; set; }
    }
}
