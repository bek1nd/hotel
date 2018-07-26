using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Base
{
    public class ResponseCodeViewModel
    {
        /// <summary>
        /// 0为正常，其他为异常
        /// </summary>
        [Description("0为正常，其他为异常")]
        public int Code { get; set; }
        /// <summary>
        /// Code描述
        /// </summary>
        [Description("Code描述")]
        public string Message { get; set; }
        /// <summary>
        /// MojoryToken
        /// </summary>
        [Description("MojoryToken")]
        public string MojoryToken { get; set; }
    }
}
