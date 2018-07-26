using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.DomainModel.Customer.CorpAduit
{
    public class DoAduitOrderResultModel
    {
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
    }
}
