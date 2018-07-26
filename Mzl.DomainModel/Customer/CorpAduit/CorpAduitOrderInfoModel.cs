using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper.CorpAduit;

namespace Mzl.DomainModel.Customer.CorpAduit
{
    public class CorpAduitOrderInfoModel : CorpAduitOrderModel
    {
        /// <summary>
        /// 审批操作人Id集合
        /// </summary>
        [Description("审批操作人Id集合")]
        public List<int> AduitCidList => FlowList.Select(n => n.FlowCid).ToList();

        /// <summary>
        /// 关联订单集合
        /// </summary>
        [Description("关联订单集合")]
        public List<CorpAduitOrderDetailModel> OrderDetailList { get; set; }

        /// <summary>
        /// 审批环节集合
        /// </summary>
        [Description("审批环节集合")]
        public List<CorpAduitOrderFlowModel> FlowList { get; set; }

        /// <summary>
        /// 操作日志集合
        /// </summary>
        [Description("操作日志集合")]
        public List<CorpAduitOrderLogModel> LogList { get; set; }

        /// <summary>
        /// 下一阶段审批人Id集合
        /// </summary>
        [Description("下一阶段审批人Id集合")]
        public List<int> NextAduitCidList
        {
            get
            {
                List<int> list = new List<int>();
                if (FlowList == null)
                    return list;
                if (this.Status == (int) CorpAduitOrderStatusEnum.F || this.Status == (int) CorpAduitOrderStatusEnum.J)
                {
                    return list;
                }
                List< CorpAduitOrderFlowModel > flowModels =FlowList.FindAll(n => n.Flow == this.CurrentFlow);
                if (flowModels != null && flowModels.Count > 0)
                {
                    flowModels.ForEach(n =>
                    {
                        if (!n.DealResult.HasValue)
                            list.Add(n.FlowCid);
                    });
                }
                return list;
            }
        }

        /// <summary>
        /// 下一级审批人信息
        /// </summary>
        [Description("下一级审批人信息")]
        public string NextAduitName
        {
            get
            {
                if (FlowList != null && Status != (int) CorpAduitOrderStatusEnum.N &&
                    Status != (int) CorpAduitOrderStatusEnum.F
                    && Status != (int) CorpAduitOrderStatusEnum.J)
                {
                    List<CorpAduitOrderFlowModel> currentFlowList = FlowList.FindAll(n => n.Flow == this.CurrentFlow);
                    if (currentFlowList != null && currentFlowList.Count > 0)
                    {
                        string a = string.Empty;
                        foreach (var corpAduitOrderFlowModel in currentFlowList)
                        {
                            a += "," + corpAduitOrderFlowModel.FlowCustomerName;
                        }
                        if (!string.IsNullOrEmpty(a))
                            a = a.Substring(1);
                        return a;
                    }
                }

                return string.Empty;
            }
        }

    }
}
