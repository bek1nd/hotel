using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
   public class BaseOutputModel
    {
        /// <summary>
        /// 是否成功
        /// </summary>  
        [Description("true:成功，false:失败")]
        public bool success { get; set; }


        /// <summary>
        /// 状态编码
        /// </summary>  
        [Description("状态编码")]
        public int code { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>  
        [Description("提示信息")]
        public string msg { get; set; }

    }
}
