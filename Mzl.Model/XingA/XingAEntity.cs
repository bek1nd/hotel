using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.XingA
{
    /// <summary>
    /// 接收行啊数据
    /// </summary>
    [Table("XingA_Data")]
    public class XingAEntity
    {
        /// <summary>
        /// 数据标识符
        /// </summary>   
        [Key]
        [Description("标识符ID")]
        public int ID { get; set; }
        /// <summary>
        /// 数据接收时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 数据代码:1-同步成功	0-同步失败
        /// </summary>
        public string msgCode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string errMsg { get; set; }
        /// <summary>
        /// 未解密的数据
        /// </summary>
        public string EncryptGetData { get; set; }
        /// <summary>
        /// 解密后的数据
        /// </summary>
        public string DecryptGetData { get; set; }
    }
}
