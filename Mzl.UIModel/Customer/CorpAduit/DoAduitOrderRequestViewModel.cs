using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.CorpAduit
{
    public class DoAduitOrderRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 审批单Id
        /// </summary>
        [Description("审批单Id")]
        public int AduitOrderId { get; set; }
        /// <summary>
        /// 当前审批环节
        /// </summary>
        [Description("当前审批环节")]
        public int CurrentFlow { get; set; }
        /// <summary>
        /// 是否通过
        /// </summary>
        [Description("是否通过")]
        public bool IsAgree { get; set; }
        /// <summary>
        /// 审批填写的原因
        /// </summary>
        public string AduitReason { get; set; }
    }
}
