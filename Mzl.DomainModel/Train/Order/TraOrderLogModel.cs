using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Order
{
    public class TraOrderLogModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int LogId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string CreateOid { get; set; }
        /// <summary>
        /// 日志时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        public string LogType { get; set; }
        /// <summary>
        /// 日志内容
        /// </summary>
        public string LogContent { get; set; }
    }
}
