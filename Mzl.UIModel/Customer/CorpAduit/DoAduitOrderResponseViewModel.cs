using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.CorpAduit
{
    public class DoAduitOrderResponseViewModel
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [Description("是否成功")]
        public bool IsSuccessed { get; set; }
        /// <summary>
        /// 审批是否终结
        /// </summary>
        [Description("审批是否终结")]
        public bool IsFinished { get; set; }
    }
}
