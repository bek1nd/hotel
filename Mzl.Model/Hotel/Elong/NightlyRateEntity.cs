using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Hotel.Elong
{
    public class NightlyRateEntity
    {

        /// <summary>
        /// 当天日期
        /// </summary>
        public System.DateTime Date { get; set; }

        /// <summary>
        /// 会员价
        /// 
        /// 已经通过DRR的计算可以直接显示给客人.。价格为-1表示不能销售。
        /// </summary>
        public decimal Member { get; set; }

        /// <summary>
        /// 结算价
        /// 
        /// 仅结算价模式下的预付产品
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// yeano:文档中没有提及
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> Basis { get; set; }

        /// <summary>
        /// 库存状态
        /// 
        /// 表示当天库存是否可用
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// -1表示不能加床
        /// </summary>
        public decimal AddBed { get; set; }

        /// <summary>
        /// yeano：文档中没有提及
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> BreakfastCount { get; set; }
    }
}
