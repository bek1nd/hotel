using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.Corporation
{
    public class ProjectNameViewModel
    {
        public int ProjectId { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Description("项目名称")]
        public string ProjectName { get; set; }
        [Description("公司编号")]
        public string CorpId { get; set; }
    }
}
