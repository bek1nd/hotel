using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Common.SessionManage
{
    public class SetSessionResponseViewModel
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        [Description("是否成功")]
        public bool IsSuccessed { get; set; }
        /// <summary>
        /// 返回的Key
        /// </summary>
        [Description("返回的Key,获取session内容需要用")]
        public string Key { get; set; }
    }
}
