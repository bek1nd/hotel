using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.Customer
{
    public class UpdateCustomerHeadPictureRequestViewModel: RequestBaseViewModel
    {
        /// <summary>
        /// 头像图片路径
        /// </summary>
        [Description("头像图片路径")]
        [Required]
        public string HeadPictureUri { get; set; }
    }
}
