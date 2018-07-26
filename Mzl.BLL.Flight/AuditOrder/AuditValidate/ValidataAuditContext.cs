using Mzl.EntityModel.Flight;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;

namespace Mzl.BLL.Flight.AuditOrder.AuditValidate
{
    public class ValidataAuditContext
    {
        /// <summary>
        /// 机票订单
        /// </summary>
        public FltOrderModel FltOrder { get; set; }
        /// <summary>
        /// 退改签申请
        /// </summary>
        public FltRetModApplyModel FltRetModApply { get; set; }
        /// <summary>
        /// 申请类型 0改签 1退票
        /// </summary>
        public int ApplyType { get; set; }
        /// <summary>
        /// 申请审核的阶段
        /// </summary>
        public string AuditStep { get; set; }
        /// <summary>
        /// 申请审核id
        /// </summary>
        public int AuditCid { get; set; }
    }
}
