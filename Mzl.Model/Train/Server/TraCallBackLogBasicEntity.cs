using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Train.Server
{
    public class TraCallBackLogBasicEntity
    {
        /// <summary>
        /// 日志ID
        /// </summary>
        [Key]
        public int LogId { get; set; }
        /// <summary>
        /// 日志原始信息
        /// </summary>
        public string LogOriginalContent { get; set; }
        /// <summary>
        /// 日志时间
        /// </summary>
        public DateTime? LogTime { get; set; }
        /// <summary>
        /// 日志写入人
        /// </summary>
        public string LogCreator { get; set; }
    }
}
