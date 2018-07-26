using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.Customer
{
    public class UpdateCustomerPwdRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 原始密码
        /// </summary>
        [Required]
        [MaxLength(32),MinLength(32)]
        public string OriginalPwd { get; set; }
        /// <summary>
        /// 修改后密码
        /// </summary>
        [Required]
        [MaxLength(32), MinLength(32)]
        public string AfterUpdatePwd { get; set; }
    }
}
