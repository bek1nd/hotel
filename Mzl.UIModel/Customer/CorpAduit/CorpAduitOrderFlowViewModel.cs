using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.CorpAduit
{
    public class CorpAduitOrderFlowViewModel
    {
        /// <summary>
        /// 审批阶段Id
        /// </summary>
        [Description("审批阶段Id")]
        public int FlowId { get; set; }
        /// <summary>
        /// 审批单号
        /// </summary>
        [Description("审批单号")]
        public int AduitOrderId { get; set; }
        /// <summary>
        /// 审批阶段
        /// </summary>
        [Description("审批阶段")]
        public int Flow { get; set; }
        /// <summary>
        /// 审批阶段描述
        /// </summary>
        [Description("审批阶段描述")]
        public string FlowDes
        {
            get
            {
                switch (Flow)
                {
                    case -1:
                        return "创建审批单";
                    case 0:
                        return "送审";
                    default:
                        return string.Format("{0}级审批", Flow);
                }
            }
        }
        /// <summary>
        /// 审批人Id
        /// </summary>
        [Description("审批人Id")]
        public int FlowCid { get; set; }
        /// <summary>
        /// 审批人名称
        /// </summary>
        [Description("审批人名称")]
        public string FlowCustomerName { get; set; }
        /// <summary>
        /// 处理结果 1审批通过 2审批不通过 0送审 3提交
        /// </summary>
        [Description("处理结果 1审批通过 2审批不通过 0送审 3提交")]
        public int? DealResult { get; set; }
        /// <summary>
        /// 处理结果描述
        /// </summary>
        [Description("处理结果描述")]
        public string DealResultDes { get; set; }
    }
}
