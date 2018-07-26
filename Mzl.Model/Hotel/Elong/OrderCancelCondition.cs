using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel.Elong
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public class OrderCancelCondition
    {
        private long orderIdField;
        private string cancelCodeField;
        private string reasonField;

        /// <summary>
        /// 供应商订单编号
        /// </summary>
        public long OrderId
        {
            get
            {
                return this.orderIdField;
            }
            set
            {
                this.orderIdField = value;
            }
        }

        /// <summary>
        /// 取消类型
        /// 对酒店相关条件不满意
        /// 航班推迟
        /// 价格过高，客人不接受
        /// 通过其它途径预订
        /// 行程变更
        /// 已换酒店
        /// 重单
        /// 其它
        /// </summary>
        public string CancelCode
        {
            get
            {
                return this.cancelCodeField;
            }
            set
            {
                this.cancelCodeField = value;
            }
        }

        /// <summary>
        /// 具体原因
        /// </summary>
        public string Reason
        {
            get
            {
                return this.reasonField;
            }
            set
            {
                this.reasonField = value;
            }
        }
    }
}
