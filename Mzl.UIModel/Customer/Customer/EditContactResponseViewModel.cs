using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.Customer
{
    public class EditContactResponseViewModel
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [Description("是否成功")]
        public bool IsSuccessed { get; set; }
        public int ContactId { get; set; }
    }
}
