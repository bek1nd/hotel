using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.CorpAduit;

namespace Mzl.DomainModel.Customer.CorpAduit
{
    public class BaseDealAduitResultModel
    {
        public int AduitOrderId { get; set; }
        public bool IsSuccessed { get; set; }
        /// <summary>
        /// 创建审批单客户Id
        /// </summary>
        public int CreateAduitOrderCid { get; set; }

        public List<BaseDealAduitResultDetailModel> DetailList { get; set; }
        /// <summary>
        /// 审批是否终结
        /// </summary>
        public bool IsFinished { get; set; }
        /// <summary>
        /// 审批单状态
        /// </summary>
        public CorpAduitOrderStatusEnum AduitOrderStatus { get; set; }
        /// <summary>
        /// 下一环节审批人Id
        /// </summary>
        public List<int> NextFlowCidList { get; set; }
    }
}
