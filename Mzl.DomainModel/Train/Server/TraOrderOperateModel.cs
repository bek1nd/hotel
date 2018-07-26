using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
    public class TraOrderOperateModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int LogId { get; set; }

        /// <summary>
        /// 接口订单Id
        /// </summary>
        [Description("接口订单Id")]
        public int InterfaceId { get; set; }


        /// <summary>
        /// 操作
        /// </summary>
        [Description("操作")]
        public int Operate { get; set; }


        /// <summary>
        /// 操作时间
        /// </summary>
        [Description("操作时间")]
        public DateTime OperateTime { get; set; }


        /// <summary>
        ///操作后状态
        /// </summary>
        [Description("操作后状态")]
        public int AfterOperateStatus { get; set; }

        /// <summary>
        /// 操作前状态
        /// </summary>
        [Description("操作前状态")]
        public int BeforOperateStatus { get; set; }


        public string Reason { get; set; }




    }
}
