using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 
    /// </summary>
    public class PsgFare
    {
        /// <summary>
        /// 数量
        /// </summary>
        public string count { get; set; }
        /// <summary>
        /// 特殊条件
        /// </summary>
        public string fare { get; set; }
        /// <summary>
        /// 乘客类型
        /// </summary>
        public string psgType { get; set; }
        /// <summary>
        /// 税率
        /// </summary>
        public List<Tax> taxList { get; set; }
        #region 2017-09-06 新增字段
        /// <summary>
        /// 
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MyProperty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string taxcd { get; set; }
        #endregion
    }
}
