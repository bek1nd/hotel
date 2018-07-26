using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.Corporation
{
    public class CostCenterViewModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Description("主键")]
        public int Cid { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        [Description("公司Id")]
        public string CorpId { get; set; }
        /// <summary>
        /// 成本中心
        /// </summary>
        [Description("成本中心")]
        public string Depart { get; set; }
    }
}
