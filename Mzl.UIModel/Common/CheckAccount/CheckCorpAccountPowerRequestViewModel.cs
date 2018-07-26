using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Common.CheckAccount
{
    public class CheckCorpAccountPowerRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 页面URL
        /// </summary>
        [Description("页面URL")]
        [Required]
        public string Url { get; set; }
    }
}
