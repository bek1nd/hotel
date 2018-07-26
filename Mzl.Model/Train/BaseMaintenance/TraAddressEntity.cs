using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mzl.EntityModel.Train.BaseMaintenance
{
    [Table("Tra_Address")]
    public class TraAddressEntity
    {
        /// <summary>
        /// 自动编号(火车票常用站)
        /// </summary>
        [Key]
        [Description("自动编号(火车票常用站)")]
        public int Aid { get; set; }
        /// <summary>
        /// 车站名称
        /// </summary>
        [Description("车站名称")]
        public string Addr_Name { get; set; }
        /// <summary>
        /// 车站缩写
        /// </summary>
        [Description("车站缩写")]
        public string Addr_S { get; set; }
        /// <summary>
        /// 类型，0为车站，1为车次
        /// </summary>
        [Description("类型，0为车站，1为车次")]
        public int Addr_Type { get; set; }
        /// <summary>
        /// 全拼
        /// </summary>
        [Description("全拼")]
        public string Addr_PinYin { get; set; }
    }
}
