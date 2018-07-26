using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.CorpAduit;

namespace Mzl.UIModel.Customer.CorpAduit
{
    public class CorpAduitOrderLogViewModel
    {
        /// <summary>
        /// 日志Id
        /// </summary>
        [Description("日志Id")]
        public int LogId { get; set; }
        /// <summary>
        /// 日志时间
        /// </summary>
        [Description("日志时间")]
        public DateTime LogTime { get; set; }
        /// <summary>
        /// 日志时间描述
        /// </summary>
        [Description("日志时间描述")]
        public string LogTimeDes => LogTime.ToString("yyyy-MM-dd HH:mm");
        /// <summary>
        /// 审批操作来源 app  oa 差旅网站
        /// </summary>
        [Description("审批操作来源 app  oa 差旅网站")]
        public string Source { get; set; }
        /// <summary>
        /// 审批操作来源描述
        /// </summary>
        [Description("审批操作来源描述")]
        public string SourceDes
        {
            get
            {
                if (Source == "O")
                    return "TC端";
                if (Source == "I")
                    return "app端";
                if (Source == "A")
                    return "app端";
                if (Source == "P")
                    return "差旅网站";
                return string.Empty;
            }
        }

        /// <summary>
        /// 审批单号
        /// </summary>
        [Description("审批单号")]
        public int AduitOrderId { get; set; }
        /// <summary>
        /// 操作人 TC端
        /// </summary>
        [Description("操作人 TC端")]
        public string DealOid { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [Description("操作人")]
        public string DealCid { get; set; }
        /// <summary>
        /// 操作人名称
        /// </summary>
        [Description("操作人名称")]
        public string DealCustomerName { get; set; }

        /// <summary>
        /// 操作类型 0送审 1审批通过 2审批不通过 3提交
        /// </summary>
        [Description("操作类型 0送审 1审批通过 2审批不通过 3提交")]
        public int DealResult { get; set; }
        /// <summary>
        /// 操作类型描述
        /// </summary>
        [Description("操作类型描述")]
        public string DealResultDes { get; set; }
        /// <summary>
        /// 审批阶段
        /// </summary>
        [Description("审批阶段")]
        public int AduitFlow { get; set; }
        /// <summary>
        /// 审批阶段描述
        /// </summary>
        [Description("审批阶段描述")]
        public string AduitFlowDes
        {
            get
            {
                switch (AduitFlow)
                {
                    case -1:
                        return "创建审批单";
                    case 0:
                        return "送审";
                    default:
                        return string.Format("{0}级审批", AduitFlow);
                }
            }
        }
        /// <summary>
        /// 审批结果内容
        /// </summary>
        [Description("审批结果内容")]
        public string AduitReason { get; set; }
        /// <summary>
        /// 0自审批 1代审批 2 tc代审批
        /// </summary>
        [Description("0自审批 1代审批 2 tc代审批")]
        public int? AduitType { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        [Description("操作类型")]
        public string AduitTypeDes { get; set; }
    }
}
