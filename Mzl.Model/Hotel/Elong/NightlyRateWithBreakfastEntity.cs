using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Hotel.Elong
{
    /// <summary>
    /// 每晚详细信息
    /// </summary>
    public class NightlyRateWithBreakfastEntity
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
        /// 库存状态
        /// 
        /// 表示当天库存是否可用
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 加床价
        /// 
        /// -1表示不能加床
        /// </summary>
        public decimal AddBed { get; set; }

        /// <summary>
        /// 包含早餐的份数
        /// </summary>
        public int BreakfastAmount { get; set; }

        /// <summary>
        /// 单加早餐信息
        /// 
        /// 存在数额并且大于0表示可以单加早餐，大于0小于1表示单加早餐金额对应饭费的比率，大于等于1表示单加早餐的金额
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> ExtraBreakfastPrice { get; set; }

        /// <summary>
        /// yeano:文档中未提及
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> Basis { get; set; }

        /// <summary>
        /// yeano:文档中未提及
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> BreakfastCount { get; set; }
    }
}
