using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Base
{

    public class ResponseBaseViewModel
    {
        /// <summary>
        /// 是否正确标识  
        /// </summary>
        [Description("是否正确标识")]
        public ResponseCodeViewModel Flag { get; set; }
    }

    /// <summary>
    /// 响应类
    /// </summary>
    public class ResponseBaseViewModel<T> : ResponseBaseViewModel
    {

        /// <summary>
        /// 响应数据信息
        /// </summary>
        [Description("响应数据信息")]
        public T Data { get; set; }

    }
}
