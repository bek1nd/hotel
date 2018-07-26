using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Train.Order
{
    public class TraOrderListDataEntity
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        public int Cid { get; set; }
        /// <summary>
        /// 是否线上
        /// </summary>
        public string IsOnline { get; set; }

        /// <summary>
        /// 创建人Id
        /// </summary>
        public string CreateOid { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 订单类型 0正单 2退单
        /// </summary>
        public int OrderType { get; set; }
        /// <summary>
        /// 送票时间
        /// </summary>
        public DateTime? SendTime { get; set; }
        /// <summary>
        /// 最晚送票时间
        /// </summary>
        public DateTime? LastSendTime { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal TotalMoney { get; set; }
        /// <summary>
        /// 应收款
        /// </summary>
        public decimal PayAmount { get; set; }
        /// <summary>
        /// 项目名称Id
        /// </summary>
        public int? ProjectId { get; set; }
        /// <summary>
        /// 成本中心
        /// </summary>
        public string CostCenter { get; set; }
        /// <summary>
        /// 出票点
        /// </summary>
        public string TrainPlace { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string CName { get; set; }
        /// <summary>
        /// 联系人手机号码
        /// </summary>
        public string CMobile { get; set; }
        /// <summary>
        /// 联系人Emai
        /// </summary>
        public string CEmail { get; set; }
        /// <summary>
        /// 退票对应正单订单号
        /// </summary>
        public int OrderRoot { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        public string Corpid { get; set; }
        /// <summary>
        /// 是否取消
        /// </summary>
        public int IsCancle { get; set; }
        /// <summary>
        /// 接口订单状态
        /// </summary>
        public int InterfaceOrderStatus { get; set; }
        /// <summary>
        /// 接口订单id
        /// </summary>
        public int InterfaceOrderId { get; set; }

        public string NumberIdentity { get; set; }
        public int ProcessStatus { get; set; }

        public int? AduitOrderId { get; set; }

        public int? AduitOrderStatus { get; set; }
        /// <summary>
        /// 是否线上隐藏 0否 1是
        /// </summary>
        public int? IsOnlineShow { get; set; }
        /// <summary>
        /// 退票类型  0普通 1虚退
        /// </summary>
        public int? RefundType { get; set; }
        /// <summary>
        /// 复制来源订单Id
        /// </summary>
        public int? CopyFromOrderId { get; set; }
        /// <summary>
        /// 复制类型 C普通复制 X虚退复制
        /// </summary>
        public string CopyType { get; set; }

        /// <summary>
        /// 线上显示订单
        /// </summary>
        public int ShowOnlineOrderId => (CopyType == "X" && CopyFromOrderId.HasValue &&
                                         (ProcessStatus & 1) == 1 &&
                                         IsCancle != 1)
            ? CopyFromOrderId.Value
            : OrderId;


    }
}
