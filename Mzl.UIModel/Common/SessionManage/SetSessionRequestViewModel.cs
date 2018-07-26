using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Common.SessionManage
{
    public class SetSessionRequestViewModel
    {
        /// <summary>
        /// Session内容
        /// </summary>
        [Description("Session内容")]
        public string SessionContent { get; set; }
    }
}
