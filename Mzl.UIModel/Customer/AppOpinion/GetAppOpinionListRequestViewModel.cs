using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.AppOpinion
{
    public class GetAppOpinionListRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 每页显示的行数
        /// </summary>
        [Description("每页显示的行数")]

        public int PageSize { get; set; }
        /// <summary>
        /// 当前页数
        /// </summary>
        [Description("当前页数")]

        public int PageIndex { get; set; }
    }
}
